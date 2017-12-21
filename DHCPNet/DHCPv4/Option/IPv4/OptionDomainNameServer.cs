namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The domain name server option specifies a list of Domain Name System
    /// (STD 13, RFC 1035) name servers available to the client.
    /// 
    /// Servers SHOULD be listed in order of preference.
    /// 
    /// Minimum length 4 bytes.
    /// Length MUST always be a multiple of 4.
    /// </summary>
    public class OptionDomainNameServer : AOptionIPAddresses
    {
        public OptionDomainNameServer()
        {
        }

        public override byte Code
        {
            get
            {
                return 6;
            }
        }
    }
}