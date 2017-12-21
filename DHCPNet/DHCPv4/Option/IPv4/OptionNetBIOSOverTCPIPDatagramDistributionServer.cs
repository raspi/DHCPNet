using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The NetBIOS datagram distribution server (NBDD) 
    /// option specifies a list of RFC 1001/1002 NBDD 
    /// servers listed in order of preference.
    /// 
    /// Minimum length 4 bytes.
    /// Length must always be a multiple of 4.
    /// </summary>
    public class OptionNetBIOSOverTCPIPDatagramDistributionServer : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 45;
            }
        }
    }
}

