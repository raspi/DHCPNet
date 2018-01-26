namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="OptionLinuxPreBootExecutionEnvironmentConfigurationFile"/>
    /// <see cref="OptionLinuxPreBootExecutionEnvironmentPathPrefix"/>
    /// <see cref="OptionLinuxPreBootExecutionEnvironmentRebootTimeSeconds"/>
    /// 
    /// If this matches, then PXELINUX bootloaders will also consume options 209-211
    /// https://tools.ietf.org/html/rfc5071#section-3
    /// </summary>
    public class OptionLinuxPreBootExecutionEnvironmentMagic : Option
    {
        /// <summary>
        /// Magic 4 bytes
        /// </summary>
        public byte[] Magic
        {
            get
            {
                return new byte[] { 0xf1, 0x00, 0x74, 0x7e };
            }
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 208;
            }
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return Magic;
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionException("Zero length");
            }

            if (raw.Length != 4)
            {
                throw new OptionException("Length is not 4.");
            }

            for (byte i = 0; i < 4; i++)
            {
                if (raw[i] != Magic[i])
                {
                    throw new OptionException("Invalid magic data");
                }
            }
        }
    }
}