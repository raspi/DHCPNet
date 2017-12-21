using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The SMTP server option specifies a list of 
    /// SMTP servers available to the client.
    /// 
    /// Servers SHOULD be listed in order of preference.
    ///
    /// Minimum length 4 bytes.
    /// Length MUST always be a multiple of 4.
    /// </summary>
    public class OptionSimpleMailTransportProtocolServer : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 69;
            }
        }
    }
}

