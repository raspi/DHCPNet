using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The Finger server option specifies a list of 
    /// Finger servers available to the client. 
    /// 
    /// Servers SHOULD be listed in order of preference.
    ///
    /// Minimum length 4 bytes.
    /// Length MUST always be a multiple of 4.
    /// </summary>
    public class OptionDefaultFingerServer : AOptionIPAddresses
    {
        public OptionDefaultFingerServer()
        {
        }

        public override byte Code
        {
            get
            {
                return 73;
            }
        }
    }
}