namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies a list of
    /// RFC 887 Resource Location servers available to the client.
    /// 
    /// Servers SHOULD be listed in order of preference.
    /// 
    /// </summary>
    class OptionResourceLocationServer : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 11;
            }
        }

    }

}