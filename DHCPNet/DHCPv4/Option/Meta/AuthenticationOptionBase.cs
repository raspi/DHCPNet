namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="AuthenticationConfigurationToken"/>
    /// <see cref="AuthenticationDelayed"/>
    /// <see cref="EAuthenticationProtocol"/>
    /// </summary>
    public abstract class AuthenticationOptionBase
    {
        /// <summary>
        /// Gets or sets protocol
        /// </summary>
        public EAuthenticationProtocol Protocol { get; set; }

        /// <summary>
        /// Get raw bytes
        /// </summary>
        /// <returns></returns>
        public abstract byte[] GetRawBytes();
    }
}