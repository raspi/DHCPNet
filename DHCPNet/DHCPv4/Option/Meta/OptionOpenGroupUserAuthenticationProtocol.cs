namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The Open Group's User Authentication Protocol
    /// https://tools.ietf.org/html/rfc2485
    /// </summary>
    public class OptionOpenGroupUserAuthenticationProtocol : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 98;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}