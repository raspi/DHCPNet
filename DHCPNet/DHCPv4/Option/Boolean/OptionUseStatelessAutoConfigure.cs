namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Disable Stateless Auto-Configuration in IPv4 Clients
    /// 
    /// The auto-configure option uses the following values:
    /// 0 = DoNotAutoConfigure
    /// 1 = AutoConfigure
    /// 
    /// When a server responds with the value "AutoConfigure", the client MAY
    /// generate a link-local IP address if appropriate. However, if the
    /// server responds with "DoNotAutoConfigure", the client MUST NOT
    /// generate a link-local IP address, possibly leaving it with no IP
    /// address.
    /// 
    /// https://tools.ietf.org/html/rfc2563#section-2
    /// </summary>
    public class OptionUseStatelessAutoConfigure : AOptionBoolean
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 116;
            }
        }
    }
}