namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// Intel Preboot eXecution Environment (PXE)
    /// Client Machine Identifier
    /// <see cref="OptionClientNetworkInterfaceIdentifier"/>
    /// <see cref="OptionClientSystemArchitectureType"/>
    /// https://tools.ietf.org/html/rfc4578#section-2.3
    /// </summary>
    public class OptionClientMachineIdentifier : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 97;
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