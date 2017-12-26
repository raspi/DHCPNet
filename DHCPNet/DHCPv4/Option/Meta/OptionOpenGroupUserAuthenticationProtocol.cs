namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc2485
    /// </summary>
    public class OptionOpenGroupUserAuthenticationProtocol : Option
    {
        public override byte Code
        {
            get
            {
                return 98;
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