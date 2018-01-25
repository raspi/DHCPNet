namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Unused Dynamic Host Configuration Protocol (DHCP) Option Codes
    /// Never published in an RFC
    /// https://tools.ietf.org/html/rfc3679
    /// </summary>
    public class OptionNetInfoParentServerTag : Option
    {
        public override void ReadRaw(byte[] raw)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 113;
            }
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}