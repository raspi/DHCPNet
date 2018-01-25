namespace DHCPNet.v4.Option
{
    /// <summary>
    /// CableLabs Client Configuration
    /// https://tools.ietf.org/html/rfc3495
    /// </summary>
    public class OptionCableLabsClientConfiguration : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 122;
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