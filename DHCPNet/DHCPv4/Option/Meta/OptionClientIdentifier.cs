using System;
using System.Text;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option is used by DHCP clients to specify their unique
    /// identifier. DHCP servers use this value to index their database of
    /// address bindings. This value is expected to be unique for all
    /// clients in an administrative domain.
    ///
    /// Identifiers SHOULD be treated as opaque objects by DHCP servers.
    ///
    /// The client identifier MAY consist of type-value pairs similar to the
    /// 'htype'/'chaddr' fields defined in DHCP header. For instance, it 
    /// MAY consist of a hardware type and hardware address. In this case 
    /// the type field SHOULD be one of the ARP hardware types defined in STD2.
    /// A hardware type of 0 (zero) should be used when the value field
    /// contains an identifier other than a hardware address (e.g.a fully
    /// qualified domain name).
    ///
    /// For correct identification of clients, each client's client-
    /// identifier MUST be unique among the client-identifiers used on the
    /// subnet to which the client is attached.  Vendors and system
    /// administrators are responsible for choosing client-identifiers that
    /// meet this requirement for uniqueness.
    ///
    /// Minimum length 2 bytes.
    /// </summary>
    class OptionClientIdentifier : Option
    {
        public override byte Code
        {
            get
            {
                return 61;
            }
        }

        public byte Type = 6;
        public byte[] Identifier = { };

        public override void ReadRaw(byte[] raw)
        {
            Type = raw[0];
            Array.Copy(raw, 1, Identifier, 0, raw.Length - 1);
        }

        public override byte[] GetRawBytes()
        {
            byte[] b = { Type };
            Array.Copy(Identifier, 0, b, 1, Identifier.Length);

            return b;
        }

        public OptionClientIdentifier(string id)
        {
            Type = 0;
            Identifier = StringToBytes(id);
        }

    }

}
