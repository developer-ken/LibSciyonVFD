using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace LibSciyonVFD
{
    public class VFDDevice
    {
        private SerialPort port;
        public byte Addr { private set; get; }
        public int BaudRate { private set; get; }
        public PortConfig CommConfig { private set; get; }
        public VFDConfiguration Config { private set; get; }

        public int MaxRetriesForSingleAccess = 5;

        private ModbusRTUMaster modbus;

        public enum PortConfig
        {
            R181N = 0,
            R181O = 1,
            R181E = 2,
            R182N = 3,
            R182O = 4,
            R182E = 5
        }

        public VFDDevice(SerialPort port, byte addr, int baudRate, PortConfig commConfig, VFDConfiguration config = null)
        {
            this.port = port;
            Addr = addr;
            BaudRate = baudRate;
            CommConfig = commConfig;
            Config = config;
            modbus = new ModbusRTUMaster(port, baudRate, commConfig, 500);
        }

        public void ReadConfigAll()
        {
            List<ConfigItem> ItemsInGroup = new List<ConfigItem>();
            foreach (var item in Config.ByCode.Values)
            {
                if (ItemsInGroup.Count == 0 || ItemsInGroup.Last().Index.CodeDomain == item.Index.CodeDomain)
                {
                    ItemsInGroup.Add(item);
                    continue;
                }
                else
                {
                    int retries = 0;
                _RETRY:
                    try
                    {
                        Console.WriteLine($"*COM* ReadHoldingRegisters({Addr},0x{ItemsInGroup.First().Index.CodeAddr.ToString("X4")})");
                        var readdata = modbus.ReadHoldingRegisters(Addr, ItemsInGroup.First().Index.CodeAddr, (ushort)ItemsInGroup.Count);
                        for (int i = 0; i < ItemsInGroup.Count; i++)
                        {
                            ItemsInGroup[i].RawValue = readdata[i];
                            ItemsInGroup[i].Modified = false;
                        }
                        ItemsInGroup.Clear();
                        ItemsInGroup.Add(item);
                        continue;
                    }
                    catch (Exception ex)
                    {
                        if (retries > MaxRetriesForSingleAccess)
                        {
                            Console.WriteLine(ex.ToString());
                            Console.WriteLine($"ERROR: Communication failed with max retries({MaxRetriesForSingleAccess}).");
                            throw;
                        }
                        retries++;
                        Console.WriteLine(ex.ToString());
                        Console.WriteLine($"Retry(s) {retries}/{MaxRetriesForSingleAccess}");
                        goto _RETRY;
                    }
                }
            }
        }

        public void WriteConfigAll()
        {
            List<ConfigItem> ItemsInGroup = new List<ConfigItem>();
            foreach (var item in Config.ByCode.Values)
            {
                if (ItemsInGroup.Count == 0 || ItemsInGroup.Last().Index.CodeDomain == item.Index.CodeDomain)
                {
                    ItemsInGroup.Add(item);
                    continue;
                }
                else
                {
                    ushort[] collected = new ushort[ItemsInGroup.Count];
                    for (int i = 0; i < ItemsInGroup.Count; i++)
                    {
                        collected[i] = ItemsInGroup[i].RawValue;
                    }
                    int retries = 0;
                _RETRY:
                    try
                    {
                        Console.WriteLine($"*COM* WriteMultipleRegisters({Addr},0x{ItemsInGroup.First().Index.CodeAddr.ToString("X4")})");
                        modbus.WriteMultipleRegisters(Addr, ItemsInGroup.First().Index.CodeAddr, collected);
                    }
                    catch (Exception ex)
                    {
                        if (retries > MaxRetriesForSingleAccess)
                        {
                            Console.WriteLine(ex.ToString());
                            Console.WriteLine($"ERROR: Communication failed with max retries({MaxRetriesForSingleAccess}).");
                            throw;
                        }
                        retries++;
                        Console.WriteLine(ex.ToString());
                        Console.WriteLine($"Retry(s) {retries}/{MaxRetriesForSingleAccess}");
                        goto _RETRY;
                    }
                    ItemsInGroup.Clear();
                    ItemsInGroup.Add(item);
                    continue;
                }
            }
        }

        public void WriteModified()
        {
            List<ConfigItem> ItemsInGroup = new List<ConfigItem>();
            foreach (var item in Config.ByCode.Values)
            {
                if (!item.Modified) continue;
                if (ItemsInGroup.Count == 0 || ItemsInGroup.Last().Index.CodeDomain == item.Index.CodeDomain)
                {
                    ItemsInGroup.Add(item);
                    continue;
                }
                else
                {
                    ushort[] collected = new ushort[ItemsInGroup.Count];
                    for (int i = 0; i < ItemsInGroup.Count; i++)
                    {
                        collected[i] = ItemsInGroup[i].RawValue;
                    }
                    int retries = 0;
                _RETRY:
                    try
                    {
                        Console.WriteLine($"*COM* WriteMultipleRegisters({Addr},0x{ItemsInGroup.First().Index.CodeAddr.ToString("X4")})");
                        modbus.WriteMultipleRegisters(Addr, ItemsInGroup.First().Index.CodeAddr, collected);
                    }
                    catch (Exception ex)
                    {
                        if (retries > MaxRetriesForSingleAccess)
                        {
                            Console.WriteLine(ex.ToString());
                            Console.WriteLine($"ERROR: Communication failed with max retries({MaxRetriesForSingleAccess}).");
                            throw;
                        }
                        retries++;
                        Console.WriteLine(ex.ToString());
                        Console.WriteLine($"Retry(s) {retries}/{MaxRetriesForSingleAccess}");
                        goto _RETRY;
                    }
                    ItemsInGroup.Clear();
                    ItemsInGroup.Add(item);
                    continue;
                }
            }
        }
    }
}
