using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the maximum length of DHCP 
    /// message that it is willing to accept. 
    /// 
    /// The length is specified as an unsigned 16-bit integer.
    /// 
    /// A client may use the maximum DHCP message size option in
    /// DHCPDISCOVER or DHCPREQUEST messages, but should not use 
    /// the option in DHCPDECLINE messages.
    /// 
    /// Length 2 bytes.
    /// Minimum legal value is 576 octets.
    /// </summary>
    class OptionMaximumDHCPMessageSize : AOptionUint16
    {
        public override byte Code
        {
            get
            {
                return 57;
            }
        }
    }
}

