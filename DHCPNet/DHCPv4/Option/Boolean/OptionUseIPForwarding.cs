namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies whether the client should
    /// configure its IP layer for packet forwarding.
    /// A value of 0 means disable IP forwarding,
    /// and a value of 1 means enable IP forwarding.
    ///
    /// Length 1 byte.
    /// https://tools.ietf.org/html/rfc2132#section-4.1
    /// </summary>
    public class OptionUseIPForwarding : AOptionBoolean
    {
        /// <inheritdoc />
        public OptionUseIPForwarding()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 19;
            }
        }
    }
}