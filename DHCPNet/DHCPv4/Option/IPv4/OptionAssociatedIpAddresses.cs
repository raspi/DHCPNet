namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc4388
    /// </summary>
    public class OptionAssociatedIpAddresses : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 92;
            }
        }
    }
}