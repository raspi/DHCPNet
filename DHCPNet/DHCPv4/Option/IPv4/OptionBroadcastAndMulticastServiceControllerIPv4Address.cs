namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The Length byte (Len) is followed by a list of IPv4 addresses
    /// indicating BCMCS controller IPv4 addresses. 
    /// 
    /// The BCMCS controllers MUST be listed in order of preference.
    /// 
    /// Minimum length is 4 bytes.
    /// Length MUST be a multiple of 4. 
    /// 
    /// https://tools.ietf.org/html/rfc4280
    /// </summary>
    public class OptionBroadcastAndMulticastServiceControllerIPv4Address : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 89;
            }
        }
    }
}