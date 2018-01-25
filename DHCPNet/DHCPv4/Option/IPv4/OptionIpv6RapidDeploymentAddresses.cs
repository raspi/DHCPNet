namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// IPv6 Rapid Deployment on IPv4 Infrastructures (6rd)
    /// 
    ///  0                   1                   2                   3
    ///  0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// |  OPTION_6RD   | option-length |  IPv4MaskLen  |  6rdPrefixLen |
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// |                                                               |
    /// |                           6rdPrefix                           |
    /// |                          (16 octets)                          |
    /// |                                                               |
    /// |                                                               |
    /// |                                                               |
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// |                     6rdBRIPv4Address(es)                      |
    /// .                                                               .
    /// .                                                               .
    /// .                                                               .
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// 
    /// https://tools.ietf.org/html/rfc5969#section-7.1.1
    /// </summary>
    public class OptionIpv6RapidDeploymentAddresses : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 212;
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