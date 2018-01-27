using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DHCPNet
{
    using System.Diagnostics;

    /// <summary>
    /// The network binary reader.
    /// <see cref="NetworkBinaryWriter"/>
    /// </summary>
    public class NetworkBinaryReader : BinaryReader
    {
        /// <inheritdoc />
        public NetworkBinaryReader(Stream input)
            : base(input)
        {
        }

        /// <inheritdoc />
        public NetworkBinaryReader(Stream input, Encoding encoding)
            : base(input, encoding)
        {
        }

        /// <inheritdoc />
        public NetworkBinaryReader(Stream input, Encoding encoding, bool leaveOpen)
            : base(input, encoding, leaveOpen)
        {
        }

        /// <inheritdoc />
        public override byte[] ReadBytes(int count)
        {
            byte[] tmp = base.ReadBytes(count);

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(tmp);
            }

#if DEBUG
            string dtmp = string.Empty;

            foreach (var i in tmp)
            {
                dtmp += string.Format("{0:x2} ", i);
            }

            Debug.WriteLine(string.Format("NBW::Reading: <{0}>", dtmp));
            Debug.WriteLine(string.Format("NBR::Length: {0:D3} Offset: 0x{1:x4} ({1:D4})", count, this.BaseStream.Position));
            Debug.WriteLine(string.Empty);
#endif

            return tmp;
        }

        /// <inheritdoc />
        public override byte ReadByte()
        {
            byte[] b = this.ReadBytes(1);
            return b[0];
        }

        /// <inheritdoc />
        public override uint ReadUInt32()
        {
            byte[] tmp = this.ReadBytes(4);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(tmp);
            }

            return BitConverter.ToUInt32(tmp, 0);
        }

        /// <inheritdoc />
        public override ushort ReadUInt16()
        {
            byte[] tmp = this.ReadBytes(2);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(tmp);
            }

            return BitConverter.ToUInt16(tmp, 0);
        }
    }
}
