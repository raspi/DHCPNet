﻿namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies a list of
    /// RFC 887 Resource Location servers available to the client.
    /// 
    /// Servers SHOULD be listed in order of preference.
    /// 
    /// </summary>
    public class OptionResourceLocationServer : AOptionIPAddresses
    {
        public OptionResourceLocationServer()
        {
        }

        public override byte Code
        {
            get
            {
                return 11;
            }
        }
    }
}