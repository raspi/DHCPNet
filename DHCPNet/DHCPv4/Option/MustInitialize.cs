using System;

namespace DHCPNet.v4.Option
{
    public abstract class MustInitialize
    {
        /// <summary>
        /// Read raw bytes to more meaningful type
        /// </summary>
        /// <param name="raw">
        /// The raw data byte array. Each option parses it to correct type.
        /// </param>
        public abstract void ReadRaw(byte[] raw);
    }
}