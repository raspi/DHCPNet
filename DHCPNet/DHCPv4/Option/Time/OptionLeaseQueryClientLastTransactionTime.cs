namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option allows the receiver to determine the time of the
    /// most recent access of the client. It is particularly useful
    /// when DHCPLEASEACTIVE messages from two different DHCP servers
    /// need to be compared, although it can be useful in other
    /// situations. The value is a duration in seconds from the
    /// current time into the past when this IP address was most
    /// recently the subject of communication between the client and
    /// DHCP server.
    /// 
    /// This MUST NOT be an absolute time. This MUST NOT be an
    /// absolute number of seconds since Jan. 1, 1970. Instead, this
    /// MUST be an integer number of seconds in the past from the time
    /// the DHCPLEASEACTIVE message is sent that the client last dealt
    /// with this server about this IP address. In the same way that
    /// the IP Address Lease Time option (option 51) encodes a lease
    /// time that is a number of seconds into the future from the time
    /// the message was sent, this option encodes a value that is a
    /// number of seconds into the past from when the message was
    /// sent.
    /// 
    /// Length 4 bytes.
    /// 
    /// https://tools.ietf.org/html/rfc4388
    /// 
    /// <see cref="OptionLeaseQueryAssociatedIpAddresses"/>
    /// <see cref="EMessageType.LeaseActive"/>
    /// <see cref="EMessageType.LeaseQuery"/>
    /// <see cref="EMessageType.LeaseUnassigned"/>
    /// <see cref="EMessageType.LeaseUnknown"/>
    /// </summary>
    public class OptionLeaseQueryClientLastTransactionTime : AOptionTimeUint32
    {
        public override byte Code
        {
            get
            {
                return 91;
            }
        }

    }
}