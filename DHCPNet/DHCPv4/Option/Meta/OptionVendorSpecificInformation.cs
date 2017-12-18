using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option is used by clients and servers to exchange vendor-
    /// specific information. The information is an opaque object of n
    /// octets, presumably interpreted by vendor-specific code on the clients
    /// and servers. The definition of this information is vendor specific.
    ///
    /// The vendor is indicated in the vendor class identifier option.
    /// Servers not equipped to interpret the vendor-specific information
    /// sent by a client MUST ignore it (although it may be reported).
    /// 
    /// Clients which do not receive desired vendor-specific information
    /// SHOULD make an attempt to operate without it, although they may do so
    /// (and announce they are doing so) in a degraded mode.
    ///
    /// If a vendor potentially encodes more than one item of information in
    /// this option, then the vendor SHOULD encode the option using
    /// "Encapsulated vendor-specific options" as described below:
    ///
    /// The Encapsulated vendor-specific options field SHOULD be encoded as a
    /// sequence of code/length/value fields of identical syntax to the DHCP
    /// options field with the following exceptions:
    ///
    ///   1) There SHOULD NOT be a "magic cookie" field in the encapsulated
    ///      vendor-specific extensions field.
    ///
    ///   2) Codes other than 0 or 255 MAY be redefined by the vendor within
    ///      the encapsulated vendor-specific extensions field, but SHOULD
    ///      conform to the tag-length-value syntax defined in section 2.
    ///
    ///   3) Code 255 (END), if present, signifies the end of the
    ///      encapsulated vendor extensions, not the end of the vendor
    ///      extensions field.If no code 255 is present, then the end of
    ///      the enclosing vendor-specific information field is taken as the
    ///      end of the encapsulated vendor-specific extensions field.
    ///
    /// Minimum length 1 byte.
    /// </summary>
    class OptionVendorSpecificInformation : Option
    {
        public byte[] VendorSpecificInformation = { };

        public override byte Code
        {
            get
            {
                return 43;
            }
        }

        public override byte[] GetRawBytes()
        {
            return VendorSpecificInformation;
        }

        public override void ReadRaw(byte[] raw)
        {
            VendorSpecificInformation = raw;
        }
    }
}

