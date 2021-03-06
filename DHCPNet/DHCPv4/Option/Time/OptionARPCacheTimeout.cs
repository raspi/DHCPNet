using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the timeout in seconds for ARP cache entries.
    /// The time is specified as a 32-bit unsigned integer.
    /// 
    /// Length 4 bytes.
    /// </summary>
    public class OptionARPCacheTimeout : AOptionTimeUint32
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 35;
            }
        }

        /// <inheritdoc />
        public OptionARPCacheTimeout()
        {
        }
    }
}