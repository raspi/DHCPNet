using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// DHCP Option Exception
    /// </summary>
    public class OptionException : DHCPException
    {
        /// <inheritdoc />
        public OptionException()
        {
        }

        /// <inheritdoc />
        public OptionException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        public OptionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}