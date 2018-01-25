namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Civic Addresses Configuration Information
    /// https://tools.ietf.org/html/rfc4776
    /// </summary>
    public class OptionCivicLocation : Option {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 99;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            if (raw.Length <= 3)
            {
                throw new OptionLengthException("Length must be at least 3.");
            }

            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}