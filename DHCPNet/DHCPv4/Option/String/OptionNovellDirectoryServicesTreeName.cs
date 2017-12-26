namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the name of the NDS tree the client will be
    /// contacting. NDS tree names are 16-bit Unicode strings. For
    /// transmission in the NDS Tree Name Option, an NDS tree name is
    /// transformed into octets using UTF-8. The string should NOT be zero
    /// terminated.
    /// 
    /// Maximum length 255 bytes.
    /// https://tools.ietf.org/html/rfc2241
    /// </summary>
    public class OptionNovellDirectoryServicesTreeName : AOptionString {
        public override byte Code
        {
            get
            {
                return 86;
            }
        }
    }
}