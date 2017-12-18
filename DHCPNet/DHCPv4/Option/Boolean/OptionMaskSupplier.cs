using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies whether or not the client 
    /// should respond to subnet mask requests using ICMP.
    /// 
    /// 0 indicates that the client should not respond.
    /// 1 means that the client should respond.
    /// 
    /// Length 1 byte.
    /// </summary>
    class OptionMaskSupplier : AOptionBoolean
    {
        public override byte Code
        {
            get
            {
                return 30;
            }
        }
    }
}

