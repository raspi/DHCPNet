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
                return this._len;
            }
        }

        public byte[] Address
        {
            get
            {
                // Always return 16 bytes
                byte[] b = new byte[this.Length];
                Array.Copy(this._addr, 0, b, 0, this.Length);
                Array.Resize(ref b, 16);
                return b;
            }
            set
            {
                if (value.Length > 16)
                {
                    throw new Exception(String.Format("Invalid length: {0}.", value.Length));
                }

                this._len = (byte)value.Length;
                this._addr = value;
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

    }

}
