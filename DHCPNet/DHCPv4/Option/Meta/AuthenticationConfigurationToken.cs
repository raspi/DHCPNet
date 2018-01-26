namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="AuthenticationOptionBase"/>
    /// <see cref="AuthenticationDelayed"/>
    /// <see cref="EAuthenticationProtocol"/>
    /// </summary>
    public class AuthenticationConfigurationToken : AuthenticationOptionBase
    {
        public EAuthenticationProtocol Protocol = EAuthenticationProtocol.ConfigurationToken;

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}