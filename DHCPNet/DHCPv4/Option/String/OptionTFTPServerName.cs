using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option is used to identify a TFTP server when 
    /// the 'sname' field in the DHCP header has been used 
    /// for DHCP options.
    ///
    /// Minimum length 1 byte.
    /// </summary>
    public class OptionTFTPServerName : AOptionString
    {
        public OptionTFTPServerName()
        {
        }

        public override byte Code
        {
            get
            {
                return 66;
            }
        }
    }
}