namespace DHCPNet.v4.Option
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// https://tools.ietf.org/html/rfc3361
    /// </summary>
    public class OptionSessionInitiationProtocolServers : Option {

        public List<string> DnsAddresses = new List<string>();
        public List<IPv4Address> Ipv4Addresses = new List<IPv4Address>();

        public override byte Code
        {
            get
            {
                return 120;
            }
        }

        public SessionInitiationProtocolServerEncoding Encoding { get; set; }

        public override void ReadRaw(byte[] raw)
        {
            Encoding = (SessionInitiationProtocolServerEncoding)raw[0];
            throw new NotImplementedException();
        }

        public override byte[] GetRawBytes()
        {
            byte[] raw = new[] { (byte)Encoding };

            throw new NotImplementedException();
        }
    }
}