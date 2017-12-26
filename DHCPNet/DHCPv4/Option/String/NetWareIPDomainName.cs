namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option code is used to convey the NetWare/IP domain name used by
    /// the NetWare/IP product.
    /// 
    /// The NetWare/IP Domain in the option is an NVT ASCII string whose 
    /// length is inferred from the option 'len' field.
    /// 
    /// https://tools.ietf.org/html/rfc2242
    /// </summary>
    public class OptionNetWareIpDomainName : AOptionString {
        public override byte Code
        {
            get
            {
                return 62;
            }
        }
    }
}