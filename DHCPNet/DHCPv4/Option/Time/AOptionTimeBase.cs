using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option contains time information
    /// </summary>
    public abstract class AOptionTimeBase : Option
    {
        public TimeSpan Time = new TimeSpan(0, 0, 0);

        public override string ToString()
        {
            return this.Time.ToString();
        }
    }

}