using System;
using System.Collections.Generic;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option which takes one IP Address as a param
    /// </summary>
    public abstract class AOptionIPAddress : Option
    {
        /// <inheritdoc />
        public List<IPv4Address> Address { get; set; }

        /// <inheritdoc />
        protected AOptionIPAddress()
        {
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            if (raw.Length != 4)
            {
                throw new OptionLengthNotExactException(string.Format("Invalid length: {0}", raw.Length));
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

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return Address[0].Address;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Address[0].Address.ToString();
        }
    }
}