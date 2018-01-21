namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc5071#section-6
    /// </summary>
    public class OptionLinuxPreBootExecutionEnvironmentRebootTimeSeconds : AOptionUint32
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 211;
            }
        }
    }
}