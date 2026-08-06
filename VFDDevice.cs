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




        public static ErrorInfo[] ErrorInfos = new ErrorInfo[]
        {
            new ErrorInfo{ Code = ErrorCode.Void, Message = "No error", Description = "No error", Suggestion = "No action needed" },
            new ErrorInfo{ Code = ErrorCode.EuU, Message = "母线欠压", Description = "内部直流母线电压过低", Suggestion = "检查输入电压是否正常。如果无法自行解决，请联系技术支持。" },
            // Add more error codes as needed
        };


        private ModbusRTUMaster modbus;

        public struct VFDStatus
        {
            public Status Status { internal set; get; }
            public float Current { internal set; get; }
            public float RailVotage { internal set; get; }
            public float LoadPercentage { internal set; get; }
        }

        public struct ErrorInfo
        {
            public ErrorCode Code { internal set; get; }
            public string Message { internal set; get; }
            public string Description { internal set; get; }
            public string Suggestion { internal set; get; }
        }

        public struct VFDStatusParams
        {
            public Status Status { internal set; get; }
            public ushort ErrorCode { internal set; get; }
            public float TargetFrequency { internal set; get; }
            public float RunningFrequency { internal set; get; }
            public ushort RailVotage { internal set; get; }
            public ushort OutputVoltage { internal set; get; }
            public float OutputCurrent { internal set; get; }
            public float OutputPower { internal set; get; }
            public float OutputFrequency { internal set; get; }
            public float OutputTorque { internal set; get; }
            public float MoudleTemerature { internal set; get; }
            public ushort MotorRotatingSpeed { internal set; get; }
            public float RemoteAI1 { internal set; get; }
            public float RemoteAI2 { internal set; get; }
            public float RemotePFInput { internal set; get; }
            public ushort RemoteDI { internal set; get; }
            public ushort RemoteDO { internal set; get; }
            public float PIDGoal { internal set; get; }
            public float PIDFeedback { internal set; get; }
            public ushort AgingTimeHours { internal set; get; }
            public ushort AgingTimeMinutes { internal set; get; }
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
            PIDGoal = 0x700A,
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

        public enum ErrorCode
        {
            Void = 0,
            EuU = 1,
            EoC1 = 2,
            EoC2 = 3,
            EoC3 = 4,
            EoU1 = 5,
            EoU2 = 6,
            EoU3 = 7,
            EoL1 = 8,
            EoL2 = 9,
            EoH1 = 10,
            EoH2 = 11,
            EoPL = 12,
            EIPL = 13,
            EFAL = 14,
            EruU = 15,
            EPdn = 16,
            ECtC = 17,
            EtUN = 18,
            Eto1 = 19,
            Eto2 = 20,
            Eto3 = 21,
            ESFt = 22,
            EPEr = 23,
            EFbH = 24,
            EFbL = 25,
            EAiH = 26,
            EAiL = 27,
            EcEr = 28,
            EcTo = 29
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

        public Status Probe()
        {
            var data = modbus.ReadHoldingRegisters(Addr, (ushort)StatusParams.StatusWord, 1);
            return (Status)data[0];
        }

        public VFDStatus BriefStatus()
        {
            VFDStatus status = new VFDStatus();
            var data = modbus.ReadHoldingRegisters(Addr, (ushort)StatusParams.StatusWord, 6);
            status.Status = (Status)data[0];
            status.RailVotage = data[1] / 10.0f;
            status.Current = data[2] / 10.0f;
            status.LoadPercentage = data[5] / 10.0f;
            return status;
        }

        public VFDStatusParams ReadDetailStatus()
        {
            VFDStatusParams status = new VFDStatusParams();
            var data = modbus.ReadHoldingRegisters(Addr, (ushort)StatusParams.StatusWord, 22);
            status.Status = (Status)data[0];
            status.ErrorCode = data[1];
            status.TargetFrequency = data[2] / 100.0f;
            status.RunningFrequency = data[3] / 100.0f;
            status.RailVotage = data[4];
            status.OutputVoltage = data[5];
            status.OutputCurrent = data[6] / 10.0f;
            status.OutputPower = data[7] / 10.0f;
            status.OutputFrequency = data[8] / 100.0f;
            status.OutputTorque = data[9] / 1000.0f;
            status.MoudleTemerature = data[10] / 10.0f;
            status.MotorRotatingSpeed = data[11];
            status.RemoteAI1 = data[12] / 100.0f;
            status.RemoteAI2 = data[13] / 100.0f;
            status.RemotePFInput = data[14] / 100.0f;
            status.RemoteDI = data[15];
            status.RemoteDO = data[16];
            status.PIDGoal = data[17] / 1000.0f;
            status.PIDFeedback = data[18] / 1000.0f;
            status.AgingTimeHours = data[19];
            status.AgingTimeMinutes = data[20];
            status.LoadPercentage = data[21] / 1000.0f;
            return status;
        }

        public void StartRunning(bool forawrd = true)
        {
            ushort command = (ushort)(forawrd ? Command.StartForward : Command.StartReverse);
            modbus.WriteSingleRegister(Addr, (ushort)ControlParams.Command, command);
        }

        public void StepRunning(bool forawrd = true)
        {
            ushort command = (ushort)(forawrd ? Command.StepForward : Command.StepReverse);
            modbus.WriteSingleRegister(Addr, (ushort)ControlParams.Command, command);
        }

        public void StopRunning(bool brake = true)
        {
            ushort command = (ushort)(brake ? Command.BrakeToStop : Command.FreeRollToStop);
            modbus.WriteSingleRegister(Addr, (ushort)ControlParams.Command, command);
        }

        public void ResetError()
        {
            ushort command = (ushort)Command.Reset;
            modbus.WriteSingleRegister(Addr, (ushort)ControlParams.Command, command);
        }

        public void SetMainFrequency(float frequency)
        {
            ushort freq = (ushort)(frequency * 100);
            modbus.WriteSingleRegister(Addr, (ushort)ControlParams.MainFrequency, freq);
        }

        public void SetAuxFrequency(float frequency)
        {
            ushort freq = (ushort)(frequency * 100);
            modbus.WriteSingleRegister(Addr, (ushort)ControlParams.AuxFrequency, freq);
        }

        public void SetMaxFrequency(float frequency)
        {
            ushort freq = (ushort)(frequency * 100);
            modbus.WriteSingleRegister(Addr, (ushort)ControlParams.MaxFrequency, freq);
        }

        public void SetTargetTorque(float percentage)
        {
            ushort t = (ushort)(percentage * 1000);
            modbus.WriteSingleRegister(Addr, (ushort)ControlParams.TargetTorque, t);
        }

        public void SetMaximunTorqueInVelocityMode(float percentage)
        {
            ushort t = (ushort)(percentage * 1000);
            modbus.WriteSingleRegister(Addr, (ushort)ControlParams.MaximunTorqueInVelocityMode, t);
        }

        public void SetMaximumVelocityInTorqueMode(float frequency)
        {
            ushort v = (ushort)(frequency * 100);
            modbus.WriteSingleRegister(Addr, (ushort)ControlParams.MaximumVelocityInTorqueMode, v);
        }
        public void SetVFSeperationVoltage(float percentage)
        {
            ushort v = (ushort)(percentage * 1000);
            modbus.WriteSingleRegister(Addr, (ushort)ControlParams.VFSeperationVoltage, v);
        }

        public void SetMultiSpeedFrequency(float frequency0, float frequency1)
        {
            ushort freq0 = (ushort)(frequency0 * 100);
            ushort freq1 = (ushort)(frequency1 * 100);
            modbus.WriteSingleRegister(Addr, (ushort)ControlParams.MultiSpeedFrequency0, freq0);
            modbus.WriteSingleRegister(Addr, (ushort)ControlParams.MultiSpeedFrequency1, freq1);
        }

        public void SetPIDGoal(float percentage)
        {
            ushort s = (ushort)(percentage * 1000);
            modbus.WriteSingleRegister(Addr, (ushort)ControlParams.PIDGoal, s);
        }

        public static Status Probe(SerialPort port, byte addr, int baudRate, PortConfig commConfig)
        {
            ModbusRTUMaster modbus = new ModbusRTUMaster(port, baudRate, commConfig, 500);
            return Probe(modbus, addr);
        }

        public static Status Probe(ModbusRTUMaster modbus, byte addr)
        {
            var data = modbus.ReadHoldingRegisters(addr, (ushort)StatusParams.StatusWord, 1);
            return (Status)data[0];
        }
    }
}
