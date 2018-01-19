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

        public List<MobilityServicesDiscoveryDnsAddress> Addresses { get; set; }

        public override byte Code
        {
            get
            {
                return 140;
            }
        }

        public override void ReadRaw(byte[] raw)
        {
            throw new NotImplementedException();
        }

        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }

    }
}