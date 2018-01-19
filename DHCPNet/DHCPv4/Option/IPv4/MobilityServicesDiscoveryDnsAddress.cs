namespace DHCPNet.v4.Option
{
    using System.Collections.Generic;

    /// <summary>
    /// Fully Qualified Domain Names
    /// <see cref="OptionMobilityServicesDiscoveryServerDomainAddresses"/>
    /// </summary>
    public class MobilityServicesDiscoveryDnsAddress
    {
        /// <summary>
        /// Sub-option type
        /// </summary>
        public EMobilityServicesDiscoverySubOption Type { get; set; }

        /// <summary>
        /// List of IPv4 addresses
        /// </summary>
        public List<string> Addresses { get; set; }
    }
}