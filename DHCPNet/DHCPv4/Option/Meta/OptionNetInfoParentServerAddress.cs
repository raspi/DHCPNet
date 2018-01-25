namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Unused Dynamic Host Configuration Protocol (DHCP) Option Codes
    /// Never published in an RFC
    /// https://tools.ietf.org/html/rfc3679
    /// </summary>
    public class OptionNetInfoParentServerAddress : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 112;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
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