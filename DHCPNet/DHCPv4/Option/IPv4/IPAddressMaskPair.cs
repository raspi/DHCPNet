using System;
using System.Net;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Ipv4 and CIDR pair
    /// </summary>
    public class IPAddressMaskPair
    {
        /// <summary>
        /// IPv4 address
        /// </summary>
        public IPv4Address Address { get; set; }

        protected byte _netmask;

        /// <summary>
        /// CIDR mask
        /// </summary>
        public byte Netmask
        {
            get
            {
                return this._netmask;
            }
            set
            {
                if (value > 32)
                {
                    throw new Exception(String.Format("Invalid value: {0}", value));
                }

                this._netmask = value;
            }
        }

        public IPAddressMaskPair()
        {
        }

        public override string ToString()
        {
            return String.Format("{0}/{1}", Address, Netmask);
        }
    }
}