using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the timeout (in seconds) to use
    /// when aging Path MTU values discovered by the mechanism
    /// defined in RFC 1191. The timeout is specified as a
    /// 32-bit unsigned integer.
    ///
    /// Length 4 bytes
    /// </summary>
    public class OptionPathMTUAgingTimeout : AOptionTimeUint32
    {
        public override byte Code
        {
            get
            {
                return 24;
            }
        }

    }

}

