namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc3925
    /// </summary>
    public class OptionVendorIdentifyingVendorClass : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 124;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}