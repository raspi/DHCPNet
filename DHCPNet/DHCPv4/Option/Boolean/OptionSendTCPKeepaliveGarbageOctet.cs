using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the whether or not the 
    /// client should send TCP keepalive messages with 
    /// a octet of garbage for compatibility with
    /// older implementations.
    /// 
    /// 0 indicates that a garbage octet should not be sent.
    /// 1 indicates that a garbage octet should be sent.
    /// https://tools.ietf.org/html/rfc2132#section-7.3
    /// </summary>
    public class OptionSendTCPKeepaliveGarbageOctet : AOptionBoolean
    {
        /// <inheritdoc />
        public OptionSendTCPKeepaliveGarbageOctet()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 39;
            }
        }
    }
}