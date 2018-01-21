namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The query-end-time option specifies an end query time to the DHCPv4
    /// server. If specified, only bindings that have changed on or before
    /// the query-end-time should be included in the response to the query.
    /// 
    /// The requestor MUST determine the query-end-time based on lease
    /// information it has received from the DHCPv4 server. This MUST be an
    /// absolute time in the context of the DHCPv4 server.
    /// 
    /// In the absence of information to the contrary, the requestor SHOULD
    /// assume that the time context of the DHCPv4 server is identical to the
    /// time context of the requestor (see Section 7.4).
    /// 
    /// This is an unsigned integer in network byte order.
    /// 
    /// https://tools.ietf.org/html/rfc6926#section-6.2.6
    /// </summary>
    public class OptionBulkLeaseQueryEndTime : AOptionUint32
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 155;
            }
        }
    }
}