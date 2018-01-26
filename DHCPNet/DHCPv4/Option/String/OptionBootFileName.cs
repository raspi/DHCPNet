using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Bootfile name
    /// 
    /// This option is used to identify a bootfile when the 
    /// 'file' field in the DHCP header has been used for DHCP options.
    /// 
    /// Minimum length is 1.
    /// 
    /// https://tools.ietf.org/html/rfc2132#section-9.5
    /// </summary>
    public class OptionBootFileName : AOptionString
    {
        /// <inheritdoc />
        public OptionBootFileName()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 67;
            }
        }
    }
}