namespace DHCPNet.v4.Option
{
    /// <summary>
    /// DHCP Option
    /// rfc2132
    /// 
    /// https://tools.ietf.org/html/rfc2132
    /// </summary>
    public interface IOption
    {
        /// <summary>
        /// Gets DHCP Option code determining which kind of option it is
        /// </summary>
        byte Code { get; }

        /// <summary>
        /// Read raw bytes and convert to meaningful type
        /// </summary>
        /// <returns>Raw array of bytes</returns>
        byte[] GetRawBytes();
    }
}