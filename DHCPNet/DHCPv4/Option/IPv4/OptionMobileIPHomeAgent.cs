using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies a list of IP addresses 
    /// indicating mobile IP home agents available to 
    /// the client.
    /// 
    /// Agents SHOULD be listed in order of preference.
    /// 
    /// Minimum length is 0 (indicating no home 
    /// agents are available)
    /// 
    /// Length MUST be a multiple of 4.
    /// 
    /// It is expected that the usual length will be four octets, containing
    /// a single home agent's address.
    /// 
    /// </summary>
    public class OptionMobileIPHomeAgent : AOptionIPAddresses
    {
        public OptionMobileIPHomeAgent()
        {
        }

        public override byte Code
        {
            get
            {
                return 68;
            }
        }
    }
}