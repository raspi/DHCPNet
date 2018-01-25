namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option Overload
    /// 
    /// This option is used to indicate that the DHCP 'sname' or 'file'
    /// fields are being overloaded by using them to carry DHCP options.A
    /// DHCP server inserts this option if the returned parameters will
    /// exceed the usual space allotted for options.
    ///
    /// If this option is present, the client interprets the specified
    /// additional fields after it concludes interpretation of the standard
    /// option fields.
    ///
    /// The code for this option is 52, and its length is 1.  Legal values
    /// for this option are:
    ///
    /// Value Meaning
    /// ----- --------
    ///   1   the 'file' field is used to hold options
    ///   2   the 'sname' field is used to hold options
    ///   3   both fields are used to hold options
    /// 
    /// https://tools.ietf.org/html/rfc2132#section-9.3
    /// </summary>
    public class OptionOverload : Option
    {
        /// <inheritdoc />
        public EOverload OverloadType = EOverload.File;

        /// <inheritdoc />
        public OptionOverload()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 52;
            }
        }

        public override byte[] GetRawBytes()
        {
            return new byte[] { (byte)OverloadType };
        }

        public override void ReadRaw(byte[] raw)
        {
            OverloadType = (EOverload)raw[0];
        }
    }
}