using System;
using System.Collections.Generic;
using System.Text;

namespace LibSciyonVFD
{
    public class ConfigIndex : IEquatable<ConfigIndex>,IEquatable<string>
    {
        /// <summary>
        /// 主功能域和子序列号，例如P0-17中的P0部分
        /// </summary>
        public string CodeDomain { get; internal set; }
        /// <summary>
        /// 功能码索引号，例如P0-17中的17部分，写成16进制0x17
        /// </summary>
        public byte CodeId { get; internal set; }
        /// <summary>
        /// 功能码寄存器地址，计算得到
        /// </summary>
        public ushort CodeAddr
        {
            get
            {
                ushort ADDR = 0;
                // bit14~12 主功能域
                switch (CodeDomain[0])
                {
                    case 'P':
                        ADDR += 0x0000;
                        break;
                    case 'A':
                        ADDR += 0x1000;
                        break;
                    case 'E':
                        ADDR += 0x2000;
                        break;
                    case 'F':
                        ADDR += 0x3000;
                        break;
                    case 'H':
                        ADDR += 0x4000;
                        break;
                    case 'U':
                        ADDR += 0x5000;
                        break;
                }
                // bit11~8  子序列号
                switch (CodeDomain[1])
                {
                    case '0':
                        ADDR += 0x000;
                        break;
                    case '1':
                        ADDR += 0x100;
                        break;
                    case '2':
                        ADDR += 0x200;
                        break;
                    case '3':
                        ADDR += 0x300;
                        break;
                    case '4':
                        ADDR += 0x400;
                        break;
                    case '5':
                        ADDR += 0x500;
                        break;
                    case '6':
                        ADDR += 0x600;
                        break;
                    case '7':
                        ADDR += 0x700;
                        break;
                    case '8':
                        ADDR += 0x800;
                        break;
                    case '9':
                        ADDR += 0x900;
                        break;
                    case 'A':
                        ADDR += 0xA00;
                        break;
                    case 'B':
                        ADDR += 0xB00;
                        break;
                    case 'C':
                        ADDR += 0xC00;
                        break;
                    case 'D':
                        ADDR += 0xD00;
                        break;
                    case 'E':
                        ADDR += 0xE00;
                        break;
                    case 'F':
                        ADDR += 0xF00;
                        break;
                }
                // bit7~0   索引号
                ADDR += CodeId;
                return ADDR;
            }
        }

        public ConfigIndex(string codedomain, byte codeid)
        {
            CodeDomain = codedomain;
            CodeId = codeid;
        }

        public ConfigIndex(string indexstr)
        {
            CodeDomain = indexstr.Substring(0, 2);
            CodeId = Convert.ToByte(indexstr.Substring(3), 16);
        }

        public override string ToString()
        {
            return CodeDomain + "-" + CodeId.ToString("X2");
        }

        public bool Equals(ConfigIndex other)
        {
            return CodeDomain.Equals(other.CodeDomain) && CodeId.Equals(other.CodeId);
        }

        public bool Equals(string other)
        {
            return ToString().Equals(other);
        }
    }
}
