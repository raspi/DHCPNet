using System;

namespace DHCPNet
{
    /// <summary>
    /// MAC Address
    /// 00:11:22:33:44:55
    /// </summary>
    public class MacAddress
    {
        /// <inheritdoc />
        protected const char DefaultSeparator = ':';

        /// <inheritdoc />
        public char Separator = DefaultSeparator;

        /// <inheritdoc />
        public byte[] Address = { 0, 0, 0, 0, 0, 0 };

        /// <inheritdoc />
        public MacAddress(byte[] v)
        {
            if (v.Length == 0)
            {
                throw new Exception("Zero length.");
            }

            if (v.Length != 6)
            {
                throw new Exception(String.Format("Invalid length: {0}.", v.Length));
            }

            Address = v;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return String.Format(
                "{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}",
                Separator,
                Address[0],
                Address[1],
                Address[2],
                Address[3],
                Address[4],
                Address[5],
                Address[6]);
        }
    }
}