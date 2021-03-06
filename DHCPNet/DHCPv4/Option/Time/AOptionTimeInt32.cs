﻿using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Option for 32 bit int seconds, 4 bytes
    /// </summary>
    public abstract class AOptionTimeInt32 : AOptionTimeBase
    {
        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            return BitConverter.GetBytes((int)Time.TotalSeconds);
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            if (raw.Length != 4)
            {
                throw new OptionLengthNotExactException("Length is not 4.");
            }

            Time = new TimeSpan(0, 0, BitConverter.ToInt32(raw, 0));
        }
    }

}