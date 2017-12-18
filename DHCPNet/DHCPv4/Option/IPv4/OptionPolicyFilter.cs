using System;
using System.Net;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies policy filters for
    /// non-local source routing. The filters consist of
    /// a list of IP addresses and masks which specify
    /// destination/mask pairs with which to filter
    /// incoming source routes. Any source routed
    /// datagram whose next-hop address does not match one
    /// of the filters should be discarded by the client.
    ///
    /// Minimum length 8 bytes.
    /// </summary>
    public class OptionPolicyFilter : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 21;
            }
        }

        public IPAdressMaskPair pair = new IPAdressMaskPair();

        public OptionPolicyFilter(IPv4Address ip, IPv4Address mask)
        {
            pair = new IPAdressMaskPair()
            {
                IP = ip,
                Netmask = (byte)GetCIDRFromBytes(mask.Address)
            };
        }

    }



}

