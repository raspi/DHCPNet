namespace DHCPNet.v4.Option
{
    /// <inheritdoc />
    public class OptionIntelPreBootExecutionEnvironment133 : OptionIntelPreBootExecutionEnvironmentBase
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 133;
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