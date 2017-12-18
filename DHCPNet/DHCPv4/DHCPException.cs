using System;

namespace DHCPNet
{
    /// <summary>
    /// DHCP Exception
    /// </summary>
    public class DHCPException : Exception
    {
        public DHCPException()
        {
        }

        public DHCPException(string message) : base(message)
        {
        }

        public DHCPException(string message, Exception inner) : base(message, inner)
        {
        }
    }


}
