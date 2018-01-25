using System;

namespace DHCPNet.v4.Option
{
    public class OptionLengthNotExactException : OptionLengthException
    {
        /// <inheritdoc />
        public OptionLengthNotExactException()
        {
        }

        /// <inheritdoc />
        public OptionLengthNotExactException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public OptionLengthNotExactException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}