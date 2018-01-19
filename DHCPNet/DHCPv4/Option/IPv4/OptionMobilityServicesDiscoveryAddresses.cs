namespace DHCPNet.v4.Option
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// https://tools.ietf.org/html/rfc5678
    /// Related: https://tools.ietf.org/html/rfc5677
    /// </summary>
    public class OptionMobilityServicesDiscoveryServerAddresses : Option {

        public List<MobilityServicesDiscoveryAddress> Addresses { get; set; }

        public override byte Code
        {
            get
            {
                return 139;
            }
        }

        public override void ReadRaw(byte[] raw)
        {
            int offset = 0;

            do
            {
                EMobilityServicesDiscoverySubOption type = (EMobilityServicesDiscoverySubOption)raw[++offset];
                byte len = raw[++offset];

                if (len == 0)
                {
                    offset++;

                    // Add option without any addresses listed
                    this.Addresses.Add(new MobilityServicesDiscoveryAddress()
                                      {
                                          Type = type,
                                          Addresses = new List<IPv4Address>(),
                                      });

                    // read next
                    continue;
                }

                if (len % 4 != 0)
                {
                    throw new OptionException(String.Format("Not divisiable by 4"));
                }

                // Add one or multiple IPv4 addresses
                List<IPv4Address> addr = new List<IPv4Address>();

                for (int i = 0; i < len; i += 4)
                {
                    offset += i;
                    byte[] buf = new byte[4] { 0, 0, 0, 0 };
                    Array.Copy(raw, offset, buf, 0, 4);
                    IPv4Address a = new IPv4Address(buf);
                }

                this.Addresses.Add(new MobilityServicesDiscoveryAddress()
                                  {
                                      Type = type,
                                      Addresses = addr,
                                  });

            }
            while (offset < raw.Length);
        }

        public override byte[] GetRawBytes()
        {
            byte[] o = { };
            int offset = 0;

            foreach (MobilityServicesDiscoveryAddress a in this.Addresses)
            {
                o[++offset] = (byte)a.Type;

                // Length
                o[++offset] = (byte)(a.Addresses.Count * 4);
                foreach (IPv4Address ip in a.Addresses)
                {
                    Array.Copy(ip.Address, 0, o, offset, 4);
                    offset += 4;
                }
            }

            return o;
        }

    }
}