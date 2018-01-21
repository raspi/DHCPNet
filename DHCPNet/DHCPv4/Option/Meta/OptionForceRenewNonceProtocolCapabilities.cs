namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The FORCERENEW_NONCE_CAPABLE option contains code 145, length n, and
    /// a sequence of algorithms the client supports:
    /// 
    /// Code Len   Algorithms
    /// +-----+-----+----+----+----+
    /// | 145 |  n  | A1 | A2 | A3 | ....
    /// +-----+-----+----+----+----+
    /// 
    /// The client would indicate that it supports the functionality by
    /// inserting the FORCERENEW_NONCE_CAPABLE option in the DHCP Discover
    /// and Request messages.
    /// 
    /// If the server supports Forcerenew nonce authentication and requires 
    /// Forcerenew nonce authentication, it will insert the FORCERENEW_NONCE_CAPABLE 
    /// option in the DHCPOFFER.
    /// 
    /// https://tools.ietf.org/html/rfc6704
    /// Errata: https://www.rfc-editor.org/errata/rfc6704
    /// </summary>
    public class OptionForceRenewNonceProtocolCapabilities : Option
    {
        public override byte Code
        {
            get
            {
                return 145;
            }
        }

        public override void ReadRaw(byte[] raw)
        {
            throw new System.NotImplementedException();
        }


        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}