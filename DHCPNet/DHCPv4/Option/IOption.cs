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
        /// Option code determining which kinf of option it is
        /// </summary>
        byte Code { get; }

        byte[] GetRawBytes();

    }

}
