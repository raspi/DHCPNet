using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option for 32 bit uint
    /// </summary>
    public abstract class AOptionTimeUint32 : Option
    {
        public TimeSpan Time = new TimeSpan(0, 0, 0);

        public override byte[] GetRawBytes()
        {
            return BitConverter.GetBytes((uint)Time.TotalSeconds);
        }

        public override void ReadRaw(byte[] raw)
        {
            Time = new TimeSpan(0, 0, (int)BitConverter.ToUInt32(raw, 0));
        }
    }
}