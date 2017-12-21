using System;

namespace DHCPNet
{
    public class IPv4Address
    {
        protected byte[] _addr;

        public byte[] Address
        {
            get
            {
                return this._addr;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new IPv4AddressException("Zero length.");
                }

                if (value.Length != 4)
                {
                    throw new IPv4AddressException(String.Format("Invalid length: {0}.", value.Length));
                }

                this._addr = value;
            }
        }

        public IPv4Address(byte[] v)
        {
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
