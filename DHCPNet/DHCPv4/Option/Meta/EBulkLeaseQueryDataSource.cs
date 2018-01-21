namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The data-source option contains information about the source of the
    /// data in a DHCPLEASEACTIVE or a DHCPLEASEUNASSIGNED message. It
    /// SHOULD be used when there are two or more servers that might have
    /// information about a particular IP address binding.
    /// 
    /// <see cref="OptionBulkLeaseQueryDataSource"/>
    /// https://tools.ietf.org/html/rfc6926#section-6.2.8
    /// </summary>
    public enum EBulkLeaseQueryDataSource : byte
    {
        /// <summary>
        /// Change took place on the server from which 
        /// this message was transmitted.
        /// </summary>
        Local,

        /// <summary>
        /// Indicates where the most recent change of state 
        /// (or other interesting change) concerning this IPv4 
        /// address took place.
        /// </summary>
        Remote,
    }
}