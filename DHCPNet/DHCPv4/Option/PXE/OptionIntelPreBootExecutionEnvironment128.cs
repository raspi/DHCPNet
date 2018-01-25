namespace DHCPNet.v4.Option
{
    /// <inheritdoc />
    public class OptionIntelPreBootExecutionEnvironment128 : OptionIntelPreBootExecutionEnvironmentBase
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 128;
            }
        }

        public override void ReadRaw(byte[] raw)
        {
            this.Raw = raw;
        }

        public override byte[] GetRawBytes()
        {
            return this.Raw;
        }
    }
}