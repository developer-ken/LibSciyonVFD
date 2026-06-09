using System;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections.Generic;

namespace LibSciyonVFD
{
    public partial class VFDConfiguration
    {
		#region P0组 别名
		public ConfigItem<ushort> P0_00 => RatedPower;
		public ConfigItem<ushort> P0_01 => RatedCurrent;
		public ConfigItem<ushort> P0_02 => RatedVoltage;
		public ConfigItem<byte> P0_03 => LoadType;
		public ConfigItem<ushort> P0_04 => FuncDisplayCtrl;
		public ConfigItem<byte> P0_05 => FuncInit;
		public ConfigItem<byte> P0_06 => ControlMode;
		public ConfigItem<byte> P0_07 => CmdSource;
		public ConfigItem<byte> P0_08 => MotorDirection;
		public ConfigItem<ushort> P0_09 => MaxFreq;
		public ConfigItem<ushort> P0_10 => ReservedP010;
		public ConfigItem<ushort> P0_11 => FreqUpper;
		public ConfigItem<ushort> P0_12 => FreqLower;
		public ConfigItem<byte> P0_13 => MainFreqSrc;
		public ConfigItem<byte> P0_14 => SubFreqSrc;
		public ConfigItem<byte> P0_15 => MainSubRelation;
		public ConfigItem<ushort> P0_16 => PresetFreq;
		public ConfigItem<byte> P0_17 => SubFreqRef;
		public ConfigItem<ushort> P0_18 => SubFreqGain;
		public ConfigItem<byte> P0_19 => FreqBiasCfg;
		public ConfigItem<ushort> P0_20 => FreqBiasRate;
		public ConfigItem<ushort> P0_21 => AccTime0;
		public ConfigItem<ushort> P0_22 => DecTime0;
		public ConfigItem<byte> P0_23 => MotorParamGroup;
		public ConfigItem<byte> P0_24 => TuneMode;
		public ConfigItem<byte> P0_25 => JogPriority;
		public ConfigItem<byte> P0_26 => FreqAccuracy;
		public ConfigItem<byte> P0_27 => IndustryMacro;
		public ConfigItem<ushort> P0_28 => ExtCardCfg;
		#endregion
		#region P1组 别名
		public ConfigItem<byte> P1_00 => Motor1Type;
		public ConfigItem<ushort> P1_01 => Motor1RatedPower;
		public ConfigItem<ushort> P1_02 => Motor1RatedVoltage;
		public ConfigItem<ushort> P1_03 => Motor1RatedCurrent;
		public ConfigItem<ushort> P1_04 => Motor1RatedFreq;
		public ConfigItem<ushort> P1_05 => Motor1RatedSpeed;
		public ConfigItem<byte> P1_06 => Motor1PoleCount;
		public ConfigItem<ushort> P1_07 => Motor1StatorRes;
		public ConfigItem<ushort> P1_08 => Motor1RotorRes;
		public ConfigItem<ushort> P1_09 => Motor1LeakInduct;
		public ConfigItem<ushort> P1_10 => Motor1MutualInduct;
		public ConfigItem<ushort> P1_11 => Motor1NoLoadCurrent;
		public ConfigItem<ushort> P1_12 => Motor1BackEMF;
		public ConfigItem<ushort> P1_13 => Motor1InitPos;
		public ConfigItem<ushort> P1_14 => Motor1CarrierFreq;
		public ConfigItem<ushort> P1_15 => CarrierOptimize;
		#endregion
		#region P2组 别名
		public ConfigItem<byte> P2_00 => VfCurve;
		public ConfigItem<ushort> P2_01 => VfFreqPoint1;
		public ConfigItem<ushort> P2_02 => VfVoltPoint1;
		public ConfigItem<ushort> P2_03 => VfFreqPoint2;
		public ConfigItem<ushort> P2_04 => VfVoltPoint2;
		public ConfigItem<ushort> P2_05 => VfFreqPoint3;
		public ConfigItem<ushort> P2_06 => VfVoltPoint3;
		public ConfigItem<byte> P2_07 => VfSepVoltSrc;
		public ConfigItem<ushort> P2_08 => VfSepVoltDigital;
		public ConfigItem<ushort> P2_09 => VfSepAccTime;
		public ConfigItem<ushort> P2_10 => VfSepDecTime;
		public ConfigItem<ushort> P2_11 => TorqueBoost;
		public ConfigItem<ushort> P2_12 => TorqueBoostFilter;
		public ConfigItem<ushort> P2_13 => TorqueBoostCutFreq;
		public ConfigItem<ushort> P2_14 => SlipCompGain;
		public ConfigItem<ushort> P2_15 => SlipCompFilter;
		public ConfigItem<ushort> P2_16 => CurrentOscSuppress;
		public ConfigItem<ushort> P2_17 => MotoringCurrentLimit;
		public ConfigItem<ushort> P2_18 => BrakingCurrentLimit;
		public ConfigItem<byte> P2_19 => AVRMode;
		public ConfigItem<ushort> P2_20 => DroopFreq;
		#endregion
		#region P3组 别名
		public ConfigItem<ushort> P3_00 => LowSpeedASR_P;
		public ConfigItem<ushort> P3_01 => LowSpeedASR_I;
		public ConfigItem<ushort> P3_02 => LowSpeedASR_SwitchFreq;
		public ConfigItem<ushort> P3_03 => HighSpeedASR_P;
		public ConfigItem<ushort> P3_04 => HighSpeedASR_I;
		public ConfigItem<ushort> P3_05 => HighSpeedASR_SwitchFreq;
		public ConfigItem<ushort> P3_06 => FluxReg_P;
		public ConfigItem<ushort> P3_07 => FluxReg_I;
		public ConfigItem<ushort> P3_08 => TorqueReg_P;
		public ConfigItem<ushort> P3_09 => TorqueReg_I;
		public ConfigItem<byte> P3_10 => MotoringTorqueLimitSrc;
		public ConfigItem<ushort> P3_11 => MotoringTorqueLimit;
		public ConfigItem<ushort> P3_12 => BrakingTorqueLimit;
		public ConfigItem<ushort> P3_13 => VectorSlipCompGain;
		public ConfigItem<ushort> P3_14 => InertiaCompGain;
		public ConfigItem<byte> P3_15 => TorqueCmdSrc;
		public ConfigItem<short> P3_16 => TorqueCmdDigital;
		public ConfigItem<ushort> P3_17 => TorqueCmdFilter;
		public ConfigItem<byte> P3_18 => SpeedLimitSrc;
		public ConfigItem<ushort> P3_19 => SpeedLimitDigital;
		#endregion
		#region P4组 别名
		public ConfigItem<byte> P4_00 => StartMode;
		public ConfigItem<ushort> P4_01 => StartFreq;
		public ConfigItem<ushort> P4_02 => StartFreqHoldTime;
		public ConfigItem<byte> P4_03 => StartFreqDirection;
		public ConfigItem<ushort> P4_04 => StartBrakeCurrent;
		public ConfigItem<ushort> P4_05 => StartBrakeHoldTime;
		public ConfigItem<ushort> P4_06 => StartTrackCurrent;
		public ConfigItem<ushort> P4_07 => StartTrackTime;
		public ConfigItem<byte> P4_08 => StopMode;
		public ConfigItem<ushort> P4_09 => StopBrakeFreq;
		public ConfigItem<ushort> P4_10 => StopBrakeCurrent;
		public ConfigItem<ushort> P4_11 => StopBrakeHoldTime;
		public ConfigItem<ushort> P4_12 => ReverseDeadTime;
		public ConfigItem<byte> P4_13 => ZeroHzVoltageMode;
		#endregion
		#region P5组 别名
		public ConfigItem<byte> P5_00 => AccDecTimeUnit;
		public ConfigItem<byte> P5_01 => AccDecMode;
		public ConfigItem<ushort> P5_02 => AccTime1;
		public ConfigItem<ushort> P5_03 => DecTime1;
		public ConfigItem<ushort> P5_04 => AccTime2;
		public ConfigItem<ushort> P5_05 => DecTime2;
		public ConfigItem<ushort> P5_06 => AccTime3;
		public ConfigItem<ushort> P5_07 => DecTime3;
		public ConfigItem<ushort> P5_08 => AccTurnFreq1;
		public ConfigItem<ushort> P5_09 => AccTurnFreq2;
		public ConfigItem<ushort> P5_10 => AccTurnFreq3;
		public ConfigItem<ushort> P5_11 => DecTurnFreq1;
		public ConfigItem<ushort> P5_12 => DecTurnFreq2;
		public ConfigItem<ushort> P5_13 => DecTurnFreq3;
		public ConfigItem<ushort> P5_14 => JogFreq;
		public ConfigItem<ushort> P5_15 => JogAccTime;
		public ConfigItem<ushort> P5_16 => JogDecTime;
		public ConfigItem<ushort> P5_17 => JumpFreq1_Upper;
		public ConfigItem<ushort> P5_18 => JumpFreq1_Lower;
		public ConfigItem<ushort> P5_19 => JumpFreq2_Upper;
		public ConfigItem<ushort> P5_20 => JumpFreq2_Lower;
		public ConfigItem<ushort> P5_21 => JumpFreq3_Upper;
		public ConfigItem<ushort> P5_22 => JumpFreq3_Lower;
		#endregion
		#region P6组 别名
		public ConfigItem<byte> P6_00 => TerminalConfig;
		public ConfigItem<byte> P6_01 => X1Function;
		public ConfigItem<byte> P6_02 => X2Function;
		public ConfigItem<byte> P6_03 => X3Function;
		public ConfigItem<byte> P6_04 => X4Function;
		public ConfigItem<byte> P6_05 => X5Function;
		public ConfigItem<byte> P6_06 => X6Function;
		public ConfigItem<byte> P6_07 => AI1Function;
		public ConfigItem<byte> P6_08 => AI2Function;
		public ConfigItem<ushort> P6_09 => InputLevel1;
		public ConfigItem<ushort> P6_10 => InputLevel2;
		public ConfigItem<float> P6_11 => TerminalFilterTime;
		public ConfigItem<float> P6_12 => X1Delay;
		public ConfigItem<float> P6_13 => X2Delay;
		public ConfigItem<float> P6_14 => AI1Gain;
		public ConfigItem<float> P6_15 => AI1Offset;
		public ConfigItem<float> P6_16 => AI1Filter;
		public ConfigItem<byte> P6_17 => AI1CurveSelect;
		public ConfigItem<float> P6_18 => AI1Point1;
		public ConfigItem<float> P6_19 => AI1Point1Set;
		public ConfigItem<float> P6_20 => AI1Point2;
		public ConfigItem<float> P6_21 => AI1Point2Set;
		public ConfigItem<float> P6_22 => AI2Gain;
		public ConfigItem<float> P6_23 => AI2Offset;
		public ConfigItem<float> P6_24 => AI2Filter;
		public ConfigItem<byte> P6_25 => AI2CurveSelect;
		public ConfigItem<float> P6_26 => AI2Point1;
		public ConfigItem<float> P6_27 => AI2Point1Set;
		public ConfigItem<float> P6_28 => AI2Point2;
		public ConfigItem<float> P6_29 => AI2Point2Set;
		public ConfigItem<float> P6_30 => PFIFilter;
		public ConfigItem<float> P6_31 => PFILow;
		public ConfigItem<float> P6_32 => PFILowSet;
		public ConfigItem<float> P6_33 => PFIHigh;
		public ConfigItem<float> P6_34 => PFIHighSet;
		#endregion
		#region P7组 别名
		public ConfigItem<byte> P7_00 => PFOEnable;
		public ConfigItem<byte> P7_01 => Y1Function;
		public ConfigItem<byte> P7_02 => Y2Function;
		public ConfigItem<byte> P7_03 => RFunction;
		public ConfigItem<ushort> P7_04 => OutputLevel;
		public ConfigItem<float> P7_05 => Y1Delay;
		public ConfigItem<float> P7_06 => Y2Delay;
		public ConfigItem<float> P7_07 => RDelay;
		public ConfigItem<byte> P7_08 => AO1Function;
		public ConfigItem<float> P7_09 => AO1Gain;
		public ConfigItem<float> P7_10 => AO1Offset;
		public ConfigItem<float> P7_11 => AO1Filter;
		public ConfigItem<byte> P7_12 => PFOFunction;
		public ConfigItem<float> P7_13 => PFOFilter;
		public ConfigItem<float> P7_14 => PFOLow;
		public ConfigItem<float> P7_15 => PFOLowSet;
		public ConfigItem<float> P7_16 => PFOHigh;
		public ConfigItem<float> P7_17 => PFOHighSet;
		#endregion
		#region P8组 别名
		public ConfigItem<float> P8_00 => MultiStep0;
		public ConfigItem<float> P8_01 => MultiStep1;
		public ConfigItem<float> P8_02 => MultiStep2;
		public ConfigItem<float> P8_03 => MultiStep3;
		public ConfigItem<float> P8_04 => MultiStep4;
		public ConfigItem<float> P8_05 => MultiStep5;
		public ConfigItem<float> P8_06 => MultiStep6;
		public ConfigItem<float> P8_07 => MultiStep7;
		public ConfigItem<float> P8_08 => MultiStep8;
		public ConfigItem<float> P8_09 => MultiStep9;
		public ConfigItem<float> P8_10 => MultiStep10;
		public ConfigItem<float> P8_11 => MultiStep11;
		public ConfigItem<float> P8_12 => MultiStep12;
		public ConfigItem<float> P8_13 => MultiStep13;
		public ConfigItem<float> P8_14 => MultiStep14;
		public ConfigItem<float> P8_15 => MultiStep15;
		public ConfigItem<byte> P8_16 => MultiStep0Source;
		public ConfigItem<byte> P8_17 => MultiStep1Source;
		#endregion
		#region P9组 别名
		public ConfigItem<ushort> P9_00 => PLCConfig;
		public ConfigItem<byte> P9_01 => PLCStep0Config;
		public ConfigItem<float> P9_02 => PLCStep0Time;
		public ConfigItem<byte> P9_03 => PLCStep1Config;
		public ConfigItem<float> P9_04 => PLCStep1Time;
		public ConfigItem<byte> P9_05 => PLCStep2Config;
		public ConfigItem<float> P9_06 => PLCStep2Time;
		public ConfigItem<byte> P9_07 => PLCStep3Config;
		public ConfigItem<float> P9_08 => PLCStep3Time;
		public ConfigItem<byte> P9_09 => PLCStep4Config;
		public ConfigItem<float> P9_10 => PLCStep4Time;
		public ConfigItem<byte> P9_11 => PLCStep5Config;
		public ConfigItem<float> P9_12 => PLCStep5Time;
		public ConfigItem<byte> P9_13 => PLCStep6Config;
		public ConfigItem<float> P9_14 => PLCStep6Time;
		public ConfigItem<byte> P9_15 => PLCStep7Config;
		public ConfigItem<float> P9_16 => PLCStep7Time;
		public ConfigItem<byte> P9_17 => PLCStep8Config;
		public ConfigItem<float> P9_18 => PLCStep8Time;
		public ConfigItem<byte> P9_19 => PLCStep9Config;
		public ConfigItem<float> P9_20 => PLCStep9Time;
		public ConfigItem<byte> P9_21 => PLCStep10Config;
		public ConfigItem<float> P9_22 => PLCStep10Time;
		public ConfigItem<byte> P9_23 => PLCStep11Config;
		public ConfigItem<float> P9_24 => PLCStep11Time;
		public ConfigItem<byte> P9_25 => PLCStep12Config;
		public ConfigItem<float> P9_26 => PLCStep12Time;
		public ConfigItem<byte> P9_27 => PLCStep13Config;
		public ConfigItem<float> P9_28 => PLCStep13Time;
		public ConfigItem<byte> P9_29 => PLCStep14Config;
		public ConfigItem<float> P9_30 => PLCStep14Time;
		public ConfigItem<byte> P9_31 => PLCStep15Config;
		public ConfigItem<float> P9_32 => PLCStep15Time;
		#endregion
		#region PA组 别名
		public ConfigItem<byte> PA_00 => PIDStrategy;
		public ConfigItem<byte> PA_01 => PIDSetpointSource;
		public ConfigItem<float> PA_02 => PIDDigitalSetpoint;
		public ConfigItem<byte> PA_03 => PIDFeedbackSource;
		public ConfigItem<byte> PA_04 => PIDDirection;
		public ConfigItem<float> PA_05 => PIDSampleTime;
		public ConfigItem<float> PA_06 => PIDKp1;
		public ConfigItem<float> PA_07 => PIDTi1;
		public ConfigItem<float> PA_08 => PIDTd1;
		public ConfigItem<float> PA_09 => PIDBiasLimit;
		public ConfigItem<float> PA_10 => PIDDerivativeFilter;
		public ConfigItem<float> PA_11 => PIDSetpointRamp;
		public ConfigItem<float> PA_12 => PIDFeedbackFilter;
		public ConfigItem<float> PA_13 => PIDOutputFilter;
		public ConfigItem<float> PA_14 => PIDKp2;
		public ConfigItem<float> PA_15 => PIDTi2;
		public ConfigItem<float> PA_16 => PIDTd2;
		public ConfigItem<byte> PA_17 => PIDParamSwitch;
		public ConfigItem<float> PA_18 => PIDSwitchBias1;
		public ConfigItem<float> PA_19 => PIDSwitchBias2;
		public ConfigItem<float> PA_20 => PIDInitialValue;
		public ConfigItem<float> PA_21 => PIDInitialHold;
		public ConfigItem<byte> PA_22 => PIDIntegralMode;
		public ConfigItem<float> PA_23 => PIDFeedbackLossValue;
		public ConfigItem<float> PA_24 => PIDFeedbackLossTime;
		public ConfigItem<float> PA_25 => PIDFeedbackHighValue;
		public ConfigItem<float> PA_26 => PIDFeedbackHighTime;
		public ConfigItem<byte> PA_27 => PIDStopOperation;
		public ConfigItem<byte> PA_28 => PIDStabilityResponse;
		public ConfigItem<float> PA_29 => PIDUpperLimit;
		public ConfigItem<float> PA_30 => PIDLowerLimit;
		#endregion
		#region Pb组 别名
		public ConfigItem<byte> Pb_00 => SwingConfig;
		public ConfigItem<float> Pb_01 => SwingAmplitude;
		public ConfigItem<float> Pb_02 => SwingJump;
		public ConfigItem<float> Pb_03 => SwingPeriod;
		public ConfigItem<float> Pb_04 => SwingRiseFactor;
		public ConfigItem<float> Pb_05 => LengthSet;
		public ConfigItem<float> Pb_06 => LengthActual;
		public ConfigItem<float> Pb_07 => PulsePerMeter;
		public ConfigItem<ushort> Pb_08 => CountSet;
		public ConfigItem<ushort> Pb_09 => CountPreset;
		#endregion
		#region PC组 别名
		public ConfigItem<byte> PC_00 => DeviceAddress;
		public ConfigItem<ushort> PC_01 => CommConfig;
		public ConfigItem<float> PC_02 => CommTimeout;
		public ConfigItem<float> PC_03 => SlaveResponseDelay;
		public ConfigItem<byte> PC_04 => MasterSlaveMode;
		public ConfigItem<byte> PC_05 => MasterOperation;
		public ConfigItem<float> PC_06 => MasterCommPeriod;
		public ConfigItem<float> PC_07 => SlaveReceiveFactor;
		#endregion
		#region Pd组 别名
		public ConfigItem<byte> Pd_00 => MFKeyFunction;
		public ConfigItem<byte> Pd_01 => StopResetFunction;
		public ConfigItem<ushort> Pd_02 => StopDisplaySelect;
		public ConfigItem<ushort> Pd_03 => RunDisplaySelect;
		public ConfigItem<ushort> Pd_04 => CustomDisplayGroup;
		public ConfigItem<ushort> Pd_05 => CustomDisplay1;
		public ConfigItem<ushort> Pd_06 => CustomDisplay2;
		public ConfigItem<ushort> Pd_07 => CustomDisplay3;
		public ConfigItem<ushort> Pd_08 => CustomDisplay4;
		public ConfigItem<byte> Pd_09 => CopyAction;
		public ConfigItem<ushort> Pd_10 => UserPassword;
		#endregion
		#region PE组 别名
		public ConfigItem<byte> PE_00 => EnergyBrakeEnable;
		public ConfigItem<ushort> PE_01 => EnergyBrakeVoltage;
		public ConfigItem<ushort> PE_02 => BrakeDutyStatistic;
		public ConfigItem<byte> PE_03 => OverVoltageStallSelect;
		public ConfigItem<ushort> PE_04 => OverVoltageStallPoint;
		public ConfigItem<byte> PE_05 => PowerLossStallEnable;
		public ConfigItem<ushort> PE_06 => PowerLossStallVoltage;
		public ConfigItem<ushort> PE_07 => PowerLossRecoverTime;
		public ConfigItem<ushort> PE_08 => PowerLossStallStrength;
		public ConfigItem<byte> PE_09 => UnderVoltageFreqLimitEnable;
		public ConfigItem<ushort> PE_10 => BusUnderVoltagePoint;
		public ConfigItem<ushort> PE_11 => BusOverVoltagePoint;
		#endregion
		#region PF组 别名
		public ConfigItem<ushort> PF_00 => MotorOverloadWarnValue;
		public ConfigItem<ushort> PF_01 => MotorOverloadWarnTime;
		public ConfigItem<byte> PF_02 => MotorOverloadWarnAction;
		public ConfigItem<ushort> PF_03 => MotorOverloadTripValue;
		public ConfigItem<ushort> PF_04 => MotorOverloadTripTime;
		public ConfigItem<byte> PF_05 => MotorTempChannel;
		public ConfigItem<ushort> PF_06 => MotorOverTempTrip;
		public ConfigItem<ushort> PF_07 => MotorOverTempWarnValue;
		public ConfigItem<ushort> PF_08 => MotorOverTempWarnTime;
		public ConfigItem<byte> PF_09 => MotorOverTempWarnAction;
		public ConfigItem<ushort> PF_10 => TorqueProtectUpper;
		public ConfigItem<ushort> PF_11 => TorqueUpperDetectTime;
		#endregion
		#region A0组 别名
		public ConfigItem<byte> A0_00 => PowerOnTerminalProtect;
		public ConfigItem<ushort> A0_01 => SleepFrequency;
		public ConfigItem<ushort> A0_02 => SleepDelay;
		public ConfigItem<ushort> A0_03 => WakeFrequency;
		public ConfigItem<ushort> A0_04 => WakeDelay;
		public ConfigItem<byte> A0_05 => TimerUnit;
		public ConfigItem<ushort> A0_06 => RunTimerSetting;
		public ConfigItem<ushort> A0_07 => ZeroCurrentWidth;
		public ConfigItem<ushort> A0_08 => ZeroCurrentDelay;
		public ConfigItem<ushort> A0_09 => CurrentLimitDetect;
		public ConfigItem<ushort> A0_10 => CurrentLimitDelay;
		public ConfigItem<ushort> A0_11 => AnyCurrentDetect1;
		public ConfigItem<ushort> A0_12 => AnyCurrentWidth1;
		public ConfigItem<ushort> A0_13 => AnyCurrentDetect2;
		public ConfigItem<ushort> A0_14 => AnyCurrentWidth2;
		public ConfigItem<ushort> A0_15 => TargetFreqArrival;
		public ConfigItem<ushort> A0_16 => FDT1Value;
		public ConfigItem<ushort> A0_17 => FDT1Width;
		public ConfigItem<ushort> A0_18 => FDT2Value;
		public ConfigItem<ushort> A0_19 => FDT2Width;
		public ConfigItem<ushort> A0_20 => AnyFreqDetect1;
		public ConfigItem<ushort> A0_21 => AnyFreqWidth1;
		public ConfigItem<ushort> A0_22 => AnyFreqDetect2;
		public ConfigItem<ushort> A0_23 => AnyFreqWidth2;
		public ConfigItem<byte> A0_24 => AIDetectConfig;
		public ConfigItem<ushort> A0_25 => AIOverLimitValue;
		public ConfigItem<ushort> A0_26 => AILossValue;
		public ConfigItem<byte> A0_27 => AIInputAccuracy;
		public ConfigItem<byte> A0_28 => MultiStepMode;
		public ConfigItem<ushort> A0_29 => EnergyCalibCoeff;
		public ConfigItem<ushort> A0_30 => EnergyPrice;
		public ConfigItem<ushort> A0_31 => EnergyCostLow;
		public ConfigItem<ushort> A0_32 => EnergyCostHigh;
		public ConfigItem<ushort> A0_33 => MotorSwitchTime;
		public ConfigItem<byte> A0_34 => CommFreqMode;
		#endregion
		#region A1组 别名
		public ConfigItem<ushort> A1_00 => AI1CurvePoint0Value;
		public ConfigItem<short> A1_01 => AI1CurvePoint0Setting;
		public ConfigItem<ushort> A1_02 => AI1CurvePoint1Value;
		public ConfigItem<short> A1_03 => AI1CurvePoint1Setting;
		public ConfigItem<ushort> A1_04 => AI1CurvePoint2Value;
		public ConfigItem<short> A1_05 => AI1CurvePoint2Setting;
		public ConfigItem<ushort> A1_06 => AI1CurvePoint3Value;
		public ConfigItem<short> A1_07 => AI1CurvePoint3Setting;
		public ConfigItem<ushort> A1_08 => AI2CurvePoint0Value;
		public ConfigItem<short> A1_09 => AI2CurvePoint0Setting;
		public ConfigItem<ushort> A1_10 => AI2CurvePoint1Value;
		public ConfigItem<short> A1_11 => AI2CurvePoint1Setting;
		public ConfigItem<ushort> A1_12 => AI2CurvePoint2Value;
		public ConfigItem<short> A1_13 => AI2CurvePoint2Setting;
		public ConfigItem<ushort> A1_14 => AI2CurvePoint3Value;
		public ConfigItem<short> A1_15 => AI2CurvePoint3Setting;
		#endregion
		#region A2组 别名
		public ConfigItem<byte> A2_00 => VirtualVDI1Func;
		public ConfigItem<byte> A2_01 => VirtualVDI2Func;
		public ConfigItem<byte> A2_02 => VirtualVDI3Func;
		public ConfigItem<byte> A2_03 => VirtualVDI4Func;
		public ConfigItem<ushort> A2_04 => VirtualVDILink;
		public ConfigItem<ushort> A2_05 => VirtualVDIState;
		public ConfigItem<byte> A2_06 => VirtualVDO1Func;
		public ConfigItem<byte> A2_07 => VirtualVDO2Func;
		public ConfigItem<byte> A2_08 => VirtualVDO3Func;
		public ConfigItem<byte> A2_09 => VirtualVDO4Func;
		public ConfigItem<ushort> A2_10 => VirtualVDO1Delay;
		public ConfigItem<ushort> A2_11 => VirtualVDO2Delay;
		public ConfigItem<ushort> A2_12 => VirtualVDO3Delay;
		public ConfigItem<ushort> A2_13 => VirtualVDO4Delay;
		public ConfigItem<ushort> A2_14 => VirtualVDOActiveLevel;
		#endregion
		#region A3组 别名
		public ConfigItem<ushort> A3_00 => AddressMappingEnable;
		public ConfigItem<ushort> A3_01 => ParamOriginalAddr1;
		public ConfigItem<ushort> A3_02 => ParamMappedAddr1;
		public ConfigItem<ushort> A3_03 => ParamOriginalAddr2;
		public ConfigItem<ushort> A3_04 => ParamMappedAddr2;
		public ConfigItem<ushort> A3_05 => ParamOriginalAddr3;
		public ConfigItem<ushort> A3_06 => ParamMappedAddr3;
		public ConfigItem<ushort> A3_07 => ParamOriginalAddr4;
		public ConfigItem<ushort> A3_08 => ParamMappedAddr4;
		public ConfigItem<ushort> A3_09 => ParamOriginalAddr5;
		public ConfigItem<ushort> A3_10 => ParamMappedAddr5;
		public ConfigItem<ushort> A3_11 => ParamOriginalAddr6;
		public ConfigItem<ushort> A3_12 => ParamMappedAddr6;
		public ConfigItem<ushort> A3_13 => ParamOriginalAddr7;
		public ConfigItem<ushort> A3_14 => ParamMappedAddr7;
		public ConfigItem<ushort> A3_15 => ParamOriginalAddr8;
		public ConfigItem<ushort> A3_16 => ParamMappedAddr8;
		#endregion
		#region A4组 别名
		public ConfigItem<byte> A4_00 => CommonParamAutoRecord;
		public ConfigItem<ushort> A4_01 => CommonParam1;
		public ConfigItem<ushort> A4_02 => CommonParam2;
		public ConfigItem<ushort> A4_03 => CommonParam3;
		public ConfigItem<ushort> A4_04 => CommonParam4;
		public ConfigItem<ushort> A4_05 => CommonParam5;
		public ConfigItem<ushort> A4_06 => CommonParam6;
		public ConfigItem<ushort> A4_07 => CommonParam7;
		public ConfigItem<ushort> A4_08 => CommonParam8;
		public ConfigItem<ushort> A4_09 => CommonParam9;
		public ConfigItem<ushort> A4_10 => CommonParam10;
		public ConfigItem<ushort> A4_11 => CommonParam11;
		public ConfigItem<ushort> A4_12 => CommonParam12;
		public ConfigItem<ushort> A4_13 => CommonParam13;
		public ConfigItem<ushort> A4_14 => CommonParam14;
		public ConfigItem<ushort> A4_15 => CommonParam15;
		public ConfigItem<ushort> A4_16 => CommonParam16;
		public ConfigItem<ushort> A4_17 => CommonParam17;
		public ConfigItem<ushort> A4_18 => CommonParam18;
		public ConfigItem<ushort> A4_19 => CommonParam19;
		public ConfigItem<ushort> A4_20 => CommonParam20;
		#endregion
		#region U0组 别名
		public ConfigItem<ushort> U0_00 => RunFrequency;
		public ConfigItem<ushort> U0_01 => SetFrequency;
		public ConfigItem<ushort> U0_02 => BusVoltage;
		public ConfigItem<ushort> U0_03 => OutputVoltage;
		public ConfigItem<ushort> U0_04 => OutputCurrent;
		public ConfigItem<ushort> U0_05 => OutputFrequency;
		public ConfigItem<short> U0_06 => SetTorque;
		public ConfigItem<short> U0_07 => OutputTorque;
		public ConfigItem<short> U0_08 => OutputPower;
		public ConfigItem<ushort> U0_09 => MotorSpeed;
		public ConfigItem<short> U0_10 => HeatsinkTemp;
		public ConfigItem<short> U0_11 => MotorTemp;
		public ConfigItem<ushort> U0_12 => RunStatus;
		public ConfigItem<ushort> U0_13 => AI1Voltage;
		public ConfigItem<ushort> U0_14 => AI2Voltage;
		public ConfigItem<ushort> U0_15 => InputTerminalStatus;
		public ConfigItem<ushort> U0_16 => OutputTerminalStatus;
		public ConfigItem<ushort> U0_17 => PulseInputPFI;
		public ConfigItem<ushort> U0_18 => AO1Output;
		public ConfigItem<ushort> U0_19 => PulseOutputPFO;
		public ConfigItem<byte> U0_20 => VirtualVDIStatus;
		public ConfigItem<byte> U0_21 => VirtualVDOStatus;
		public ConfigItem<ushort> U0_22 => RunTimeHours;
		public ConfigItem<byte> U0_23 => RunTimeMinutes;
		public ConfigItem<byte> U0_24 => PIDSet;
		public ConfigItem<byte> U0_25 => PIDFeedback;
		public ConfigItem<ushort> U0_26 => CounterValue;
		public ConfigItem<ushort> U0_27 => LengthValue;
		public ConfigItem<ushort> U0_28 => PowerOnTimeLow;
		public ConfigItem<ushort> U0_29 => PowerOnTimeHigh;
		public ConfigItem<byte> U0_30 => VFSeparatedTargetVoltage;
		public ConfigItem<byte> U0_31 => VFSeparatedOutputVoltage;
		public ConfigItem<byte> U0_32 => PLCStage;
		public ConfigItem<ushort> U0_33 => PLCTime;
		public ConfigItem<ushort> U0_34 => EnergyLow;
		public ConfigItem<ushort> U0_35 => EnergyHigh;
		public ConfigItem<short> U0_36 => UpDnBias;
		public ConfigItem<ushort> U0_37 => SystemWord;
		#endregion
		#region U1组 别名
		public ConfigItem<byte> U1_00 => CurrentFaultIndex;
		public ConfigItem<byte> U1_01 => Fault1Index;
		public ConfigItem<ushort> U1_02 => Fault1RunFreq;
		public ConfigItem<ushort> U1_03 => Fault1OutFreq;
		public ConfigItem<ushort> U1_04 => Fault1OutCurrent;
		public ConfigItem<ushort> U1_05 => Fault1BusVoltH;
		public ConfigItem<ushort> U1_06 => Fault1BusVoltL;
		public ConfigItem<ushort> U1_07 => Fault1BusVolt;
		public ConfigItem<short> U1_08 => Fault1ModuleTemp;
		public ConfigItem<ushort> U1_09 => Fault1InputStatus;
		public ConfigItem<ushort> U1_10 => Fault1RunHours;
		public ConfigItem<byte> U1_11 => Fault2Index;
		public ConfigItem<ushort> U1_12 => Fault2RunFreq;
		public ConfigItem<ushort> U1_13 => Fault2OutFreq;
		public ConfigItem<ushort> U1_14 => Fault2OutCurrent;
		public ConfigItem<ushort> U1_15 => Fault2BusVoltH;
		public ConfigItem<ushort> U1_16 => Fault2BusVoltL;
		public ConfigItem<ushort> U1_17 => Fault2BusVolt;
		public ConfigItem<short> U1_18 => Fault2ModuleTemp;
		public ConfigItem<ushort> U1_19 => Fault2InputStatus;
		public ConfigItem<ushort> U1_20 => Fault2RunHours;
		public ConfigItem<byte> U1_21 => Fault3Index;
		public ConfigItem<ushort> U1_22 => Fault3RunFreq;
		public ConfigItem<ushort> U1_23 => Fault3OutFreq;
		public ConfigItem<ushort> U1_24 => Fault3OutCurrent;
		public ConfigItem<ushort> U1_25 => Fault3BusVoltH;
		public ConfigItem<ushort> U1_26 => Fault3BusVoltL;
		public ConfigItem<ushort> U1_27 => Fault3BusVolt;
		public ConfigItem<short> U1_28 => Fault3ModuleTemp;
		public ConfigItem<ushort> U1_29 => Fault3InputStatus;
		public ConfigItem<ushort> U1_30 => Fault3RunHours;
		public ConfigItem<byte> U1_31 => Fault4Index;
		public ConfigItem<byte> U1_32 => Fault5Index;
		public ConfigItem<byte> U1_33 => Fault6Index;
		public ConfigItem<byte> U1_34 => Fault7Index;
		public ConfigItem<byte> U1_35 => Fault8Index;
		public ConfigItem<byte> U1_36 => Fault9Index;
		public ConfigItem<byte> U1_37 => Fault10Index;
		#endregion
		#region n1组 别名
		public ConfigItem<ushort> n1_00 => DealerPassword;
		public ConfigItem<ushort> n1_01 => DealerRunTimeSetting;
		public ConfigItem<byte> n1_02 => DealerCommand;
		#endregion
    }
}
