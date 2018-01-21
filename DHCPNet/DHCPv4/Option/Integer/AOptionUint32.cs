using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// 32-bit unsigned integer, 4 bytes 
    /// </summary>
    public abstract class AOptionUint32 : Option
    {
        public uint Value;

        public override void ReadRaw(byte[] raw)
        {
            Value = BitConverter.ToUInt32(raw, 0);
        }

        public override byte[] GetRawBytes()
        {
            return BitConverter.GetBytes(Value);
        }
    }
}