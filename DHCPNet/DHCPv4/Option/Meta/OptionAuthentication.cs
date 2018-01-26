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
    /// <see cref="EAuthenticationProtocol"/>
    /// <see cref="AuthenticationOptionBase"/>
    /// <see cref="AuthenticationDelayed"/>
    /// <see cref="AuthenticationConfigurationToken"/>
    /// https://tools.ietf.org/html/rfc3118
    /// </summary>
    public class OptionAuthentication : Option
    {
        /// <summary>
        /// Gets or sets authentication protocol
        /// <see cref="AuthenticationDelayed"/>
        /// <see cref="AuthenticationConfigurationToken"/>
        /// </summary>
        public AuthenticationOptionBase Protocol { get; set; }

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

            EAuthenticationProtocol protocol = (EAuthenticationProtocol)raw[0];

            switch (protocol)
            {
                case EAuthenticationProtocol.ConfigurationToken:
                    throw new NotImplementedException();
                    this.Protocol = new AuthenticationConfigurationToken();
                    break;

                case EAuthenticationProtocol.DelayedAuthentication:
                    byte[] tmp = new byte[raw.Length - 3];
                    Array.Copy(raw, 3, tmp, 0, raw.Length - 3);
                    this.Protocol = new AuthenticationDelayed()
                                   {
                                       Algorithm = (EAuthenticationDelayedAlgorithm)raw[1],
                                       ReplayDetectionMethod = (EAuthenticationDelayedReplayDetectionMethod)raw[2],
                                       ReplayValue = tmp,
                                   };
                    break;

                default:
                    throw new OptionException("Unknown protocol.");
            }

        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return this.Protocol.GetRawBytes();
        }
    }
}