namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// Intel Preboot eXecution Environment (PXE)
    /// Client Network Interface Identifier
    /// <see cref="OptionClientMachineIdentifier"/>
    /// <see cref="OptionClientSystemArchitectureType"/>
    /// https://tools.ietf.org/html/rfc4578#section-2.2
    /// </summary>
    public class OptionClientNetworkInterfaceIdentifier : Option {

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 94;
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