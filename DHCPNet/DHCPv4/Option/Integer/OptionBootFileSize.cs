using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the length in 512-octet blocks of
    /// the default boot image for the client.
    /// The file length is specified as an unsigned 16-bit integer.
    ///
    /// Length is 2 bytes.
    /// </summary>
    public class OptionBootFileSize : AOptionUint16
    {
        /// <inheritdoc />
        public OptionBootFileSize()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 13;
            }
        }
    }
}