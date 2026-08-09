using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using LibSciyonVFD.Serial;

namespace LibSciyonVFD
{
    public class VFDDevice
    {
        public byte Addr { private set; get; }
        public int BaudRate { private set; get; }
        public PortConfig CommConfig { private set; get; }
        public VFDConfiguration Config { private set; get; }

        public int MaxRetriesForSingleAccess = 5;


        public static ErrorInfo[] ErrorInfos { private set; get; } = new ErrorInfo[]
        {
            new ErrorInfo{ Code = ErrorCode.Void, Message = "No error", Description = "No error", Suggestion = "No action needed" },
            new ErrorInfo{ Code = ErrorCode.EuU, Message = "母线欠压", Description = "内部直流母线电压过低", Suggestion = "检查输入电压是否正常。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EoC1, Message = "加速过流", Description = "启动或加速时输出电流过大", Suggestion = "检查电机是否短路，功率是否合适。对于惯性负载，增大加速时间设定。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EoC2, Message = "恒速过流", Description = "平稳运行中输出电流突然过大", Suggestion = "检查电机是否短路，功率是否合适，电网电压是否存在波动。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EoC3, Message = "减速过流", Description = "减速时输出电流过大", Suggestion = "检查电机是否短路，功率是否合适，电网电压是否存在波动。对于惯性负载，增大减速时间设定。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EoU1, Message = "加速过压", Description = "加速过程中母线电压异常上升", Suggestion = "检查电机接线是否正确，电网是否过压。考虑使用能耗制动。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EoU2, Message = "恒速过压", Description = "平稳运行中母线电压异常上升", Suggestion = "检查负载是否剧烈波动，电网是否过压，参数设置是否正确。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EoU3, Message = "减速过压", Description = "减速过程中母线电压异常上升", Suggestion = "检查负载是否剧烈波动，电网是否过压，参数设置是否正确。考虑使用能耗制动。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EoL1, Message = "变频过载", Description = "变频器输出功率超限", Suggestion = "检查负载是否过大，电机功率是否合适。对于惯性负载，增大加速时间设定。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EoL2, Message = "电机过载", Description = "电机功率超限", Suggestion = "检查电机参数设置是否正确，负载是否过大。非变频电机不建议重载低速运行。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EoH1, Message = "变频过热", Description = "变频器内部温度过高", Suggestion = "检查环境温度是否过高，散热条件是否良好。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EoH2, Message = "电机过热", Description = "电机温度过高", Suggestion = "检查电机是否过载，环境温度是否过高，过温阈值设置是否合适。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EoPL, Message = "输出缺相", Description = "输出相位不完整", Suggestion = "检查电机接线是否正确，电机是否损坏。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EIPL, Message = "输入缺相", Description = "输入相位不完整", Suggestion = "检查电源接线是否正确，用万用表测量三相电压是否平衡。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EFAL, Message = "模块故障", Description = "变频器功率模块上报了致命错误", Suggestion = "检查输出是否短路。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EruU, Message = "运行欠压", Description = "运行中内部直流母线电压过低", Suggestion = "检查输入电压是否正常，上电时是否听到内部接触器动作声。如果无法自行解决，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EPdn, Message = "对地异常", Description = "输出接线似乎在对地漏电", Suggestion = "检查电机、输出线是否绝缘损坏。尝试脱开输出线，若仍然报错，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.ECtC, Message = "检流异常", Description = "内部电流传感器异常", Suggestion = "内部硬件异常，请联系技术支持。" },
            new ErrorInfo{ Code = ErrorCode.EtUN, Message = "辨识失败", Description = "无法完成自动电机参数测量", Suggestion = "确保电机接线正确、不在旋转，检查电机参数设置。" },
            new ErrorInfo{ Code = ErrorCode.Eto1, Message = "厂商锁定", Description = "代理商运行时间到", Suggestion = "联系代理商处理" },
            new ErrorInfo{ Code = ErrorCode.Eto2, Message = "厂商锁定", Description = "定时运行时间到", Suggestion = "联系技术支持" },
            new ErrorInfo{ Code = ErrorCode.Eto3, Message = "厂商锁定", Description = "累计运行时间到", Suggestion = "联系技术支持" },
            new ErrorInfo{ Code = ErrorCode.ESFt, Message = "软件故障", Description = "软件版本不匹配", Suggestion = "联系技术支持" },
            new ErrorInfo{ Code = ErrorCode.EPEr, Message = "外部故障", Description = "外部故障输入有效", Suggestion = "检查外部故障输入信号状态" },
            new ErrorInfo{ Code = ErrorCode.EFbH, Message = "反馈超限", Description = "PID反馈信号超限", Suggestion = "检查反馈信号接线是否正确，反馈信号是否正常，PID参数是否正常" },
            new ErrorInfo{ Code = ErrorCode.EFbL, Message = "反馈丢失", Description = "PID反馈信号丢失", Suggestion = "检查反馈信号接线是否正确，反馈信号是否正常" },
            new ErrorInfo{ Code = ErrorCode.EAiH, Message = "模拟超限", Description = "模拟量输入信号超限", Suggestion = "检查模拟量输入信号接线是否正确，模拟量输入信号是否正常" },
            new ErrorInfo{ Code = ErrorCode.EAiL, Message = "模拟丢失", Description = "模拟量输入信号丢失", Suggestion = "联系技术支持" },
            new ErrorInfo{ Code = ErrorCode.EcEr, Message = "存储异常", Description = "内部存储器异常", Suggestion = "联系技术支持" },
            new ErrorInfo{ Code = ErrorCode.EcTo, Message = "通讯超时", Description = "外部通信可能存在异常", Suggestion = "检查通讯线路是否正常，通讯参数是否正确。如果无法自行解决，请联系技术支持。" }
            // Add more error codes as needed
        };


        private ModbusRTUMaster modbus;

        public struct VFDStatus
        {
            public Status Status { internal set; get; }
            public ErrorCode ErrorCode { internal set; get; }
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
            RunningForward = 0b0001,
            RunningReverse = 0b0010,
            Idle = 0b0011,
            Error = 0b0100
        }

        public VFDDevice(SerialPort port, byte addr, int baudRate, PortConfig commConfig, VFDConfiguration config = null)
        {
            Addr = addr;
            Config = config;
            modbus = new ModbusRTUMaster(port, baudRate, commConfig, 500);
            if (Config is null)
            {
                Config = new VFDConfiguration();
            }
        }

        // Cross-platform constructor using ISerialPort
        public VFDDevice(ISerialPort port, byte addr, int baudRate, PortConfig commConfig, VFDConfiguration config = null)
        {
            Addr = addr;
            Config = config;
            modbus = new ModbusRTUMaster(port, baudRate, commConfig, 500);
            if (Config is null)
            {
                Config = new VFDConfiguration();
            }
        }

        public VFDDevice(ModbusRTUMaster modbus, byte addr, VFDConfiguration config = null)
        {
            Addr = addr;
            Config = config;
            this.modbus = modbus;
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
                    if ((ItemsInGroup.Count == 0 || ItemsInGroup.Last().Index.CodeDomain == item.Index.CodeDomain) && ItemsInGroup.Count < 16)
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
                        catch (InvalidOperationException ex)
                        {
                            // Modbus ERRCode, dont retry here
                            Console.WriteLine(ex.Message);
                            throw;
                        }
                        catch (Exception ex)
                        {
                            if (retries >= MaxRetriesForSingleAccess)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine($"ERROR: Communication failed with max retries({MaxRetriesForSingleAccess}).");
                                throw;
                            }
                            retries++;
                            Console.WriteLine(ex.Message);
                            Console.WriteLine($"Retry(s) {retries}/{MaxRetriesForSingleAccess}");
                            goto _RETRY;
                        }
                    }
                }
                catch (TimeoutException)
                {
                    throw;
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
            bool isRunning = Probe() >= Status.Idle;
            foreach (var item in Config.ByCode.Values)
            {
                bool skipped_by_code = false;
            _BEGINPROCESS:
                if (skipped_by_code) continue;
                try
                {
                    skipped_by_code = item.IsReadonly == ReadOnly.Always || (item.IsReadonly == ReadOnly.WhenRuning && isRunning);
                    if (
                        ((ItemsInGroup.Count == 0 || ItemsInGroup.Last().Index.CodeDomain == item.Index.CodeDomain) && ItemsInGroup.Count < 16)
                        && !skipped_by_code
                        )
                    {
                        ItemsInGroup.Add(item);
                        continue;
                    }
                    else
                    {
                        if (ItemsInGroup.Count == 0) continue;
                        ushort[] collected = new ushort[ItemsInGroup.Count];
                        for (int i = 0; i < ItemsInGroup.Count; i++)
                        {
                            collected[i] = ItemsInGroup[i].RawValue;
                            ItemsInGroup[i].Modified = false;
                        }
                        int retries = 0;
                    _RETRY:
                        try
                        {
                            Console.WriteLine($"*COM* WriteMultipleRegisters({Addr},0x{ItemsInGroup.First().Index.CodeAddr.ToString("X4")})");
                            modbus.WriteMultipleRegisters(Addr, ItemsInGroup.First().Index.CodeAddr, collected);
                        }
                        catch (InvalidOperationException ex)
                        {
                            // Modbus ERRCode, dont retry here
                            Console.WriteLine(ex.Message);
                            throw;
                        }
                        catch (Exception ex)
                        {
                            if (retries >= MaxRetriesForSingleAccess)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine($"ERROR: Communication failed with max retries({MaxRetriesForSingleAccess}).");
                                throw;
                            }
                            retries++;
                            Console.WriteLine(ex.Message);
                            Console.WriteLine($"Retry(s) {retries}/{MaxRetriesForSingleAccess}");
                            goto _RETRY;
                        }
                        ItemsInGroup.Clear();
                        goto _BEGINPROCESS;
                    }
                }
                catch (TimeoutException)
                {
                    throw;
                }
                catch
                {
                    Console.WriteLine($"! Error writing sector {ItemsInGroup.First().Index.CodeDomain}-{ItemsInGroup.First().Index.CodeId}~{ItemsInGroup.Last().Index.CodeId}, skipped.");
                    ItemsInGroup.Clear();
                    goto _BEGINPROCESS;
                }
            }
        }

        public int WriteModified()
        {
            int success = 0;
            List<ConfigItem> ItemsInGroup = new List<ConfigItem>();
            bool isRunning = Probe() >= Status.Idle;
            foreach (var item in Config.ByCode.Values)
            {
                bool skipped_by_code = false;
            _BEGINPROCESS:
                if (skipped_by_code) continue;
                try
                {
                    skipped_by_code = ((!item.Modified) || (item.IsReadonly == ReadOnly.Always || (item.IsReadonly == ReadOnly.WhenRuning && isRunning)));
                    if (
                        ((ItemsInGroup.Count == 0 || ItemsInGroup.Last().Index.CodeDomain == item.Index.CodeDomain) && ItemsInGroup.Count < 16)
                        && !skipped_by_code
                        )
                    {
                        ItemsInGroup.Add(item);
                        continue;
                    }
                    else
                    {
                        if (ItemsInGroup.Count == 0) continue;
                        ushort[] collected = new ushort[ItemsInGroup.Count];
                        for (int i = 0; i < ItemsInGroup.Count; i++)
                        {
                            collected[i] = ItemsInGroup[i].RawValue;
                            ItemsInGroup[i].Modified = false;
                        }
                        int retries = 0;
                    _RETRY:
                        try
                        {
                            Console.WriteLine($"*COM* WriteMultipleRegisters({Addr},0x{ItemsInGroup.First().Index.CodeAddr.ToString("X4")})");
                            modbus.WriteMultipleRegisters(Addr, ItemsInGroup.First().Index.CodeAddr, collected);
                            success += collected.Length;
                        }
                        catch (InvalidOperationException ex)
                        {
                            // Modbus ERRCode, dont retry here
                            Console.WriteLine(ex.Message);
                            throw;
                        }
                        catch (Exception ex)
                        {
                            if (retries >= MaxRetriesForSingleAccess)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine($"ERROR: Communication failed with max retries({MaxRetriesForSingleAccess}).");
                                throw;
                            }
                            retries++;
                            Console.WriteLine(ex.Message);
                            Console.WriteLine($"Retry(s) {retries}/{MaxRetriesForSingleAccess}");
                            goto _RETRY;
                        }
                        ItemsInGroup.Clear();
                        goto _BEGINPROCESS;
                    }
                }
                catch (TimeoutException)
                {
                    throw;
                }
                catch
                {
                    Console.WriteLine($"! Error writing sector {ItemsInGroup.First().Index.CodeDomain}-{ItemsInGroup.First().Index.CodeId}~{ItemsInGroup.Last().Index.CodeId}, skipped.");
                    ItemsInGroup.Clear();
                    goto _BEGINPROCESS;
                }
            }
            return success;
        }

        public bool CanWrite(ConfigItem item)
        {
            var st = Probe();
            bool isRunning = st == Status.RunningForward || st == Status.RunningReverse;
            return !(item.IsReadonly == ReadOnly.Always || (item.IsReadonly == ReadOnly.WhenRuning && isRunning));
        }

        public Status Probe()
        {
            return Probe(modbus, Addr);
        }

        public VFDStatus BriefStatus()
        {
            return BriefStatus(modbus, Addr);
        }

        public static VFDStatus BriefStatus(ModbusRTUMaster modbus, byte Addr)
        {
            VFDStatus status = new VFDStatus();
            var data = modbus.ReadHoldingRegisters(Addr, (ushort)StatusParams.StatusWord, 2);
            status.Status = (Status)data[0];
            status.ErrorCode = (ErrorCode)data[1];
            return status;
        }

        public VFDStatusParams ReadDetailStatus()
        {
            return ReadDetailStatus(modbus, Addr);
        }

        public static VFDStatusParams ReadDetailStatus(ModbusRTUMaster modbus, byte Addr)
        {
            VFDStatusParams status = new VFDStatusParams();
            var data = modbus.ReadHoldingRegisters(Addr, (ushort)StatusParams.StatusWord, 16);
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
            data = modbus.ReadHoldingRegisters(Addr, (ushort)StatusParams.StatusWord, 6);
            status.RemoteDO = data[0];
            status.PIDGoal = data[1] / 1000.0f;
            status.PIDFeedback = data[2] / 1000.0f;
            status.AgingTimeHours = data[3];
            status.AgingTimeMinutes = data[4];
            status.LoadPercentage = data[5] / 1000.0f;
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

        public static Status Probe(ISerialPort port, byte addr, int baudRate, PortConfig commConfig)
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
