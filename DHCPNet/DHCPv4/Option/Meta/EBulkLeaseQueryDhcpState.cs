namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="OptionBulkLeaseQueryDhcpState"/>
    /// The dhcp-state option allows greater detail to be returned than
    /// allowed by the DHCPLEASEACTIVE and DHCPLEASEUNASSIGNED message types.
    /// https://tools.ietf.org/html/rfc6926#section-6.2.7
    /// </summary>
    public enum EBulkLeaseQueryDhcpState : byte
    {
        /// <summary>
        /// Address is available to local DHCPv4 server
        /// </summary>
        Available = 1,

        /// <summary>
        /// Address is assigned to a DHCPv4 client
        /// </summary>
        Active,

        /// <summary>
        /// Lease has expired
        /// </summary>
        Expired,

        /// <summary>
        /// Lease has been released by DHCPv4 client
        /// </summary>
        Released,

        /// <summary>
        /// Server or client flagged address as unusable
        /// </summary>
        Abandoned,

        /// <summary>
        /// Lease was freed by some external agent
        /// </summary>
        Reset,

        /// <summary>
        /// Address is available to a remote DHCPv4 server
        /// </summary>
        Remote,

        /// <summary>
        /// Address is moving between states
        /// </summary>
        Transitioning,
    }
}