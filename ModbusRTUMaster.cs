using System;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Collections.Generic;

namespace LibSciyonVFD
{
    internal class ModbusRTUMaster
    {
        private readonly SerialPort _port;
        private readonly int _responseTimeoutMs;
        private readonly object _sync = new object();

        public ModbusRTUMaster(SerialPort port, int responseTimeoutMs = 1000)
        {
            _port = port ?? throw new ArgumentNullException(nameof(port));
            _responseTimeoutMs = responseTimeoutMs;
            // make sure port has sensible timeouts
            try
            {
                _port.ReadTimeout = 50; // short poll timeout; we'll implement our own overall timeout
                _port.WriteTimeout = 1000;
            }
            catch { }
        }

        public ushort[] ReadHoldingRegisters(byte slaveAddress, ushort startAddress, ushort quantity)
        {
            if (quantity == 0 || quantity > 125) throw new ArgumentOutOfRangeException(nameof(quantity));
            var request = new List<byte>(8);
            request.Add(slaveAddress);
            request.Add(0x03);
            request.Add((byte)(startAddress >> 8));
            request.Add((byte)(startAddress & 0xFF));
            request.Add((byte)(quantity >> 8));
            request.Add((byte)(quantity & 0xFF));
            var req = AppendCrc(request.ToArray());

            var resp = SendAndReceive(req);
            // resp: addr, func, byteCount, data..., crcLo, crcHi
            if (resp.Length < 5) throw new InvalidOperationException("Invalid response length");
            if (resp[1] == (0x80 | 0x03)) throw new InvalidOperationException($"Modbus exception code: {resp[2]}");
            int byteCount = resp[2];
            if (resp.Length != 3 + byteCount + 2) throw new InvalidOperationException("Unexpected response size");
            var result = new ushort[byteCount / 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (ushort)((resp[3 + i * 2] << 8) | resp[3 + i * 2 + 1]);
            }
            return result;
        }

        public void WriteSingleRegister(byte slaveAddress, ushort address, ushort value)
        {
            var request = new List<byte>(8);
            request.Add(slaveAddress);
            request.Add(0x06);
            request.Add((byte)(address >> 8));
            request.Add((byte)(address & 0xFF));
            request.Add((byte)(value >> 8));
            request.Add((byte)(value & 0xFF));
            var req = AppendCrc(request.ToArray());

            var resp = SendAndReceive(req);
            // expect echo of request (except possibly CRC order)
            if (resp.Length < 8) throw new InvalidOperationException("Invalid response length");
            if (resp[1] == (0x80 | 0x06)) throw new InvalidOperationException($"Modbus exception code: {resp[2]}");
            // validate address and value echoed
            if (resp[0] != slaveAddress || resp[1] != 0x06) throw new InvalidOperationException("Unexpected response header");
        }

        public void WriteMultipleRegisters(byte slaveAddress, ushort startAddress, ushort[] values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (values.Length == 0 || values.Length > 123) throw new ArgumentOutOfRangeException(nameof(values));
            var request = new List<byte>(9 + values.Length * 2);
            request.Add(slaveAddress);
            request.Add(0x10);
            request.Add((byte)(startAddress >> 8));
            request.Add((byte)(startAddress & 0xFF));
            request.Add((byte)(values.Length >> 8));
            request.Add((byte)(values.Length & 0xFF));
            request.Add((byte)(values.Length * 2));
            foreach (var v in values)
            {
                request.Add((byte)(v >> 8));
                request.Add((byte)(v & 0xFF));
            }
            var req = AppendCrc(request.ToArray());

            var resp = SendAndReceive(req);
            // expect addr, func, startAddrHi, startAddrLo, qtyHi, qtyLo, crcLo, crcHi
            if (resp.Length < 8) throw new InvalidOperationException("Invalid response length");
            if (resp[1] == (0x80 | 0x10)) throw new InvalidOperationException($"Modbus exception code: {resp[2]}");
        }

        public ushort[] ReadWriteMultipleRegisters(byte slaveAddress,
            ushort readStart, ushort readQty,
            ushort writeStart, ushort[] writeValues)
        {
            if (readQty == 0 || readQty > 125) throw new ArgumentOutOfRangeException(nameof(readQty));
            if (writeValues == null) throw new ArgumentNullException(nameof(writeValues));
            if (writeValues.Length == 0 || writeValues.Length > 121) throw new ArgumentOutOfRangeException(nameof(writeValues));

            var request = new List<byte>();
            request.Add(slaveAddress);
            request.Add(0x17);
            request.Add((byte)(readStart >> 8));
            request.Add((byte)(readStart & 0xFF));
            request.Add((byte)(readQty >> 8));
            request.Add((byte)(readQty & 0xFF));
            request.Add((byte)(writeStart >> 8));
            request.Add((byte)(writeStart & 0xFF));
            request.Add((byte)(writeValues.Length >> 8));
            request.Add((byte)(writeValues.Length & 0xFF));
            request.Add((byte)(writeValues.Length * 2));
            foreach (var v in writeValues)
            {
                request.Add((byte)(v >> 8));
                request.Add((byte)(v & 0xFF));
            }
            var req = AppendCrc(request.ToArray());

            var resp = SendAndReceive(req);
            if (resp.Length < 5) throw new InvalidOperationException("Invalid response length");
            if (resp[1] == (0x80 | 0x17)) throw new InvalidOperationException($"Modbus exception code: {resp[2]}");
            int byteCount = resp[2];
            if (resp.Length != 3 + byteCount + 2) throw new InvalidOperationException("Unexpected response size");
            var result = new ushort[byteCount / 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (ushort)((resp[3 + i * 2] << 8) | resp[3 + i * 2 + 1]);
            }
            return result;
        }

        private byte[] SendAndReceive(byte[] request)
        {
            lock (_sync)
            {
                // clear existing input to avoid mixing previous data
                try { if (_port.IsOpen) _port.DiscardInBuffer(); } catch { }

                // send one byte at a time to support collision detection / echo handling
                for (int i = 0; i < request.Length; i++)
                {
                    _port.Write(request, i, 1);
                    // small delay to allow immediate echo
                    Thread.Sleep(1);
                    // if data available while sending, perform collision detection
                    try
                    {
                        while (_port.BytesToRead > 0)
                        {
                            int available = _port.BytesToRead;
                            var buffer = new byte[available];
                            int read = _port.Read(buffer, 0, available);
                            // Compare to the request beginning; if differs -> collision
                            for (int k = 0; k < read; k++)
                            {
                                if (k >= request.Length) break;
                                if (buffer[k] != request[k])
                                {
                                    throw new IOException("Collision detected on serial bus");
                                }
                                // otherwise it is echo; ignore
                            }
                        }
                    }
                    catch (TimeoutException) { }
                }

                // now wait for response
                var sw = System.Diagnostics.Stopwatch.StartNew();
                var received = new List<byte>();
                while (sw.ElapsedMilliseconds < _responseTimeoutMs)
                {
                    try
                    {
                        while (_port.BytesToRead > 0)
                        {
                            int toRead = _port.BytesToRead;
                            var buf = new byte[toRead];
                            int r = _port.Read(buf, 0, toRead);
                            for (int i = 0; i < r; i++) received.Add(buf[i]);
                        }
                    }
                    catch (TimeoutException) { }

                    // minimal frame length is 5 (addr, func, 1 byte, crcLo, crcHi) but usually we need at least 5
                    if (received.Count >= 5)
                    {
                        // check if we have full frame by function code
                        int expected = ExpectedResponseLength(received);
                        if (expected > 0 && received.Count >= expected)
                        {
                            // validate CRC
                            var arr = received.ToArray();
                            if (!ValidateCrc(arr)) throw new InvalidOperationException("CRC error in response");
                            return arr;
                        }
                    }

                    Thread.Sleep(2);
                }

                throw new TimeoutException("Modbus RTU response timeout");
            }
        }

        private static int ExpectedResponseLength(List<byte> received)
        {
            // need at least 2 bytes to inspect function
            if (received.Count < 2) return 0;
            byte func = received[1];
            if ((func & 0x80) != 0)
            {
                // exception response: addr, func, exceptionCode, crcLo, crcHi
                return 5;
            }
            switch (func)
            {
                case 0x03:
                case 0x04:
                case 0x17:
                    if (received.Count >= 3)
                    {
                        int byteCount = received[2];
                        return 3 + byteCount + 2;
                    }
                    return 0;
                case 0x06:
                case 0x10:
                    return 8; // addr + func + addrHi + addrLo + qtyHi + qtyLo + crcLo + crcHi
                default:
                    return 0;
            }
        }

        private static byte[] AppendCrc(byte[] data)
        {
            ushort crc = Crc16(data, 0, data.Length);
            var outb = new byte[data.Length + 2];
            Array.Copy(data, 0, outb, 0, data.Length);
            outb[outb.Length - 2] = (byte)(crc & 0xFF);
            outb[outb.Length - 1] = (byte)(crc >> 8);
            return outb;
        }

        private static bool ValidateCrc(byte[] frame)
        {
            if (frame.Length < 3) return false;
            int len = frame.Length - 2;
            ushort crc = Crc16(frame, 0, len);
            byte lo = (byte)(crc & 0xFF);
            byte hi = (byte)(crc >> 8);
            return frame[len] == lo && frame[len + 1] == hi;
        }

        private static ushort Crc16(byte[] data, int offset, int length)
        {
            ushort crc = 0xFFFF;
            for (int i = 0; i < length; i++)
            {
                crc ^= data[offset + i];
                for (int j = 0; j < 8; j++)
                {
                    bool lsb = (crc & 0x0001) != 0;
                    crc >>= 1;
                    if (lsb) crc ^= 0xA001;
                }
            }
            return crc;
        }

    }
}
