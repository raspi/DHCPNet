using DHCPNet.v4.Option;

using System;

namespace DHCPNet
{
    /// <summary>
    /// DEPRECATED by:
    /// 100 <see cref="OptionTimezone"/>
    /// 101 <see cref="OptionTimezoneDatabase"/>
    /// 
    /// The time offset field specifies the offset of
    /// the client's subnet in seconds from
    /// Coordinated Universal Time (UTC). The offset is
    /// expressed as a two's complement 32-bit integer.
    ///
    /// (+) Positive offset
    /// indicates a location east of the zero meridian.
    ///
    /// (-) Negative offset
    /// indicates a location west of the zero meridian.
    /// </summary>
    public class OptionTimeOffset : AOptionTimeInt32
    {
        public OptionTimeOffset()
        {
        }

        public override byte Code
        {
            get
            {
                return 2;
            }
        }
    }
}