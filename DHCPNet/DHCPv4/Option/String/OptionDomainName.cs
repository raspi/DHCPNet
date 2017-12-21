using System.Text;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Don't confuse for OptionDomainNameServer.
    /// <seealso cref="OptionDomainNameServer"/>
    /// </summary>
    public class OptionDomainName : AOptionString
    {
        public OptionDomainName()
        {
        }

        public override byte Code
        {
            get
            {
                return 15;
            }
        }
    }
}