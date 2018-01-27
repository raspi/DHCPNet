namespace DHCPNet.v4.Option
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

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
                        IPv4Address ip = new IPv4Address(b);

                        Debug.WriteLine(string.Format("Adding IP {0}", ip));

                        addrs.Add(ip);
                    }

                    this.Addresses.Add(new OptionSessionInitiationProtocolServerIPAddress()
                                           {
                                               Type = SessionInitiationProtocolServerEncoding.Ipv4AddressList,
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
                byte[] data = addr.GetRawBytes();

                foreach (var i in data)
                {
                    b.Add(i);
                }
            }

            return b.ToArray();

        }
    }
}