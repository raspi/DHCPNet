namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// Authentication for DHCP Messages
    /// 
    /// This document defines a new Dynamic Host Configuration Protocol
    /// (DHCP) option through which authorization tickets can be easily
    /// generated and newly attached hosts with proper authorization can be
    /// automatically configured from an authenticated DHCP server. DHCP
    /// provides a framework for passing configuration information to hosts
    /// on a TCP/IP network. In some situations, network administrators may
    /// wish to constrain the allocation of addresses to authorized hosts.
    /// Additionally, some network administrators may wish to provide for
    /// authentication of the source and contents of DHCP messages.
    /// 
    /// https://tools.ietf.org/html/rfc3118
    /// </summary>
    public class OptionAuthentication : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 90;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }
    }
}