using System.Net;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option is used in DHCPOFFER and DHCPREQUEST messages, and may
    /// optionally be included in the DHCPACK and DHCPNAK messages.
    /// DHCP servers include this option in the DHCPOFFER in order to allow
    /// the client to distinguish between lease offers. DHCP clients use the
    /// contents of the 'server identifier' field as the destination address
    /// for any DHCP messages unicast to the DHCP server. DHCP clients also
    /// indicate which of several lease offers is being accepted by including
    /// this option in a DHCPREQUEST message.
    ///
    /// The identifier is the IP address of the selected server.
    ///
    /// Length 4 bytes.
    /// </summary>
    public class OptionServerIdentifier : AOptionIPAddress
    {
        public override byte Code
        {
            get
            {
                return 54;
            }
        }

    }

}
