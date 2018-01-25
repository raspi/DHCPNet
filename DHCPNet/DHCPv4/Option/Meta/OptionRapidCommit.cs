namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// Rapid Commit Option for the Dynamic Host Configuration 
    /// Protocol version 4 (DHCPv4)
    /// 
    /// This document defines a new Dynamic Host Configuration Protocol
    /// version 4 (DHCPv4) option, modeled on the DHCPv6 Rapid Commit option,
    /// for obtaining IP address and configuration information using a
    /// 2-message exchange rather than the usual 4-message exchange,
    /// expediting client configuration.
    /// 
    /// https://tools.ietf.org/html/rfc4039#section-4
    /// </summary>
    public class OptionRapidCommit : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 80;
            }
        }

        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }

        public override void ReadRaw(byte[] raw)
        {
            throw new NotImplementedException();
        }
    }
}