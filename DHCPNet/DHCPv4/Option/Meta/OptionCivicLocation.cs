namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc4776
    /// </summary>
    public class OptionCivicLocation : Option {
        public override byte Code
        {
            get
            {
                return 99;
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