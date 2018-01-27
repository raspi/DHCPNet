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
        public NetworkBinaryReader(Stream input)
            : base(input)
        {
        }

        public NetworkBinaryReader(Stream input, Encoding encoding)
            : base(input, encoding)
        {
        }

        public NetworkBinaryReader(Stream input, Encoding encoding, bool leaveOpen)
            : base(input, encoding, leaveOpen)
        {
        }

        /// <summary>
        /// 
        /// </summary>
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

            Debug.WriteLine("Read: " + dtmp);
            Debug.WriteLine(string.Format("Offset: 0x{0:x2} ({0:D4})", this.BaseStream.Position));
#endif

            return tmp;
        }

        public override uint ReadUInt32()
        {
            byte[] tmp = ReadBytes(4);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(tmp);
            }

            return BitConverter.ToUInt32(tmp, 0);
        }

        public override ushort ReadUInt16()
        {
            byte[] tmp = ReadBytes(2);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(tmp);
            }

            return BitConverter.ToUInt16(tmp, 0);
        }

    }

}
