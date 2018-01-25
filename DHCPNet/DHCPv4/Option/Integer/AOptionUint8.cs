namespace DHCPNet.v4.Option
{
    /// <summary>
    /// 8-bit unsigned integer
    /// </summary>
    public abstract class AOptionUint8 : Option
    {
        public byte Value;

        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            if (raw.Length != 1)
            {
                throw new OptionLengthNotExactException("Length is not 1.");
            }

            Value = raw[0];
        }

        public override byte[] GetRawBytes()
        {
            return new byte[] { Value };
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}