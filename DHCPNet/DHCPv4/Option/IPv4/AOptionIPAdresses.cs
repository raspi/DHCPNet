using System;
using System.Collections.Generic;
using System.Net;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option which takes multiple IP Adressess as a param
    /// </summary>
    public abstract class AOptionIPAddresses : Option
    {
        public List<IPv4Address> IPAdresses = new List<IPv4Address>();

        protected AOptionIPAddresses()
        {
        }

        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0) throw new OptionException("Zero length.");
            if (raw.Length % 4 != 0) throw new OptionException("Length must be divisible by 4");

            for (int i = 0; i < raw.Length; i += 4)
            {
                byte[] b = { 0, 0, 0, 0 };
                Array.Copy(raw, i, b, 0, 4);
                IPAdresses.Add(new IPv4Address(b));
            }

        }

        /// <summary>
        /// Set IP
        /// </summary>
        protected AOptionIPAddresses(IPv4Address ip)
        {
            IPAdresses.Add(ip);
        }

        /// <summary>
        ///
        /// </summary>
        protected AOptionIPAddresses(IPv4Address[] ips)
        {
            foreach (IPv4Address i in ips)
            {
                IPAdresses.Add(i);
            }
        }

        protected AOptionIPAddresses(List<IPv4Address> ips)
        {
            IPAdresses = ips;
        }

        /// <summary>
        /// Get IPv4 addresses 
        /// </summary>
        /// <returns></returns>
        public override byte[] GetRawBytes()
        {
            byte[] b = { };

            foreach (IPv4Address i in IPAdresses)
            {
                Array.Copy(i.Address, 0, b, 0, 4);
            }

            return b;
        }

    }


}