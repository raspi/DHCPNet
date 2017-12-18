using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option is used by a DHCP server to 
    /// provide an error message to a DHCP client in 
    /// a DHCPNAK message in the event of a failure.
    /// 
    /// A client may use this option in a 
    /// DHCPDECLINE message to indicate the why the
    /// client declined the offered parameters.
    /// 
    /// The message consists of n octets of NVT ASCII text, 
    /// which the client may display on an available output device.
    /// 
    /// Minimum length is 1.
    /// </summary>
    class OptionMessage : AOptionString
    {
        public override byte Code
        {
            get
            {
                return 56;
            }
        }
    }
}

