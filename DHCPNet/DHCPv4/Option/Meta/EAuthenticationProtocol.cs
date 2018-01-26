namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="OptionAuthentication"/>
    /// https://tools.ietf.org/html/rfc3118
    /// </summary>
    public enum EAuthenticationProtocol : byte
    {
        /// <summary>
        /// The authentication information field holds a simple configuration token
        /// https://tools.ietf.org/html/rfc3118#section-4
        /// </summary>
        ConfigurationToken,

        /// <summary>
        /// The message is using the "delayed authentication" mechanism
        /// https://tools.ietf.org/html/rfc3118#section-5
        /// </summary>
        DelayedAuthentication,
    }
}