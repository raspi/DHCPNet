using System;

namespace DHCPNet.v4.Option
{

    /// <summary>
    /// This option specifies the broadcast address in use 
    /// on the client's subnet. 
    /// Legal values for broadcast addresses are 
    /// specified in section 3.2.1.3
    /// 
    /// Length 4 bytes
    /// </summary>
    public class OptionBroadcastAddress : AOptionIPAddress
    {
        public override byte Code
        {
            get
            {
                return 28;
            }
        }
    }
}

