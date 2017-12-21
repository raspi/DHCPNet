namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies whether the client should
    /// configure its IP layer for packet forwarding.
    /// A value of 0 means disable IP forwarding,
    /// and a value of 1 means enable IP forwarding.
    ///
    /// Length 1 byte.
    /// </summary>
    public class OptionIPForwarding : AOptionBoolean
    {
        public OptionIPForwarding()
        {
        }

        public override byte Code
        {
            get
            {
                return 19;
            }
        }
    }
}