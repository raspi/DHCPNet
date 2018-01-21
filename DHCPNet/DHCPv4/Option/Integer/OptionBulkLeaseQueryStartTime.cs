namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="OptionBulkLeaseQueryStateStartSeconds"/>
    /// <see cref="OptionBulkLeaseQueryBaseTime"/>
    /// <see cref="OptionLeaseQueryClientLastTransactionTime"/>
    /// <see cref="OptionLeaseQueryAssociatedIpAddresses"/>
    /// <see cref="EMessageType.BulkLeaseDone"/>
    /// <see cref="EMessageType.BulkLeaseQuery"/>
    /// 
    /// The query-start-time option specifies a start query time to the
    /// DHCPv4 server. If specified, only bindings that have changed on or
    /// after the query-start-time should be included in the response to the
    /// query.
    /// 
    /// The requestor MUST determine the query-start-time using lease
    /// information it has received from the DHCPv4 server.This MUST be an
    /// absolute time in the DHCPv4 server's context (see Section 7.4).
    /// 
    /// Typically(though this is not a requirement), the query-start-time
    /// option will contain the value most recently received in a base-time
    /// option by the requestor, as this will indicate the last successful
    /// communication with the DHCP server.
    /// 
    /// https://tools.ietf.org/html/rfc6926#section-6.2.5
    /// </summary>
    public class OptionBulkLeaseQueryStartTime : AOptionUint32
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 154;
            }
        }
    }
}