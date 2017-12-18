using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the address to which the 
    /// client should transmit router solicitation requests.
    /// 
    /// Length 4 bytes.
    /// </summary>
    class OptionRouterSolicitationAddress : AOptionIPAddress
    {
        public override byte Code
        {
            get
            {
                return 32;
            }
        }
    }
}

