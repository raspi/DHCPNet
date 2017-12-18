namespace DHCPNet.v4.Option
{
    /// <summary>
    /// DHCP Message Type
    /// </summary>
    public enum EMessageType
    {
        /// <summary>
        /// Client Broadcast: Can I have an IP?
        /// </summary>
        Discover = 1,

        /// <summary>
        /// Server Broadcast: Here's an IP
        /// </summary>
        Offer,

        /// <summary>
        /// Client Broadcast: I'll take that IP (Also start for renewals)
        /// </summary>
        Request,

        /// <summary>
        /// Client Broadcast: Sorry I can't use that IP
        /// </summary>
        Decline,

        /// <summary>
        /// Server: Yes you can have that IP
        /// </summary>
        Acknowledge,

        /// <summary>
        /// Server: No you cannot have that IP
        /// </summary>
        NotAcknowledged,

        /// <summary>
        /// Client: I don't need that IP anymore
        /// </summary>
        Release,

        /// <summary>
        /// Client: I have this IP and there's nothing you can do about it
        /// </summary>
        Inform,
    }
}
