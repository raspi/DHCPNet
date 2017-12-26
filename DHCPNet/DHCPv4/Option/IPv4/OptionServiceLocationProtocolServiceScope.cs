namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// https://tools.ietf.org/html/rfc2610
    /// </summary>
    public class OptionServiceLocationProtocolServiceScope : Option
    {
        public override byte Code
        {
            get
            {
                return 79;
            }
        }

        public OptionServiceLocationProtocolServiceScope()
        {
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