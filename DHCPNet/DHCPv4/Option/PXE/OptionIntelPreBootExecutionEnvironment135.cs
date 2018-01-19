namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Intel Preboot eXecution Environment (PXE)
    /// undefined (vendor specific)
    /// https://tools.ietf.org/html/rfc4578
    /// </summary>
    public class OptionIntelPreBootExecutionEnvironment135 : OptionIntelPreBootExecutionEnvironmentBase
    {
        public override byte Code
        {
            get
            {
                return 135;
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