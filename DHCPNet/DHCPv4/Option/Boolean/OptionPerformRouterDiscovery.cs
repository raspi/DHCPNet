using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies whether or not the client should solicit
    /// routers using the Router Discovery mechanism defined in RFC 1256
    /// 
    /// 0 indicates that the client should not perform router discovery.
    /// 1 means that the client should perform router discovery.
    ///
    /// Length 1 byte.
    /// </summary>
    class OptionPerformRouterDiscovery : AOptionBoolean
    {
        public override byte Code
        {
            get
            {
                return 31;
            }
        }
    }
}

