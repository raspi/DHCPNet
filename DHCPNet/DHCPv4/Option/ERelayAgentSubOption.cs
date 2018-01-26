namespace DHCPNet.v4.Option
{
    /// <summary>
    /// DHCP Relay Agent Sub-options
    /// <see cref="OptionRelayAgentCircuitInformation"/>
    /// https://tools.ietf.org/html/rfc3046#section-2.0
    /// </summary>
    public enum ERelayAgentSubOption : byte
    {
        /// <summary>
        /// Agent Circuit ID Sub-option
        /// </summary>
        Circuit = 1,

        /// <summary>
        /// Agent Remote ID Sub-option
        /// </summary>
        Remote,
    }
}