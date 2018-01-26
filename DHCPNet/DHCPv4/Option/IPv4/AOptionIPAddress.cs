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
        public IPv4Address Address { get; set; }

        /// <inheritdoc />
        protected AOptionIPAddress()
        {
        }

        /// <summary>
        /// Replace IPv4 Address in list
        /// </summary>
        protected AOptionIPAddress(IPv4Address ip)
        {
            this.Address = ip;
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

            this.Address = new IPv4Address(raw);
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return this.Address.Address;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.Address.Address.ToString();
        }
    }
}