using System.Text;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Extensions Path
    /// 
    /// A string to specify a file, retrievable via TFTP,
    /// which contains information which can be interpreted
    /// in the same way as the 64-octet vendor-extension
    /// field within the BOOTP response, with the following
    /// exceptions:
    /// - the length of the file is unconstrained;
    /// - all references to Tag 18 (i.e., instances of the
    ///   BOOTP Extensions Path field) within the file are
    ///   ignored.
    ///
    /// Minimum length is 1 byte.
    /// https://tools.ietf.org/html/rfc2132#section-3.20
    /// </summary>
    public class OptionExtensionPath : AOptionString
    {
        /// <inheritdoc />
        public OptionExtensionPath()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 18;
            }
        }
    }
}