namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc2563
    /// </summary>
    public class OptionUseStatelessAutoConfigure : AOptionBoolean
    {
        public override byte Code
        {
            get
            {
                return 116;
            }
        }
    }
}