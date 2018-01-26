using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// 32-bit unsigned integer, 4 bytes 
    /// </summary>
    public abstract class AOptionUint32 : Option
    {
        /// <inheritdoc />
        public uint Value { get; set; }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            if (raw.Length != 4)
            {
                throw new OptionLengthNotExactException("Length is not 4");
            }

            Value = BitConverter.ToUInt32(raw, 0);
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