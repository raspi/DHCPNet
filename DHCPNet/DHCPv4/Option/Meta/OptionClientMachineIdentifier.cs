namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// https://tools.ietf.org/html/rfc4578
    /// </summary>
    public class OptionClientMachineIdentifier : Option
    {

        public override byte Code
        {
            get
            {
                return 97;
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