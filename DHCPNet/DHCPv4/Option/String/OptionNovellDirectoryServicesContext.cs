namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the initial NDS context the client should use.
    /// NDS contexts are 16-bit Unicode strings.For transmission in the NDS
    /// Context Option, an NDS context is transformed into octets using UTF-
    /// 8. The string should NOT be zero terminated.
    /// 
    /// A single DHCP option can only contain 255 octets.Since an NDS
    /// context name can be longer than that, this option can appear more
    /// than once in the DHCP packet.The contents of all NDS Context options
    /// in the packet should be concatenated as suggested in the DHCP
    /// specification[3, page 24] to get the complete NDS context.A single
    /// encoded character could be split between two NDS Context Options.
    /// 
    /// The code for this option is 87. The maximum length for each instance
    /// of this option is 255, but, as just described, the option may appear
    /// more than once if the desired NDS context takes up more than 255
    /// octets.Implementations are discouraged from enforcing any specific
    /// maximum to the final concatenated NDS context.
    /// 
    /// https://tools.ietf.org/html/rfc2241
    /// </summary>
    public class OptionNovellDirectoryServicesContext : AOptionString
    {
        public override byte Code
        {
            get
            {
                return 87;
            }
        }
    }
}