using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies a list of IP addresses 
    /// indicating NIS servers available to the client.
    /// 
    /// Servers SHOULD be listed in order of preference.
    ///
    /// Minimum length 4 bytes.
    /// Length MUST be a multiple of 4.
    /// </summary>
    class OptionNetworkInformationServiceServers : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 41;
            }
        }
    }
}

