using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// 16-bit unsigned integer
    /// </summary>
    public abstract class AOptionUint16 : Option
    {
        public ushort Value;

        public override void ReadRaw(byte[] raw)
        {
            Value = BitConverter.ToUInt16(raw, 0);
        }

        public override byte[] GetRawBytes()
        {
            return BitConverter.GetBytes(Value);
        }
    }
}