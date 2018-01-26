using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies whether or not the client 
    /// should respond to subnet mask requests using 
    /// Internet Control Message Protocol (ICMP).
    /// 
    /// 0 indicates that the client should not respond.
    /// 1 means that the client should respond.
    /// 
    /// Length 1 byte.
    /// https://tools.ietf.org/html/rfc2132#section-5.5
    /// ICMP Reference: https://tools.ietf.org/html/rfc792
    /// </summary>
    public class OptionClientShouldRespondsToSubnetMaskICMPRequests : AOptionBoolean
    {
        /// <inheritdoc />
        public OptionClientShouldRespondsToSubnetMaskICMPRequests()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 30;
            }
        }
    }
}