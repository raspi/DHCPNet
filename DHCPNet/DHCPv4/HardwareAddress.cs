using System;

namespace DHCPNet
{
    /// <summary>
    /// chaddr
    /// </summary>
    public class HardwareAddress
    {
        public byte[] Address = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public HardwareAddress()
        {
        }

        public HardwareAddress(byte[] raw)
        {
            if (raw.Length == 0) throw new Exception("Zero length.");
            if (raw.Length != 16) throw new Exception(String.Format("Invalid length: {0}.", raw.Length));
            Address = raw;
        }


        public HardwareAddress(MacAddress mac)
        {
            Array.Copy(mac.Address, 0, Address, 0, 6);
        }

    }
}
