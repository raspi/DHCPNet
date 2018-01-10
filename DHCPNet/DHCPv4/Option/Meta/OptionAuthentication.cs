namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// https://tools.ietf.org/html/rfc3118
    /// </summary>
    public class OptionAuthentication : Option
    {
        public override byte Code
        {
            get
            {
                return 90;
            }
        }

        public override void ReadRaw(byte[] raw)
        {
            throw new NotImplementedException();
        }


        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }
    }
}