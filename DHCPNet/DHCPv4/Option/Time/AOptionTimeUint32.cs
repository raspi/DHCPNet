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
            Time = new TimeSpan(0, 0, (int)BitConverter.ToUInt32(raw, 0));
        }
    }
}