using System;

namespace DHCPNet
{
    /// <summary>
    /// DHCP Exception
    /// </summary>
    public class DHCPException : Exception
    {
        /// <inheritdoc />
        public DHCPException()
        {
        }

        /// <inheritdoc />
        public DHCPException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        public DHCPException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}