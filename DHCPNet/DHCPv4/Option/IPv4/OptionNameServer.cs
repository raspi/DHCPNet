namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <seealso cref="OptionDomainNameServer"/>
    /// The name server option specifies a list of
    /// IEN 116 name servers available to the client.
    /// Servers SHOULD be listed in order of preference.
    ///
    /// Don't confuse with OptionDomainNameServer
    /// </summary>
    public class OptionNameServer : AOptionIPAddresses
    {
        public OptionNameServer()
        {
        }

        public override byte Code
        {
            get
            {
                return 5;
            }
        }
    }
}