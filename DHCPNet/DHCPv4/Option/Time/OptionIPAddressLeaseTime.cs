using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option is used in a client request 
    /// (DHCPDISCOVER or DHCPREQUEST) to allow 
    /// the client to request a lease time for 
    /// the IP address.
    /// 
    /// In a server reply (DHCPOFFER), a DHCP server 
    /// uses this option to specify the lease time 
    /// it is willing to offer.
    /// 
    /// The time is in units of seconds, and is 
    /// specified as a 32-bit unsigned integer.
    /// 
    /// Length 4 bytes.
    /// </summary>
    public class OptionIPAddressLeaseTime : AOptionTimeUint32
    {
        /// <inheritdoc />
        public OptionIPAddressLeaseTime()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 51;
            }
        }
    }
}