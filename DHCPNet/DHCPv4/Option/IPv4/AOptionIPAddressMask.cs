using System;
using System.Collections.Generic;
using System.Net;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option which takes IPv4 Address and mask as a param
    /// </summary>
    public abstract class AOptionIPAddressMask : AOptionIPAddresses
    {
        /// <inheritdoc />
        public List<IPAddressMaskPair> IPMaskPair { get; set; }

        /// <inheritdoc />
        protected AOptionIPAddressMask(IPAddressMaskPair ipmask)
        {
            IPMaskPair.Add(ipmask);
        }

        /// <summary>
        /// Set IP
        /// </summary>
        protected AOptionIPAddressMask(IPv4Address ip, IPv4Address mask)
        {
            IPMaskPair.Add(new IPAddressMaskPair() { Address = ip, Netmask = (byte)GetCIDRFromBytes(mask.Address) });
        }
    }
}