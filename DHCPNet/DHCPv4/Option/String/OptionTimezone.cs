namespace DHCPNet.v4.Option
{
    /// <summary>
    /// IEEE 1003.1 String
    /// https://tools.ietf.org/html/rfc4833
    /// </summary>
    public class OptionTimezone : AOptionString {
        public override byte Code
        {
            get
            {
                return 100;
            }
        }
    }
}