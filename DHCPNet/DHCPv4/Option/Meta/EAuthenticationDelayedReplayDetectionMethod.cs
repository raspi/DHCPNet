namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The Replay Detection Method (RDM) field determines the type of replay
    /// detection used in the Replay Detection field.
    /// <see cref="AuthenticationDelayed"/>
    /// </summary>
    public enum EAuthenticationDelayedReplayDetectionMethod : byte
    {
        /// <summary>
        /// If the RDM field contains 0x00, the replay detection field MUST be
        /// set to the value of a monotonically increasing counter
        /// </summary>
        MonotonicallyIncreasingCounter,
    }
}