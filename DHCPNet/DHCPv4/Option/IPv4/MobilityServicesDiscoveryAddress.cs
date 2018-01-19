namespace DHCPNet.v4.Option
{
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="OptionMobilityServicesDiscoveryServerAddresses"/>
    /// </summary>
    public class MobilityServicesDiscoveryAddress
    {
        /// <summary>
        /// Sub-option type
        /// </summary>
        public EMobilityServicesDiscoverySubOption Type { get; set; }

        /// <summary>
        /// List of IPv4 addresses
        /// </summary>
        public List<IPv4Address> Addresses { get; set; }
    }
}