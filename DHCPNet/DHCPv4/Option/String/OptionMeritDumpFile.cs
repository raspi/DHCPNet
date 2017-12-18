using System.Text;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the path-name of a file to which
    /// the client's core image should be dumped in the event
    /// the client crashes.
    /// The path is formatted as a character string
    /// consisting of characters from the NVT ASCII character set.
    ///
    /// Minimum length 1 byte.
    /// </summary>
    class OptionMeritDumpFile : AOptionString
    {
        public override byte Code
        {
            get
            {
                return 14;
            }
        }

    }


}
