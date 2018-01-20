namespace DHCPNet.v4.Option
{
    /// <summary>
    ///  This specification defines DHCP option code 141, the "SIP UA
    /// Configuration Service Domains" for inclusion in the IANA registry
    /// "BOOTP Vendor Extensions and DHCP Options" defined by [RFC2939].
    ///        0                   1                   2                   3
    ///    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |      141      |     Len       |         Searchstring...       |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///   |                     Searchstring...                           |
    ///   +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///
    /// In the above diagram, Searchstring is a string specifying the
    /// searchlist.If the length of the searchlist exceeds the maximum
    /// permissible within a single option (255 octets), then multiple
    /// options MAY be used, as described in [RFC3396] "Encoding Long DHCP
    /// Options in the Dynamic Host Configuration Protocol(DHCPv4)".
    ///
    /// To enable the searchlist to be encoded compactly, searchstrings in
    /// the searchlist MUST be concatenated and encoded using the technique
    /// described in Section 4.1.4 of[RFC1035], "Domain Names -
    /// Implementation and Specification".  In this scheme, an entire domain
    /// name or a list of labels at the end of a domain name is replaced with
    /// a pointer to a prior occurrence of the same name.Despite its
    /// complexity, this technique is valuable since the space available for
    /// encoding DHCP options is limited, and it is likely that a domain
    /// searchstring will contain repeated instances of the same domain name.
    /// Thus, the DNS name compression is both useful and likely to be
    /// effective.
    ///
    /// For use in this specification, the pointer refers to the offset
    /// within the data portion of the DHCP option (not including the
    /// preceding DHCP option code byte or DHCP option length byte).
    ///
    /// If multiple SIP UA Configuration Service Domains options are present,
    /// then the data portions of all the SIP UA Configuration Service
    /// Domains options are concatenated together as specified in RFC 3396,
    /// and the pointer indicates an offset within the complete aggregate
    /// block of data.
    ///
    /// For examples of encoding this option, see Section 3 of[RFC3397],
    /// "Dynamic Host Configuration Protocol (DHCP) Domain Search Option",
    /// which uses the same encoding for option 119.
    /// 
    /// https://tools.ietf.org/html/rfc6011#section-4.1
    /// </summary>
    public class OptionSessionInitiationProtocolUserAgentConfigurationServiceDomains : Option
    {

        public override byte Code
        {
            get
            {
                return 141;
            }
        }

        public override void ReadRaw(byte[] raw)
        {
            throw new System.NotImplementedException();
        }

        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}