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
    /// </summary>
    public class OptionMessageType : Option
    {
        public override byte Code
        {
            get
            {
                return 53;
            }
        }

        public EMessageType Type { get; set; }

        public OptionMessageType()
        {
        }

        public OptionMessageType(EMessageType type)
        {
            Type = type;
        }

        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new Exception("Zero length.");
            }

            if (raw.Length > 1)
            {
                throw new Exception(String.Format("Invalid length: {0}", raw.Length));
            }

            Type = (EMessageType)(byte)raw[0];
        }

        public override byte[] GetRawBytes()
        {
            return new byte[] { (byte)Type };
        }
    }
}