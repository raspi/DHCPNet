namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="OptionBulkLeaseQueryStateStartSeconds"/>
    /// <see cref="OptionBulkLeaseQueryBaseTime"/>
    /// <see cref="OptionLeaseQueryClientLastTransactionTime"/>
    /// <see cref="OptionLeaseQueryAssociatedIpAddresses"/>
    /// <see cref="EMessageType.BulkLeaseDone"/>
    /// <see cref="EMessageType.BulkLeaseQuery"/>
    /// <see cref="EBulkLeaseQueryDataSource"/>
    /// 
    /// The data-source option contains information about the source of the
    /// data in a DHCPLEASEACTIVE or a DHCPLEASEUNASSIGNED message. It
    /// SHOULD be used when there are two or more servers that might have
    /// information about a particular IP address binding.  Frequently, two
    /// servers work together to provide an increased availability solution
    /// for the DHCPv4 service, and in these cases, both servers will respond
    /// 
    /// to Bulk Leasequery requests for the same IP address.  When one server
    /// is working with another server and both may respond with information
    /// 
    /// about the same IP address, each server SHOULD return the data-source
    /// option with the other information provided about the IP address.
    /// 
    /// The data contained in this option will allow an external process to
    /// better discriminate between the information provided by each of the
    /// servers servicing this IPv4 address.
    /// </summary>
    public class OptionBulkLeaseQueryDataSource : Option
    {
        /// <summary>
        /// Gets or sets dhcp state
        /// </summary>
        public EBulkLeaseQueryDataSource Source { get; set; }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 157;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionException("Zero length");
            }

            if (raw.Length != 1)
            {
                throw new OptionException("Length is not 1.");
            }

            this.Source = (EBulkLeaseQueryDataSource)raw[0];
        }


        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return new byte[] { (byte)this.Source };
        }
    }
}