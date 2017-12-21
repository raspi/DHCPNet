using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the default TTL that 
    /// the client should use when sending TCP segments.
    /// 
    /// The value is represented as an 
    /// 8-bit unsigned integer.
    /// 
    /// The minimum value is 1.
    ///
    /// Length 1 byte.
    /// </summary>
    public class OptionTCPDefaultTTL : AOptionUint8
    {
        public OptionTCPDefaultTTL()
        {
        }

        public override byte Code
        {
            get
            {
                return 37;
            }
        }
    }
}