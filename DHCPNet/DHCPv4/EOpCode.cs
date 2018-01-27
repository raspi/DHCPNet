namespace DHCPNet
{
    /// <summary>
    /// Op code
    /// <see cref="DHCPPacketBootRequest"/>
    /// <see cref="DHCPPacketBootReply"/>
    /// https://tools.ietf.org/html/rfc2131
    /// </summary>
    public enum EOpCode : byte
    {
        /// <summary>
        /// Sent by Client
        /// </summary>
        BootRequest = 1,

        /// <summary>
        /// Sent by Server
        /// </summary>
        BootReply,
    }
}