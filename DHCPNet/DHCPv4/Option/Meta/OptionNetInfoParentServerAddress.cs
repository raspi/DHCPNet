namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Unused Dynamic Host Configuration Protocol (DHCP) Option Codes
    /// Never published in an RFC
    /// https://tools.ietf.org/html/rfc3679
    /// </summary>
    public class OptionNetInfoParentServerAddress : Option
    {
        public override void ReadRaw(byte[] raw)
        {
            throw new System.NotImplementedException();
        }

        public override byte Code
        {
            get
            {
                return 112;
            }
        }

        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}