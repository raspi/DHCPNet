namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="OptionNetBIOSOverTCPIPNodeType"/>
    /// https://tools.ietf.org/html/rfc2132#section-8.7
    /// </summary>
    public enum ENetBIOSNodeType : byte
    {
        /// <summary>
        /// B-node Node Type
        /// </summary>
        BNode = 0x01,

        /// <summary>
        /// P-node Node Type
        /// </summary>
        PNode = 0x02,

        /// <summary>
        /// M-node Node Type
        /// </summary>
        MNode = 0x04,

        /// <summary>
        /// H-node Node Type
        /// </summary>
        HNode = 0x08,
    }
}

