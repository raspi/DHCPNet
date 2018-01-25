namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// This document describes a Dynamic Host Configuration Protocol for
    /// IPv4 (DHCPv4) option that can be used to exchange information about a
    /// DHCPv4 client's fully qualified domain name and about responsibility
    /// for updating the DNS RR related to the client's address assignment.
    /// 
    /// https://tools.ietf.org/html/rfc4702#section-2.1
    /// </summary>
    public class OptionFullyQualifiedDomainName : Option {

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 81;
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