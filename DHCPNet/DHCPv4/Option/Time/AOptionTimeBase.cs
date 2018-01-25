using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option contains time information
    /// </summary>
    public abstract class AOptionTimeBase : Option
    {
        /// <inheritdoc />
        public TimeSpan Time = new TimeSpan(0, 0, 0);

        /// <inheritdoc />
        public override string ToString()
        {
            return Time.ToString();
        }
    }

}