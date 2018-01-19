namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc3925
    /// </summary>
    public class OptionVendorIdentifyingVendorSpecificInformation : Option
    {
        public override byte Code
        {
            get
            {
                return 125;
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