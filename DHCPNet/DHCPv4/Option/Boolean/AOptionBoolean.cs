using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Boolean option (on/off)
    /// </summary>
    public abstract class AOptionBoolean : Option
    {
        /// <inheritdoc />
        public bool Enabled { get; set; }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return new byte[] { Enabled ? (byte)1 : (byte)0 };
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            if (raw.Length != 1)
            {
                throw new OptionLengthNotExactException("Length > 1");
            }

            if (raw[0] > 1)
            {
                throw new OptionException(string.Format("Invalid value: {0}", raw[0]));
            }

            Enabled = raw[0] == 1;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Enabled ? "true" : "false";
        }
    }
}