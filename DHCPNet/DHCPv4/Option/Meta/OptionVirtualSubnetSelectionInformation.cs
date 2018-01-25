namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// Virtual Subnet Selection
    /// 
    /// https://tools.ietf.org/html/rfc6607#section-3.1
    /// https://tools.ietf.org/html/rfc6607#section-3.5
    /// </summary>
    public class OptionVirtualSubnetSelectionInformation : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 221;
            }
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


        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }
    }
}