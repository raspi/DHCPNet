namespace DHCPNet.v4.Option
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The NetWare/IP option code will be used to convey all the NetWare/IP
    /// related information except for the NetWare/IP domain name.
    /// 
    /// The code for this option is 63, and its maximum length is 255. A
    /// number of NetWare/IP sub-options will be conveyed using this option
    /// code.  The 'len' field for this option gives the length of the option
    /// data, which includes the sub-option code, length and data fields.
    /// 
    /// Each sub-option contains in sequential order, a one byte sub-option
    /// code, a one byte length, and an optional multiple byte value field.
    /// The sub-option length gives the length of the value field for the
    /// sub-option.The example below illustrates the use of the 'len' and
    /// sub-option length fields in this option.
    /// 
    /// One and only one of the following four sub-options must be the first
    /// sub-option to be present in option 63 encoding.Each of them is
    /// simply a type length pair with length set to zero.
    /// </summary>
    public class OptionNetWareIpInformation : Option
    {
        public List<NetWareIpInformation> Options { get; set; }

        public override byte Code
        {
            get
            {
                return 63;
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