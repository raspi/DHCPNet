using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies a list of IP addresses 
    /// indicating NIS+ servers available to the client.
    /// 
    /// Servers SHOULD be listed in order ofpreference.
    /// 
    /// Minimum length 4 bytes.
    /// Length MUST be a multiple of 4.
    /// </summary>
    public class OptionNetworkInformationServicePlusServers : AOptionIPAddresses
    {
        public OptionNetworkInformationServicePlusServers()
        {
        }

        public override byte Code
        {
            get
            {
                return 65;
            }
        }
    }
}