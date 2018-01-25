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
    /// The dhcp-state option allows greater detail to be returned than
    /// allowed by the DHCPLEASEACTIVE and DHCPLEASEUNASSIGNED message types.
    /// 
    ///  0                   1                   2
    ///  0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// |     156       |    Length     |    State      |
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// 
    /// Length The option length, 1 octet.
    /// 
    /// State The state of the IP address.
    /// 
    /// 1 AVAILABLE Address is available to local DHCPv4 server
    /// 2 ACTIVE Address is assigned to a DHCPv4 client
    /// 3 EXPIRED Lease has expired
    /// 4 RELEASED Lease has been released by DHCPv4 client
    /// 5 ABANDONED Server or client flagged address as unusable
    /// 6 RESET Lease was freed by some external agent
    /// 7 REMOTE Address is available to a remote DHCPv4 server
    /// 8 TRANSITIONING Address is moving between states
    /// 
    /// Note that some of these states may be transient and may not appear in
    /// normal use.  A DHCPv4 server MUST implement at least the AVAILABLE
    /// and ACTIVE states and SHOULD implement at least the ABANDONED and
    /// RESET states.
    /// 
    /// Length 1 byte.
    /// 
    /// https://tools.ietf.org/html/rfc6926#section-6.2.7
    /// </summary>
    public class OptionBulkLeaseQueryDhcpState : Option
    {
        /// <summary>
        /// Gets or sets state
        /// </summary>
        public EBulkLeaseQueryDhcpState State { get; set; }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 156;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            if (raw.Length != 1)
            {
                throw new OptionLengthNotExactException("Length is not 1.");
            }

            State = (EBulkLeaseQueryDhcpState)raw[0];
        }


        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return new byte[] { (byte)State };
        }
    }
}