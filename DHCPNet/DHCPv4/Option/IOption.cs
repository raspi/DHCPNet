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
        byte Code { get; }

        byte[] GetRawBytes();

    }

}
