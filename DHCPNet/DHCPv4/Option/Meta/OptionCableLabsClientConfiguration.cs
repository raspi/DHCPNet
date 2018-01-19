namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc3495
    /// </summary>
    public class OptionCableLabsClientConfiguration : Option
    {
        public override byte Code
        {
            get
            {
                return 122;
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