namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Intel Preboot eXecution Environment (PXE)
    /// undefined (vendor specific)
    /// https://tools.ietf.org/html/rfc4578
    /// </summary>
    public abstract class OptionIntelPreBootExecutionEnvironmentBase : Option
    {
        /// <inheritdoc />
        public byte[] Raw { get; set; }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            this.Raw = raw;
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return this.Raw;
        }
    }
}