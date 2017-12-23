using System;
using System.IO;

namespace DHCPNet
{
    using System.Diagnostics;

    /// <summary>
    /// The network binary writer.
    /// </summary>
    public class NetworkBinaryWriter : BinaryWriter
    {
        public NetworkBinaryWriter(Stream output) : base(output)
        {
        }

        public override void Write(byte[] buffer)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buffer);
            }

            base.Write(buffer);
        }

        public override void Write(uint value)
        {
            byte[] buffer = BitConverter.GetBytes(value);

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(buffer);
            }

            base.Write(buffer);
        }

    }

}
