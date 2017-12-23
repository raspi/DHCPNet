using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Boolean option (on/off)
    /// </summary>
    public abstract class AOptionBoolean : Option
    {
        public bool Enabled { get; set; }

        public override byte[] GetRawBytes()
        {
            return new byte[] { Enabled ? (byte)1 : (byte)0 };
        }

        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionException("Zero length");
            }

            if (raw.Length > 1)
            {
                throw new OptionException("Length > 1");
            }

            if (raw[0] > 1)
            {
                throw new OptionException(String.Format("Invalid value: {0}", raw[0]));
            }

            Enabled = raw[0] == 1;
        }

        public override string ToString()
        {
            return Enabled ? "true" : "false";
        }
    }
}