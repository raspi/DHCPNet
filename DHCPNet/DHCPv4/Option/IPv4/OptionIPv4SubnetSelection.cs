namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This memo defines a new Dynamic Host Configuration Protocol (DHCP)
    /// option for selecting the subnet on which to allocate an address.
    /// This option would override a DHCP server's normal methods of
    /// selecting the subnet on which to allocate an address for a client.
    /// 
    /// https://tools.ietf.org/html/rfc3011
    /// </summary>
    public class OptionIPv4SubnetSelection : AOptionIPAddress
    {
        public override byte Code
        {
            get
            {
                return 118;
            }
        }
    }
}