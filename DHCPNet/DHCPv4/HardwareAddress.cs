using System;

namespace DHCPNet
{
    /// <summary>
    /// chaddr
    /// </summary>
    public class HardwareAddress
    {
        protected byte[] _addr = { };

        protected byte _len;

        public byte Length
        {
            get
            {
                return _len;
            }
        }

        public byte[] Address
        {
            get
            {
                // Always return 16 bytes
                byte[] b = new byte[Length];
                Array.Copy(_addr, 0, b, 0, Length);
                Array.Resize(ref b, 16);
                return b;
            }
            set
            {
                if (value.Length > 16)
                {
                    throw new Exception(String.Format("Invalid length: {0}.", value.Length));
                }

                _len = (byte)value.Length;
                _addr = value;
            }
        }

        public HardwareAddress()
        {
        }

        public HardwareAddress(byte[] raw)
        {
            Address = raw;
        }

        public HardwareAddress(MacAddress mac)
        {
            Address = mac.Address;
        }

        public override string ToString()
        {
            string o = String.Empty;
            foreach (byte i in this._addr)
            {
                o += String.Format("{0:x2} ", i);
            }

            return o;
        }
    }
}