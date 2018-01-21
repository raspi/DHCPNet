namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// https://tools.ietf.org/html/rfc6656
    /// </summary>
    public class OptionCiscoSystemsSubnetAllocation : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 220;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            throw new NotImplementedException();
        }


        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }
    }
}