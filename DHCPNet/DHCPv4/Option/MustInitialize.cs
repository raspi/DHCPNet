using System;

namespace DHCPNet.v4.Option
{
    public abstract class MustInitialize
    {
        /// <summary>
        /// Read raw bytes to more meaningful type
        /// </summary>
        public abstract void ReadRaw(byte[] raw);
    }
}