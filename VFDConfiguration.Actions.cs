using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;
using System.Net;

namespace LibSciyonVFD
{
    public partial class VFDConfiguration
    {
        // Dictionary of alias references indexed by string like "P0-00".
        // Built via reflection so it automatically includes all alias properties
        // with the naming pattern Group_DD (e.g. P0_00, A1_12, n1_02).
        private Dictionary<string, IConfigType> _aliasByCode;
        public Dictionary<string, IConfigType> ByCode => _aliasByCode ?? (_aliasByCode = BuildAliasDictionary());

        private Dictionary<string, IConfigType> BuildAliasDictionary()
        {
            var dict = new Dictionary<string, IConfigType>();
            var props = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in props)
            {
                var name = p.Name;
                if (string.IsNullOrEmpty(name)) continue;
                var parts = name.Split('_');
                if (parts.Length != 2) continue;
                var suffix = parts[1];
                // only accept two-digit numeric suffix like "00", "01", ...
                if (suffix.Length != 2) continue;
                if (!char.IsDigit(suffix[0]) || !char.IsDigit(suffix[1])) continue;
                var key = parts[0] + "-" + suffix;
                var val = (IConfigType)p.GetValue(this);
                dict[key] = val;
            }
            return dict;
        }

        /// <summary>
        /// 将配置按组序列化为INI文件。每个组为一个节，键为两位序号（例如"00"），值为功能码的当前值。
        /// </summary>
        public void Serialize(string path)
        {
            var groups = new Dictionary<string, List<KeyValuePair<string, object>>>();
            foreach (var kv in ByCode)
            {
                var parts = kv.Key.Split('-');
                if (parts.Length != 2) continue;
                var section = parts[0];
                var key = parts[1];
                if (!groups.TryGetValue(section, out var list))
                {
                    list = new List<KeyValuePair<string, object>>();
                    groups[section] = list;
                }
                list.Add(new KeyValuePair<string, object>(key, kv.Value));
            }

            var sb = new StringBuilder();
            foreach (var g in groups.OrderBy(g => g.Key))
            {
                sb.AppendLine("[" + g.Key + "]");
                foreach (var kv in g.Value.OrderBy(i => i.Key))
                {
                    var item = kv.Value;
                    var fi = item.GetType().GetField("Value");
                    object val = fi?.GetValue(item);
                    string sval;
                    if (val == null) sval = string.Empty;
                    else if (val is float f) sval = f.ToString(CultureInfo.InvariantCulture);
                    else if (val is double d) sval = d.ToString(CultureInfo.InvariantCulture);
                    else sval = Convert.ToString(val, CultureInfo.InvariantCulture);
                    sb.AppendLine(kv.Key + "=" + sval);
                }
                sb.AppendLine();
            }

            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// 从INI文件反序列化并设置配置项的Value字段（只对存在的键生效）。
        /// </summary>
        public void Deserialize(string path)
        {
            if (!File.Exists(path)) return;
            string currentSection = null;
            foreach (var raw in File.ReadAllLines(path, Encoding.UTF8))
            {
                var line = raw.Trim();
                if (line.Length == 0) continue;
                if (line.StartsWith(";") || line.StartsWith("#")) continue;
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    currentSection = line.Substring(1, line.Length - 2).Trim();
                    continue;
                }
                if (currentSection == null) continue;
                var idx = line.IndexOf('=');
                if (idx <= 0) continue;
                var key = line.Substring(0, idx).Trim();
                var valstr = line.Substring(idx + 1).Trim();
                var fullKey = currentSection + "-" + key;
                if (!ByCode.TryGetValue(fullKey, out var item)) continue;
                var fi = item.GetType().GetField("Value");
                if (fi == null) continue;
                var targetType = fi.FieldType;
                try
                {
                    object parsed;
                    if (targetType == typeof(float)) parsed = float.Parse(valstr, CultureInfo.InvariantCulture);
                    else if (targetType == typeof(double)) parsed = double.Parse(valstr, CultureInfo.InvariantCulture);
                    else parsed = Convert.ChangeType(valstr, targetType, CultureInfo.InvariantCulture);
                    fi.SetValue(item, parsed);
                }
                catch
                {
                    // 忽略解析/设置错误
                }
            }
        }

        public void SyncFrom(VFDConfiguration conf, params string[]? skips)
        {
            foreach(IConfigType confitem in conf.ByCode.Values)
            {
                var item = (confitem.ValueType())confitem;
                if(ByCode.ContainsKey(confitem)
            }
        }
    }
}
