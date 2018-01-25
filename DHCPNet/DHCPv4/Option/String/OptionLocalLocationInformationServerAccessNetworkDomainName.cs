namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc5986#section-3.2
    /// </summary>
    public class OptionLocalLocationInformationServerAccessNetworkDomainName : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 213;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            throw new System.NotImplementedException();
        }


        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}