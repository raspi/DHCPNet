using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Meta
    /// </summary>
    public abstract class AOptionMetaData : Option
    {
        public override byte[] GetRawBytes()
        {
            return new byte[] { this.Code };
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

            if (raw[0] != Code)
            {
                throw new OptionException(String.Format("Malformed packet: Invalid data: {0}.", raw[0]));
            }
        }
    }
}