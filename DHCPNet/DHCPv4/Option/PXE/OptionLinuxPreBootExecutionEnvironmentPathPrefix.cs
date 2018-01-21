namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc5071#section-5
    /// </summary>
    public class OptionLinuxPreBootExecutionEnvironmentPathPrefix : AOptionString
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 210;
            }
        }
    }
}