namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option is used to return all of the IP addresses
    /// associated with the DHCP client specified in a particular
    /// DHCPLEASEQUERY message.
    /// 
    /// Code Len         Address 1               Address 2
    /// +-----+-----+-----+-----+-----+-----+-----+-----+--
    /// |  92 |  n  |  a1 |  a2 |  a3 |  a4 |  a1 |  a2 |  ...
    /// +-----+-----+-----+-----+-----+-----+-----+-----+--
    /// 
    /// Minimum length 4 bytes.
    /// Length MUST always be a multiple of 4.
    /// 
    /// https://tools.ietf.org/html/rfc4388
    /// 
    /// <see cref="OptionLeaseQueryClientLastTransactionTime"/>
    /// <see cref="EMessageType.LeaseActive"/>
    /// <see cref="EMessageType.LeaseQuery"/>
    /// <see cref="EMessageType.LeaseUnassigned"/>
    /// <see cref="EMessageType.LeaseUnknown"/>
    /// </summary>
    public class OptionLeaseQueryAssociatedIpAddresses : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 92;
            }
        }
    }
}