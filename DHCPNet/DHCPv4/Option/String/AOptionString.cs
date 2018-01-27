using System.Text;

namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// Option is string
    /// </summary>
    public abstract class AOptionString : Option
    {
        /// <summary>
        /// Gets or sets string value
        /// </summary>
        public string Value { get; set; }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            this.Value = Encoding.UTF8.GetString(raw, 0, raw.Length);
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return Encoding.UTF8.GetBytes(this.Value);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format("'{0}'", this.Value);
        }
    }
}