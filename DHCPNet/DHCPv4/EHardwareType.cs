namespace DHCPNet
{
    /// <summary>
    /// Hardware type
    /// 
    /// https://tools.ietf.org/html/rfc1060
    /// Page 46
    /// </summary>
    public enum EHardwareType
    {
        /// <summary>
        /// Ethernet (10Mb)
        /// </summary>
        Ethernet = 1, // *

        /// <summary>
        /// Experimental Ethernet (3 Mb)
        /// </summary>
        ExperimentalEthernet,

        /// <summary>
        /// Amateur Radio AX.25
        /// </summary>
        AmateurRadioAX25,

        /// <summary>
        /// Proteon ProNET Token Ring
        /// </summary>
        TokenRing,

        /// <summary>
        /// Chaos
        /// </summary>
        Chaos,

        /// <summary>
        /// IEEE 802 Networks
        /// </summary>
        IEEE802,

        /// <summary>
        /// ARCNET
        /// </summary>
        ARCNET,

        /// <summary>
        /// Hyperchannel
        /// </summary>
        Hyperchannel,

        /// <summary>
        /// Lanstar
        /// </summary>
        Lanstar,

        /// <summary>
        /// Autonet Short Address
        /// </summary>
        AutonetShortAddress,

        /// <summary>
        /// LocalTalk
        /// </summary>
        LocalTalk,

        /// <summary>
        /// LocalNet (IBM PCNet or SYTEK LocalNET)
        /// </summary>
        LocalNet,
    }


}
