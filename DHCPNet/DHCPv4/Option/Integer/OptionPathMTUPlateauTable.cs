using System;
using System.Collections.Generic;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies a table of MTU sizes to use when performing
    /// Path MTU Discovery as defined in RFC 1191. The table is formatted
    /// as a list of 16-bit unsigned integers, ordered from smallest to 
    /// largest. The minimum MTU value cannot be smaller than 68.
    /// 
    /// Length MUST be a multiple of 2 bytes.
    /// Minimum length 2 bytes
    /// </summary>
    public class OptionPathMTUPlateauTable : Option
    {
        /// <inheritdoc />
        public List<ushort> List = new List<ushort>();
        /// <inheritdoc />

        public OptionPathMTUPlateauTable()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 25;
            }
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            ushort[] source = List.ToArray();
            byte[] target = new byte[source.Length * 2];
            Buffer.BlockCopy(source, 0, target, 0, source.Length * 2);
            return target;
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionException("Zero length.");
            }

            if (raw.Length % 2 != 0)
            {
                throw new OptionException("Not divisiable by 2.");
            }

            for (int i = 0; i < raw.Length; i += 2)
            {
                List.Add(BitConverter.ToUInt16(raw, i));
            }
        }
    }
}