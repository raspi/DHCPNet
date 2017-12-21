using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies whether or not the client 
    /// should perform subnet mask discovery using ICMP.
    /// 
    /// 0 indicates that the client should not perform mask discovery.
    /// 1 means that the client should perform mask discovery.
    /// 
    /// Length 1 byte.
    /// </summary>
    public class OptionPerformMaskDiscovery : AOptionBoolean
    {
        public OptionPerformMaskDiscovery()
        {
        }

        public override byte Code
        {
            get
            {
                return 29;
            }
        }
    }
}