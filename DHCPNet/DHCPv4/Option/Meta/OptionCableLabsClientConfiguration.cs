namespace DHCPNet.v4.Option
{
    using System.Collections.Generic;

    /// <summary>
    /// CableLabs Client Configuration
    /// https://tools.ietf.org/html/rfc3495
    /// </summary>
    public class OptionCableLabsClientConfiguration : Option
    {
        /// <inheritdoc />
        public List<OptionCableLabsClientConfigurationSubOption> Options { get; set; }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 122;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            throw new System.NotImplementedException();

            for (int i = 0; i < raw.Length; i++)
            {
                ECableLabsClientConfigurationSubOptionCode type = (ECableLabsClientConfigurationSubOptionCode)raw[i];
            }

        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}