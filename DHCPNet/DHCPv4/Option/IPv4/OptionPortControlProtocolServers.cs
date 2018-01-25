namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// Port Control Protocol (PCP)
    /// https://tools.ietf.org/html/rfc7291#section-4
    /// </summary>
    public class OptionPortControlProtocolServers : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 158;
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