namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <para>
    /// In the above diagram, Searchstring is a string specifying the
    /// searchlist. If the length of the searchlist exceeds the maximum
    /// permissible within a single option(255 octets), then multiple
    /// options MAY be used, as described in "Encoding Long Options in the
    /// Dynamic Host Configuration Protocol(DHCPv4)" [RFC3396].
    /// </para>
    /// <para>
    /// To enable the searchlist to be encoded compactly, searchstrings in
    /// the searchlist MUST be concatenated and encoded using the technique
    /// described in section 4.1.4 of "Domain Names - Implementation And
    /// Specification" [RFC1035].  In this scheme, an entire domain name or a
    /// list of labels at the end of a domain name is replaced with a pointer
    /// to a prior occurrence of the same name.Despite its complexity, this
    /// technique is valuable since the space available for encoding DHCP
    /// options is limited, and it is likely that a domain searchstring will
    /// contain repeated instances of the same domain name.  Thus the DNS
    /// name compression is both useful and likely to be effective.
    /// </para>
    /// <para>
    /// For use in this specification, the pointer refers to the offset
    /// within the data portion of the DHCP option (not including the
    /// preceding DHCP option code byte or DHCP option length byte).
    /// </para>
    /// <para>
    /// If multiple Domain Search Options are present, then the data portions
    /// of all the Domain Search Options are concatenated together as
    /// specified in "Encoding Long DHCP Options in the Dynamic Host
    /// Configuration Protocol(DHCPv4)" [RFC3396] and the pointer indicates
    /// an offset within the complete aggregate block of data.
    /// </para>
    /// <para>
    /// https://tools.ietf.org/html/rfc3397
    /// </para>
    /// </summary>
    public class OptionDomainSearch : Option
    {
        public override byte Code
        {
            get
            {
                return 119;
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