using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The IRC server option specifies a list of IRC available to the
    /// client. 
    /// 
    /// Servers SHOULD be listed in order of preference.
    /// 
    /// Minimum length 4 bytes.
    /// Length MUST always be a multiple of 4.
    /// </summary>
    public class OptionDefaultInternetRelayChat : AOptionIPAddresses
    {
        public OptionDefaultInternetRelayChat()
        {
        }

        public override byte Code
        {
            get
            {
                return 74;
            }
        }
    }
}