using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// 16-bit unsigned integer
    /// </summary>
    public abstract class AOptionUint16 : Option
    {
        /// <inheritdoc />
        public ushort Value;

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            Value = BitConverter.ToUInt16(raw, 0);
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return BitConverter.GetBytes(Value);
        }
    }
}