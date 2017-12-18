using System;

namespace DHCPNet.v4.Option
{

    public abstract class Option : MustInitialize, IOption
    {
        public abstract byte Code { get; }

        protected Option() { }

        public abstract byte[] GetRawBytes();

        public static byte GetCIDRFromBytes(byte[] bytes)
        {
            byte cidrnet = 0;
            bool zeroed = false;

            for (var i = 0; i < bytes.Length; i++)
            {
                for (int v = bytes[i]; (v & 0xFF) != 0; v = v << 1)
                {
                    if (zeroed) throw new OptionException("Invalid mask");
                    if ((v & 0x80) == 0) zeroed = true;
                    else cidrnet++;
                }
            }

            return cidrnet;
        }

        public static byte[] GetCIDRBytes(byte cidr)
        {
            return BitConverter.GetBytes((0xFFFFFFFFL << (32 - cidr)));
        }

        public static string BytesToString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        public static byte[] StringToBytes(string str)
        {
            byte[] bytes = new byte[str.Length];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, str.Length);
            return bytes;
        }


    }

}
