using System;
using System.Net;

namespace DHCPNet.v4.Option
{
    public class IPAdressMaskPair
    {
        public IPv4Address Address = new IPv4Address(new byte[] { 0, 0, 0, 0 });

        public byte Netmask = 24;

        public IPAdressMaskPair()
        {
        }

        public override string ToString()
        {
            return String.Format("{0}/{1}", Address, Netmask);
        }
    }
}