namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// Option Length Exception
    /// </summary>
    public class OptionLengthException : OptionException
    {
        /// <inheritdoc />
        public OptionLengthException()
        {
        }

        /// <inheritdoc />
        public OptionLengthException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        public OptionLengthException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}