namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc3495#section-4
    /// </summary>
    public abstract class OptionCableLabsClientConfigurationSubOption
    {
        public ECableLabsClientConfigurationSubOptionCode Type { get; set; }

        /// <inheritdoc />
        public void ReadRaw(byte[] raw)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}