using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace LibSciyonVFD
{
    public class ConfigItem<T>
    {
        /// <summary>
        /// 功能码的值
        /// </summary>
        public T Value;
        /// <summary>
        /// 功能码的默认值
        /// </summary>
        public T DefaultValue { get; internal set; }
        /// <summary>
        /// 功能码地址索引
        /// </summary>
        public ConfigIndex Index { get; internal set; }
        /// <summary>
        /// 功能码的功能描述
        /// </summary>
        public string Discription { get; internal set; }
        /// <summary>
        /// 功能码是否有确定的默认值
        /// </summary>
        public bool HasDefaultValue { get; internal set; }

        /// <summary>
        /// 功能码是否是只读的
        /// </summary>
        public ReadOnly IsReadonly { get; internal set; }

        public ConfigItem(T value, ConfigIndex index, string discription, ReadOnly readonly_ = ReadOnly.Never)
        {
            Value = value;
            Index = index;
            Discription = discription;
            HasDefaultValue = false;
            IsReadonly = readonly_;
        }

        public ConfigItem(T value, ConfigIndex index, string discription, T defaultvalue, ReadOnly readonly_ = ReadOnly.Never)
        {
            Value = value;
            Index = index;
            Discription = discription;
            HasDefaultValue = false;
            Discription = discription;
            HasDefaultValue = true;
            IsReadonly = readonly_;
        }
    }

    public enum ReadOnly
    {
        Always = 0,
        WhenRuning = 1,
        Never = 2
    }
}
