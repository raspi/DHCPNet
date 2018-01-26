using System.Text;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Domain Name
    /// 
    /// This option specifies the domain name that client should use when
    /// resolving hostnames via the Domain Name System.
    /// 
    /// Don't confuse for OptionDomainNameServer.
    /// <seealso cref="OptionDomainNameServer"/>
    /// https://tools.ietf.org/html/rfc2132#section-3.17
    /// </summary>
    public class OptionDomainName : AOptionString
    {
        /// <inheritdoc />
        public OptionDomainName()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 15;
            }
        }
    }
}