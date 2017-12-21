namespace DHCPNet
{
    /// <summary>
    /// Op code
    /// </summary>
    public enum EOpCode
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