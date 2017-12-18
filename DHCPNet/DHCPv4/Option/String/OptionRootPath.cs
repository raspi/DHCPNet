using System.Text;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the path-name that contains the
    /// client's root disk. The path is formatted as a
    /// character string consisting of characters from
    /// the NVT ASCII character set.
    /// </summary>
    class OptionRootPath : AOptionString
    {
        public override byte Code
        {
            get
            {
                return 17;
            }
        }

    }

}
