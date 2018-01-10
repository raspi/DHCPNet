namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// https://tools.ietf.org/html/rfc4578
    /// </summary>
    public class OptionClientSystemArchitectureType : Option {

        public override byte Code
        {
            get
            {
                return 93;
            }
        }

        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }

        public override void ReadRaw(byte[] raw)
        {
            throw new NotImplementedException();
        }
    }
}