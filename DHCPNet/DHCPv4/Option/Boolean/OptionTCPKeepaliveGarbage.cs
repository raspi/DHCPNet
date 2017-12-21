using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the whether or not the 
    /// client should send TCP keepalive messages with 
    /// a octet of garbage for compatibility with
    /// older implementations.
    /// 
    /// 0 indicates that a garbage octet should not be sent.
    /// 1 indicates that a garbage octet should be sent.
    /// </summary>
    public class OptionTCPKeepaliveGarbage : AOptionBoolean
    {
        public override byte Code
        {
            get
            {
                return 39;
            }
        }
    }
}

