namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Reference to the TZ Database
    /// https://tools.ietf.org/html/rfc4833
    /// </summary>
    public class OptionTimezoneDatabase : AOptionString
    {
        public override byte Code
        {
            get
            {
                return 101;
            }
        }
    }
}