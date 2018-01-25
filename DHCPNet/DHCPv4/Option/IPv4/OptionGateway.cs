namespace DHCPNet.v4.Option
{
    /// <summary>
    /// IP Address(es) of gateway(s)
    /// 
    /// The router option specifies a list of IP addresses for 
    /// routers on the client's subnet.
    /// 
    /// Routers SHOULD be listed in order of preference.
    ///
    /// Minimum length 4 bytes.
    /// Length MUST always be a multiple of 4.
    /// </summary>
    public class OptionGateway : AOptionIPAddresses
    {
        /// <inheritdoc />
        public OptionGateway()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 3;
            }
        }
    }
}