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
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}