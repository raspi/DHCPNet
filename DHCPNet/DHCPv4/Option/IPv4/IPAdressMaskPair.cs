using System;
using System.Net;

namespace DHCPNet.v4.Option
{
    public class IPAdressMaskPair
    {
        public IPv4Address IP = new IPv4Address(new byte[] { 0, 0, 0, 0 });

        public byte Netmask = 24;

        public IPAdressMaskPair()
        {
        }
    }
}