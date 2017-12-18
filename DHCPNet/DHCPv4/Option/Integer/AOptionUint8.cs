namespace DHCPNet.v4.Option
{
    /// <summary>
    /// 8-bit unsigned integer
    /// </summary>
    public abstract class AOptionUint8 : Option
    {

        public byte Value;

        public override void ReadRaw(byte[] raw)
        {
            Value = raw[0];
        }

        public override byte[] GetRawBytes()
        {
            return new byte[] { Value };
        }
    }

}
