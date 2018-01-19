namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Encoding type for SessionInitiationProtocolServers
    /// <see cref="SessionInitiationProtocolServers"/>
    /// https://tools.ietf.org/html/rfc3361
    /// </summary>
    public enum SessionInitiationProtocolServerEncoding : byte
    {
        /// <summary>
        ///  Code  Len   enc   DNS name of SIP server
        /// +-----+-----+-----+-----+-----+-----+-----+-----+--
        /// | 120 |  n  |  0  |  s1 |  s2 |  s3 |  s4 | s5  |  ...
        /// +-----+-----+-----+-----+-----+-----+-----+-----+--
        /// </summary>
        DnsNameOfSipServer,

        /// <summary>
        ///  Code   Len   enc   Address 1               Address 2
        /// +-----+-----+-----+-----+-----+-----+-----+-----+--
        /// | 120 |  n  |  1  | a1  | a2  | a3  | a4  | b1  |  ...
        /// +-----+-----+-----+-----+-----+-----+-----+-----+--
        /// </summary>
        Ipv4AddressList
    }
}