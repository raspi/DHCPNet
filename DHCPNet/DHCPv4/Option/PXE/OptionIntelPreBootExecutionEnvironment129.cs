namespace DHCPNet.v4.Option
{
    /// <inheritdoc />
    public class OptionIntelPreBootExecutionEnvironment129 : OptionIntelPreBootExecutionEnvironmentBase
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 129;
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