namespace DHCPNet.v4.Option
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Fully Qualified Domain Names
    /// https://tools.ietf.org/html/rfc5678
    /// Related: https://tools.ietf.org/html/rfc5677
    /// </summary>
    public class OptionMobilityServicesDiscoveryServerDomainAddresses : Option
    {
        /// <inheritdoc />
        public List<MobilityServicesDiscoveryDnsAddress> Addresses { get; set; }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 140;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }

    }
}