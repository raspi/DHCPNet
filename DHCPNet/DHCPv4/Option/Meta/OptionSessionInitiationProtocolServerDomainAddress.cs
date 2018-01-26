namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// Session Initiation Protocol (SIP) Servers as FQDN
    /// <see cref="OptionSessionInitiationProtocolServers"/>
    /// <see cref="SessionInitiationProtocolServerEncoding"/>
    /// </summary>
    public class OptionSessionInitiationProtocolServerDomainAddress : OptionSessionInitiationProtocolServerBase
    {
        /// <inheritdoc />
        public SessionInitiationProtocolServerEncoding Type = SessionInitiationProtocolServerEncoding.DnsNameOfSipServer;

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }
    }
}