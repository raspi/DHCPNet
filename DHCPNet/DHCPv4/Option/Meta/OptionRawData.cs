namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Raw option data
    /// Usually unknown
    /// </summary>
    public class OptionRawData : Option
    {
        public byte[] RawBytes { get; set; }

        public byte _code { get; set; }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return this._code;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            this.RawBytes = raw;
        }


        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return this.RawBytes;
        }
    }
}