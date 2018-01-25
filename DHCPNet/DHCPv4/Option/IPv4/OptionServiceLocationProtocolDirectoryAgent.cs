namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// https://tools.ietf.org/html/rfc2610
    /// </summary>
    public class OptionServiceLocationProtocolDirectoryAgent : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 78;
            }
        }

        /// <inheritdoc />
        public OptionServiceLocationProtocolDirectoryAgent()
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