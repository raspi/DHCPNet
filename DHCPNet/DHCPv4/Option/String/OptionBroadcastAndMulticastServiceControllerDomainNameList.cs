namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc4280
    /// </summary>
    public class OptionBroadcastAndMulticastServiceControllerDomainNameList : AOptionString
    {
        public override byte Code
        {
            get
            {
                return 88;
            }
        }
    }
}