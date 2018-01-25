using System.Text;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option is string
    /// </summary>
    public abstract class AOptionString : Option
    {
        /// <inheritdoc />
        public string Value = "";

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            Value = BytesToString(raw);
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return StringToBytes(Value);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Value;
        }
    }
}