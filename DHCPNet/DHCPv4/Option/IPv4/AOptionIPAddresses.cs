using System;
using System.Collections.Generic;
using System.Net;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option which takes multiple IP Addressess as a param
    /// </summary>
    public abstract class AOptionIPAddresses : Option
    {
        /// <inheritdoc />
        public List<IPv4Address> IPAddresses { get; set; }

        /// <inheritdoc />
        protected AOptionIPAddresses()
        {
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            if (raw.Length % 4 != 0)
            {
                throw new OptionLengthNotMultipleOfException("Length must be multiple of 4.");
            }

            for (int i = 0; i < raw.Length; i += 4)
            {
                byte[] b = { 0, 0, 0, 0 };
                Array.Copy(raw, i, b, 0, 4);
                this.IPAddresses.Add(new IPv4Address(b));
            }
        }

        /// <summary>
        /// Set IP
        /// </summary>
        protected AOptionIPAddresses(IPv4Address ip)
        {
            this.IPAddresses.Add(ip);
        }

        /// <summary>
        ///
        /// </summary>
        protected AOptionIPAddresses(IPv4Address[] ips)
        {
            foreach (IPv4Address i in ips)
            {
                this.IPAddresses.Add(i);
            }
        }

        protected AOptionIPAddresses(List<IPv4Address> ips)
        {
            this.IPAddresses = ips;
        }

        /// <summary>
        /// Get IPv4 addresses 
        /// </summary>
        /// <returns></returns>
        public override byte[] GetRawBytes()
        {
            byte[] b = { };

            foreach (IPv4Address i in this.IPAddresses)
            {
                Array.Copy(i.Address, 0, b, 0, 4);
            }

            return b;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            string tmp = string.Empty;

            foreach (IPv4Address ip in IPAddresses)
            {
                tmp += ip + " ";
            }

            return tmp.TrimEnd(' ');
        }

    }
}