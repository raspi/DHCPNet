namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="OptionMobilityServicesDiscoveryServerAddresses"/>
    /// * https://tools.ietf.org/html/rfc5678
    /// * http://www.ieee802.org/21/
    /// * IEEE Standard for Local and Metropolitan Area Networks
    /// - Part 21: Media Independent Handover Services", 
    /// IEEE LAN/MAN Std 802.21-2008, January 2009, 
    /// http://www.ieee802.org/21/private/Published%20Spec/802.21-2008.pdf
    /// </summary>
    public enum EMobilityServicesDiscoverySubOption : byte
    {
        /// <summary>
        /// IS provides a unified framework to the higher-layer entities
        /// across the heterogeneous network environment to facilitate
        /// discovery and selection of multiple types of networks existing
        /// within a geographical area.  The objective is to help the higher-
        /// layer mobility protocols acquire a global view of heterogeneous
        /// networks and perform seamless handover across these networks.
        /// </summary>
        InformationServices = 1,

        /// <summary>
        /// Events may indicate changes in state and transmission behavior of
        /// the physical, data link, and logical link layers, or predict state
        /// changes of these layers.  The Event Service may also be used to
        /// indicate management actions or command status on the part of the
        /// network or some management entity.
        /// </summary>
        EventServices,

        /// <summary>
        /// The command service enables higher layers to control the physical,
        /// data link, and logical link layers.  The higher layers may control
        /// the reconfiguration or selection of an appropriate link through a
        /// set of handover commands.
        /// </summary>
        CommandServices,
    }
}