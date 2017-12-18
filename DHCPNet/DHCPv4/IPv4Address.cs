using System;

namespace DHCPNet
{
    public class IPv4Address
    {
        public byte[] Address = { 0, 0, 0, 0 };

        public IPv4Address(byte[] v)
        {
            if (v.Length == 0) throw new IPv4AddressException("Zero length.");
            if (v.Length != 4) throw new IPv4AddressException(String.Format("Invalid length: {0}.", v.Length));
            Address = v;
        }

        public IPv4Address(UInt32 v)
        {
            Address = BitConverter.GetBytes(v);
        }

        public UInt32 ToUInt32()
        {
            return BitConverter.ToUInt32(Address, 0);
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}.{2}.{3}", Address[0], Address[1], Address[2], Address[3]);
        }

    }


}
