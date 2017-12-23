using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DHCPNet
{
    /// <summary>
    /// The network binary reader.
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

        public override byte[] ReadBytes(int count)
        {
            byte[] tmp = base.ReadBytes(count);

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(tmp);
            }

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
    }

}
