using System.Net;
using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Subnet mask
    /// For example 255.255.255.0
    /// </summary>
    public class OptionSubnetMask : Option
    {
        public OptionSubnetMask()
        {
        }

        public override byte Code
        {
            get
            {
                return 1;
            }
        }

        protected byte _cidr = 24;

        /// <summary>
        /// Subnet mask as CIDR
        /// 32 = 255.255.255.255
        /// 24 = 255.255.255.0
        /// 0 = 0.0.0.0
        ///
        /// https://en.wikipedia.org/wiki/Classless_Inter-Domain_Routing
        /// </summary>
        public byte CIDR
        {
            get
            {
                return _cidr;
            }
            set
            {
                if (value > 32)
                {
                    throw new OptionException(String.Format("Invalid CIDR: {0}", value));
                }

                _cidr = value;
            }
        }

        public override void ReadRaw(byte[] raw)
        {
            CIDR = (byte)GetCIDRFromBytes(raw);
        }

        public OptionSubnetMask(IPv4Address mask)
        {
            CIDR = (byte)GetCIDRFromBytes(mask.Address);
        }

        public OptionSubnetMask(byte cidr)
        {
            CIDR = cidr;
        }

        public IPv4Address GetSubnetMaskAsIPAddress()
        {
            return new IPv4Address(GetCIDRBytes(CIDR));
        }

        public override byte[] GetRawBytes()
        {
            return GetCIDRBytes(CIDR);
        }
    }
}