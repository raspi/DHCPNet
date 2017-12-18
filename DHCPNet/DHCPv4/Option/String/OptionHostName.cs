using System.Text;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the name of the client.
    /// The name may or may not be qualified with
    /// the local domain name(see section 3.17 for the
    /// preferred way to retrieve the domain name).
    /// See RFC 1035 for character set restrictions.
    ///
    /// Minimum length is 1 byte.
    /// </summary>
    class OptionHostName : AOptionString
    {
        public override byte Code
        {
            get
            {
                return 12;
            }
        }
    }


}
