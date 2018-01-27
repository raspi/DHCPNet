using System;
using System.IO;

namespace DHCPNet
{
    using System.Diagnostics;

    /// <summary>
    /// The network binary writer.
    /// <see cref="NetworkBinaryReader"/>
    /// </summary>
    public class NetworkBinaryWriter : BinaryWriter
    {
        /// <summary>
        /// 
        /// </summary>
        public NetworkBinaryWriter(Stream output) : base(output)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Write(byte[] buffer, int index, int count)
        {
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(buffer);
            }

#if DEBUG
            string dtmp = string.Empty;

            for (var idx = index; idx < count; idx++)
            {
                var i = buffer[idx];
                dtmp += string.Format("{0:X2} ", i);
            }

            Debug.WriteLine(string.Format("NBW::Writing: <{0}>", dtmp));
            Debug.WriteLine(string.Format("NBW::Length: {0:D3} Offset: 0x{1:x4} ({1:D4})", count, this.BaseStream.Position));
#endif

            base.Write(buffer, index, count);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Write(byte[] buffer)
        {
            this.Write(buffer, 0, buffer.Length);
        }

        public override void Write(byte b)
        {
            this.Write(new byte[] { b }, 0, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Write(uint value)
        {
            byte[] buffer = BitConverter.GetBytes(value);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buffer);
            }

            base.Write(buffer, 0, 4);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Write(ushort value)
        {
            byte[] buffer = BitConverter.GetBytes(value);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buffer);
            }

            base.Write(buffer, 0, 2);
        }

    }

}
