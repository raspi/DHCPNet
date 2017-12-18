using System;

namespace DHCPNet
{
    /// <summary>
    /// IPv4 Address Exception
    /// </summary>
    public class IPv4AddressException : Exception
    {
        public IPv4AddressException()
        {
        }

        public IPv4AddressException(string message) : base(message)
        {
        }

        public IPv4AddressException(string message, Exception inner) : base(message, inner)
        {
        }
    }


}
