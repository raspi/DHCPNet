namespace DHCPNet.v4.Option
{
    /// <summary>
    /// IPv4 address(es) of ANDSF server(s)
    ///
    /// ANDSF servers MUST be listed in order of preference, and the client
    /// SHOULD process them in decreasing order of preference.
    /// https://tools.ietf.org/html/rfc6153#section-2
    /// </summary>
    public class OptionAccessNetworkDiscoveryAndSelectionFunctionIPv4Addresses : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 142;
            }
        }
    }
}