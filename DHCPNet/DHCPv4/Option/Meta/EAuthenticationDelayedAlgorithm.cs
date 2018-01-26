namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="AuthenticationDelayed"/>
    /// </summary>
    public enum EAuthenticationDelayedAlgorithm : byte
    {
        /// <summary>
        /// Algorithm 1 specifies the use of Hash-based Message Authentication Code (HMAC) Message Digest 5 (MD5).
        /// </summary>
        MessageDigest5 = 1,
    }
}