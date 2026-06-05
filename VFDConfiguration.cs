using System;
using System.Collections.Generic;
using System.Text;

namespace LibSciyonVFD
{
    public class VFDConfiguration
    {
        // ---------------- P0 组：系统参数组 ----------------

        public ConfigItem<ushort> RatedPower = new ConfigItem<ushort>(0, new ConfigIndex("P0-00"), "变频器额定功率 (0.75~400kW)", ReadOnly.Always);
        public ConfigItem<ushort> RatedCurrent = new ConfigItem<ushort>(0, new ConfigIndex("P0-01"), "变频器额定电流（机型确定）", ReadOnly.Always);
        public ConfigItem<ushort> RatedVoltage = new ConfigItem<ushort>(0, new ConfigIndex("P0-02"), "变频器额定电压 (220/380/480/690/1140V)", ReadOnly.Always);
        public ConfigItem<byte> LoadType = new ConfigItem<byte>(1, new ConfigIndex("P0-03"), "GP类型显示：1=G型(恒转矩)，2=P型(风机/水泵)", ReadOnly.Always);
        public ConfigItem<ushort> FuncDisplayCtrl = new ConfigItem<ushort>(000, new ConfigIndex("P0-04"),
            "功能码显示控制\n百位：0=全部显示,1=控制策略优化\n十位：0=全部显示,1=显示修改项,2=A4组\n个位：0=允许修改,1=禁止修改",
            ReadOnly.WhenRuning);

    }
}
