using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies whether or not the client should use Ethernet
    /// Version 2 (RFC 894) or IEEE 802.3 (RFC 1042) encapsulation
    /// if the interface is an Ethernet.
    /// 
    /// 0 indicates that the client should use RFC 894 encapsulation.
    /// 1 means that the client should use RFC 1042 encapsulation.
    ///
    /// Length 1 byte
    /// https://tools.ietf.org/html/rfc2132#section-6.3
    /// </summary>
    public class OptionUseEthernetEncapsulation : AOptionBoolean
    {
        /// <inheritdoc />
        public OptionUseEthernetEncapsulation()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 36;
            }
        }
    }
}