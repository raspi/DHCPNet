using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The NetBIOS name server (NBNS) option specifies 
    /// a list of RFC 1001/1002 NBNS name servers listed 
    /// in order of preference.
    ///
    /// Minimum length 4 bytes.
    /// Length must always be a multiple of 4.
    /// </summary>
    class OptionNetBIOSOverTCPIPNameServer : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 44;
            }
        }
    }
}

