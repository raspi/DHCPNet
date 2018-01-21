namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="OptionBulkLeaseQueryStateStartSeconds"/>
    /// <see cref="OptionLeaseQueryClientLastTransactionTime"/>
    /// <see cref="OptionLeaseQueryAssociatedIpAddresses"/>
    /// <see cref="EMessageType.BulkLeaseDone"/>
    /// <see cref="EMessageType.BulkLeaseQuery"/>
    /// 
    /// The base-time option is the current time the message was created to
    /// be sent by the DHCPv4 server to the requestor of the Bulk Leasequery.
    /// This MUST be an absolute time. All of the other time-based options
    /// in the reply message are relative to this time, including the 
    /// dhcp-lease-time [RFC2132] and client-last-transaction-time [RFC4388].
    /// 
    /// This time is in the context of the DHCPv4 server that placed this
    /// option in a message.
    /// 
    /// This is an unsigned integer in network byte order.
    /// 
    /// https://tools.ietf.org/html/rfc6926#section-6.2.3
    /// </summary>
    public class OptionBulkLeaseQueryBaseTime : AOptionUint32
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 152;
            }
        }
    }
}