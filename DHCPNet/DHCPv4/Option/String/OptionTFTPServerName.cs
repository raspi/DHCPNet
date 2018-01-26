using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// TFTP server name
    /// 
    /// This option is used to identify a TFTP server when 
    /// the 'sname' field in the DHCP header has been used 
    /// for DHCP options.
    ///
    /// Minimum length 1 byte.
    /// https://tools.ietf.org/html/rfc2132#section-9.4
    /// </summary>
    public class OptionTFTPServerName : AOptionString
    {
        /// <inheritdoc />
        public OptionTFTPServerName()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 66;
            }
        }
    }
}