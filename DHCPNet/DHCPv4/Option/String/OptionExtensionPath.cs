using System.Text;

namespace DHCPNet.v4.Option
{
    /// <summary>
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
    /// </summary>
    public class OptionExtensionPath : AOptionString
    {
        public OptionExtensionPath()
        {
        }

        public override byte Code
        {
            get
            {
                return 18;
            }
        }
    }
}