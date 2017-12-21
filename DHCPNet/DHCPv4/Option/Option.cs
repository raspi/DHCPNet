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

            if (bytes.Length == 0)
            {
                throw new OptionException(String.Format("Zero length"));
            }

            if (bytes.Length != 4)
            {
                throw new OptionException(String.Format("Invalid length: {0}", bytes.Length));
            }

            byte cidrnet = 0;
            bool zeroed = false;

            for (var i = 0; i < bytes.Length; i++)
            {
                for (int v = bytes[i]; (v & 0xFF) != 0; v = v << 1)
                {
                    if (zeroed)
                    {
                        throw new OptionException("Invalid mask");
                    }

                    if ((v & 0x80) == 0)
                    {
                        zeroed = true;
                    }
                    else
                    {
                        cidrnet++;
                    }
                }
            }

            return cidrnet;
        }

        /// <summary>
        /// Get CIDR as byte[4]
        /// </summary>
        /// <param name="cidr">CIDR</param>
        /// <exception cref="OptionException"></exception>
        /// <returns></returns>
        public static byte[] GetCIDRBytes(byte cidr)
        {
            if (cidr > 32)
            {
                throw new OptionException(String.Format("Invalid CIDR: {0}", cidr));
            }

            byte[] b = { 0, 0, 0, 0 };

            Array.Copy(BitConverter.GetBytes((0xFFFFFFFFL << (32 - (int)cidr))), 0, b, 0, 4);

            return b;
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

        public static byte[] StringToBytes(string str, int len)
        {
            byte[] bytes = new byte[len];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, str.Length);
            return bytes;
        }


    }

}
