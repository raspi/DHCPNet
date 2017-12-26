namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies one or more NDS servers for the client to
    /// contact for access to the NDS database.
    /// 
    /// Servers SHOULD be listed in order of preference.
    /// 
    /// The code for this option is 85. The minimum length of this option is
    /// 4 octets, and the length MUST be a multiple of 4.
    /// https://tools.ietf.org/html/rfc2241
    /// </summary>
    public class OptionNovellDirectoryServicesServers : AOptionIPAddresses {
        public override byte Code
        {
            get
            {
                return 85;
            }
        }
    }
}