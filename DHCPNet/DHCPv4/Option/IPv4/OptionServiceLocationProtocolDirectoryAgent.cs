namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// https://tools.ietf.org/html/rfc2610
    /// </summary>
    public class OptionServiceLocationProtocolDirectoryAgent : Option
    {
        public override byte Code
        {
            get
            {
                return 78;
            }
        }

        public OptionServiceLocationProtocolDirectoryAgent()
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