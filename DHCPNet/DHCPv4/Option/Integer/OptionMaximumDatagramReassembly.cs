using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the maximum size datagram that
    /// the client should be prepared to reassemble. The size
    /// is specified as a 16-bit unsigned integer. The minimum
    /// legal value is 576.
    ///
    /// Length 2 bytes
    /// </summary>
    public class OptionMaximumDatagramReassembly : AOptionUint16
    {
        public OptionMaximumDatagramReassembly()
        {
        }

        public override byte Code
        {
            get
            {
                return 22;
            }
        }
    }
}