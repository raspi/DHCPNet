namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// This option is used by a Dynamic Host Configuration Protocol (DHCP)
    /// client to optionally identify the type or category of user or
    /// applications it represents.The information contained in this option
    /// is an opaque field that represents the user class of which the client
    /// is a member.Based on this class, a DHCP server selects the
    /// appropriate address pool to assign an address to the client and the
    /// appropriate configuration parameters.This option should be
    /// configurable by a user.
    /// 
    /// https://tools.ietf.org/html/rfc3004
    /// </summary>
    public class OptionUserClassIdentity : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 77;
            }
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            throw new NotImplementedException();
        }
    }
}