using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the time interval from address assignment
    /// until the client transitions to the REBINDING state.
    ///
    /// The value is in units of seconds, and is specified as a 32-bit
    /// unsigned integer.
    ///
    /// Length 4 bytes.
    /// </summary>
    class OptionRebindingTime : AOptionTimeUint32
    {
        public override byte Code
        {
            get
            {
                return 59;
            }
        }
    }


}
