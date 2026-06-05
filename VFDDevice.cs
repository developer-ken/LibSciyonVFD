using System;
using System.IO.Ports;

namespace LibSciyonVFD
{
    public class VFDDevice
    {
        private SerialPort port;
        public byte Addr { private set; get; }
        public uint BaudRate { private set; get; }
        public PortConfig CommConfig { private set; get; }

        public enum PortConfig
        {
            R181N=0,
            R181O=1,
            R181E=2,
            R182N=3,
            R182O=4,
            R182E=5
        }


    }
}
