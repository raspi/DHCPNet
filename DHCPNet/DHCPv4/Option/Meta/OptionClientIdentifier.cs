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
    public class OptionClientIdentifier : Option
    {
        public override byte Code
        {
            get
            {
                return 61;
            }
        }

        public EHardwareType Type { get; set; }

        protected byte[] _id;

        public byte[] Identifier
        {
            get
            {
                return this._id;
            }
            set
            {
                if (value.Length < 2)
                {
                    throw new OptionException("Minimum length 2");
                }

                this._id = value;
            }
        }

        public override void ReadRaw(byte[] raw)
        {
            Type = (EHardwareType)raw[0];
            Array.Copy(raw, 1, Identifier, 0, raw.Length - 1);
        }

        public override byte[] GetRawBytes()
        {
            byte[] b = { (byte)Type };
            Array.Copy(Identifier, 0, b, 1, Identifier.Length);

            return b;
        }

        public OptionClientIdentifier(byte[] id)
        {
            if (id.Length == 6)
            {
                this.Type = EHardwareType.Ethernet;
            }

            Array.Copy(id, 1, Identifier, 0, id.Length - 1);
        }

        public OptionClientIdentifier(byte[] id, EHardwareType type)
        {
            this.Type = type;

            Identifier = id;
        }

        public OptionClientIdentifier(string id)
        {
            Type = 0;
            Identifier = StringToBytes(id);
        }

    }

}
