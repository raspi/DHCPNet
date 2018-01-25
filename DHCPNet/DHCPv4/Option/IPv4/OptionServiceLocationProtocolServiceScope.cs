namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// https://tools.ietf.org/html/rfc2610
    /// </summary>
    public class OptionServiceLocationProtocolServiceScope : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 79;
            }
        }

        /// <inheritdoc />
        public OptionServiceLocationProtocolServiceScope()
        {
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }
    }
}