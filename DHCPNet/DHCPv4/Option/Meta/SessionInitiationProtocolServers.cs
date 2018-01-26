namespace DHCPNet.v4.Option
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Session Initiation Protocol (SIP) Servers
    /// 
    /// https://tools.ietf.org/html/rfc3361
    /// </summary>
    public class OptionSessionInitiationProtocolServers : Option
    {
        /// <inheritdoc />
        public List<OptionSessionInitiationProtocolServerBase> Addresses = new List<OptionSessionInitiationProtocolServerBase>();

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 120;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            SessionInitiationProtocolServerEncoding enc = (SessionInitiationProtocolServerEncoding)raw[0];

            switch (enc)
            {
                case SessionInitiationProtocolServerEncoding.DnsNameOfSipServer:
                    if (raw.Length < 3)
                    {
                        throw new OptionLengthException("Minimum length is 3 bytes.");
                    }

                    throw new NotImplementedException();
                    //Addresses = new List<OptionSessionInitiationProtocolServerDomainAddress>();
                    break;

                case SessionInitiationProtocolServerEncoding.Ipv4AddressList:
                    if (raw.Length < 5)
                    {
                        throw new OptionLengthException("Minimum length is 5 bytes.");
                    }

                    if ((raw.Length - 1) % 4 != 0)
                    {
                        throw new OptionLengthNotMultipleOfException("Length is not multiple of 4.");
                    }

                    List<IPv4Address> addrs = new List<IPv4Address>();

                    for (int i = 1; i < raw.Length; i += 4)
                    {
                        byte[] b = { 0, 0, 0, 0 };
                        Array.Copy(raw, i, b, 0, 4);
                        addrs.Add(new IPv4Address(b));
                    }

                    this.Addresses.Add(new OptionSessionInitiationProtocolServerIPAddress()
                                           {
                                               Addresses = addrs,
                                           });

                    //Addresses = new List<OptionSessionInitiationProtocolServerIPAddress>();
                    break;
            }

            if (this.Addresses.Count == 0)
            {
                throw new OptionException("No addresses.");
            }

        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            List<byte> b = new List<byte>();

            foreach (var addr in this.Addresses)
            {
                b.Add((byte)addr.Type);
                foreach (var i in addr.GetRawBytes())
                {
                    b.Add(i);
                }
            }

            return b.ToArray();

        }
    }
}