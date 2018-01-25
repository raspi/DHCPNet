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
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            if (raw.Length != 2)
            {
                throw new OptionLengthNotExactException("Length is not 2.");
            }

            Value = BitConverter.ToUInt16(raw, 0);
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return BitConverter.GetBytes(Value);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.Value.ToString();
        }

    }
}