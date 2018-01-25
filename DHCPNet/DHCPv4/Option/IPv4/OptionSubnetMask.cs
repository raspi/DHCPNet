using System.Net;
using System;
using System.Collections.Generic;

namespace DHCPNet.v4.Option
{

    /// <summary>
    /// Subnet mask
    /// For example 255.255.255.0
    /// </summary>
    public class OptionSubnetMask : AOptionIPAddress
    {
        /// <inheritdoc />
        public OptionSubnetMask()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 1;
            }
        }

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
                return GetCIDRFromBytes(GetRawBytes());
            }
            set
            {
                if (value > 32)
                {
                    throw new OptionException(String.Format("Invalid CIDR: {0}", value));
                }

                Address = new List<IPv4Address>()
                                   {
                                       new IPv4Address(GetCIDRBytes(value))
                                   };
            }
        }
    }
}