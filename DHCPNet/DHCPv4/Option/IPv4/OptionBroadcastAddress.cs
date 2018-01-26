using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Broadcast Address
    /// 
    /// This option specifies the broadcast address in use 
    /// on the client's subnet. 
    /// Legal values for broadcast addresses are 
    /// specified in section 3.2.1.3
    /// 
    /// Length 4 bytes
    /// https://tools.ietf.org/html/rfc2132#section-5.3
    /// </summary>
    public class OptionBroadcastAddress : AOptionIPAddress
    {
        public OptionBroadcastAddress()
        {
        }

        public override byte Code
        {
            get
            {
                return 28;
            }
        }
    }
}