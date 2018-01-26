using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Perform Mask Discovery
    /// 
    /// This option specifies whether or not the client 
    /// should perform subnet mask discovery using ICMP.
    /// 
    /// 0 indicates that the client should not perform mask discovery.
    /// 1 means that the client should perform mask discovery.
    /// 
    /// Length 1 byte.
    /// https://tools.ietf.org/html/rfc2132#section-5.4
    /// </summary>
    public class OptionPerformMaskDiscovery : AOptionBoolean
    {
        /// <inheritdoc />
        public OptionPerformMaskDiscovery()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 29;
            }
        }
    }
}