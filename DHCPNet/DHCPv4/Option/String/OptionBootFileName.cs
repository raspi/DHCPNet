using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option is used to identify a bootfile when the 
    /// 'file' field in the DHCP header has been used for DHCP options.
    /// 
    /// Minimum length is 1.
    /// </summary>
    public class OptionBootFileName : AOptionString
    {
        public OptionBootFileName()
        {
        }

        public override byte Code
        {
            get
            {
                return 67;
            }
        }
    }
}