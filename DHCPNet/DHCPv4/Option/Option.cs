using System;
using System.Diagnostics;

namespace DHCPNet.v4.Option
{
    using System.Text;

    /// <summary>
    /// DHCP Option base class
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class Option : MustInitialize, IOption
    {
        /// <summary>
        /// Gets Debug string
        /// </summary>
        private string DebuggerDisplay
        {
            get
            {
                return string.Format("Class: {0} Code: {1:d} - {2}", this.GetType(), this.Code, this.ToString()); 
            }
        }

        /// <inheritdoc />
        public abstract byte Code { get; }

        /// <inheritdoc />
        public abstract byte[] GetRawBytes();

        /// <inheritdoc />
        public static byte GetCIDRFromBytes(byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                throw new OptionException(string.Format("Zero length"));
            }

            if (bytes.Length != 4)
            {
                throw new OptionException(string.Format("Invalid length: {0}", bytes.Length));
            }

            byte cidrnet = 0;
            bool zeroed = false;

            foreach (var t in bytes)
            {
                for (int v = t; (v & 0xFF) != 0; v = v << 1)
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
                throw new OptionException(string.Format("Invalid CIDR: {0}", cidr));
            }

            byte[] b = { 0, 0, 0, 0 };

            Array.Copy(BitConverter.GetBytes((0xFFFFFFFFL << (32 - (int)cidr))), 0, b, 0, 4);

            return b;
        }

        /// <inheritdoc />
        public static byte[] StringToBytes(string str, int len)
        {
            byte[] bytes = new byte[len];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, str.Length);
            return bytes;
        }
    }
}