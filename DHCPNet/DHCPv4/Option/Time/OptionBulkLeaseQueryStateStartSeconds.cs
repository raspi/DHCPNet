namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="OptionBulkLeaseQueryBaseTime"/>
    /// <see cref="OptionLeaseQueryClientLastTransactionTime"/>
    /// <see cref="OptionLeaseQueryAssociatedIpAddresses"/>
    /// <see cref="EMessageType.BulkLeaseDone"/>
    /// <see cref="EMessageType.BulkLeaseQuery"/>
    /// 
    /// The start-time-of-state option allows the receiver to determine the
    /// time at which the IP address made the transition into its current
    /// state.
    /// 
    /// This MUST NOT be an absolute time, which is equivalent to saying that
    /// this MUST NOT be an absolute number of seconds since January 1, 1970.
    /// Instead, this MUST be the unsigned integer number of seconds from the
    /// time the IP address transitioned its current state to the time
    /// specified in the base-time option in the same message.
    /// 
    /// This is an unsigned integer in network byte order.
    /// 
    /// https://tools.ietf.org/html/rfc6926#section-6.2.4
    /// </summary>
    public class OptionBulkLeaseQueryStateStartSeconds : AOptionTimeUint32
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 153;
            }
        }
    }
}