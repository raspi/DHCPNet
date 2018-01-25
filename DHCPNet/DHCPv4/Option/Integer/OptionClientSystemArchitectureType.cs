namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// Intel Preboot eXecution Environment (PXE)
    /// Client System Architecture Type Option Definition
    /// <see cref="OptionClientMachineIdentifier"/>
    /// <see cref="OptionClientNetworkInterfaceIdentifier"/>
    /// https://tools.ietf.org/html/rfc4578#section-2.1
    /// Errata: https://www.rfc-editor.org/errata_search.php?rfc=4578
    /// </summary>
    public class OptionClientSystemArchitectureType : Option {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 93;
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