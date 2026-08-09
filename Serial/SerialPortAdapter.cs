using System;
using System.IO.Ports;

namespace LibSciyonVFD.Serial
{
    // Adapter to wrap System.IO.Ports.SerialPort as ISerialPort
    public class SerialPortAdapter : ISerialPort
    {
        private readonly SerialPort _port;
        public SerialPortAdapter(string portName)
        {
            _port = new SerialPort(portName);
        }

        public bool IsOpen => _port?.IsOpen ?? false;

        public void Configure(int baudRate, LibSciyonVFD.VFDDevice.PortConfig commConfig)
        {
            _port.BaudRate = baudRate;
            switch (commConfig)
            {
                case LibSciyonVFD.VFDDevice.PortConfig.R181N:
                    _port.DataBits = 8;
                    _port.StopBits = StopBits.One;
                    _port.Parity = Parity.None;
                    break;
                case LibSciyonVFD.VFDDevice.PortConfig.R181O:
                    _port.DataBits = 8;
                    _port.StopBits = StopBits.One;
                    _port.Parity = Parity.Odd;
                    break;
                case LibSciyonVFD.VFDDevice.PortConfig.R182N:
                    _port.DataBits = 8;
                    _port.StopBits = StopBits.Two;
                    _port.Parity = Parity.None;
                    break;
                case LibSciyonVFD.VFDDevice.PortConfig.R182O:
                    _port.DataBits = 8;
                    _port.StopBits = StopBits.Two;
                    _port.Parity = Parity.Odd;
                    break;
                case LibSciyonVFD.VFDDevice.PortConfig.R182E:
                    _port.DataBits = 8;
                    _port.StopBits = StopBits.Two;
                    _port.Parity = Parity.Even;
                    break;
            }
        }

        public bool Open(string devicePath, int baudRate)
        {
            if (_port == null) return false;
            if (!_port.IsOpen)
            {
                _port.BaudRate = baudRate;
                try { _port.Open(); } catch { return false; }
            }
            return _port.IsOpen;
        }

        public void Close()
        {
            try { _port.Close(); } catch { }
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            try
            {
                return _port.Read(buffer, offset, count);
            }
            catch (TimeoutException) { return 0; }
        }

        public int Write(byte[] buffer, int offset, int count)
        {
            _port.Write(buffer, offset, count);
            return count;
        }

        public int BytesToRead
        {
            get
            {
                try { return _port.BytesToRead; } catch { return 0; }
            }
        }

        public void DiscardInBuffer()
        {
            try { _port.DiscardInBuffer(); } catch { }
        }

        public void SetTimeouts(int readTimeoutMs, int writeTimeoutMs)
        {
            try { _port.ReadTimeout = Math.Max(1, readTimeoutMs); } catch { }
            try { _port.WriteTimeout = Math.Max(1, writeTimeoutMs); } catch { }
        }

        public void Dispose()
        {
            Close();
            _port?.Dispose();
        }
    }
}
