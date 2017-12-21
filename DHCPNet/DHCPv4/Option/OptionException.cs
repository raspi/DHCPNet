using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// DHCP Option Exception
    /// </summary>
    public class OptionException : DHCPException
    {
        public OptionException()
        {
        }

        public OptionException(string message)
            : base(message)
        {
        }

        public OptionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}