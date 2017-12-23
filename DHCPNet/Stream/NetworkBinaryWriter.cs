using System;
using System.IO;

namespace DHCPNet
{

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
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(buffer);
            }

            base.Write(buffer);
        }

        public override void Write(uint value)
        {
            Write(BitConverter.GetBytes(value));
        }
    }

}
