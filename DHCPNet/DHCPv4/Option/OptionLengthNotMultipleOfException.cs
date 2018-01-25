namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// Option Length Zero Exception
    /// </summary>
    public class OptionLengthNotMultipleOfException : OptionLengthException
    {
        /// <inheritdoc />
        public OptionLengthNotMultipleOfException()
        {
        }

        /// <inheritdoc />
        public OptionLengthNotMultipleOfException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        public OptionLengthNotMultipleOfException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}