using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies a list of IP addresses of 
    /// systems that are running the X Window System 
    /// Display Manager and are available to the client.
    /// 
    /// Addresses SHOULD be listed in order of preference.
    /// 
    /// Minimum length 4 bytes.
    /// Length MUST be a multiple of 4.
    /// </summary>
    public class OptionXWindowSystemDisplayManager : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 49;
            }
        }
    }
}

