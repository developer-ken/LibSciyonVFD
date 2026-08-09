using System;
using LibSciyonVFD;

namespace LibSciyonVFD.Serial
{
    // Minimal cross-platform serial abstraction used by ModbusRTUMaster/VFDDevice
    public interface ISerialPort : IDisposable
    {
        // Configure port parameters (baud + comm config such as parity/stopbits)
        void Configure(int baudRate, VFDDevice.PortConfig commConfig);

        // Open/close lifecycle (devicePath may be optional for platform implementations)
        bool Open(string devicePath, int baudRate);
        void Close();

        // Basic read/write
        int Read(byte[] buffer, int offset, int count);
        int Write(byte[] buffer, int offset, int count);

        // Input buffer inspection and flushing
        int BytesToRead { get; }
        void DiscardInBuffer();

        bool IsOpen { get; }
        void SetTimeouts(int readTimeoutMs, int writeTimeoutMs);
    }
}
