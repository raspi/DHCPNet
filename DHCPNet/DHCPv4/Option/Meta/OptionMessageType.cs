using System.Net;
using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option is used to convey the type of the DHCP message. 
    /// Legal values for options are:
    ///
    ///  1 DHCPDISCOVER
    ///  2 DHCPOFFER
    ///  3 DHCPREQUEST
    ///  4 DHCPDECLINE
    ///  5 DHCPACK
    ///  6 DHCPNAK
    ///  7 DHCPRELEASE
    ///  8 DHCPINFORM
    /// 10 DHCPLEASEQUERY rfc4388
    /// 11 DHCPLEASEUNASSIGNED rfc4388
    /// 12 DHCPLEASEUNKNOWN rfc4388
    /// 13 DHCPLEASEACTIVE rfc4388
    /// 
    /// Length 1 byte. 
    /// https://tools.ietf.org/html/rfc2132#section-9.6
    /// </summary>
    public class OptionMessageType : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 53;
            }
        }

        /// <inheritdoc />
        public EMessageType Type { get; set; }

        /// <inheritdoc />
        public OptionMessageType()
        {
        }

        /// <inheritdoc />
        public OptionMessageType(EMessageType type)
        {
            this.Type = type;
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            if (raw.Length != 1)
            {
                throw new OptionLengthNotExactException(string.Format("Invalid length: {0}. Should be 1.", raw.Length));
            }

            this.Type = (EMessageType)(byte)raw[0];
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return new byte[] { (byte)this.Type };
        }
    }
}