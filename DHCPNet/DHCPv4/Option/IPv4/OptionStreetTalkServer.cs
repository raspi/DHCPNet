using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The StreetTalk server option specifies a list 
    /// of StreetTalk servers available to the client.
    /// 
    /// Servers SHOULD be listed in order of preference.
    /// 
    /// Minimum length 4 bytes.
    /// Length MUST always be a multiple of 4.
    /// </summary>
    class OptionStreetTalkServer : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 75;
            }
        }
    }
}

