using System;
using System.Collections.Generic;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option which takes one IP Adress as a param
    /// </summary>
    public abstract class AOptionIPAddress : Option
    {
        public List<IPv4Address> Address = new List<IPv4Address>();

        protected AOptionIPAddress()
        {
        }

        protected AOptionIPAddress(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionException("Zero length.");
            }

            if (raw.Length != 4)
            {
                throw new OptionException(String.Format("Invalid length: {0}", raw.Length));
            }

            Address.Add(new IPv4Address(raw));
        }

        /// <summary>
        /// Add IPv4 Address to list
        /// </summary>
        protected AOptionIPAddress(IPv4Address ip)
        {
            Address.Add(ip);
        }

        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionException("Zero length.");
            }

            if (raw.Length != 4)
            {
                throw new OptionException(String.Format("Invalid length: {0}", raw.Length));
            }

            Address.Add(new IPv4Address(raw));
        }

        /// <summary>
        ///
        /// </summary>
        public List<IPv4Address> GetIPs()
        {
            return Address;
        }

        public override byte[] GetRawBytes()
        {
            return Address[0].Address;
        }
    }
}