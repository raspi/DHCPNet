using System;
using System.Collections.Generic;
using System.Net;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option which takes IPv4 Adress and mask as a param
    /// </summary>
    public abstract class AOptionIPAddressMask : AOptionIPAddresses
    {
        public List<IPAdressMaskPair> IPMaskPair = new List<IPAdressMaskPair>();

        protected AOptionIPAddressMask(IPAdressMaskPair ipmask)
        {
            IPMaskPair.Add(ipmask);
        }

        /// <summary>
        /// Set IP
        /// </summary>
        protected AOptionIPAddressMask(IPv4Address ip, IPv4Address mask)
        {
            IPMaskPair.Add(new IPAdressMaskPair() { Address = ip, Netmask = (byte)GetCIDRFromBytes(mask.Address) });
        }
    }
}