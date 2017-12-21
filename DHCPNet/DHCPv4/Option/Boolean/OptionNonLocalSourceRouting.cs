namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies whether the client should
    /// configure its IP layer to allow forwarding of
    /// datagrams with non-local source routes (see
    /// Section 3.3.5 for a discussion of this topic).
    /// A value of 0 means disallow forwarding of such
    /// datagrams, and a value of 1 means allow forwarding.
    ///
    /// Length 1 byte.
    /// </summary>
    public class OptionNonLocalSourceRouting : AOptionBoolean
    {
        public OptionNonLocalSourceRouting()
        {
        }

        public override byte Code
        {
            get
            {
                return 20;
            }
        }
    }
}