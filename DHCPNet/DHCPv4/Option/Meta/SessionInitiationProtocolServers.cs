namespace DHCPNet.v4.Option
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// https://tools.ietf.org/html/rfc3361
    /// </summary>
    public class OptionSessionInitiationProtocolServers : Option
    {
        /// <inheritdoc />
        public List<string> DnsAddresses = new List<string>();

        /// <inheritdoc />
        public List<IPv4Address> Ipv4Addresses = new List<IPv4Address>();

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 120;
            }
        }

        /// <inheritdoc />
        public SessionInitiationProtocolServerEncoding Encoding { get; set; }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            Encoding = (SessionInitiationProtocolServerEncoding)raw[0];
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            byte[] raw = new[] { (byte)Encoding };

            throw new NotImplementedException();
        }
    }
}