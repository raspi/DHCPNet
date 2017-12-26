namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The TFTP Server Address option is a DHCP option [RFC2132].  The
    /// option contains one or more IPv4 addresses that the client MAY use.
    /// The current use of this option is for downloading configuration from
    /// a VoIP server via TFTP; however, the option may be used for purposes
    /// other than contacting a VoIP configuration server.
    /// 
    /// https://tools.ietf.org/html/rfc5859
    /// </summary>
    public class OptionTftpServerAddresses : AOptionIPAddresses
    {
        public override byte Code
        {
            get
            {
                return 150;
            }
        }
    }
}