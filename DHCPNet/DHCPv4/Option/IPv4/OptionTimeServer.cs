namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The time server option specifies a list of
    /// RFC 868 time servers available to the client.
    /// Servers SHOULD be listed in order of preference.
    /// </summary>
    public class OptionTimeServer : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 4;
            }
        }
    }

}
