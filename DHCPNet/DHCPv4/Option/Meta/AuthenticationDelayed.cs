namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// <see cref="AuthenticationOptionBase"/>
    /// <see cref="AuthenticationConfigurationToken"/>
    /// <see cref="EAuthenticationProtocol"/>
    /// </summary>
    public class AuthenticationDelayed : AuthenticationOptionBase
    {
        public EAuthenticationProtocol Protocol = EAuthenticationProtocol.DelayedAuthentication;

        /// <summary>
        /// Gets or sets algorithm
        /// </summary>
        public EAuthenticationDelayedAlgorithm Algorithm { get; set; }

        /// <summary>
        /// Gets or sets Replay Detection Method
        /// </summary>
        public EAuthenticationDelayedReplayDetectionMethod ReplayDetectionMethod { get; set; }

        /// <summary>
        /// Gets or sets Replay Detection Method (RDM) Replay Detection Value
        /// </summary>
        public byte[] ReplayValue { get; set; }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            byte[] tmp = new byte[3 + this.ReplayValue.Length];
            tmp[0] = (byte)this.Protocol;
            tmp[1] = (byte)this.Algorithm;
            tmp[2] = (byte)this.ReplayDetectionMethod;

            Array.Copy(this.ReplayValue, 0, tmp, 3, this.ReplayValue.Length);

            return tmp;
        }
    }
}