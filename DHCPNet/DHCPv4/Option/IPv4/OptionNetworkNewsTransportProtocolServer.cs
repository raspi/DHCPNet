using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The NNTP server option specifies a list of NNTP available to the
    /// client.
    /// 
    /// Servers SHOULD be listed in order of preference.
    /// 
    /// Minimum length 4 bytes.
    /// Length MUST always be a multiple of 4.
    /// </summary>
    class OptionNetworkNewsTransportProtocolServer : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 71;
            }
        }
    }
}

