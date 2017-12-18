using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The NetBIOS scope option specifies the 
    /// NetBIOS over TCP/IP scope parameter for 
    /// the client as specified in RFC 1001/1002.
    /// 
    /// See [19], [20], and [8] for character-set restrictions.
    ///
    /// Minimum length 1 byte.
    /// </summary>
    class OptionNetBIOSOverTCPIPScope : AOptionString
    {
        public override byte Code
        {
            get
            {
                return 47;
            }
        }
    }
}

