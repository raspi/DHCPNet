namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The LPR server option specifies a list of
    /// RFC 1179 line printer servers available to the client.
    /// Servers SHOULD be listed in order of preference.
    /// </summary>
    public class OptionLPRServer : AOptionIPAddresses
    {
        public OptionLPRServer()
        {
        }

        public override byte Code
        {
            get
            {
                return 9;
            }
        }
    }
}