using System.Net;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option is used in a client request (DHCPDISCOVER) 
    /// to allow the client to request that a particular 
    /// IP address be assigned.
    ///
    /// Length 4 bytes
    /// </summary>
    public class OptionRequestedIPAddress : AOptionIPAddress
    {
        public override byte Code
        {
            get
            {
                return 50;
            }
        }

    }

}
