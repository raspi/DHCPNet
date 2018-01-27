namespace DHCPNet.v4.Option
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Session Initiation Protocol (SIP) IPv4 Servers
    /// <see cref="OptionSessionInitiationProtocolServers"/>
    /// <see cref="SessionInitiationProtocolServerEncoding"/>
    /// </summary>
    public class OptionSessionInitiationProtocolServerIPAddress : OptionSessionInitiationProtocolServerBase
    {

        /// <summary>
        /// IP addresses
        /// </summary>
        public List<IPv4Address> Addresses = new List<IPv4Address>();

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            byte[] tmp = new byte[this.Addresses.Count * 4];

            for (var index = 0; index < this.Addresses.Count; index++)
            {
                IPv4Address addr = this.Addresses[index];
                Array.Copy(addr.Address, 0, tmp, index * 4, 4);
            }

            return tmp;
        }
    }
}