namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="OptionNetWareIpInformation"/>
    /// </summary>
    public class NetWareIpInformation
    {
        /// <summary>
        /// Gets or sets the option.
        /// </summary>
        public ENetWareIpInformation Option { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public byte[] Data { get; set; }
    }
}