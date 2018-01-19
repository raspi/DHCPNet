namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Unused Dynamic Host Configuration Protocol (DHCP) Option Codes
    /// Never published in an RFC
    /// https://tools.ietf.org/html/rfc3679
    /// </summary>
    public class OptionUrl : AOptionString
    {
        public override byte Code
        {
            get
            {
                return 114;
            }
        }
    }
}