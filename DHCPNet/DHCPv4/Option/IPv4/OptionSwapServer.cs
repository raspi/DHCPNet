using System.Net;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This specifies the IP address of the client's swap server.
    ///
    /// Length 4 bytes.
    /// </summary>
    public class OptionSwapServer : AOptionIPAddress
    {
        public override byte Code
        {
            get
            {
                return 16;
            }
        }

    }


}
