using System;
using System.Collections.Generic;
using System.Net;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option which takes IPv4 Adress and mask as a param
    /// </summary>
    public abstract class AOptionIPAdressMask : AOptionIPAddresses
    {
        public List<IPAdressMaskPair> IPMaskPair = new List<IPAdressMaskPair>();

        protected AOptionIPAdressMask(IPAdressMaskPair ipmask)
        {
            IPMaskPair.Add(ipmask);
        }

        /// <summary>
        /// Set IP
        /// </summary>
        protected AOptionIPAdressMask(IPv4Address ip, IPv4Address mask)
        {
            IPMaskPair.Add(new IPAdressMaskPair() { IP = ip, Netmask = (byte)GetCIDRFromBytes(mask.Address) });
        }
    }
}