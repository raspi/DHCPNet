using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The StreetTalk Directory Assistance (STDA)
    /// server option specifies a list of STDA 
    /// servers available to the client.
    /// 
    /// Servers SHOULD be listed in order of preference.
    ///
    /// Minimum length 4 bytes.
    /// Length MUST always be a multiple of 4.
    /// </summary>
    public class OptionStreetTalkDirectoryAssistanceServer : AOptionIPAddresses
    {
        public OptionStreetTalkDirectoryAssistanceServer()
        {
        }

        public override byte Code
        {
            get
            {
                return 76;
            }
        }
    }
}