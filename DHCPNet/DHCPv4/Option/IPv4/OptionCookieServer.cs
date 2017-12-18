namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The cookie server option specifies a list of
    /// RFC 865 cookie servers available to the client.
    /// Servers SHOULD be listed in order of preference.
    /// </summary>
    class OptionCookieServer : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 8;
            }
        }
    }

}
