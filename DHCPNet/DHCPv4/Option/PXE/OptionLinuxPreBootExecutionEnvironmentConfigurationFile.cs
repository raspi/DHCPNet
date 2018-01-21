namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc5071#section-4
    /// </summary>
    public class OptionLinuxPreBootExecutionEnvironmentConfigurationFile : AOptionString
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 209;
            }
        }
    }
}