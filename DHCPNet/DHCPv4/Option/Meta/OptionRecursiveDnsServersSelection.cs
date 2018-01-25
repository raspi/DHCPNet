namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <para>
    /// The DHCPv4 option described below can be used to inform resolvers
    /// which RDNSS can be contacted when initiating forward or reverse DNS
    /// lookup procedures.This option is DNS record type agnostic and
    /// applies, for example, equally to both A and AAAA queries.
    /// </para>
    /// <para>
    ///  0                   1                   2                   3
    ///  0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// |     CODE      |     Len       | Reserved  |prf|    Primary..  |
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// | .. DNS-recursive-name-server's IPv4 address   |  Secondary .. |
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// | .. DNS-recursive-name-server's IPv4 address   |               |
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+               |
    /// |                                                               |
    /// +                          Domains and networks                 |
    /// |                          (variable length)                    |
    /// |                                                               |
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// </para>
    /// 
    /// option-code:  RDNSS Selection(146)
    /// option-len:  Length of the option in octets
    /// Reserved: Field reserved for the future. 
    /// MUST be set to zero and MUST be ignored on receipt.
    /// 
    /// prf:  RDNSS preference:
    /// 00 Medium
    /// 01 High
    /// 10 Reserved - MUST NOT be sent. 
    /// 11 Low
    ///
    /// Reserved preference value (10) MUST NOT be sent. 
    /// On receipt, the Reserved value MUST be treated as Medium preference (00).
    ///
    /// Primary DNS-recursive-name-server's IPv4 address:  Address of a
    ///                                                     primary RDNSS
    ///
    /// Secondary DNS-recursive-name-server's IPv4 address:  Address of a
    ///                                                      secondary RDNSS
    ///                                                      or 0.0.0.0 if
    ///                                                      not configured
    ///
    /// Domains and networks:  The list of domains for forward DNS lookup and
    ///                        networks for reverse DNS lookup about which
    ///                        the RDNSSes have special knowledge.Field
    ///                        MUST be encoded as specified in Section 8 of
    ///                        [RFC3315].  A special domain of "." is used to
    ///                        indicate capability to resolve global names
    ///                        and act as the default RDNSS.Lack of a "."
    ///                        domain on the list indicates that RDNSSes only
    ///                        have information related to listed domains and
    ///                        networks.  Networks for reverse mapping are
    ///                        encoded as defined for IP6.ARPA[RFC3596] or
    ///                        IN-ADDR.ARPA[RFC2317].
    ///
    /// The RDNSS Selection option contains one or more domains of which the
    /// primary and secondary RDNSSes have particular knowledge.If the
    /// length of the domains and networks field causes option length to
    /// exceed the maximum permissible for a single option (255 octets), then
    /// multiple options MAY be used, as described in "Encoding Long Options
    /// in the Dynamic Host Configuration Protocol(DHCPv4)" [RFC3396].  When
    /// multiple options are present, the data portions of all option
    /// instances are concatenated together.
    ///
    /// The list of networks MUST cover all the domains configured in this
    /// option.The length of the included networks SHOULD be as long as
    /// possible to avoid potential collision with information received on
    /// other option instances or with options received from DHCP servers of
    /// other network interfaces.Overlapping networks are interpreted so
    /// that the resolver can use any of the RDNSSes for queries matching the
    /// networks.
    /// 
    /// If the RDNSS Selection option contains an RDNSS address already
    /// learned from other DHCPv4 servers of the same network and contains
    /// new domains or networks, the node SHOULD append the information to
    /// the information received earlier.The node MUST NOT remove
    /// previously obtained information.However, the node SHOULD NOT extend
    /// the lifetime of earlier information either.When a conflicting RDNSS
    /// address is learned from a less trusted interface, the node MUST
    /// ignore the option.
    ///
    /// The client SHALL periodically refresh information learned with the
    /// RDNSS Selection option.The information SHALL be refreshed on link-
    /// state changes, such as those caused by node mobility, and when
    /// extending the lease of IPv4 addresses configured with DHCPv4.
    /// 
    /// https://tools.ietf.org/html/rfc6731#section-4.3
    /// </summary>
    public class OptionRecursiveDnsServersSelection : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 146;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
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