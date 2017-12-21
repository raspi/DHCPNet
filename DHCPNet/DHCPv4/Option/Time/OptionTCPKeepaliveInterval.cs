using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the interval (in seconds) that 
    /// the client TCP should wait before sending a keepalive 
    /// message on a TCP connection.
    /// 
    /// The time is specified as a 32-bit unsigned integer.
    /// A value of zero indicates that the client should not 
    /// generate keepalive messages on connections unless 
    /// specifically requested by an application.
    ///
    /// Length 4 bytes.
    /// </summary>
    public class OptionTCPKeepaliveInterval : AOptionTimeUint32
    {
        public OptionTCPKeepaliveInterval()
        {
        }

        public override byte Code
        {
            get
            {
                return 38;
            }
        }
    }
}