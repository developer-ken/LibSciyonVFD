namespace LibSciyonVFD
{
    public partial class VFDConfiguration
    {
        #region P0组 系统参数
        public ConfigItem RatedPower = new ConfigItem(
            0, new ConfigIndex("P0-00"),
            "变频器额定功率 (0.75~400.0kW)",
            ReadOnly.Always, shift: 10);

        public ConfigItem RatedCurrent = new ConfigItem(
            0, new ConfigIndex("P0-01"),
            "变频器额定电流（机型确定）",
            ReadOnly.Always);

        public ConfigItem RatedVoltage = new ConfigItem(
            0, new ConfigIndex("P0-02"),
            "变频器额定电压 (220/380/480/690/1140V)",
            ReadOnly.Always);

        public ConfigItem LoadType = new ConfigItem(
            1, new ConfigIndex("P0-03"),
            "GP类型显示：1=G型(恒转矩)，2=P型(风机/水泵)",
            ReadOnly.Always);

        public ConfigItem FuncDisplayCtrl = new ConfigItem(
            0, new ConfigIndex("P0-04"),
            "功能码显示控制\n百位：0=全部显示,1=控制策略优化\n十位：0=全部显示,1=显示修改项,2=A4组\n个位：0=允许修改,1=禁止修改",
            ReadOnly.WhenRuning);

        public ConfigItem FuncInit = new ConfigItem(
            0, new ConfigIndex("P0-05"),
            "功能码初始化：0=无操作,1=除电机参数外恢复出厂,2=全部恢复出厂,3=清除故障记录",
            ReadOnly.WhenRuning);

        public ConfigItem ControlMode = new ConfigItem(
            0, new ConfigIndex("P0-06"),
            "控制模式选择：0=V/f,1=无PG矢量速度,2=无PG矢量转矩,3=带PG速度,4=带PG转矩",
            ReadOnly.WhenRuning);

        public ConfigItem CmdSource = new ConfigItem(
            0, new ConfigIndex("P0-07"),
            "命令源通道：0=BOP,1=端子,2=Modbus,3=选购卡",
            ReadOnly.Never);

        public ConfigItem MotorDirection = new ConfigItem(
            0, new ConfigIndex("P0-08"),
            "电机转向：十位=反转禁止(0/1)，个位=相序对调(0/1)",
            ReadOnly.WhenRuning);

        public ConfigItem MaxFreq = new ConfigItem(
            5000, new ConfigIndex("P0-09"),
            "最大频率 (50.00~600.00Hz)",
            ReadOnly.WhenRuning, shift: 100);

        public ConfigItem ReservedP010 = new ConfigItem(
            0, new ConfigIndex("P0-10"),
            "保留",
            ReadOnly.WhenRuning);

        public ConfigItem FreqUpper = new ConfigItem(
            5000, new ConfigIndex("P0-11"),
            "频率上限 (≤最大频率)",
            ReadOnly.WhenRuning, shift: 100);

        public ConfigItem FreqLower = new ConfigItem(
            0, new ConfigIndex("P0-12"),
            "频率下限 (0~P0-11)",
            ReadOnly.WhenRuning, shift: 100);

        public ConfigItem MainFreqSrc = new ConfigItem(
            0, new ConfigIndex("P0-13"),
            "主频率指令源A (0~7)",
            ReadOnly.WhenRuning);

        public ConfigItem SubFreqSrc = new ConfigItem(
            0, new ConfigIndex("P0-14"),
            "辅频率指令源B (0~7)",
            ReadOnly.WhenRuning);

        public ConfigItem MainSubRelation = new ConfigItem(
            0, new ConfigIndex("P0-15"),
            "主辅组合关系：十位=运算(0:+,1:-,2:MAX,3:MIN)，个位=选择(0主/1运算/2切换/3切换/4切换)",
            ReadOnly.WhenRuning);

        public ConfigItem PresetFreq = new ConfigItem(
            5000, new ConfigIndex("P0-16"),
            "频率预置设定 (P0-12~P0-11)",
            ReadOnly.Never, shift: 100);

        public ConfigItem SubFreqRef = new ConfigItem(
            0, new ConfigIndex("P0-17"),
            "辅频率参考量：0=相对最大频率,1=相对主频率",
            ReadOnly.Never);

        public ConfigItem SubFreqGain = new ConfigItem(
            100, new ConfigIndex("P0-18"),
            "辅频率增益 (0~150%)",
            ReadOnly.Never, shift: 1000);

        public ConfigItem FreqBiasCfg = new ConfigItem(
            1, new ConfigIndex("P0-19"),
            "频率偏置配置：十位=存储(0存储/1不存储/2运行有效/3无效)，个位=模式(0点加/1积分)",
            ReadOnly.Never);

        public ConfigItem FreqBiasRate = new ConfigItem(
            1, new ConfigIndex("P0-20"),
            "频率偏置速率 (0.01~10.00Hz/200ms)",
            ReadOnly.Never, shift: 100);

        public ConfigItem AccTime0 = new ConfigItem(
            0, new ConfigIndex("P0-21"),
            "加速时间0 (机型确定)",
            ReadOnly.Never, shift: 10);

        public ConfigItem DecTime0 = new ConfigItem(
            0, new ConfigIndex("P0-22"),
            "减速时间0 (机型确定)",
            ReadOnly.Never, shift: 10);

        public ConfigItem MotorParamGroup = new ConfigItem(
            0, new ConfigIndex("P0-23"),
            "电机参数组选择：0=组1",
            ReadOnly.WhenRuning);

        public ConfigItem TuneMode = new ConfigItem(
            0, new ConfigIndex("P0-24"),
            "调谐选择：0无/1静止/2旋转",
            ReadOnly.WhenRuning);

        public ConfigItem JogPriority = new ConfigItem(
            0, new ConfigIndex("P0-25"),
            "点动优先：0无效 1有效",
            ReadOnly.Never);

        public ConfigItem FreqAccuracy = new ConfigItem(
            0, new ConfigIndex("P0-26"),
            "频率精度：0=0.01Hz,1=0.1Hz",
            ReadOnly.WhenRuning);

        public ConfigItem IndustryMacro = new ConfigItem(
            0, new ConfigIndex("P0-27"),
            "行业宏选择：0通用/1供水/2空压机/3雕刻300Hz/4雕刻400Hz/5塑机串口/6塑机CAN",
            ReadOnly.WhenRuning);

        public ConfigItem ExtCardCfg = new ConfigItem(
            0, new ConfigIndex("P0-28"),
            "扩展卡配置：百位=通信卡,十位=AI卡,个位=DI卡 (0无效/1有效)",
        ReadOnly.WhenRuning);
        #endregion

        #region P1组 第一电机参数特性

        public ConfigItem Motor1Type = new ConfigItem(
            0, new ConfigIndex("P1-00"),
            "电机1类型：0=普通异步电机，1=变频异步电机，2=普通永磁电机",
            ReadOnly.WhenRuning);

        public ConfigItem Motor1RatedPower = new ConfigItem(
            0, new ConfigIndex("P1-01"),
            "电机1额定功率 (按铭牌设置，0.1~400.0kW)",
            ReadOnly.WhenRuning, shift: 10);

        public ConfigItem Motor1RatedVoltage = new ConfigItem(
            0, new ConfigIndex("P1-02"),
            "电机1额定电压 (按铭牌设置，1~690V)",
            ReadOnly.WhenRuning);

        public ConfigItem Motor1RatedCurrent = new ConfigItem(
            0, new ConfigIndex("P1-03"),
            "电机1额定电流 (按铭牌设置，0.1~6500A)",
            ReadOnly.WhenRuning, shift: 10);

        public ConfigItem Motor1RatedFreq = new ConfigItem(
            0, new ConfigIndex("P1-04"),
            "电机1额定频率 (按铭牌设置，0.01Hz~最大频率)",
            ReadOnly.WhenRuning, shift: 100);

        public ConfigItem Motor1RatedSpeed = new ConfigItem(
            0, new ConfigIndex("P1-05"),
            "电机1额定转速 (按铭牌设置，1~65535rpm)",
            ReadOnly.WhenRuning);

        public ConfigItem Motor1PoleCount = new ConfigItem(
            4, new ConfigIndex("P1-06"),
            "电机1极数 (2~80)",
            ReadOnly.WhenRuning);

        public ConfigItem Motor1StatorRes = new ConfigItem(
            0, new ConfigIndex("P1-07"),
            "电机1定子电阻 (调谐后自动更新，0.001~65.535Ω)",
            ReadOnly.WhenRuning, shift: 1000);

        public ConfigItem Motor1RotorRes = new ConfigItem(
            0, new ConfigIndex("P1-08"),
            "电机1转子电阻 (调谐后自动更新，0.001~65.535Ω)",
            ReadOnly.WhenRuning, shift: 1000);

        public ConfigItem Motor1LeakInduct = new ConfigItem(
            0, new ConfigIndex("P1-09"),
            "电机1漏感 (调谐后自动更新，0.1~6553.5mH)",
            ReadOnly.WhenRuning, shift: 10);

        public ConfigItem Motor1MutualInduct = new ConfigItem(
            0, new ConfigIndex("P1-10"),
            "电机1互感 (调谐后自动更新，0.1~6553.5mH)",
            ReadOnly.WhenRuning, shift: 10);

        public ConfigItem Motor1NoLoadCurrent = new ConfigItem(
            0, new ConfigIndex("P1-11"),
            "电机1空载电流 (调谐后自动更新，0.01A~额定电流)",
            ReadOnly.WhenRuning, shift: 100);

        public ConfigItem Motor1BackEMF = new ConfigItem(
            0, new ConfigIndex("P1-12"),
            "电机1反电势系数 (40%~100%，仅永磁电机有效)",
            ReadOnly.Never, shift: 1000);

        public ConfigItem Motor1InitPos = new ConfigItem(
            0, new ConfigIndex("P1-13"),
            "电机1初始位置角 (0.00~6.28rad)",
            ReadOnly.Never, shift: 100);

        public ConfigItem Motor1CarrierFreq = new ConfigItem(
            0, new ConfigIndex("P1-14"),
            "电机1载波频率 (机型确定，1.0~16.0kHz)",
            ReadOnly.Never, shift: 10);

        public ConfigItem CarrierOptimize = new ConfigItem(
            2010, new ConfigIndex("P1-15"),
            "载波优化选择：千位=调制方式(0七段/1五段/2自由)，百位=温升调整，十位=调制比优化，个位=低速载频调整",
            ReadOnly.Never);

        #endregion

        #region P2组 电机V/f控制参数组

        public ConfigItem VfCurve = new ConfigItem(
            0, new ConfigIndex("P2-00"),
            "V/f曲线设定：0直线，1多点折线，2V/f分离，3 1.2次方，4 1.4次方，5 1.6次方，6 1.8次方，7 2次方",
            ReadOnly.WhenRuning);

        public ConfigItem VfFreqPoint1 = new ConfigItem(
            0, new ConfigIndex("P2-01"),
            "多点V/f频率点1（P2-00=1时有效）",
            ReadOnly.WhenRuning, shift: 100);

        public ConfigItem VfVoltPoint1 = new ConfigItem(
            0, new ConfigIndex("P2-02"),
            "多点V/f电压点1（0~100%）",
            ReadOnly.WhenRuning, shift: 1000);

        public ConfigItem VfFreqPoint2 = new ConfigItem(
            0, new ConfigIndex("P2-03"),
            "多点V/f频率点2",
            ReadOnly.WhenRuning, shift: 100);

        public ConfigItem VfVoltPoint2 = new ConfigItem(
            0, new ConfigIndex("P2-04"),
            "多点V/f电压点2（0~100%）",
            ReadOnly.WhenRuning, shift: 1000);

        public ConfigItem VfFreqPoint3 = new ConfigItem(
            0, new ConfigIndex("P2-05"),
            "多点V/f频率点3",
            ReadOnly.WhenRuning, shift: 100);

        public ConfigItem VfVoltPoint3 = new ConfigItem(
            0, new ConfigIndex("P2-06"),
            "多点V/f电压点3（0~100%）",
            ReadOnly.WhenRuning, shift: 1000);

        public ConfigItem VfSepVoltSrc = new ConfigItem(
            0, new ConfigIndex("P2-07"),
            "V/f分离电压源：0数字，1AI1，2AI2，3PFI，4多段，5PID，6PLC，7通信",
            ReadOnly.Never);

        public ConfigItem VfSepVoltDigital = new ConfigItem(
            0, new ConfigIndex("P2-08"),
            "分离电压数字设定（0~100%）",
            ReadOnly.Never, shift: 1000);

        public ConfigItem VfSepAccTime = new ConfigItem(
            50, new ConfigIndex("P2-09"),
            "分离电压加速时间（0~1000s）",
            ReadOnly.Never, shift: 10);

        public ConfigItem VfSepDecTime = new ConfigItem(
            50, new ConfigIndex("P2-10"),
            "分离电压减速时间（0~1000s）",
            ReadOnly.Never, shift: 10);

        public ConfigItem TorqueBoost = new ConfigItem(
            1, new ConfigIndex("P2-11"),
            "转矩提升（0.0%~30.0%，0=自动）",
            ReadOnly.Never, shift: 1000);

        public ConfigItem TorqueBoostFilter = new ConfigItem(
            1000, new ConfigIndex("P2-12"),
            "转矩提升滤波时间（0.000~5.000s）",
            ReadOnly.Never, shift: 1000);

        public ConfigItem TorqueBoostCutFreq = new ConfigItem(
            4000, new ConfigIndex("P2-13"),
            "转矩提升截止频率（0~600Hz）",
            ReadOnly.Never, shift: 100);

        public ConfigItem SlipCompGain = new ConfigItem(
            0, new ConfigIndex("P2-14"),
            "转差补偿增益（0~200%）",
            ReadOnly.Never, shift: 1000);

        public ConfigItem SlipCompFilter = new ConfigItem(
            2000, new ConfigIndex("P2-15"),
            "转差补偿滤波时间（0.000~5.000s）",
            ReadOnly.Never, shift: 1000);

        public ConfigItem CurrentOscSuppress = new ConfigItem(
            50, new ConfigIndex("P2-16"),
            "电流振荡抑制强度（0~1000）",
            ReadOnly.Never);

        public ConfigItem MotoringCurrentLimit = new ConfigItem(
            130, new ConfigIndex("P2-17"),
            "电动限流门限（0~300%）",
            ReadOnly.WhenRuning, shift: 1000);

        public ConfigItem BrakingCurrentLimit = new ConfigItem(
            110, new ConfigIndex("P2-18"),
            "制动限流门限（0~300%）",
            ReadOnly.WhenRuning, shift: 1000);

        public ConfigItem AVRMode = new ConfigItem(
            2, new ConfigIndex("P2-19"),
            "AVR功能：0全程有效，1全程无效，2减速无效",
            ReadOnly.Never);

        public ConfigItem DroopFreq = new ConfigItem(
            0, new ConfigIndex("P2-20"),
            "下垂频率（0.00~10.00Hz）",
            ReadOnly.Never, shift: 100);

        #endregion

        #region P3组 矢量控制参数组

        public ConfigItem LowSpeedASR_P = new ConfigItem(
            1, new ConfigIndex("P3-00"),
            "低速ASR比例（0.00~200.00）",
            ReadOnly.Never, shift: 100);

        public ConfigItem LowSpeedASR_I = new ConfigItem(
            1, new ConfigIndex("P3-01"),
            "低速ASR积分（0.00~200.00）",
            ReadOnly.Never, shift: 100);

        public ConfigItem LowSpeedASR_SwitchFreq = new ConfigItem(
            500, new ConfigIndex("P3-02"),
            "低速ASR切换频率（0.00Hz~P3-05）",
            ReadOnly.Never, shift: 100);

        public ConfigItem HighSpeedASR_P = new ConfigItem(
            1, new ConfigIndex("P3-03"),
            "高速ASR比例（0.00~200.00）",
            ReadOnly.Never, shift: 100);

        public ConfigItem HighSpeedASR_I = new ConfigItem(
            1, new ConfigIndex("P3-04"),
            "高速ASR积分（0.00~200.00）",
            ReadOnly.Never, shift: 100);

        public ConfigItem HighSpeedASR_SwitchFreq = new ConfigItem(
            1000, new ConfigIndex("P3-05"),
            "高速ASR切换频率（P3-02~最大输出频率）",
            ReadOnly.Never, shift: 100);

        public ConfigItem FluxReg_P = new ConfigItem(
            1, new ConfigIndex("P3-06"),
            "励磁调节比例（电流环PI参数）",
            ReadOnly.Never, shift: 100);

        public ConfigItem FluxReg_I = new ConfigItem(
            1, new ConfigIndex("P3-07"),
            "励磁调节积分（0.00~200.00）",
            ReadOnly.Never, shift: 100);

        public ConfigItem TorqueReg_P = new ConfigItem(
            1, new ConfigIndex("P3-08"),
            "转矩调节比例（电流环PI参数）",
            ReadOnly.Never, shift: 100);

        public ConfigItem TorqueReg_I = new ConfigItem(
            1, new ConfigIndex("P3-09"),
            "转矩调节积分（0.00~200.00）",
            ReadOnly.Never, shift: 100);

        public ConfigItem MotoringTorqueLimitSrc = new ConfigItem(
            0, new ConfigIndex("P3-10"),
            "电动转矩限定源：0数字，1AI1，2AI2，3PFI，4通信",
            ReadOnly.WhenRuning);

        public ConfigItem MotoringTorqueLimit = new ConfigItem(
            150, new ConfigIndex("P3-11"),
            "电动转矩数字限定（0~200%）",
            ReadOnly.Never, shift: 1000);

        public ConfigItem BrakingTorqueLimit = new ConfigItem(
            150, new ConfigIndex("P3-12"),
            "制动转矩数字限定（0~200%）",
            ReadOnly.Never, shift: 1000);

        public ConfigItem VectorSlipCompGain = new ConfigItem(
            1, new ConfigIndex("P3-13"),
            "矢量转差补偿增益（0~200%）",
            ReadOnly.Never, shift: 1000);

        public ConfigItem InertiaCompGain = new ConfigItem(
            50, new ConfigIndex("P3-14"),
            "惯量补偿增益（0~130%）",
            ReadOnly.Never, shift: 1000);

        public ConfigItem TorqueCmdSrc = new ConfigItem(
            0, new ConfigIndex("P3-15"),
            "转矩给定源：0数字，1AI1，2AI2，3PFI，4多段，5通信",
            ReadOnly.WhenRuning);

        public ConfigItem TorqueCmdDigital = new ConfigItem(
            0, new ConfigIndex("P3-16"),
            "转矩数字设定（-200%~200%）",
            ReadOnly.Never, shift: 1000);

        public ConfigItem TorqueCmdFilter = new ConfigItem(
            0, new ConfigIndex("P3-17"),
            "转矩指令滤波时间（0.000~10.000s）",
            ReadOnly.Never, shift: 1000);

        public ConfigItem SpeedLimitSrc = new ConfigItem(
            0, new ConfigIndex("P3-18"),
            "转速限定源：0数字，1AI1，2AI2，3PFI，4通信",
            ReadOnly.WhenRuning);

        public ConfigItem SpeedLimitDigital = new ConfigItem(
            5000, new ConfigIndex("P3-19"),
            "转速数字限定（0~上限频率）",
            ReadOnly.Never, shift: 100);

        #endregion

        #region P4组 启停控制组

        public ConfigItem StartMode = new ConfigItem(
            0, new ConfigIndex("P4-00"),
            "启动方式：0正常启动，1制动再启动，2转速跟踪再启动",
            ReadOnly.WhenRuning);

        public ConfigItem StartFreq = new ConfigItem(
            0, new ConfigIndex("P4-01"),
            "启动频率（0.00~10.00Hz）",
            ReadOnly.WhenRuning, shift: 100);

        public ConfigItem StartFreqHoldTime = new ConfigItem(
            0, new ConfigIndex("P4-02"),
            "启动频率维持时间（0.0~60.0s）",
            ReadOnly.WhenRuning, shift: 10);

        public ConfigItem StartFreqDirection = new ConfigItem(
            0, new ConfigIndex("P4-03"),
            "启动频率方向：0与运行命令一致，1正转，2反转",
            ReadOnly.WhenRuning);

        public ConfigItem StartBrakeCurrent = new ConfigItem(
            80, new ConfigIndex("P4-04"),
            "启动制动电流（0~100%）",
            ReadOnly.WhenRuning, shift: 1000);

        public ConfigItem StartBrakeHoldTime = new ConfigItem(
            5, new ConfigIndex("P4-05"),
            "启动制动维持时间（0.0~100.0s）",
            ReadOnly.WhenRuning, shift: 10);

        public ConfigItem StartTrackCurrent = new ConfigItem(
            15, new ConfigIndex("P4-06"),
            "启动转速跟踪电流（0~100%）",
            ReadOnly.WhenRuning, shift: 1000);

        public ConfigItem StartTrackTime = new ConfigItem(
            300, new ConfigIndex("P4-07"),
            "启动转速跟踪时间（0.0~10.0s）",
            ReadOnly.WhenRuning, shift: 10);

        public ConfigItem StopMode = new ConfigItem(
            0, new ConfigIndex("P4-08"),
            "停机方式：0减速停机，1自由停机",
            ReadOnly.WhenRuning);

        public ConfigItem StopBrakeFreq = new ConfigItem(
            0, new ConfigIndex("P4-09"),
            "停机制动频率（0.00~10.00Hz）",
            ReadOnly.WhenRuning, shift: 100);

        public ConfigItem StopBrakeCurrent = new ConfigItem(
            80, new ConfigIndex("P4-10"),
            "停机制动电流（0~100%）",
            ReadOnly.WhenRuning, shift: 1000);

        public ConfigItem StopBrakeHoldTime = new ConfigItem(
            0, new ConfigIndex("P4-11"),
            "停机制动维持时间（0.0~60.0s）",
            ReadOnly.WhenRuning, shift: 10);

        public ConfigItem ReverseDeadTime = new ConfigItem(
            0, new ConfigIndex("P4-12"),
            "正反转死区时间（0.0~600.0s）",
            ReadOnly.WhenRuning, shift: 10);

        public ConfigItem ZeroHzVoltageMode = new ConfigItem(
            1, new ConfigIndex("P4-13"),
            "0Hz电压输出选择：0有电压输出，1无电压输出",
            ReadOnly.WhenRuning);

        #endregion

        #region P5组 启停调整参数组

        public ConfigItem AccDecTimeUnit = new ConfigItem(
            1, new ConfigIndex("P5-00"),
            "加减速时间单位：0=1s，1=0.1s，2=0.01s",
            ReadOnly.WhenRuning);

        public ConfigItem AccDecMode = new ConfigItem(
            0, new ConfigIndex("P5-01"),
            "加减速方式：0直线加减速，1分段加减速",
            ReadOnly.Never);

        public ConfigItem AccTime1 = new ConfigItem(
            0, new ConfigIndex("P5-02"),
            "加速时间1（机型确定）",
            ReadOnly.Never, shift: 10);

        public ConfigItem DecTime1 = new ConfigItem(
            0, new ConfigIndex("P5-03"),
            "减速时间1（机型确定）",
            ReadOnly.Never, shift: 10);

        public ConfigItem AccTime2 = new ConfigItem(
            0, new ConfigIndex("P5-04"),
            "加速时间2（机型确定）",
            ReadOnly.Never, shift: 10);

        public ConfigItem DecTime2 = new ConfigItem(
            0, new ConfigIndex("P5-05"),
            "减速时间2（机型确定）",
            ReadOnly.Never, shift: 10);

        public ConfigItem AccTime3 = new ConfigItem(
            0, new ConfigIndex("P5-06"),
            "加速时间3（机型确定）",
            ReadOnly.Never, shift: 10);

        public ConfigItem DecTime3 = new ConfigItem(
            0, new ConfigIndex("P5-07"),
            "减速时间3（机型确定）",
            ReadOnly.Never, shift: 10);

        public ConfigItem AccTurnFreq1 = new ConfigItem(
            0, new ConfigIndex("P5-08"),
            "加速转折频率1（0~上限频率）",
            ReadOnly.Never, shift: 100);

        public ConfigItem AccTurnFreq2 = new ConfigItem(
            0, new ConfigIndex("P5-09"),
            "加速转折频率2（0~上限频率）",
            ReadOnly.Never, shift: 100);

        public ConfigItem AccTurnFreq3 = new ConfigItem(
            0, new ConfigIndex("P5-10"),
            "加速转折频率3（0~上限频率）",
            ReadOnly.Never, shift: 100);

        public ConfigItem DecTurnFreq1 = new ConfigItem(
            0, new ConfigIndex("P5-11"),
            "减速转折频率1（0~上限频率）",
            ReadOnly.Never, shift: 100);

        public ConfigItem DecTurnFreq2 = new ConfigItem(
            0, new ConfigIndex("P5-12"),
            "减速转折频率2（0~上限频率）",
            ReadOnly.Never, shift: 100);

        public ConfigItem DecTurnFreq3 = new ConfigItem(
            0, new ConfigIndex("P5-13"),
            "减速转折频率3（0~上限频率）",
            ReadOnly.Never, shift: 100);

        public ConfigItem JogFreq = new ConfigItem(
            500, new ConfigIndex("P5-14"),
            "点动频率（0~上限频率）",
            ReadOnly.Never, shift: 100);

        public ConfigItem JogAccTime = new ConfigItem(
            0, new ConfigIndex("P5-15"),
            "点动加速时间（机型确定）",
            ReadOnly.Never, shift: 10);

        public ConfigItem JogDecTime = new ConfigItem(
            0, new ConfigIndex("P5-16"),
            "点动减速时间（机型确定）",
            ReadOnly.Never, shift: 10);

        public ConfigItem JumpFreq1_Upper = new ConfigItem(
            0, new ConfigIndex("P5-17"),
            "跳跃频率1上限（0~600Hz）",
            ReadOnly.Never, shift: 100);

        public ConfigItem JumpFreq1_Lower = new ConfigItem(
            0, new ConfigIndex("P5-18"),
            "跳跃频率1下限（0~600Hz）",
            ReadOnly.Never, shift: 100);

        public ConfigItem JumpFreq2_Upper = new ConfigItem(
            0, new ConfigIndex("P5-19"),
            "跳跃频率2上限（0~600Hz）",
            ReadOnly.Never, shift: 100);

        public ConfigItem JumpFreq2_Lower = new ConfigItem(
            0, new ConfigIndex("P5-20"),
            "跳跃频率2下限（0~600Hz）",
            ReadOnly.Never, shift: 100);

        public ConfigItem JumpFreq3_Upper = new ConfigItem(
            0, new ConfigIndex("P5-21"),
            "跳跃频率3上限（0~600Hz）",
            ReadOnly.Never, shift: 100);

        public ConfigItem JumpFreq3_Lower = new ConfigItem(
            0, new ConfigIndex("P5-22"),
            "跳跃频率3下限（0~600Hz）",
            ReadOnly.Never, shift: 100);

        #endregion

        #region P6组 端子输入参数组
        // P6-00 端子配置
        public ConfigItem TerminalConfig = new ConfigItem(
            0,
            new ConfigIndex("P6-00"),
            "端子配置\n范围：00~13\n十位：X6端子PFI功能配置（0=数字量输入，1=高速脉冲输入）\n个位：端子命令模式（0=2线式1，1=2线式2，2=3线式1，3=3线式2）\n注：个位模式仅在P0-07=1时有效。",
            ReadOnly.WhenRuning);

        // P6-01 X1端子功能
        public ConfigItem X1Function = new ConfigItem(
            3,
            new ConfigIndex("P6-01"),
            "X1端子功能定义，范围：0~50",
            ReadOnly.WhenRuning);

        // P6-02 X2端子功能
        public ConfigItem X2Function = new ConfigItem(
            4,
            new ConfigIndex("P6-02"),
            "X2端子功能定义，范围：0~50",
            ReadOnly.WhenRuning);

        // P6-03 X3端子功能
        public ConfigItem X3Function = new ConfigItem(
            5,
            new ConfigIndex("P6-03"),
            "X3端子功能定义，范围：0~50",
            ReadOnly.WhenRuning);

        // P6-04 X4端子功能
        public ConfigItem X4Function = new ConfigItem(
            0,
            new ConfigIndex("P6-04"),
            "X4端子功能定义，范围：0~50",
            ReadOnly.WhenRuning);

        // P6-05 X5端子功能
        public ConfigItem X5Function = new ConfigItem(
            0,
            new ConfigIndex("P6-05"),
            "X5端子功能定义，范围：0~50",
            ReadOnly.WhenRuning);

        // P6-06 X6端子功能
        public ConfigItem X6Function = new ConfigItem(
            0,
            new ConfigIndex("P6-06"),
            "X6端子功能定义，范围：0~50",
            ReadOnly.WhenRuning);

        // P6-07 AI1端子功能
        public ConfigItem AI1Function = new ConfigItem(
            0,
            new ConfigIndex("P6-07"),
            "AI1端子功能定义，范围：0~50",
            ReadOnly.WhenRuning);

        // P6-08 AI2端子功能
        public ConfigItem AI2Function = new ConfigItem(
            0,
            new ConfigIndex("P6-08"),
            "AI2端子功能定义，范围：0~50",
            ReadOnly.WhenRuning);

        // P6-09 有效输入电平1
        public ConfigItem InputLevel1 = new ConfigItem(
            0,
            new ConfigIndex("P6-09"),
            "端子有效电平极性（X1~X4），范围：0000~1111\n0=低有效，1=高有效",
            ReadOnly.WhenRuning);

        // P6-10 有效输入电平2
        public ConfigItem InputLevel2 = new ConfigItem(
            1100,
            new ConfigIndex("P6-10"),
            "端子有效电平极性（X5/X6/AI1/AI2），范围：0000~1111\n0=低有效，1=高有效",
            ReadOnly.WhenRuning);

        // P6-11 端子滤波时间
        public ConfigItem TerminalFilterTime = new ConfigItem(
            0.000f,
            new ConfigIndex("P6-11"),
            "X1~X6、AI1~AI2滤波时间，范围：0.000~1.000s",
            ReadOnly.Never, shift: 1000);

        // P6-12 X1输入延时
        public ConfigItem X1Delay = new ConfigItem(
            0.000f,
            new ConfigIndex("P6-12"),
            "X1输入延迟响应时间，范围：0.000~1.000s",
            ReadOnly.WhenRuning, shift: 1000);

        // P6-13 X2输入延时
        public ConfigItem X2Delay = new ConfigItem(
            0.000f,
            new ConfigIndex("P6-13"),
            "X2输入延迟响应时间，范围：0.000~1.000s",
            ReadOnly.WhenRuning, shift: 1000);

        // P6-14 AI1增益
        public ConfigItem AI1Gain = new ConfigItem(
            1f,
            new ConfigIndex("P6-14"),
            "AI1增益校正，范围：0.0%~200.0%",
            ReadOnly.Never, shift: 1000);

        // P6-15 AI1偏置
        public ConfigItem AI1Offset = new ConfigItem(
            0f,
            new ConfigIndex("P6-15"),
            "AI1偏置校正，范围：-10.00~10.00V",
            ReadOnly.Never, shift: 100);

        // P6-16 AI1滤波时间
        public ConfigItem AI1Filter = new ConfigItem(
            0.020f,
            new ConfigIndex("P6-16"),
            "AI1滤波时间，范围：0.000~1.000s",
            ReadOnly.Never, shift: 1000);

        // P6-17 AI1曲线选择
        public ConfigItem AI1CurveSelect = new ConfigItem(
            0,
            new ConfigIndex("P6-17"),
            "AI1曲线选择：0=两点曲线，1=多点曲线",
            ReadOnly.Never);

        // P6-18 AI1输入点1
        public ConfigItem AI1Point1 = new ConfigItem(
            0.00f,
            new ConfigIndex("P6-18"),
            "AI1输入点1，范围：0.00~10.00V",
            ReadOnly.Never, shift: 100);

        // P6-19 AI1输入点1设定
        public ConfigItem AI1Point1Set = new ConfigItem(
            0f,
            new ConfigIndex("P6-19"),
            "AI1输入点1设定，范围：0.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P6-20 AI1输入点2
        public ConfigItem AI1Point2 = new ConfigItem(
            10.00f,
            new ConfigIndex("P6-20"),
            "AI1输入点2，范围：0.00~10.00V",
            ReadOnly.Never, shift: 100);

        // P6-21 AI1输入点2设定
        public ConfigItem AI1Point2Set = new ConfigItem(
            1f,
            new ConfigIndex("P6-21"),
            "AI1输入点2设定，范围：0.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P6-22 AI2增益
        public ConfigItem AI2Gain = new ConfigItem(
            1f,
            new ConfigIndex("P6-22"),
            "AI2增益校正，范围：0.0%~200.0%",
            ReadOnly.Never, shift: 1000);

        // P6-23 AI2偏置
        public ConfigItem AI2Offset = new ConfigItem(
            0f,
            new ConfigIndex("P6-23"),
            "AI2偏置校正，范围：-10.00~10.00V",
            ReadOnly.Never, shift: 100);

        // P6-24 AI2滤波时间
        public ConfigItem AI2Filter = new ConfigItem(
            0.020f,
            new ConfigIndex("P6-24"),
            "AI2滤波时间，范围：0.000~1.000s",
            ReadOnly.Never, shift: 1000);

        // P6-25 AI2曲线选择
        public ConfigItem AI2CurveSelect = new ConfigItem(
            0,
            new ConfigIndex("P6-25"),
            "AI2曲线选择：0=两点曲线，1=多点曲线",
            ReadOnly.Never);

        // P6-26 AI2输入点1
        public ConfigItem AI2Point1 = new ConfigItem(
            0.00f,
            new ConfigIndex("P6-26"),
            "AI2输入点1，范围：0.00~10.00V",
            ReadOnly.Never, shift: 100);

        // P6-27 AI2输入点1设定
        public ConfigItem AI2Point1Set = new ConfigItem(
            0f,
            new ConfigIndex("P6-27"),
            "AI2输入点1设定，范围：0.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P6-28 AI2输入点2
        public ConfigItem AI2Point2 = new ConfigItem(
            10.00f,
            new ConfigIndex("P6-28"),
            "AI2输入点2，范围：0.00~10.00V",
            ReadOnly.Never, shift: 100);

        // P6-29 AI2输入点2设定
        public ConfigItem AI2Point2Set = new ConfigItem(
            1f,
            new ConfigIndex("P6-29"),
            "AI2输入点2设定，范围：0.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P6-30 PFI滤波时间
        public ConfigItem PFIFilter = new ConfigItem(
            0.000f,
            new ConfigIndex("P6-30"),
            "高速脉冲输入滤波时间，范围：0.000~1.000s",
            ReadOnly.Never, shift: 1000);

        // P6-31 PFI下限输入
        public ConfigItem PFILow = new ConfigItem(
            0.00f,
            new ConfigIndex("P6-31"),
            "PFI下限输入，范围：0.00~50.00kHz",
            ReadOnly.Never, shift: 100);

        // P6-32 PFI下限对应设定
        public ConfigItem PFILowSet = new ConfigItem(
            0f,
            new ConfigIndex("P6-32"),
            "PFI下限对应设定，范围：0.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P6-33 PFI上限输入
        public ConfigItem PFIHigh = new ConfigItem(
            50.00f,
            new ConfigIndex("P6-33"),
            "PFI上限输入，范围：0.00~50.00kHz",
            ReadOnly.Never, shift: 100);

        // P6-34 PFI上限对应设定
        public ConfigItem PFIHighSet = new ConfigItem(
            1f,
            new ConfigIndex("P6-34"),
            "PFI上限对应设定，范围：0.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        #endregion

        #region P7组 端子输出参数组
        // P7-00 PFO端子使能
        public ConfigItem PFOEnable = new ConfigItem(
            0,
            new ConfigIndex("P7-00"),
            "PFO端子使能：0=开路集电极输出，1=高速脉冲输出功能",
            ReadOnly.Never);

        // P7-01 Y1端子功能
        public ConfigItem Y1Function = new ConfigItem(
            2,
            new ConfigIndex("P7-01"),
            "Y1端子功能选择，范围：0~50",
            ReadOnly.Never);

        // P7-02 Y2端子功能
        public ConfigItem Y2Function = new ConfigItem(
            0,
            new ConfigIndex("P7-02"),
            "Y2端子功能选择，范围：0~50",
            ReadOnly.Never);

        // P7-03 R端子功能
        public ConfigItem RFunction = new ConfigItem(
            3,
            new ConfigIndex("P7-03"),
            "继电器R端子功能选择，范围：0~50",
            ReadOnly.Never);

        // P7-04 有效输出电平
        public ConfigItem OutputLevel = new ConfigItem(
            0,
            new ConfigIndex("P7-04"),
            "有效输出电平极性，范围：0000~1111\n0=低有效，1=高有效",
            ReadOnly.Never);

        // P7-05 Y1输出延时
        public ConfigItem Y1Delay = new ConfigItem(
            0.000f,
            new ConfigIndex("P7-05"),
            "Y1输出延迟时间，范围：0.000~60.000s",
            ReadOnly.Never, shift: 1000);

        // P7-06 Y2输出延时
        public ConfigItem Y2Delay = new ConfigItem(
            0.000f,
            new ConfigIndex("P7-06"),
            "Y2输出延迟时间，范围：0.000~60.000s",
            ReadOnly.Never, shift: 1000);

        // P7-07 R输出延时
        public ConfigItem RDelay = new ConfigItem(
            0.000f,
            new ConfigIndex("P7-07"),
            "继电器R输出延迟时间，范围：0.000~60.000s",
            ReadOnly.Never, shift: 1000);

        // P7-08 AO1输出功能
        public ConfigItem AO1Function = new ConfigItem(
            1,
            new ConfigIndex("P7-08"),
            "AO1模拟量输出功能选择，范围：0~99",
            ReadOnly.Never);

        // P7-09 AO1增益
        public ConfigItem AO1Gain = new ConfigItem(
            1f,
            new ConfigIndex("P7-09"),
            "AO1输出增益校正，范围：-200.0%~200.0%",
            ReadOnly.Never, shift: 1000);

        // P7-10 AO1偏置
        public ConfigItem AO1Offset = new ConfigItem(
            0f,
            new ConfigIndex("P7-10"),
            "AO1输出偏置校正，范围：-10.00~10.00V",
            ReadOnly.Never, shift: 100);

        // P7-11 AO1输出滤波时间
        public ConfigItem AO1Filter = new ConfigItem(
            0.000f,
            new ConfigIndex("P7-11"),
            "AO1输出滤波时间，范围：0.000~10.000s",
            ReadOnly.Never, shift: 1000);

        // P7-12 PFO输出功能
        public ConfigItem PFOFunction = new ConfigItem(
            0,
            new ConfigIndex("P7-12"),
            "PFO脉冲输出功能选择，范围：0~99",
            ReadOnly.Never);

        // P7-13 PFO输出滤波时间
        public ConfigItem PFOFilter = new ConfigItem(
            0.000f,
            new ConfigIndex("P7-13"),
            "PFO输出滤波时间，范围：0.000~10.000s",
            ReadOnly.Never, shift: 1000);

        // P7-14 PFO下限值
        public ConfigItem PFOLow = new ConfigItem(
            0.00f,
            new ConfigIndex("P7-14"),
            "PFO下限频率，范围：0.00~50.00kHz",
            ReadOnly.Never, shift: 100);

        // P7-15 PFO下限值设定
        public ConfigItem PFOLowSet = new ConfigItem(
            0f,
            new ConfigIndex("P7-15"),
            "PFO下限对应设定，范围：0.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P7-16 PFO上限值
        public ConfigItem PFOHigh = new ConfigItem(
            50.00f,
            new ConfigIndex("P7-16"),
            "PFO上限频率，范围：0.00~50.00kHz",
            ReadOnly.Never, shift: 100);

        // P7-17 PFO上限值设定
        public ConfigItem PFOHighSet = new ConfigItem(
            1f,
            new ConfigIndex("P7-17"),
            "PFO上限对应设定，范围：0.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        #endregion

        #region P8组 多段指令组

        // P8-00 多段指令0
        public ConfigItem MultiStep0 = new ConfigItem(
            0f,
            new ConfigIndex("P8-00"),
            "多段指令0，范围：-100.0%~100.0%（相对于最大频率）",
            ReadOnly.Never, shift: 1000);

        // P8-01 多段指令1
        public ConfigItem MultiStep1 = new ConfigItem(
            0f,
            new ConfigIndex("P8-01"),
            "多段指令1，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-02 多段指令2
        public ConfigItem MultiStep2 = new ConfigItem(
            0f,
            new ConfigIndex("P8-02"),
            "多段指令2，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-03 多段指令3
        public ConfigItem MultiStep3 = new ConfigItem(
            0f,
            new ConfigIndex("P8-03"),
            "多段指令3，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-04 多段指令4
        public ConfigItem MultiStep4 = new ConfigItem(
            0f,
            new ConfigIndex("P8-04"),
            "多段指令4，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-05 多段指令5
        public ConfigItem MultiStep5 = new ConfigItem(
            0f,
            new ConfigIndex("P8-05"),
            "多段指令5，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-06 多段指令6
        public ConfigItem MultiStep6 = new ConfigItem(
            0f,
            new ConfigIndex("P8-06"),
            "多段指令6，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-07 多段指令7
        public ConfigItem MultiStep7 = new ConfigItem(
            0f,
            new ConfigIndex("P8-07"),
            "多段指令7，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-08 多段指令8
        public ConfigItem MultiStep8 = new ConfigItem(
            0f,
            new ConfigIndex("P8-08"),
            "多段指令8，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-09 多段指令9
        public ConfigItem MultiStep9 = new ConfigItem(
            0f,
            new ConfigIndex("P8-09"),
            "多段指令9，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-10 多段指令10
        public ConfigItem MultiStep10 = new ConfigItem(
            0f,
            new ConfigIndex("P8-10"),
            "多段指令10，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-11 多段指令11
        public ConfigItem MultiStep11 = new ConfigItem(
            0f,
            new ConfigIndex("P8-11"),
            "多段指令11，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-12 多段指令12
        public ConfigItem MultiStep12 = new ConfigItem(
            0f,
            new ConfigIndex("P8-12"),
            "多段指令12，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-13 多段指令13
        public ConfigItem MultiStep13 = new ConfigItem(
            0f,
            new ConfigIndex("P8-13"),
            "多段指令13，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-14 多段指令14
        public ConfigItem MultiStep14 = new ConfigItem(
            0f,
            new ConfigIndex("P8-14"),
            "多段指令14，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-15 多段指令15
        public ConfigItem MultiStep15 = new ConfigItem(
            0f,
            new ConfigIndex("P8-15"),
            "多段指令15，范围：-100.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // P8-16 多段指令0设定源
        public ConfigItem MultiStep0Source = new ConfigItem(
            0,
            new ConfigIndex("P8-16"),
            "多段指令0设定源，范围：0~5\n0=数字参考\n1=AI1\n2=AI2\n3=PFI\n4=PID\n5=通讯",
            ReadOnly.Never);

        // P8-17 多段指令1设定源
        public ConfigItem MultiStep1Source = new ConfigItem(
            0,
            new ConfigIndex("P8-17"),
            "多段指令1设定源，范围：0~5\n0=数字参考\n1=AI1\n2=AI2\n3=PFI\n4=PID\n5=通讯",
            ReadOnly.Never);

        #endregion

        #region P9组 简易PLC组

        // P9-00 PLC配置
        public ConfigItem PLCConfig = new ConfigItem(
            0,
            new ConfigIndex("P9-00"),
            "PLC配置，范围：0000~1112\n千位：时间精度（0=秒，1=分）\n百位：停机再启动（0=不记忆，1=记忆）\n十位：异常再启动（0=从第0段，1=从中断点）\n个位：模式（0=单次运行，1=保持最终值，2=连续循环）",
            ReadOnly.WhenRuning);

        // P9-01 PLC第0段配置
        public ConfigItem PLCStep0Config = new ConfigItem(
            0,
            new ConfigIndex("P9-01"),
            "PLC第0段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-02 PLC第0段时间
        public ConfigItem PLCStep0Time = new ConfigItem(
            10f,
            new ConfigIndex("P9-02"),
            "PLC第0段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-03 PLC第1段配置
        public ConfigItem PLCStep1Config = new ConfigItem(
            0,
            new ConfigIndex("P9-03"),
            "PLC第1段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-04 PLC第1段时间
        public ConfigItem PLCStep1Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-04"),
            "PLC第1段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-05 PLC第2段配置
        public ConfigItem PLCStep2Config = new ConfigItem(
            0,
            new ConfigIndex("P9-05"),
            "PLC第2段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-06 PLC第2段时间
        public ConfigItem PLCStep2Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-06"),
            "PLC第2段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-07 PLC第3段配置
        public ConfigItem PLCStep3Config = new ConfigItem(
            0,
            new ConfigIndex("P9-07"),
            "PLC第3段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-08 PLC第3段时间
        public ConfigItem PLCStep3Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-08"),
            "PLC第3段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-09 PLC第4段配置
        public ConfigItem PLCStep4Config = new ConfigItem(
            0,
            new ConfigIndex("P9-09"),
            "PLC第4段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-10 PLC第4段时间
        public ConfigItem PLCStep4Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-10"),
            "PLC第4段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-11 PLC第5段配置
        public ConfigItem PLCStep5Config = new ConfigItem(
            0,
            new ConfigIndex("P9-11"),
            "PLC第5段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-12 PLC第5段时间
        public ConfigItem PLCStep5Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-12"),
            "PLC第5段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-13 PLC第6段配置
        public ConfigItem PLCStep6Config = new ConfigItem(
            0,
            new ConfigIndex("P9-13"),
            "PLC第6段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-14 PLC第6段时间
        public ConfigItem PLCStep6Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-14"),
            "PLC第6段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-15 PLC第7段配置
        public ConfigItem PLCStep7Config = new ConfigItem(
            0,
            new ConfigIndex("P9-15"),
            "PLC第7段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-16 PLC第7段时间
        public ConfigItem PLCStep7Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-16"),
            "PLC第7段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-17 PLC第8段配置
        public ConfigItem PLCStep8Config = new ConfigItem(
            0,
            new ConfigIndex("P9-17"),
            "PLC第8段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-18 PLC第8段时间
        public ConfigItem PLCStep8Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-18"),
            "PLC第8段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-19 PLC第9段配置
        public ConfigItem PLCStep9Config = new ConfigItem(
            0,
            new ConfigIndex("P9-19"),
            "PLC第9段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-20 PLC第9段时间
        public ConfigItem PLCStep9Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-20"),
            "PLC第9段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-21 PLC第10段配置
        public ConfigItem PLCStep10Config = new ConfigItem(
            0,
            new ConfigIndex("P9-21"),
            "PLC第10段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-22 PLC第10段时间
        public ConfigItem PLCStep10Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-22"),
            "PLC第10段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-23 PLC第11段配置
        public ConfigItem PLCStep11Config = new ConfigItem(
            0,
            new ConfigIndex("P9-23"),
            "PLC第11段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-24 PLC第11段时间
        public ConfigItem PLCStep11Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-24"),
            "PLC第11段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-25 PLC第12段配置
        public ConfigItem PLCStep12Config = new ConfigItem(
            0,
            new ConfigIndex("P9-25"),
            "PLC第12段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-26 PLC第12段时间
        public ConfigItem PLCStep12Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-26"),
            "PLC第12段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-27 PLC第13段配置
        public ConfigItem PLCStep13Config = new ConfigItem(
            0,
            new ConfigIndex("P9-27"),
            "PLC第13段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-28 PLC第13段时间
        public ConfigItem PLCStep13Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-28"),
            "PLC第13段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-29 PLC第14段配置
        public ConfigItem PLCStep14Config = new ConfigItem(
            0,
            new ConfigIndex("P9-29"),
            "PLC第14段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-30 PLC第14段时间
        public ConfigItem PLCStep14Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-30"),
            "PLC第14段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        // P9-31 PLC第15段配置
        public ConfigItem PLCStep15Config = new ConfigItem(
            0,
            new ConfigIndex("P9-31"),
            "PLC第15段加减速时间选择，范围：0~3",
            ReadOnly.Never);

        // P9-32 PLC第15段时间
        public ConfigItem PLCStep15Time = new ConfigItem(
            0f,
            new ConfigIndex("P9-32"),
            "PLC第15段运行时间，范围：0.0~6500.0s(min)",
            ReadOnly.Never, shift: 10);

        #endregion

        #region PA组 通用PID控制组

        // PA-00 PID控制策略
        public ConfigItem PIDStrategy = new ConfigItem(
            0,
            new ConfigIndex("PA-00"),
            "PID控制策略：0=不启用，1=闭环频率调节",
            ReadOnly.Never);

        // PA-01 PID给定源
        public ConfigItem PIDSetpointSource = new ConfigItem(
            0,
            new ConfigIndex("PA-01"),
            "PID给定源：0=数字设定，1=AI1，2=AI2，3=PFI，4=通讯，5=多段指令",
            ReadOnly.Never);

        // PA-02 PID数字给定
        public ConfigItem PIDDigitalSetpoint = new ConfigItem(
            0.5f,
            new ConfigIndex("PA-02"),
            "PID数字给定，范围：0.00%~100.00%",
            ReadOnly.Never, shift: 1000);

        // PA-03 PID反馈源
        public ConfigItem PIDFeedbackSource = new ConfigItem(
            0,
            new ConfigIndex("PA-03"),
            "PID反馈源：0=AI1，1=AI2，2=PFI，3=通讯",
            ReadOnly.Never);

        // PA-04 PID作用方向
        public ConfigItem PIDDirection = new ConfigItem(
            0,
            new ConfigIndex("PA-04"),
            "PID作用方向：0=正向作用，1=反向作用",
            ReadOnly.Never);

        // PA-05 采样周期T
        public ConfigItem PIDSampleTime = new ConfigItem(
            0.010f,
            new ConfigIndex("PA-05"),
            "PID采样周期，范围：0.000~10.000s",
            ReadOnly.Never, shift: 1000);

        // PA-06 比例增益Kp1
        public ConfigItem PIDKp1 = new ConfigItem(
            2f,
            new ConfigIndex("PA-06"),
            "PID比例增益1，范围：0.0~100.0",
            ReadOnly.Never, shift: 10);

        // PA-07 积分时间Ti1
        public ConfigItem PIDTi1 = new ConfigItem(
            1.00f,
            new ConfigIndex("PA-07"),
            "PID积分时间1，范围：0.01~10.00s",
            ReadOnly.Never, shift: 100);

        // PA-08 微分时间Td1
        public ConfigItem PIDTd1 = new ConfigItem(
            0.000f,
            new ConfigIndex("PA-08"),
            "PID微分时间1，范围：0.000~10.000s",
            ReadOnly.Never, shift: 1000);

        // PA-09 偏差极限
        public ConfigItem PIDBiasLimit = new ConfigItem(
            0f,
            new ConfigIndex("PA-09"),
            "PID偏差极限，范围：0.00%~100.00%",
            ReadOnly.Never, shift: 10000);

        // PA-10 微分滤波时间
        public ConfigItem PIDDerivativeFilter = new ConfigItem(
            0.000f,
            new ConfigIndex("PA-10"),
            "PID微分滤波时间，范围：0.000~10.000s",
            ReadOnly.Never, shift: 1000);

        // PA-11 给定变化时间
        public ConfigItem PIDSetpointRamp = new ConfigItem(
            0.00f,
            new ConfigIndex("PA-11"),
            "PID给定变化时间，范围：0.00~650.00s",
            ReadOnly.Never, shift: 100);

        // PA-12 反馈滤波时间
        public ConfigItem PIDFeedbackFilter = new ConfigItem(
            0.00f,
            new ConfigIndex("PA-12"),
            "PID反馈滤波时间，范围：0.00~60.00s",
            ReadOnly.Never, shift: 100);

        // PA-13 输出滤波时间
        public ConfigItem PIDOutputFilter = new ConfigItem(
            0.00f,
            new ConfigIndex("PA-13"),
            "PID输出滤波时间，范围：0.00~60.00s",
            ReadOnly.Never, shift: 100);

        // PA-14 比例增益Kp2
        public ConfigItem PIDKp2 = new ConfigItem(
            2f,
            new ConfigIndex("PA-14"),
            "PID比例增益2，范围：0.0~100.0",
            ReadOnly.Never, shift: 10);

        // PA-15 积分时间Ti2
        public ConfigItem PIDTi2 = new ConfigItem(
            1.00f,
            new ConfigIndex("PA-15"),
            "PID积分时间2，范围：0.01~10.00s",
            ReadOnly.Never, shift: 100);

        // PA-16 微分时间Td2
        public ConfigItem PIDTd2 = new ConfigItem(
            0.000f,
            new ConfigIndex("PA-16"),
            "PID微分时间2，范围：0.000~10.000s",
            ReadOnly.Never, shift: 1000);

        // PA-17 PID参数切换
        public ConfigItem PIDParamSwitch = new ConfigItem(
            0,
            new ConfigIndex("PA-17"),
            "PID参数切换：0=不切换，1=X端子切换，2=偏差自动切换，3=运行频率切换",
            ReadOnly.Never);

        // PA-18 参数切换偏差1
        public ConfigItem PIDSwitchBias1 = new ConfigItem(
            0f,
            new ConfigIndex("PA-18"),
            "PID参数切换偏差1，范围：0.00%~PA-19",
            ReadOnly.Never, shift: 10000);

        // PA-19 参数切换偏差2
        public ConfigItem PIDSwitchBias2 = new ConfigItem(
            0f,
            new ConfigIndex("PA-19"),
            "PID参数切换偏差2，范围：PA-18~100.0%",
            ReadOnly.Never, shift: 1000);

        // PA-20 PID初值
        public ConfigItem PIDInitialValue = new ConfigItem(
            0f,
            new ConfigIndex("PA-20"),
            "PID初值，范围：0.00%~100.00%",
            ReadOnly.Never, shift: 10000);

        // PA-21 PID初值保持时间
        public ConfigItem PIDInitialHold = new ConfigItem(
            0.00f,
            new ConfigIndex("PA-21"),
            "PID初值保持时间，范围：0.00~650.00s",
            ReadOnly.Never, shift: 100);

        // PA-22 PID积分属性
        public ConfigItem PIDIntegralMode = new ConfigItem(
            1,
            new ConfigIndex("PA-22"),
            "PID积分属性：0=继续积分，1=停止积分",
            ReadOnly.Never);

        // PA-23 反馈丢失值
        public ConfigItem PIDFeedbackLossValue = new ConfigItem(
            0f,
            new ConfigIndex("PA-23"),
            "PID反馈丢失检测值，范围：0.00%~100.00%",
            ReadOnly.Never, shift: 10000);

        // PA-24 反馈丢失检测时间
        public ConfigItem PIDFeedbackLossTime = new ConfigItem(
            0.0f,
            new ConfigIndex("PA-24"),
            "PID反馈丢失检测时间，范围：0.0~20.0s",
            ReadOnly.Never, shift: 10);

        // PA-25 反馈超限值
        public ConfigItem PIDFeedbackHighValue = new ConfigItem(
            0f,
            new ConfigIndex("PA-25"),
            "PID反馈超限检测值，范围：0.00%~100.00%",
            ReadOnly.Never, shift: 10000);

        // PA-26 反馈超限检测时间
        public ConfigItem PIDFeedbackHighTime = new ConfigItem(
            0.0f,
            new ConfigIndex("PA-26"),
            "PID反馈超限检测时间，范围：0.0~20.0s",
            ReadOnly.Never, shift: 10);

        // PA-27 PID停机运算
        public ConfigItem PIDStopOperation = new ConfigItem(
            0,
            new ConfigIndex("PA-27"),
            "PID停机后是否继续运算：0=不运算，1=运算",
            ReadOnly.Never);

        // PA-28 稳定与响应优先
        public ConfigItem PIDStabilityResponse = new ConfigItem(
            10,
            new ConfigIndex("PA-28"),
            "PID稳定/响应优先：十位=过调抑制，个位=稳定/响应优先",
            ReadOnly.Never);

        // PA-29 PID上限定值
        public ConfigItem PIDUpperLimit = new ConfigItem(
            1f,
            new ConfigIndex("PA-29"),
            "PID输出上限，范围：PA-30~100.0%",
            ReadOnly.Never, shift: 1000);

        // PA-30 PID下限定值
        public ConfigItem PIDLowerLimit = new ConfigItem(
            0f,
            new ConfigIndex("PA-30"),
            "PID输出下限，范围：-100.0%~PA-29",
            ReadOnly.Never, shift: 1000);

        #endregion

        #region Pb组 摆频定长计数

        // Pb-00 摆频配置
        public ConfigItem SwingConfig = new ConfigItem(
            0,
            new ConfigIndex("Pb-00"),
            "摆频功能配置，范围：00~11\n十位：0=自动运行，1=手动投入\n个位：0=相对中心频率，1=相对最大频率",
            ReadOnly.Never);

        // Pb-01 摆频幅度
        public ConfigItem SwingAmplitude = new ConfigItem(
            0f,
            new ConfigIndex("Pb-01"),
            "摆频幅度，范围：0.0%~100.0%（基准由Pb-00决定）",
            ReadOnly.Never, shift: 1000);

        // Pb-02 突跳频率幅度
        public ConfigItem SwingJump = new ConfigItem(
            0f,
            new ConfigIndex("Pb-02"),
            "突跳频率幅度，范围：0.0%~50.0%（相对于摆幅）",
            ReadOnly.Never, shift: 1000);

        // Pb-03 摆频周期
        public ConfigItem SwingPeriod = new ConfigItem(
            10.0f,
            new ConfigIndex("Pb-03"),
            "摆频周期，范围：0.0~6500.0s",
            ReadOnly.Never, shift: 10);

        // Pb-04 上升时间系数
        public ConfigItem SwingRiseFactor = new ConfigItem(
            0.5f,
            new ConfigIndex("Pb-04"),
            "摆频上升时间系数，范围：0.0%~100.0%",
            ReadOnly.Never, shift: 1000);

        // Pb-05 设定长度
        public ConfigItem LengthSet = new ConfigItem(
            1000f,
            new ConfigIndex("Pb-05"),
            "定长控制设定长度，范围：0~65000m",
            ReadOnly.Never);

        // Pb-06 实际长度（只读）
        public ConfigItem LengthActual = new ConfigItem(
            0f,
            new ConfigIndex("Pb-06"),
            "实际长度（只读）",
            ReadOnly.Always);

        // Pb-07 每米脉冲数
        public ConfigItem PulsePerMeter = new ConfigItem(
            1f,
            new ConfigIndex("Pb-07"),
            "每米脉冲数，范围：0.1~6500.0",
            ReadOnly.Never, shift: 10);

        // Pb-08 设定计数值
        public ConfigItem CountSet = new ConfigItem(
            0,
            new ConfigIndex("Pb-08"),
            "设定计数值，范围：Pb-09~65000",
            ReadOnly.Never);

        // Pb-09 预置计数值
        public ConfigItem CountPreset = new ConfigItem(
            0,
            new ConfigIndex("Pb-09"),
            "预置计数值，范围：0~Pb-08",
            ReadOnly.Never);

        #endregion

        #region Pc组 Modbus通信组

        // PC-00 设备地址
        public ConfigItem DeviceAddress = new ConfigItem(
            1,
            new ConfigIndex("PC-00"),
            "Modbus设备地址，范围：1~247（0为广播地址）",
            ReadOnly.Never);

        // PC-01 通信配置
        public ConfigItem CommConfig = new ConfigItem(
            1,
            new ConfigIndex("PC-01"),
            "通信配置，范围：000~125\n百位：通信优化\n十位：数据格式（0=1-8-1-N，1=1-8-1-O，2=1-8-1-E）\n个位：波特率（0=4800，1=9600，2=19200，3=38400，4=57600，5=115200）",
            ReadOnly.WhenRuning);

        // PC-02 通信超时时间
        public ConfigItem CommTimeout = new ConfigItem(
            0.0f,
            new ConfigIndex("PC-02"),
            "通信超时时间，范围：0.0~600.0s",
            ReadOnly.Never, shift: 10);

        // PC-03 从站应答延时
        public ConfigItem SlaveResponseDelay = new ConfigItem(
            0.005f,
            new ConfigIndex("PC-03"),
            "从站应答延时，范围：0.000~1.000s",
            ReadOnly.Never, shift: 1000);

        // PC-04 主从选择
        public ConfigItem MasterSlaveMode = new ConfigItem(
            0,
            new ConfigIndex("PC-04"),
            "主从选择：0=单机，1=本机为从机，2=本机为主机",
            ReadOnly.Never);

        // PC-05 主机操作参数设置
        public ConfigItem MasterOperation = new ConfigItem(
            0,
            new ConfigIndex("PC-05"),
            "主机操作参数：0=发送运行命令+设定频率，1=发送运行命令+运行频率",
            ReadOnly.Never);

        // PC-06 主机通信周期
        public ConfigItem MasterCommPeriod = new ConfigItem(
            0.10f,
            new ConfigIndex("PC-06"),
            "主机广播帧发送周期，范围：0.00~60.00s",
            ReadOnly.Never, shift: 100);

        // PC-07 从机接收校正系数
        public ConfigItem SlaveReceiveFactor = new ConfigItem(
            1f,
            new ConfigIndex("PC-07"),
            "从机接收校正系数，范围：0.0%~200.0%",
            ReadOnly.Never, shift: 1000);

        #endregion

        #region Pd组 操作器控制组

        // Pd-00 MF键配置功能
        public ConfigItem MFKeyFunction = new ConfigItem(
            1,
            new ConfigIndex("Pd-00"),
            "MF按键功能配置，范围：0~6\n0=左移\n1=正转点动\n2=反转点动\n3=正反转切换\n4=紧急停机\n5=自由停机\n6=命令给定方式切换",
            ReadOnly.WhenRuning);

        // Pd-01 STOP/RST按键功能
        public ConfigItem StopResetFunction = new ConfigItem(
            1,
            new ConfigIndex("Pd-01"),
            "STOP/RST按键功能，范围：0~2\n0=仅面板控制有效\n1=复位按键一直有效\n2=STOP键始终有效",
            ReadOnly.WhenRuning);

        // Pd-02 停机显示选择
        public ConfigItem StopDisplaySelect = new ConfigItem(
            3,
            new ConfigIndex("Pd-02"),
            "停机显示选择，范围：0000~FFFF\n可显示：PID给定、PID反馈、AI1/AI2电压、母线电压、输入端子状态、输出端子状态等",
            ReadOnly.Never);

        // Pd-03 运行显示选择
        public ConfigItem RunDisplaySelect = new ConfigItem(
            0x001F,
            new ConfigIndex("Pd-03"),
            "运行显示选择，范围：0000~FFFF\n可显示：运行频率、设定频率、输出电压、电流、转矩、转速等",
            ReadOnly.Never);

        // Pd-04 自定义显示设置
        public ConfigItem CustomDisplayGroup = new ConfigItem(
            0,
            new ConfigIndex("Pd-04"),
            "自定义显示隶属组别，范围：0000~2222\n0=停机组\n1=运行组\n2=两组均属于",
            ReadOnly.Never);

        // Pd-05 自定义显示1
        public ConfigItem CustomDisplay1 = new ConfigItem(
            0,
            new ConfigIndex("Pd-05"),
            "自定义显示1，范围：0000~EFFF",
            ReadOnly.Never);

        // Pd-06 自定义显示2
        public ConfigItem CustomDisplay2 = new ConfigItem(
            0,
            new ConfigIndex("Pd-06"),
            "自定义显示2，范围：0000~EFFF",
            ReadOnly.Never);

        // Pd-07 自定义显示3
        public ConfigItem CustomDisplay3 = new ConfigItem(
            0,
            new ConfigIndex("Pd-07"),
            "自定义显示3，范围：0000~EFFF",
            ReadOnly.Never);

        // Pd-08 自定义显示4
        public ConfigItem CustomDisplay4 = new ConfigItem(
            0,
            new ConfigIndex("Pd-08"),
            "自定义显示4，范围：0000~EFFF",
            ReadOnly.Never);

        // Pd-09 拷贝动作选择
        public ConfigItem CopyAction = new ConfigItem(
            0,
            new ConfigIndex("Pd-09"),
            "拷贝动作：0=无动作，1=变频器→BOP，2=BOP→变频器",
            ReadOnly.Never);

        // Pd-10 用户密码设置
        public ConfigItem UserPassword = new ConfigItem(
            0,
            new ConfigIndex("Pd-10"),
            "用户密码设置（非0生效）",
            ReadOnly.Never);

        #endregion

        #region PE组 载波及失速控制组

        public ConfigItem EnergyBrakeEnable = new ConfigItem(
            0,
            new ConfigIndex("PE-00"),
            "能耗制动使能\n0：无效 1：有效\n若能耗制动使能，当母线电压高于PE-01设置的电压点时投入制动电阻，低于该值时切出。",
            ReadOnly.Never);

        public ConfigItem EnergyBrakeVoltage = new ConfigItem(
            690,
            new ConfigIndex("PE-01"),
            "能耗制动电压点\n范围：0~3000V\n使用能耗制动前需确认制动单元及电阻已正确安装。",
            ReadOnly.Never);

        public ConfigItem BrakeDutyStatistic = new ConfigItem(
            0,
            new ConfigIndex("PE-02"),
            "制动器开通率统计（1秒内累计投入百分比）\n范围：0.0%~100.0%\n>90% 时存在潜在过压风险。",
            ReadOnly.Always, shift: 1000);

        public ConfigItem OverVoltageStallSelect = new ConfigItem(
            11,
            new ConfigIndex("PE-03"),
            "过压失速选择\n十位：失速强度选择（0~F）\n个位：过压失速功能使能（0：关闭 1：使能）\n若使能，当母线电压高于PE-04设定点时进入失速处理。",
            ReadOnly.Never);

        public ConfigItem OverVoltageStallPoint = new ConfigItem(
            690,
            new ConfigIndex("PE-04"),
            "过压失速点设定\n范围：0~3000V",
            ReadOnly.Never);

        public ConfigItem PowerLossStallEnable = new ConfigItem(
            0,
            new ConfigIndex("PE-05"),
            "掉电失速使能\n0：关闭 1：使能\n利用电机惯量能量在掉电瞬间维持运行或平稳停机。",
            ReadOnly.Never);

        public ConfigItem PowerLossStallVoltage = new ConfigItem(
            450,
            new ConfigIndex("PE-06"),
            "掉电失速电压点\n范围：0~3000V",
            ReadOnly.Never);

        public ConfigItem PowerLossRecoverTime = new ConfigItem(
            20, // 2.0s → 以 0.1s 为单位存储时通常为 20，如你有固定格式可调整
            new ConfigIndex("PE-07"),
            "掉电失速恢复时间\n范围：0.0~10.0s",
            ReadOnly.Never, shift: 10);

        public ConfigItem PowerLossStallStrength = new ConfigItem(
            100,
            new ConfigIndex("PE-08"),
            "掉电失速强度\n范围：1~2000",
            ReadOnly.Never);

        public ConfigItem UnderVoltageFreqLimitEnable = new ConfigItem(
            0,
            new ConfigIndex("PE-09"),
            "欠压频率限定使能\n0：关闭 1：使能\n用于电网偏低时自动降低运行频率避免过流。",
            ReadOnly.Never);

        public ConfigItem BusUnderVoltagePoint = new ConfigItem(
            340,
            new ConfigIndex("PE-10"),
            "母线欠压点设定\n低于该值报欠压故障。",
            ReadOnly.Never);

        public ConfigItem BusOverVoltagePoint = new ConfigItem(
            750,
            new ConfigIndex("PE-11"),
            "母线过压点设定\n高于该值报过压故障。",
            ReadOnly.Never);

        #endregion

        #region PF组 故障保护组

        public ConfigItem MotorOverloadWarnValue = new ConfigItem(
            130,
            new ConfigIndex("PF-00"),
            "电机过载预警值（相对额定电流）\n范围：0.0%~300.0%\n当实际电流超过该值并持续 PF-01 时间后，按 PF-02 动作处理。",
            ReadOnly.Never);

        public ConfigItem MotorOverloadWarnTime = new ConfigItem(
            50, // 5.0s → 若系统以 0.1s 为单位存储，则为 50
            new ConfigIndex("PF-01"),
            "过载预警检出时间\n范围：0.0~600.0s",
            ReadOnly.Never, shift: 10);

        public ConfigItem MotorOverloadWarnAction = new ConfigItem(
            0,
            new ConfigIndex("PF-02"),
            "过载预警动作选择\n0：继续运行\n1：减速停机\n2：自由停机",
            ReadOnly.Never);

        public ConfigItem MotorOverloadTripValue = new ConfigItem(
            150,
            new ConfigIndex("PF-03"),
            "电机过载设定值（相对额定电流）\n范围：PF-00~300.0%\n超过该值并持续 PF-04 时间后报 E.OL2。",
            ReadOnly.Never);

        public ConfigItem MotorOverloadTripTime = new ConfigItem(
            50, // 5.0s
            new ConfigIndex("PF-04"),
            "电机过载检出时间\n范围：0.0~600.0s",
            ReadOnly.Never, shift: 10);

        public ConfigItem MotorTempChannel = new ConfigItem(
            0,
            new ConfigIndex("PF-05"),
            "电机温度通道选择\n十位：温度传感器类型（0：无 1：PT100 2：PT1000）\n个位：输入通道（0：无 1：AI1 2：AI2）",
            ReadOnly.Never);

        public ConfigItem MotorOverTempTrip = new ConfigItem(
            900, // 90.0℃
            new ConfigIndex("PF-06"),
            "电机过温设定值\n范围：PF-07~180.0℃\n达到该温度报 E.OH2。",
            ReadOnly.Never, shift: 10);
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public ConfigItem MotorOverTempWarnValue = new ConfigItem(
            750, // 75.0℃
            new ConfigIndex("PF-07"),
            "电机过温预警值\n超过该值并持续 PF-08 时间后按 PF-09 动作处理。",
            ReadOnly.Never);

        public ConfigItem MotorOverTempWarnTime = new ConfigItem(
            600, // 60.0s
            new ConfigIndex("PF-08"),
            "电机过温预警时间\n范围：0.0~6000.0s",
            ReadOnly.Never);

        public ConfigItem MotorOverTempWarnAction = new ConfigItem(
            0,
            new ConfigIndex("PF-09"),
            "电机过温预警动作\n0：继续运行\n1：减速停机\n2：自由停机",
            ReadOnly.Never);

        public ConfigItem TorqueProtectUpper = new ConfigItem(
            150,
            new ConfigIndex("PF-10"),
            "转矩保护上限（相对额定转矩）\n范围：0.0%~300.0%\n超过该值并持续 PF-11 时间触发预警动作。",
            ReadOnly.Never);

        public ConfigItem TorqueUpperDetectTime = new ConfigItem(
            5, // 0.5s
            new ConfigIndex("PF-11"),
            "转矩上限检出时间\n范围：0.0~60.0s",
            ReadOnly.Never);

        public ConfigItem TorqueProtectLower = new ConfigItem(
            0,
            new ConfigIndex("PF-12"),
            "转矩保护下限（相对额定转矩）\n范围：0.0%~300.0%\n低于该值并持续 PF-13 时间触发预警动作。",
            ReadOnly.Never);

        public ConfigItem TorqueLowerDetectTime = new ConfigItem(
            1, // 0.1s
            new ConfigIndex("PF-13"),
            "转矩下限检出时间\n范围：0.0~60.0s",
            ReadOnly.Never);

        public ConfigItem TorqueProtectAction = new ConfigItem(
            0,
            new ConfigIndex("PF-14"),
            "转矩保护预警动作\n0：继续运行\n1：减速停机\n2：自由停机",
            ReadOnly.Never);

        public ConfigItem ModuleOverTempTrip = new ConfigItem(
            900, // 90.0℃
            new ConfigIndex("PF-15"),
            "模块过温设定值\n范围：PF-16~120.0℃\n达到该温度报 E.OH1。",
            ReadOnly.Never);

        public ConfigItem ModuleOverTempWarnValue = new ConfigItem(
            750, // 75.0℃
            new ConfigIndex("PF-16"),
            "模块过温预警值\n超过该值并持续 PF-18 时间按 PF-19 动作处理。\n若温度低于 PF-17 则判定传感器失效。",
            ReadOnly.Never);

        public ConfigItem TempSensorFailValue = new ConfigItem(
            -300, // -30.0℃
            new ConfigIndex("PF-17"),
            "温度传感器失效值\n范围：-40.0℃~PF-16",
            ReadOnly.Never);

        public ConfigItem ModuleOverTempDetectTime = new ConfigItem(
            10, // 1.0s
            new ConfigIndex("PF-18"),
            "模块过温检测时间\n范围：0.0~180.0s",
            ReadOnly.Never);

        public ConfigItem ModuleOverTempWarnAction = new ConfigItem(
            0,
            new ConfigIndex("PF-19"),
            "模块过温预警动作\n0：继续运行\n1：减速停机\n2：自由停机",
            ReadOnly.Never);

        public ConfigItem FanWorkMode = new ConfigItem(
            2,
            new ConfigIndex("PF-20"),
            "风扇工作模式\n0：自动（按温度）\n1：一直开启\n2：运行时开启，停机延时关闭",
            ReadOnly.Never);

        public ConfigItem FanStartTemp = new ConfigItem(
            450, // 45.0℃
            new ConfigIndex("PF-21"),
            "风扇开启温度\n范围：0.0℃~PF-16",
            ReadOnly.Never);

        public ConfigItem FanStopDelay = new ConfigItem(
            100, // 10.0s
            new ConfigIndex("PF-22"),
            "风扇停机延时\n范围：0.0~300.0s",
            ReadOnly.Never);

        public ConfigItem InputPhaseLossProtect = new ConfigItem(
            0,
            new ConfigIndex("PF-23"),
            "输入缺相保护\n0：关闭\n1：使能",
            ReadOnly.Never);

        public ConfigItem OutputPhaseLossProtect = new ConfigItem(
            0,
            new ConfigIndex("PF-24"),
            "输出缺相保护\n0：关闭\n1：使能",
            ReadOnly.Never);

        public ConfigItem GroundShortProtect = new ConfigItem(
            0,
            new ConfigIndex("PF-25"),
            "对地短路保护\n0：关闭\n1：使能",
            ReadOnly.Never);

        public ConfigItem FaultAutoResetCount = new ConfigItem(
            0,
            new ConfigIndex("PF-26"),
            "故障自动复位次数\n范围：0~5",
            ReadOnly.Never);

        public ConfigItem FaultAutoResetInterval = new ConfigItem(
            20, // 2.0s
            new ConfigIndex("PF-27"),
            "故障自动复位间隔\n范围：0.1~60.0s",
            ReadOnly.Never);

        public ConfigItem FaultAutoResetConfig = new ConfigItem(
            0,
            new ConfigIndex("PF-28"),
            "自动复位配置\n十位：复位中故障指示（0：不输出 1：输出）\n个位：重启机制（0：按P4-00启动模式 1：转速追踪启动）",
            ReadOnly.Never);

        #endregion

        #region A0组 系统增强组1

        public ConfigItem PowerOnTerminalProtect = new ConfigItem(
            0,
            new ConfigIndex("A0-00"),
            "上电端子运行保护\n0：不保护\n1：保护",
            ReadOnly.Never);

        public ConfigItem SleepFrequency = new ConfigItem(
            0,
            new ConfigIndex("A0-01"),
            "休眠频率\n当设定频率 ≤ A0-01 且持续 A0-02 时间后进入休眠。",
            ReadOnly.Never);

        public ConfigItem SleepDelay = new ConfigItem(
            0,
            new ConfigIndex("A0-02"),
            "休眠延时\n范围：0.0~6500.0s",
            ReadOnly.Never);

        public ConfigItem WakeFrequency = new ConfigItem(
            0,
            new ConfigIndex("A0-03"),
            "唤醒频率\n休眠状态下，当设定频率 ≥ A0-03 且持续 A0-04 时间后唤醒。",
            ReadOnly.Never);

        public ConfigItem WakeDelay = new ConfigItem(
            0,
            new ConfigIndex("A0-04"),
            "唤醒延时\n范围：0.0~6500.0s",
            ReadOnly.Never);

        public ConfigItem TimerUnit = new ConfigItem(
            0,
            new ConfigIndex("A0-05"),
            "定时用单位\n0：分钟(min)\n1：小时(h)",
            ReadOnly.Never);

        public ConfigItem RunTimerSetting = new ConfigItem(
            0,
            new ConfigIndex("A0-06"),
            "本次运行定时设置\n0：无定时\n0.1~6500.0s：定时时间\n到达后停机并可输出指示。",
            ReadOnly.Never);

        public ConfigItem ZeroCurrentWidth = new ConfigItem(
            5, // 0.05%
            new ConfigIndex("A0-07"),
            "零电流检出宽度（相对额定电流）\n0.0%~200.0%\n≤该范围且持续 A0-08 时间判定为零电流。",
            ReadOnly.Never);

        public ConfigItem ZeroCurrentDelay = new ConfigItem(
            5, // 0.5s
            new ConfigIndex("A0-08"),
            "零电流检出延时\n范围：0.0~30.0s",
            ReadOnly.Never);

        public ConfigItem CurrentLimitDetect = new ConfigItem(
            200, // 2%
            new ConfigIndex("A0-09"),
            "电流超限检测（相对额定电流）\n0.0%~200.0%\n达到并持续 A0-10 时间判定超限。",
            ReadOnly.Never);

        public ConfigItem CurrentLimitDelay = new ConfigItem(
            20, // 2.0s
            new ConfigIndex("A0-10"),
            "电流超限检测延时\n范围：0.0~30.0s",
            ReadOnly.Never);

        public ConfigItem AnyCurrentDetect1 = new ConfigItem(
            100, // 1%
            new ConfigIndex("A0-11"),
            "任意电流检测1\n设定检测电流大小。",
            ReadOnly.Never);

        public ConfigItem AnyCurrentWidth1 = new ConfigItem(
            0,
            new ConfigIndex("A0-12"),
            "电流检测1宽度\n范围：0.0%~300.0%",
            ReadOnly.Never);

        public ConfigItem AnyCurrentDetect2 = new ConfigItem(
            100, // 1%
            new ConfigIndex("A0-13"),
            "任意电流检测2\n设定检测电流大小。",
            ReadOnly.Never);

        public ConfigItem AnyCurrentWidth2 = new ConfigItem(
            0,
            new ConfigIndex("A0-14"),
            "电流检测2宽度\n范围：0.0%~300.0%",
            ReadOnly.Never);

        public ConfigItem TargetFreqArrival = new ConfigItem(
            0,
            new ConfigIndex("A0-15"),
            "指定频率到达\n非零：运行频率 ≥ 该值输出有效\n零：运行频率 = 设定频率输出有效。",
            ReadOnly.Never);

        public ConfigItem FDT1Value = new ConfigItem(
            5000, // 50.00Hz
            new ConfigIndex("A0-16"),
            "频率检测值 FDT1\n输出频率 ≤ (A0-16 + A0-17) 时输出有效。",
            ReadOnly.Never);

        public ConfigItem FDT1Width = new ConfigItem(
            5, // 0.05
            new ConfigIndex("A0-17"),
            "FDT1 检出宽度\n范围：0.0%~100.0%",
            ReadOnly.Never);

        public ConfigItem FDT2Value = new ConfigItem(
            5000,
            new ConfigIndex("A0-18"),
            "频率检测值 FDT2\n输出频率 ≥ (A0-18 + A0-19) 时输出有效。",
            ReadOnly.Never);

        public ConfigItem FDT2Width = new ConfigItem(
            5,
            new ConfigIndex("A0-19"),
            "FDT2 检出宽度\n范围：0.0%~100.0%",
            ReadOnly.Never);

        public ConfigItem AnyFreqDetect1 = new ConfigItem(
            5000,
            new ConfigIndex("A0-20"),
            "任意频率检测1\n≥(A0-20 + A0-21) 输出有效\n≤(A0-20 - A0-21) 输出无效。",
            ReadOnly.Never);

        public ConfigItem AnyFreqWidth1 = new ConfigItem(
            0,
            new ConfigIndex("A0-21"),
            "任意频率到达检测宽度1\n范围：0.0%~100.0%",
            ReadOnly.Never);

        public ConfigItem AnyFreqDetect2 = new ConfigItem(
            5000,
            new ConfigIndex("A0-22"),
            "任意频率检测2\n(A0-22 - A0-23) ≤ 输出频率 ≤ (A0-22 + A0-23) 输出有效。",
            ReadOnly.Never);

        public ConfigItem AnyFreqWidth2 = new ConfigItem(
            0,
            new ConfigIndex("A0-23"),
            "任意频率到达检测宽度2\n范围：0.0%~100.0%",
            ReadOnly.Never);

        public ConfigItem AIDetectConfig = new ConfigItem(
            0,
            new ConfigIndex("A0-24"),
            "AI 检测配置\n十位：丢失通道\n个位：超限通道\n0：不检测 1：AI1 2：AI2",
            ReadOnly.WhenRuning);

        public ConfigItem AIOverLimitValue = new ConfigItem(
            0,
            new ConfigIndex("A0-25"),
            "AI 超限值\n超过该电压报 E.AiH\n0.00V 表示不检测。",
            ReadOnly.WhenRuning);

        public ConfigItem AILossValue = new ConfigItem(
            0,
            new ConfigIndex("A0-26"),
            "AI 丢失值\n低于该电压报 E.AiL\n0.00V 表示不检测。",
            ReadOnly.WhenRuning);

        public ConfigItem AIInputAccuracy = new ConfigItem(
            0,
            new ConfigIndex("A0-27"),
            "模拟量/脉冲量输入精度\n0：0.01\n1：0.1\n2：0.001",
            ReadOnly.Never);

        public ConfigItem MultiStepMode = new ConfigItem(
            0,
            new ConfigIndex("A0-28"),
            "多段量模式\n0：百分比模式\n1：频率模式",
            ReadOnly.WhenRuning);

        public ConfigItem EnergyCalibCoeff = new ConfigItem(
            100, // 1.00 = 100%
            new ConfigIndex("A0-29"),
            "用电量累计校正系数\n范围：0.0%~200.0%",
            ReadOnly.WhenRuning);

        public ConfigItem EnergyPrice = new ConfigItem(
            100, // 1.00元
            new ConfigIndex("A0-30"),
            "用电量每千瓦单价\n范围：0.00~10.00元",
            ReadOnly.WhenRuning);

        public ConfigItem EnergyCostLow = new ConfigItem(
            0,
            new ConfigIndex("A0-31"),
            "用电量总费用低位\n范围：0~9999元",
            ReadOnly.Always);

        public ConfigItem EnergyCostHigh = new ConfigItem(
            0,
            new ConfigIndex("A0-32"),
            "用电量总费用高位\n范围：0~9999万元",
            ReadOnly.Always);

        public ConfigItem MotorSwitchTime = new ConfigItem(
            200, // 0.200s
            new ConfigIndex("A0-33"),
            "电机切换时间\n电机1/电机2在线切换时外部接触器动作时间。",
            ReadOnly.Never);

        public ConfigItem CommFreqMode = new ConfigItem(
            0,
            new ConfigIndex("A0-34"),
            "通信给定频率模式\n0：默认模式(0x7002)\n1：百分比模式1\n2：百分比模式2",
            ReadOnly.Never);

        #endregion

        #region A1组 系统增强组2（AI多段曲线）

        public ConfigItem AI1CurvePoint0Value = new ConfigItem(
            0,
            new ConfigIndex("A1-00"),
            "AI1 曲线 2 点 0 值\n范围：0.00~10.00V(20mA)\nP6-17=1 时启用多点曲线。",
            ReadOnly.Never);

        public ConfigItem AI1CurvePoint0Setting = new ConfigItem(
            0,
            new ConfigIndex("A1-01"),
            "AI1 曲线 2 点 0 设定\n范围：-200.0%~200.0%",
            ReadOnly.Never);

        public ConfigItem AI1CurvePoint1Value = new ConfigItem(
            0,
            new ConfigIndex("A1-02"),
            "AI1 曲线 2 点 1 值\n范围：0.00~10.00V(20mA)",
            ReadOnly.Never);

        public ConfigItem AI1CurvePoint1Setting = new ConfigItem(
            0,
            new ConfigIndex("A1-03"),
            "AI1 曲线 2 点 1 设定\n范围：-200.0%~200.0%",
            ReadOnly.Never);

        public ConfigItem AI1CurvePoint2Value = new ConfigItem(
            0,
            new ConfigIndex("A1-04"),
            "AI1 曲线 2 点 2 值\n范围：0.00~10.00V(20mA)",
            ReadOnly.Never);

        public ConfigItem AI1CurvePoint2Setting = new ConfigItem(
            0,
            new ConfigIndex("A1-05"),
            "AI1 曲线 2 点 2 设定\n范围：-200.0%~200.0%",
            ReadOnly.Never);

        public ConfigItem AI1CurvePoint3Value = new ConfigItem(
            0,
            new ConfigIndex("A1-06"),
            "AI1 曲线 2 点 3 值\n范围：0.00~10.00V(20mA)",
            ReadOnly.Never);

        public ConfigItem AI1CurvePoint3Setting = new ConfigItem(
            0,
            new ConfigIndex("A1-07"),
            "AI1 曲线 2 点 3 设定\n范围：-200.0%~200.0%",
            ReadOnly.Never);

        public ConfigItem AI2CurvePoint0Value = new ConfigItem(
            0,
            new ConfigIndex("A1-08"),
            "AI2 曲线 2 点 0 值\n范围：0.00~10.00V\nP6-25=1 时启用多点曲线。",
            ReadOnly.Never);

        public ConfigItem AI2CurvePoint0Setting = new ConfigItem(
            0,
            new ConfigIndex("A1-09"),
            "AI2 曲线 2 点 0 设定\n范围：-200.0%~200.0%",
            ReadOnly.Never);

        public ConfigItem AI2CurvePoint1Value = new ConfigItem(
            0,
            new ConfigIndex("A1-10"),
            "AI2 曲线 2 点 1 值\n范围：0.00~10.00V",
            ReadOnly.Never);

        public ConfigItem AI2CurvePoint1Setting = new ConfigItem(
            0,
            new ConfigIndex("A1-11"),
            "AI2 曲线 2 点 1 设定\n范围：-200.0%~200.0%",
            ReadOnly.Never);

        public ConfigItem AI2CurvePoint2Value = new ConfigItem(
            0,
            new ConfigIndex("A1-12"),
            "AI2 曲线 2 点 2 值\n范围：0.00~10.00V",
            ReadOnly.Never);

        public ConfigItem AI2CurvePoint2Setting = new ConfigItem(
            0,
            new ConfigIndex("A1-13"),
            "AI2 曲线 2 点 2 设定\n范围：-200.0%~200.0%",
            ReadOnly.Never);

        public ConfigItem AI2CurvePoint3Value = new ConfigItem(
            0,
            new ConfigIndex("A1-14"),
            "AI2 曲线 2 点 3 值\n范围：0.00~10.00V",
            ReadOnly.Never);

        public ConfigItem AI2CurvePoint3Setting = new ConfigItem(
            0,
            new ConfigIndex("A1-15"),
            "AI2 曲线 2 点 3 设定\n范围：-200.0%~200.0%",
            ReadOnly.Never);

        #endregion

        #region A2组 系统增强组3（虚拟DI，DO功能）

        public ConfigItem VirtualVDI1Func = new ConfigItem(
            0,
            new ConfigIndex("A2-00"),
            "虚拟 VDI1 功能\n与 P6 组端子功能一致\n不可设置为 UP/DN 功能。",
            ReadOnly.WhenRuning);

        public ConfigItem VirtualVDI2Func = new ConfigItem(
            0,
            new ConfigIndex("A2-01"),
            "虚拟 VDI2 功能\n可与实际端子功能重复。",
            ReadOnly.WhenRuning);

        public ConfigItem VirtualVDI3Func = new ConfigItem(
            0,
            new ConfigIndex("A2-02"),
            "虚拟 VDI3 功能\n不可设置为 UP/DN 功能。",
            ReadOnly.WhenRuning);

        public ConfigItem VirtualVDI4Func = new ConfigItem(
            0,
            new ConfigIndex("A2-03"),
            "虚拟 VDI4 功能\n范围：0~50",
            ReadOnly.WhenRuning);

        public ConfigItem VirtualVDILink = new ConfigItem(
            1111,
            new ConfigIndex("A2-04"),
            "虚拟 VDI 连接设置\n千位：VDI4\n百位：VDI3\n十位：VDI2\n个位：VDI1\n0：内联（由 VDO 状态决定）\n1：独立（由 A2-05 决定）\n2：通信给定",
            ReadOnly.Never);

        public ConfigItem VirtualVDIState = new ConfigItem(
            0,
            new ConfigIndex("A2-05"),
            "虚拟 VDI 状态设置\n千位：VDI4\n百位：VDI3\n十位：VDI2\n个位：VDI1\n0：无效给定\n1：有效给定",
            ReadOnly.Never);

        public ConfigItem VirtualVDO1Func = new ConfigItem(
            0,
            new ConfigIndex("A2-06"),
            "虚拟 VDO1 功能\n0：无效\n1~99：参考物理输出端子定义",
            ReadOnly.Never);

        public ConfigItem VirtualVDO2Func = new ConfigItem(
            0,
            new ConfigIndex("A2-07"),
            "虚拟 VDO2 功能\n0：无效\n1~99：参考物理输出端子定义",
            ReadOnly.Never);

        public ConfigItem VirtualVDO3Func = new ConfigItem(
            0,
            new ConfigIndex("A2-08"),
            "虚拟 VDO3 功能\n0：无效\n1~99：参考物理输出端子定义",
            ReadOnly.Never);

        public ConfigItem VirtualVDO4Func = new ConfigItem(
            0,
            new ConfigIndex("A2-09"),
            "虚拟 VDO4 功能\n0：无效\n1~99：参考物理输出端子定义",
            ReadOnly.Never);

        public ConfigItem VirtualVDO1Delay = new ConfigItem(
            0,
            new ConfigIndex("A2-10"),
            "虚拟 VDO1 延时\n范围：0.000~60.000s",
            ReadOnly.Never);

        public ConfigItem VirtualVDO2Delay = new ConfigItem(
            0,
            new ConfigIndex("A2-11"),
            "虚拟 VDO2 延时\n范围：0.000~60.000s",
            ReadOnly.Never);

        public ConfigItem VirtualVDO3Delay = new ConfigItem(
            0,
            new ConfigIndex("A2-12"),
            "虚拟 VDO3 延时\n范围：0.000~60.000s",
            ReadOnly.Never);

        public ConfigItem VirtualVDO4Delay = new ConfigItem(
            0,
            new ConfigIndex("A2-13"),
            "虚拟 VDO4 延时\n范围：0.000~60.000s",
            ReadOnly.Never);

        public ConfigItem VirtualVDOActiveLevel = new ConfigItem(
            1111,
            new ConfigIndex("A2-14"),
            "虚拟 VDO 有效电平\n千位：VDO4\n百位：VDO3\n十位：VDO2\n个位：VDO1\n0：低电平有效\n1：高电平有效",
            ReadOnly.Never);

        #endregion

        #region A3组 自定义功能码地址映射组

        public ConfigItem AddressMappingEnable = new ConfigItem(
            0,
            new ConfigIndex("A3-00"),
            "地址映射使能\n千位：通信控制字映射选择（0：无映射 1：厂家1 2：厂家2 3：厂家3）\n百位：映射冲突优先级（0：本机地址优先 1：映射地址优先）\n十位：用户自定义/厂家映射（0：用户自定义 1：厂家1 2：厂家2）\n个位：映射使能开关（0：关闭 1：开启）",
            ReadOnly.Never);

        public ConfigItem ParamOriginalAddr1 = new ConfigItem(
            0,
            new ConfigIndex("A3-01"),
            "参数原始地址1\n设置本变频器功能码参数原始通讯地址1。",
            ReadOnly.Never);

        public ConfigItem ParamMappedAddr1 = new ConfigItem(
            0,
            new ConfigIndex("A3-02"),
            "参数映射地址1\n配置映射后的通讯地址1。",
            ReadOnly.Never);

        public ConfigItem ParamOriginalAddr2 = new ConfigItem(
            0,
            new ConfigIndex("A3-03"),
            "参数原始地址2\n设置本变频器功能码参数原始通讯地址2。",
            ReadOnly.Never);

        public ConfigItem ParamMappedAddr2 = new ConfigItem(
            0,
            new ConfigIndex("A3-04"),
            "参数映射地址2\n配置映射后的通讯地址2。",
            ReadOnly.Never);

        public ConfigItem ParamOriginalAddr3 = new ConfigItem(
            0,
            new ConfigIndex("A3-05"),
            "参数原始地址3\n设置本变频器功能码参数原始通讯地址3。",
            ReadOnly.Never);

        public ConfigItem ParamMappedAddr3 = new ConfigItem(
            0,
            new ConfigIndex("A3-06"),
            "参数映射地址3\n配置映射后的通讯地址3。",
            ReadOnly.Never);

        public ConfigItem ParamOriginalAddr4 = new ConfigItem(
            0,
            new ConfigIndex("A3-07"),
            "参数原始地址4\n设置本变频器功能码参数原始通讯地址4。",
            ReadOnly.Never);

        public ConfigItem ParamMappedAddr4 = new ConfigItem(
            0,
            new ConfigIndex("A3-08"),
            "参数映射地址4\n配置映射后的通讯地址4。",
            ReadOnly.Never);

        public ConfigItem ParamOriginalAddr5 = new ConfigItem(
            0,
            new ConfigIndex("A3-09"),
            "参数原始地址5\n设置本变频器功能码参数原始通讯地址5。",
            ReadOnly.Never);

        public ConfigItem ParamMappedAddr5 = new ConfigItem(
            0,
            new ConfigIndex("A3-10"),
            "参数映射地址5\n配置映射后的通讯地址5。",
            ReadOnly.Never);

        public ConfigItem ParamOriginalAddr6 = new ConfigItem(
            0,
            new ConfigIndex("A3-11"),
            "参数原始地址6\n设置本变频器功能码参数原始通讯地址6。",
            ReadOnly.Never);

        public ConfigItem ParamMappedAddr6 = new ConfigItem(
            0,
            new ConfigIndex("A3-12"),
            "参数映射地址6\n配置映射后的通讯地址6。",
            ReadOnly.Never);

        public ConfigItem ParamOriginalAddr7 = new ConfigItem(
            0,
            new ConfigIndex("A3-13"),
            "参数原始地址7\n设置本变频器功能码参数原始通讯地址7。",
            ReadOnly.Never);

        public ConfigItem ParamMappedAddr7 = new ConfigItem(
            0,
            new ConfigIndex("A3-14"),
            "参数映射地址7\n配置映射后的通讯地址7。",
            ReadOnly.Never);

        public ConfigItem ParamOriginalAddr8 = new ConfigItem(
            0,
            new ConfigIndex("A3-15"),
            "参数原始地址8\n设置本变频器功能码参数原始通讯地址8。",
            ReadOnly.Never);

        public ConfigItem ParamMappedAddr8 = new ConfigItem(
            0,
            new ConfigIndex("A3-16"),
            "参数映射地址8\n配置映射后的通讯地址8。",
            ReadOnly.Never);

        #endregion

        #region A4组 常用参数设定组

        public ConfigItem CommonParamAutoRecord = new ConfigItem(
            1,
            new ConfigIndex("A4-00"),
            "参数自动登记功能\n0：无效\n1：自动登记有效（最近变更的参数自动保存到 A4 组）\n2：用户自动填充",
            ReadOnly.Never);

        public ConfigItem CommonParam1 = new ConfigItem(
            0,
            new ConfigIndex("A4-01"),
            "常用参数1（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam2 = new ConfigItem(
            0,
            new ConfigIndex("A4-02"),
            "常用参数2（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam3 = new ConfigItem(
            0,
            new ConfigIndex("A4-03"),
            "常用参数3（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam4 = new ConfigItem(
            0,
            new ConfigIndex("A4-04"),
            "常用参数4（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam5 = new ConfigItem(
            0,
            new ConfigIndex("A4-05"),
            "常用参数5（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam6 = new ConfigItem(
            0,
            new ConfigIndex("A4-06"),
            "常用参数6（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam7 = new ConfigItem(
            0,
            new ConfigIndex("A4-07"),
            "常用参数7（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam8 = new ConfigItem(
            0,
            new ConfigIndex("A4-08"),
            "常用参数8（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam9 = new ConfigItem(
            0,
            new ConfigIndex("A4-09"),
            "常用参数9（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam10 = new ConfigItem(
            0,
            new ConfigIndex("A4-10"),
            "常用参数10（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam11 = new ConfigItem(
            0,
            new ConfigIndex("A4-11"),
            "常用参数11（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam12 = new ConfigItem(
            0,
            new ConfigIndex("A4-12"),
            "常用参数12（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam13 = new ConfigItem(
            0,
            new ConfigIndex("A4-13"),
            "常用参数13（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam14 = new ConfigItem(
            0,
            new ConfigIndex("A4-14"),
            "常用参数14（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam15 = new ConfigItem(
            0,
            new ConfigIndex("A4-15"),
            "常用参数15（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam16 = new ConfigItem(
            0,
            new ConfigIndex("A4-16"),
            "常用参数16（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam17 = new ConfigItem(
            0,
            new ConfigIndex("A4-17"),
            "常用参数17（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam18 = new ConfigItem(
            0,
            new ConfigIndex("A4-18"),
            "常用参数18（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam19 = new ConfigItem(
            0,
            new ConfigIndex("A4-19"),
            "常用参数19（显示为功能码标识符）",
            ReadOnly.Never);

        public ConfigItem CommonParam20 = new ConfigItem(
            0,
            new ConfigIndex("A4-20"),
            "常用参数20（显示为功能码标识符）",
            ReadOnly.Never);

        #endregion

        #region U0组 状态监视组

        public ConfigItem RunFrequency = new ConfigItem(
            0,
            new ConfigIndex("U0-00"),
            "运行频率 (0.00~600.00Hz)",
            ReadOnly.Always);

        public ConfigItem SetFrequency = new ConfigItem(
            0,
            new ConfigIndex("U0-01"),
            "设定频率 (0.00~600.00Hz)",
            ReadOnly.Always);

        public ConfigItem BusVoltage = new ConfigItem(
            0,
            new ConfigIndex("U0-02"),
            "母线电压 (0~65535V)",
            ReadOnly.Always);

        public ConfigItem OutputVoltage = new ConfigItem(
            0,
            new ConfigIndex("U0-03"),
            "输出电压 (0~65535V)",
            ReadOnly.Always);

        public ConfigItem OutputCurrent = new ConfigItem(
            0,
            new ConfigIndex("U0-04"),
            "输出电流 (0~6553.5A)",
            ReadOnly.Always);

        public ConfigItem OutputFrequency = new ConfigItem(
            0,
            new ConfigIndex("U0-05"),
            "输出频率 (0.00~600.00Hz)",
            ReadOnly.Always);

        public ConfigItem SetTorque = new ConfigItem(
            0,
            new ConfigIndex("U0-06"),
            "设定转矩 (-200.0%~200.0%)",
            ReadOnly.Always);

        public ConfigItem OutputTorque = new ConfigItem(
            0,
            new ConfigIndex("U0-07"),
            "输出转矩 (-200.0%~200.0%)",
            ReadOnly.Always);

        public ConfigItem OutputPower = new ConfigItem(
            0,
            new ConfigIndex("U0-08"),
            "输出功率 (-3000.0~3000.0kW)",
            ReadOnly.Always);

        public ConfigItem MotorSpeed = new ConfigItem(
            0,
            new ConfigIndex("U0-09"),
            "电机转速 (0~66635rpm)",
            ReadOnly.Always);

        public ConfigItem HeatsinkTemp = new ConfigItem(
            0,
            new ConfigIndex("U0-10"),
            "散热器温度 (-40.0~100.0℃)",
            ReadOnly.Always);

        public ConfigItem MotorTemp = new ConfigItem(
            0,
            new ConfigIndex("U0-11"),
            "电机温度 (-40.0~100.0℃)",
            ReadOnly.Always);

        public ConfigItem RunStatus = new ConfigItem(
            0,
            new ConfigIndex("U0-12"),
            "运行状态\nbit0：0停止/1运行\nbit1：0正转/1反转\nbit2~3：0恒速 1加速 2减速\nbit4~9：故障指示码",
            ReadOnly.Always);

        public ConfigItem AI1Voltage = new ConfigItem(
            0,
            new ConfigIndex("U0-13"),
            "AI1 电压 (0.00~10.00V)",
            ReadOnly.Always);

        public ConfigItem AI2Voltage = new ConfigItem(
            0,
            new ConfigIndex("U0-14"),
            "AI2 电压 (0.00~10.00V)",
            ReadOnly.Always);

        public ConfigItem InputTerminalStatus = new ConfigItem(
            0,
            new ConfigIndex("U0-15"),
            "输入端子状态 (bit0~bit7 对应 X1~AI2)",
            ReadOnly.Always);

        public ConfigItem OutputTerminalStatus = new ConfigItem(
            0,
            new ConfigIndex("U0-16"),
            "输出端子状态 (bit0~bit7 对应 X1~AI2)",
            ReadOnly.Always);

        public ConfigItem PulseInputPFI = new ConfigItem(
            0,
            new ConfigIndex("U0-17"),
            "脉冲输入 PFI (0.00~50.00kHz)",
            ReadOnly.Always);

        public ConfigItem AO1Output = new ConfigItem(
            0,
            new ConfigIndex("U0-18"),
            "AO1 输出 (0.00~10.00V)",
            ReadOnly.Always);

        public ConfigItem PulseOutputPFO = new ConfigItem(
            0,
            new ConfigIndex("U0-19"),
            "脉冲输出 PFO (0.00~50.00kHz)",
            ReadOnly.Always);

        public ConfigItem VirtualVDIStatus = new ConfigItem(
            0,
            new ConfigIndex("U0-20"),
            "虚拟 VDI 状态 (bit0~bit3 对应 VDI1~VDI4)",
            ReadOnly.Always);

        public ConfigItem VirtualVDOStatus = new ConfigItem(
            0,
            new ConfigIndex("U0-21"),
            "虚拟 VDO 状态 (bit0~bit3 对应 VDO1~VDO4)",
            ReadOnly.Always);

        public ConfigItem RunTimeHours = new ConfigItem(
            0,
            new ConfigIndex("U0-22"),
            "持续运行时间 (小时)",
            ReadOnly.Always);

        public ConfigItem RunTimeMinutes = new ConfigItem(
            0,
            new ConfigIndex("U0-23"),
            "持续运行时间 (分钟)",
            ReadOnly.Always);

        public ConfigItem PIDSet = new ConfigItem(
            0,
            new ConfigIndex("U0-24"),
            "PID 给定 (0.0%~100.0%)",
            ReadOnly.Always);

        public ConfigItem PIDFeedback = new ConfigItem(
            0,
            new ConfigIndex("U0-25"),
            "PID 反馈 (0.0%~100.0%)",
            ReadOnly.Always);

        public ConfigItem CounterValue = new ConfigItem(
            0,
            new ConfigIndex("U0-26"),
            "计数值 (0~65535)",
            ReadOnly.Always);

        public ConfigItem LengthValue = new ConfigItem(
            0,
            new ConfigIndex("U0-27"),
            "长度值 (0~65535m)",
            ReadOnly.Always);

        public ConfigItem PowerOnTimeLow = new ConfigItem(
            0,
            new ConfigIndex("U0-28"),
            "开机时间 L (秒)",
            ReadOnly.Always);

        public ConfigItem PowerOnTimeHigh = new ConfigItem(
            0,
            new ConfigIndex("U0-29"),
            "开机时间 H (小时)",
            ReadOnly.Always);

        public ConfigItem VFSeparatedTargetVoltage = new ConfigItem(
            0,
            new ConfigIndex("U0-30"),
            "V/F 分离目标电压 (0.0%~100.0%)",
            ReadOnly.Always);

        public ConfigItem VFSeparatedOutputVoltage = new ConfigItem(
            0,
            new ConfigIndex("U0-31"),
            "V/F 分离输出电压 (0.0%~100.0%)",
            ReadOnly.Always);

        public ConfigItem PLCStage = new ConfigItem(
            0,
            new ConfigIndex("U0-32"),
            "PLC 当前阶段 (0~15)",
            ReadOnly.Always);

        public ConfigItem PLCTime = new ConfigItem(
            0,
            new ConfigIndex("U0-33"),
            "PLC 当前阶段运行时间 (0.0~6500.0s)",
            ReadOnly.Always);

        public ConfigItem EnergyLow = new ConfigItem(
            0,
            new ConfigIndex("U0-34"),
            "用电量累计低位 (0.0~999.9kWh)",
            ReadOnly.Always);

        public ConfigItem EnergyHigh = new ConfigItem(
            0,
            new ConfigIndex("U0-35"),
            "用电量累计高位 (0~9999MWh)",
            ReadOnly.Always);

        public ConfigItem UpDnBias = new ConfigItem(
            0,
            new ConfigIndex("U0-36"),
            "UP/DN 偏置值 (-50.00~50.00Hz)",
            ReadOnly.Always);

        public ConfigItem SystemWord = new ConfigItem(
            0,
            new ConfigIndex("U0-37"),
            "系统存储字",
            ReadOnly.Always);

        #endregion

        #region U1组 故障记录组

        public ConfigItem CurrentFaultIndex = new ConfigItem(
            0,
            new ConfigIndex("U1-00"),
            "当前发生故障索引（0 表示无故障）",
            ReadOnly.Always);

        public ConfigItem Fault1Index = new ConfigItem(
            0,
            new ConfigIndex("U1-01"),
            "前 1 次发生故障索引",
            ReadOnly.Always);

        public ConfigItem Fault1RunFreq = new ConfigItem(
            0,
            new ConfigIndex("U1-02"),
            "故障1时运行频率 (0.00~600.00Hz)",
            ReadOnly.Always);

        public ConfigItem Fault1OutFreq = new ConfigItem(
            0,
            new ConfigIndex("U1-03"),
            "故障1时输出频率 (0.00~600.00Hz)",
            ReadOnly.Always);

        public ConfigItem Fault1OutCurrent = new ConfigItem(
            0,
            new ConfigIndex("U1-04"),
            "故障1时输出电流 (0.0~6553.5A)",
            ReadOnly.Always);

        public ConfigItem Fault1BusVoltH = new ConfigItem(
            0,
            new ConfigIndex("U1-05"),
            "故障1时母线电压高位",
            ReadOnly.Always);

        public ConfigItem Fault1BusVoltL = new ConfigItem(
            0,
            new ConfigIndex("U1-06"),
            "故障1时母线电压低位",
            ReadOnly.Always);

        public ConfigItem Fault1BusVolt = new ConfigItem(
            0,
            new ConfigIndex("U1-07"),
            "故障1时母线电压",
            ReadOnly.Always);

        public ConfigItem Fault1ModuleTemp = new ConfigItem(
            0,
            new ConfigIndex("U1-08"),
            "故障1时模块温度 (-40.0~100.0℃)",
            ReadOnly.Always);

        public ConfigItem Fault1InputStatus = new ConfigItem(
            0,
            new ConfigIndex("U1-09"),
            "故障1时输入端状态 (bit0~bit15)",
            ReadOnly.Always);

        public ConfigItem Fault1RunHours = new ConfigItem(
            0,
            new ConfigIndex("U1-10"),
            "故障1前运行小时数",
            ReadOnly.Always);

        public ConfigItem Fault2Index = new ConfigItem(
            0,
            new ConfigIndex("U1-11"),
            "前 2 次发生故障索引",
            ReadOnly.Always);

        public ConfigItem Fault2RunFreq = new ConfigItem(
            0,
            new ConfigIndex("U1-12"),
            "故障2时运行频率",
            ReadOnly.Always);

        public ConfigItem Fault2OutFreq = new ConfigItem(
            0,
            new ConfigIndex("U1-13"),
            "故障2时输出频率",
            ReadOnly.Always);

        public ConfigItem Fault2OutCurrent = new ConfigItem(
            0,
            new ConfigIndex("U1-14"),
            "故障2时输出电流",
            ReadOnly.Always);

        public ConfigItem Fault2BusVoltH = new ConfigItem(
            0,
            new ConfigIndex("U1-15"),
            "故障2时母线电压高位",
            ReadOnly.Always);

        public ConfigItem Fault2BusVoltL = new ConfigItem(
            0,
            new ConfigIndex("U1-16"),
            "故障2时母线电压低位",
            ReadOnly.Always);

        public ConfigItem Fault2BusVolt = new ConfigItem(
            0,
            new ConfigIndex("U1-17"),
            "故障2时母线电压",
            ReadOnly.Always);

        public ConfigItem Fault2ModuleTemp = new ConfigItem(
            0,
            new ConfigIndex("U1-18"),
            "故障2时模块温度",
            ReadOnly.Always);

        public ConfigItem Fault2InputStatus = new ConfigItem(
            0,
            new ConfigIndex("U1-19"),
            "故障2时输入端状态",
            ReadOnly.Always);

        public ConfigItem Fault2RunHours = new ConfigItem(
            0,
            new ConfigIndex("U1-20"),
            "故障2前运行小时数",
            ReadOnly.Always);

        public ConfigItem Fault3Index = new ConfigItem(
            0,
            new ConfigIndex("U1-21"),
            "前 3 次发生故障索引",
            ReadOnly.Always);

        public ConfigItem Fault3RunFreq = new ConfigItem(
            0,
            new ConfigIndex("U1-22"),
            "故障3时运行频率",
            ReadOnly.Always);

        public ConfigItem Fault3OutFreq = new ConfigItem(
            0,
            new ConfigIndex("U1-23"),
            "故障3时输出频率",
            ReadOnly.Always);

        public ConfigItem Fault3OutCurrent = new ConfigItem(
            0,
            new ConfigIndex("U1-24"),
            "故障3时输出电流",
            ReadOnly.Always);

        public ConfigItem Fault3BusVoltH = new ConfigItem(
            0,
            new ConfigIndex("U1-25"),
            "故障3时母线电压高位",
            ReadOnly.Always);

        public ConfigItem Fault3BusVoltL = new ConfigItem(
            0,
            new ConfigIndex("U1-26"),
            "故障3时母线电压低位",
            ReadOnly.Always);

        public ConfigItem Fault3BusVolt = new ConfigItem(
            0,
            new ConfigIndex("U1-27"),
            "故障3时母线电压",
            ReadOnly.Always);

        public ConfigItem Fault3ModuleTemp = new ConfigItem(
            0,
            new ConfigIndex("U1-28"),
            "故障3时模块温度",
            ReadOnly.Always);

        public ConfigItem Fault3InputStatus = new ConfigItem(
            0,
            new ConfigIndex("U1-29"),
            "故障3时输入端状态",
            ReadOnly.Always);

        public ConfigItem Fault3RunHours = new ConfigItem(
            0,
            new ConfigIndex("U1-30"),
            "故障3前运行小时数",
            ReadOnly.Always);

        public ConfigItem Fault4Index = new ConfigItem(
            0,
            new ConfigIndex("U1-31"),
            "前 4 次发生故障索引",
            ReadOnly.Always);

        public ConfigItem Fault5Index = new ConfigItem(
            0,
            new ConfigIndex("U1-32"),
            "前 5 次发生故障索引",
            ReadOnly.Always);

        public ConfigItem Fault6Index = new ConfigItem(
            0,
            new ConfigIndex("U1-33"),
            "前 6 次发生故障索引",
            ReadOnly.Always);

        public ConfigItem Fault7Index = new ConfigItem(
            0,
            new ConfigIndex("U1-34"),
            "前 7 次发生故障索引",
            ReadOnly.Always);

        public ConfigItem Fault8Index = new ConfigItem(
            0,
            new ConfigIndex("U1-35"),
            "前 8 次发生故障索引",
            ReadOnly.Always);

        public ConfigItem Fault9Index = new ConfigItem(
            0,
            new ConfigIndex("U1-36"),
            "前 9 次发生故障索引",
            ReadOnly.Always);

        public ConfigItem Fault10Index = new ConfigItem(
            0,
            new ConfigIndex("U1-37"),
            "前 10 次发生故障索引",
            ReadOnly.Always);

        #endregion

        #region n1组 代理商参数

        public ConfigItem DealerPassword = new ConfigItem(
            0,
            new ConfigIndex("n1-00"),
            "代理商密码\n范围：0~FFFF",
            ReadOnly.Never);

        public ConfigItem DealerRunTimeSetting = new ConfigItem(
            0,
            new ConfigIndex("n1-01"),
            "代理商设定总运行时间（小时）\n范围：0~65535h",
            ReadOnly.Never);

        public ConfigItem DealerCommand = new ConfigItem(
            0,
            new ConfigIndex("n1-02"),
            "代理商命令（只写/控制类）",
            ReadOnly.WhenRuning);

        #endregion
    }
}
