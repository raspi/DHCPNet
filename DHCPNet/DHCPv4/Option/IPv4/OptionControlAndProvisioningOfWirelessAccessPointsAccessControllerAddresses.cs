namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The Control And Provisioning of Wireless Access Points Protocol
    /// allows a Wireless Termination Point to use DHCP to discover the
    /// Access Controllers to which it is to connect.
    /// 
    /// https://tools.ietf.org/html/rfc5417
    /// </summary>
    public class OptionControlAndProvisioningOfWirelessAccessPointsAccessControllerAddresses : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 138;
            }
        }
    }
}