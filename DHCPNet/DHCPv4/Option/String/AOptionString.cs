using System.Text;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// String
    /// </summary>
    public abstract class AOptionString : Option
    {

        public string Value = "";

        public override void ReadRaw(byte[] raw)
        {
            Value = BytesToString(raw);
        }

        public override byte[] GetRawBytes()
        {
            return StringToBytes(Value);
        }
    }

}
