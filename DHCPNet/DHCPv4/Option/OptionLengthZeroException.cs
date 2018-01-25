namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// Option Length Zero Exception
    /// </summary>
    public class OptionLengthZeroException : OptionLengthException
    {
        /// <inheritdoc />
        public OptionLengthZeroException()
        {
        }

        /// <inheritdoc />
        public OptionLengthZeroException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        public OptionLengthZeroException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}