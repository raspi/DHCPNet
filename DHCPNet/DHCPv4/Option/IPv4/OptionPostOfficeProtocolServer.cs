using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The POP3 server option specifies a list 
    /// of POP3 available to the client.
    /// 
    /// Servers SHOULD be listed in order of preference.
    ///
    /// Minimum length 4 bytes. 
    /// Length MUST always be a multiple of 4.
    /// </summary>
    class OptionPostOfficeProtocolServer : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 70;
            }
        }
    }
}

