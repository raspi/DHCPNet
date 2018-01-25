namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc3495#section-4
    /// </summary>
    public enum ECableLabsClientConfigurationSubOptionCode : byte
    {
        /// <summary>
        /// TSP's Primary DHCP Server Address
        /// <see cref="OptionCableLabsClientConfigurationSubOptionPrimaryDHCPServerAddress"/>
        /// </summary>
        PrimaryDHCPServerAddress,

        /// <summary>
        /// TSP's Secondary DHCP Server Address
        /// <see cref="OptionCableLabsClientConfigurationSubOptionSecondaryDHCPServerAddress"/>
        /// </summary>
        SecondaryDHCPServerAddress,

        /// <summary>
        /// TSP's Provisioning Server Address
        /// </summary>
        ProvisioningServerAddress,

        /// <summary>
        /// TSP's AS-REQ/AS-REP Backoff and Retry
        /// </summary>
        AuthenticationServiceReplyOrQuery,

        /// <summary>
        /// TSP's AP-REQ/AP-REP Backoff and Retry
        /// </summary>
        AuthenticationApplicationReplyOrQuery,

        /// <summary>
        /// TSP's Kerberos Realm Name
        /// </summary>
        KerberosRealmName,

        /// <summary>
        /// TSP's Ticket Granting Server Utilization
        /// </summary>
        TicketGrantingServerUtilization,

        /// <summary>
        /// TSP's Provisioning Timer Value
        /// </summary>
        ProvisioningTimerValue,

        /// <summary>
        /// Reserved for future extensions
        /// </summary>
        Reserved,
    }
}