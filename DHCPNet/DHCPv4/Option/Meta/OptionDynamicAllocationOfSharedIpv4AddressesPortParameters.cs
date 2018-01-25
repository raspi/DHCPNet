namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The meanings of the offset, PSID-len, and PSID fields of the DHCPv4
    /// Port Parameters option are identical to those of the offset,
    /// PSID-len, and PSID fields of the S46 Port Parameters option
    /// (Section 4.5 of [RFC7598]).  The use of the same encoding in both
    /// options is meant to ensure compatibility with existing port-set
    /// implementations.
    /// 
    /// The format of OPTION_V4_PORTPARAMS is shown in Figure 1.
    /// 
    /// 0                             1
    /// 0  1  2  3  4  5  6  7  8  9  0  1  2  3  4  5
    /// +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    /// |      option-code      |     option-len        |
    /// +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    /// |         offset        |       PSID-len        |
    /// +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    /// |                     PSID                      |
    /// +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    /// 
    /// Figure 1: DHCPv4 Port Parameters Option
    /// 
    /// o  offset: PSID offset.  8-bit field that specifies the numeric value
    ///    for the excluded port range/offset bits('a' bits), as per
    ///    Section 5.1 of [RFC7597].  Allowed values are between 0 and 15,
    ///    with the default value being 6 for MAP-based implementations.
    ///    This parameter is unused by a Lightweight 4over6 client and should
    ///    be set to 0.
    /// o  PSID-len: Bit length value of the number of significant bits in
    ///    the PSID field(also known as 'k').  When set to 0, the PSID field
    ///    is to be ignored.After the first 'a' bits, there are k bits in
    ///    the port number representing the value of PSID.Subsequently, the
    ///    address-sharing ratio would be 2^k.
    /// o  PSID: Explicit 16-bit (unsigned word) PSID value.  The PSID value
    ///    algorithmically identifies a set of ports assigned to a client.
    ///    The first k bits on the left of this 2-octet field indicate the
    ///    PSID value. The remaining (16 - k) bits on the right are padding
    ///    zeros.
    /// 
    /// Section 5.1 of [RFC7597] provides a full description of how the PSID
    /// is interpreted by the client.
    /// 
    /// In order to exclude the system ports ([RFC6335]) or ports reserved by
    /// ISPs, the former port sets that contain well-known ports MUST NOT be
    /// assigned unless the operator has explicitly configured otherwise
    /// (e.g., by allocating a full IPv4 address).
    /// 
    /// Length is 4 bytes
    /// 
    /// https://tools.ietf.org/html/rfc7618#section-9
    /// </summary>
    public class OptionDynamicAllocationOfSharedIpv4AddressesPortParameters : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 159;
            }
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
                throw new OptionLengthNotExactException("Length is not 4");
            }

            throw new System.NotImplementedException();
        }


        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}