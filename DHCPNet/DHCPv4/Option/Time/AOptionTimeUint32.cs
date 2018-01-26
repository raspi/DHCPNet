using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option for 32 bit uint seconds, 4 bytes
    /// </summary>
    public abstract class AOptionTimeUint32 : AOptionTimeBase
    {
        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return BitConverter.GetBytes((uint)Time.TotalSeconds);
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            if (raw.Length != 4)
            {
                throw new OptionLengthNotExactException("Length is not 4.");
            }

            uint seconds = BitConverter.ToUInt32(raw, 0);

            Time = TimeSpan.FromSeconds(seconds);
        }
    }
}