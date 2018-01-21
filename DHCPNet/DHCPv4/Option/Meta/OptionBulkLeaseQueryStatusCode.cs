namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="OptionLeaseQueryClientLastTransactionTime"/>
    /// <see cref="OptionLeaseQueryAssociatedIpAddresses"/>
    /// <see cref="EBulkLeaseQueryStatusCode"/>
    /// <see cref="EMessageType.BulkLeaseDone"/>
    /// <see cref="EMessageType.BulkLeaseQuery"/>
    /// 
    /// The status-code option allows a machine-readable value to be returned
    /// regarding the status of a DHCPBULKLEASEQUERY request.
    /// 
    /// This option has two possible scopes when used with Bulk Leasequery,
    /// depending on the context in which it appears. It refers to the
    /// information in a single Leasequery reply if the value of the dhcp-
    /// message-type is DHCPLEASEACTIVE or DHCPLEASEUNASSIGNED. It refers to
    /// the message stream related to an entire request if the value of the
    /// dhcp-message-type is DHCPLEASEQUERYDONE.
    /// 
    ///               Status         Status
    ///  Code    Len   Code          Message
    /// +------+------+------+------+------+--   --+-----+
    /// |  151 | n+1  |status|  s1  |  s2  |  ...  | sn  |
    /// +------+------+------+------+------+--   --+-----+
    /// 
    /// The status-code is indicated in one octet as defined in the table
    /// below. The Status Message is an optional UTF-8-encoded text string
    /// suitable for display to an end user.This text string MUST NOT
    /// contain a termination character(e.g., a null).  The Len field
    /// describes the length of the Status Message without any terminator
    /// character. Null characters MUST NOT appear in the Status Message
    /// string, and it is a protocol violation for them to appear in any
    /// position in the Status Message, including at the end.
    /// 
    /// Name    Status Code Description
    /// ----    ----------- -----------
    /// Success         000 Success. Also signaled by absence of
    ///                              a status-code option.
    /// UnspecFail      001 Failure, reason unspecified.
    /// QueryTerminated 002 Indicates that the server is unable to
    ///                     perform a query or has prematurely terminated
    ///                     the query for some reason (which should be
    ///                     communicated in the text message).
    /// MalformedQuery  003 The query was not understood.
    /// NotAllowed      004 The query or request was understood but was
    ///                     not allowed in this context.
    /// 
    /// A status-code option MAY appear in the options field of a DHCPv4
    /// message. If the status-code option does not appear, it is assumed
    /// that the operation was successful.  The status-code option SHOULD NOT
    /// appear in a message that is successful unless there is some text
    /// string that needs to be communicated to the requestor.
    /// 
    /// Length is a minimum of 1 byte.
    /// 
    /// https://tools.ietf.org/html/rfc6926#section-6.2.2
    /// </summary>
    public class OptionBulkLeaseQueryStatusCode : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 151;
            }
        }

        /// <summary>
        /// Get or sets status code
        /// </summary>
        public EBulkLeaseQueryStatusCode StatusCode { get; set; }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}