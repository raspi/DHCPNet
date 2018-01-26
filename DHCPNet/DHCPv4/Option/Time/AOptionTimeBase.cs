using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option contains time information
    /// </summary>
    public abstract class AOptionTimeBase : Option
    {
        /// <inheritdoc />
        public TimeSpan Time { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Time.ToString();
        }
    }

}