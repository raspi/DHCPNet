namespace DHCPNet.v4.Option
{
    /// <summary>
    /// DHCP Message Type
    /// https://tools.ietf.org/html/rfc2132#section-9.6
    /// </summary>
    public enum EMessageType : byte
    {
        /// <summary>
        /// Client Broadcast: Can I have an IP?
        /// https://tools.ietf.org/html/rfc2132#section-9.6
        /// </summary>
        Discover = 1,

        /// <summary>
        /// Server Broadcast: Here's an IP
        /// https://tools.ietf.org/html/rfc2132#section-9.6
        /// </summary>
        Offer,

        /// <summary>
        /// Client Broadcast: I'll take that IP (Also start for renewals)
        /// https://tools.ietf.org/html/rfc2132#section-9.6
        /// </summary>
        Request,

        /// <summary>
        /// Client Broadcast: Sorry I can't use that IP
        /// https://tools.ietf.org/html/rfc2132#section-9.6
        /// </summary>
        Decline,

        /// <summary>
        /// Server: Yes you can have that IP
        /// https://tools.ietf.org/html/rfc2132#section-9.6
        /// </summary>
        Acknowledge,

        /// <summary>
        /// Server: No you cannot have that IP
        /// https://tools.ietf.org/html/rfc2132#section-9.6
        /// </summary>
        NotAcknowledged,

        /// <summary>
        /// Client: I don't need that IP anymore
        /// https://tools.ietf.org/html/rfc2132#section-9.6
        /// </summary>
        Release,

        /// <summary>
        /// Client: I have this IP and there's nothing you can do about it
        /// https://tools.ietf.org/html/rfc2132#section-9.6
        /// </summary>
        Inform,

        /// <summary>
        /// Leasequery
        /// <see cref="OptionLeaseQueryAssociatedIpAddresses"/>
        /// <see cref="OptionLeaseQueryClientLastTransactionTime"/>
        /// https://tools.ietf.org/html/rfc4388
        /// </summary>
        LeaseQuery = 10,

        /// <summary>
        /// Leasequery
        /// <see cref="OptionLeaseQueryAssociatedIpAddresses"/>
        /// <see cref="OptionLeaseQueryClientLastTransactionTime"/>
        /// https://tools.ietf.org/html/rfc4388
        /// </summary>
        LeaseUnassigned = 11,

        /// <summary>
        /// Leasequery
        /// <see cref="OptionLeaseQueryAssociatedIpAddresses"/>
        /// <see cref="OptionLeaseQueryClientLastTransactionTime"/>
        /// https://tools.ietf.org/html/rfc4388
        /// </summary>
        LeaseUnknown = 12,

        /// <summary>
        /// Leasequery
        /// <see cref="OptionLeaseQueryAssociatedIpAddresses"/>
        /// <see cref="OptionLeaseQueryClientLastTransactionTime"/>
        /// https://tools.ietf.org/html/rfc4388
        /// </summary>
        LeaseActive = 13,

        /// <summary>
        /// Bulk Leasequery
        /// https://tools.ietf.org/html/rfc6926#section-6.2.1
        /// </summary>
        BulkLeaseQuery = 14,

        /// <summary>
        /// Bulk Leasequery
        /// https://tools.ietf.org/html/rfc6926#section-6.2.1
        /// </summary>
        BulkLeaseDone = 15,
    }
}