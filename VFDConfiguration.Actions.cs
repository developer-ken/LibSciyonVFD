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
        private Dictionary<string,  ConfigItem> _aliasByCode;
        public Dictionary<string, ConfigItem> ByCode => _aliasByCode ?? (_aliasByCode = BuildAliasDictionary());

        private Dictionary<string, ConfigItem> BuildAliasDictionary()
        {
            // Generated implementation will replace reflection. The source generator
            // creates BuildAliasDictionary_Generated(VFDConfiguration) at compile time.
            return BuildAliasDictionary_Generated(this);
        }

        /// <summary>
        /// 将配置按组序列化为INI文件。每个组为一个节，键为两位序号（例如"00"），值为功能码的当前值。
        /// </summary>
        public void Serialize(string path)
        {
            var groups = new Dictionary<string, List<KeyValuePair<string, ConfigItem>>>();
            foreach (var kv in ByCode)
            {
                var parts = kv.Key.Split('-');
                if (parts.Length != 2) continue;
                var section = parts[0];
                var key = parts[1];
                if (!groups.TryGetValue(section, out var list))
                {
                    list = new List<KeyValuePair<string, ConfigItem>>();
                    groups[section] = list;
                }
                list.Add(new KeyValuePair<string, ConfigItem>(key, kv.Value));
            }

            var sb = new StringBuilder();
            foreach (var g in groups.OrderBy(g => g.Key))
            {
                sb.AppendLine("[" + g.Key + "]");
                foreach (var kv in g.Value.OrderBy(i => i.Key))
                {
                    sb.AppendLine(kv.Key + "=" + kv.Value.RawValue);
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
                item.RawValue = ushort.Parse(valstr, CultureInfo.InvariantCulture);
            }
        }

        public void CopyFrom(VFDConfiguration conf, params string[]? skips)
        {
            var skipSet = skips != null ? new HashSet<string>(skips) : new HashSet<string>();
            foreach (var kvp in conf.ByCode)
            {
                if (skipSet.Contains(kvp.Key)) continue;

                if (ByCode.TryGetValue(kvp.Key, out var targetItem))
                {
                    targetItem.RawValue = kvp.Value.RawValue;
                }
            }
        }
    }
}
