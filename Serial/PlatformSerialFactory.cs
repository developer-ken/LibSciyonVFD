using System;
using System.Linq;

namespace LibSciyonVFD.Serial
{
    public static class PlatformSerialFactory
    {
        // Application can set this to provide a platform-specific implementation.
        // Signature: (devicePath, baudRate) => ISerialPort
        public static Func<string?, int, ISerialPort>? CreatePlatformPort { get; set; }

        public static ISerialPort Create(string? devicePath, int baudRate)
        {
            if (CreatePlatformPort != null)
            {
                var p = CreatePlatformPort(devicePath, baudRate);
                if (p != null) return p;
            }

#if WINDOWS || WIN32 || NETFRAMEWORK || NET || NET6_0_WINDOWS
            // On Windows, use System.IO.Ports via adapter
            var adapter = new SerialPortAdapter(devicePath ?? "COM1");
            adapter.Open(devicePath ?? "COM1", baudRate);
            return adapter;
#else
            // Default: try to return System.IO.Ports if available
            try
            {
                var adapter = new SerialPortAdapter(devicePath ?? "COM1");
                adapter.Open(devicePath ?? "COM1", baudRate);
                return adapter;
            }
            catch
            {
                throw new PlatformNotSupportedException("No platform serial implementation available. Set PlatformSerialFactory.CreatePlatformPort in application startup for this platform.");
            }
#endif
        }

        public static System.Collections.Generic.IEnumerable<string> GetAvailablePorts()
        {
#if ANDROID
            try
            {
                var mgr = global::Android.App.Application.Context.GetSystemService(global::Android.Content.Context.UsbService) as global::Android.Hardware.Usb.UsbManager;
                if (mgr == null) return System.Linq.Enumerable.Empty<string>();
                return mgr.DeviceList.Values.Select(d => d.DeviceName).OrderBy(n => n);
            }
            catch
            {
                return System.Linq.Enumerable.Empty<string>();
            }
#else
            try
            {
                return System.IO.Ports.SerialPort.GetPortNames().OrderBy(n => n);
            }
            catch
            {
                return System.Linq.Enumerable.Empty<string>();
            }
#endif
        }
    }
}
