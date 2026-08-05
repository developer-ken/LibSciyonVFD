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

        public int MaxRetriesForSingleAccess = 2;



        private ModbusRTUMaster modbus;

        public struct VFDStatus
        {
            public Status Status { internal set; get; }
            public float Current { internal set; get; }
            public float RailVotage { internal set; get; }
            public float LoadPercentage { internal set; get; }
        }

        public enum PortConfig
        {
            R181N = 0,
            R181O = 1,
            R181E = 2,
            R182N = 3,
            R182O = 4,
            R182E = 5
        }

        public enum ControlParams
        {
            Command = 0x7000,
            MaxFrequency = 0x7001,
            MainFrequency = 0x7002,
            AuxFrequency = 0x7003,
            VFSeperationVoltage = 0x7004,
            MaximunTorqueInVelocityMode = 0x7005,
            TargetTorque = 0x7006,
            MaximumVelocityInTorqueMode = 0x7007,
            MultiSpeedFrequency0 = 0x7008,
            MultiSpeedFrequency1 = 0x7009,
            PIDScale = 0x700A,
            PIDFeedback = 0x700B,
            VirtualDI = 0x700C,
            RemoteDO = 0x700D,
            RemoteAO = 0x700E,
            RemotePFO = 0x700F,
            _SyncCommand = 0x7016,
            _SyncFrequency = 0x7017,
            _ReservedPercentage1 = 0x7018,
            _ReservedPercentage2 = 0x7019
        }

        public enum StatusParams
        {
            StatusWord = 0x7100,
            ErrorCode = 0x7101,
            TargetFrequency = 0x7102,
            RunningFrequency = 0x7103,
            RailVoltage = 0x7104,
            OutputVoltage = 0x7105,
            OutputCurrent = 0x7106,
            OutputPower = 0x7107,
            OutputFrequency = 0x7108,
            OutputTorque = 0x7109,
            MoudleTemerature = 0x710A,
            MotorRotatingSpeed = 0x710B,
            RemoteAI1 = 0x710C,
            RemoteAI2 = 0x710D,
            RemotePFInput = 0x710E,
            RemoteDI = 0x710F,
            RemoteDO = 0x7110,
            PIDGoal = 0x7111,
            PIDFeedback = 0x7112,
            AgingTimeHours = 0x7113,
            AgingTimeMinutes = 0x7114,
            LoadPercentage = 0x7115,
            _RailVoltage = 0x7116,
            _ReflectedStatusWord = 0x7117,
        }

        public enum Command
        {
            Void = 0,
            StartForward = 1 << 4,
            StartReverse = 2 << 4,
            StepForward = 3 << 4,
            StepReverse = 4 << 4,
            BrakeToStop = 5 << 4,
            FreeRollToStop = 6 << 4,
            Reset = 7 << 4
        }

        public enum Status
        {
            Void = 0,
            RunningForward = 0b0001 << 4,
            RunningReverse = 0b0010 << 4,
            Idle = 0b0011 << 4,
            Error = 0b0100 << 4
        }

        public VFDDevice(SerialPort port, byte addr, int baudRate, PortConfig commConfig, VFDConfiguration config = null)
        {
            this.port = port;
            Addr = addr;
            BaudRate = baudRate;
            CommConfig = commConfig;
            Config = config;
            modbus = new ModbusRTUMaster(port, baudRate, commConfig, 500);
            if (Config is null)
            {
                Config = new VFDConfiguration();
            }
        }

        public void ReadConfigAll()
        {
            List<ConfigItem> ItemsInGroup = new List<ConfigItem>();
            foreach (var item in Config.ByCode.Values)
            {
                try
                {
                    if ((ItemsInGroup.Count == 0 || ItemsInGroup.Last().Index.CodeDomain == item.Index.CodeDomain) && ItemsInGroup.Count < 5)
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
                            Console.WriteLine($"*COM* ReadHoldingRegisters({Addr},0x{ItemsInGroup.First().Index.CodeAddr.ToString("X4")},{ItemsInGroup.Count})");
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
                catch
                {
                    Console.WriteLine($"! Error reading sector {ItemsInGroup.First().Index.CodeDomain}-{ItemsInGroup.First().Index.CodeId}~{ItemsInGroup.Last().Index.CodeId}, skipped.");
                    ItemsInGroup.Clear();
                    ItemsInGroup.Add(item);
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

        public Status ProbeStatus()
        {
            var data = modbus.ReadHoldingRegisters(Addr, (ushort)StatusParams.StatusWord, 1);
            return (Status)data[0];
        }
    }
}
