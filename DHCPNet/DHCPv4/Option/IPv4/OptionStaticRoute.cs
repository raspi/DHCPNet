using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies a list of static routes that 
    /// the client should install in its routing cache.
    /// If multiple routes to the same destination are 
    /// specified, they are listed in descending order of priority.
    /// 
    /// The routes consist of a list of IP address pairs.
    /// The first address is the destination address, and 
    /// the second address is the router for the destination.
    /// 
    /// The default route (0.0.0.0) is an illegal destination 
    /// for a static route.
    /// 
    /// See section 3.5 for information about the router option.
    /// 
    /// Minimum length 8 bytes.
    /// Length MUST be a multiple of 8.
    /// </summary>
    public class OptionStaticRoute : AOptionIPAddresses
    {
        public OptionStaticRoute()
        {
        }

        public override byte Code
        {
            get
            {
                return 33;
            }
        }
    }
}