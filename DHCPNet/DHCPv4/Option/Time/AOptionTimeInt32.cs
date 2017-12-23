using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option for 32 bit int seconds
    /// </summary>
    public abstract class AOptionTimeInt32 : AOptionTimeBase
    {
        public override byte[] GetRawBytes()
        {
            return BitConverter.GetBytes((int)Time.TotalSeconds);
        }

        public override void ReadRaw(byte[] raw)
        {
            Time = new TimeSpan(0, 0, BitConverter.ToInt32(raw, 0));
        }
    }

}