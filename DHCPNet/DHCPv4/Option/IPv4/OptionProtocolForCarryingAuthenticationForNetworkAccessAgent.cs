namespace DHCPNet.v4.Option
{
    /// <summary>
    /// List of IP addresses to locate one or more PANA 
    /// (Protocol for carrying Authentication for Network Access) 
    /// Authentication Agents (PAAs).
    /// 
    /// https://tools.ietf.org/html/rfc5192
    /// </summary>
    public class OptionProtocolForCarryingAuthenticationForNetworkAccessAgent : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 136;
            }
        }
    }
}