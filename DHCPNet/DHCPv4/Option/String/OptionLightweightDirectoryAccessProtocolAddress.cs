namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Never published in an RFC
    /// https://tools.ietf.org/html/rfc3679
    /// </summary>
    public class OptionLightweightDirectoryAccessProtocolAddress : AOptionString
    {
        public override byte Code
        {
            get
            {
                return 95;
            }
        }
    }
}