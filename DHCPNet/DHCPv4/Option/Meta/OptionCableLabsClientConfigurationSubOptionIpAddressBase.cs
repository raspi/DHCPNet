namespace DHCPNet.v4.Option
{
    /// <summary>
    /// IPv4 address
    /// https://tools.ietf.org/html/rfc3495#section-5.1
    /// </summary>
    public abstract class OptionCableLabsClientConfigurationSubOptionIpAddressBase : OptionCableLabsClientConfigurationSubOption
    {
        public IPv4Address Address { get; set; }

        /// <inheritdoc />
        public void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionException("Zero length.");
            }

            if (raw.Length != 4)
            {
                throw new OptionException(string.Format("Invalid length: {0}", raw.Length));
            }

            Address = new IPv4Address(raw);
        }

        /// <inheritdoc />
        public byte[] GetRawBytes()
        {
            return Address.Address;
        }

    }
}