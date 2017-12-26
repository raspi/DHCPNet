namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// This document describes a Dynamic Host Configuration Protocol for
    /// IPv4(DHCPv4) option that can be used to exchange information about a
    /// DHCPv4 client's fully qualified domain name and about responsibility
    /// for updating the DNS RR related to the client's address assignment.
    /// 
    /// https://tools.ietf.org/html/rfc4702
    /// </summary>
    public class OptionFullyQualifiedDomainName : Option {

        public override byte Code
        {
            get
            {
                return 81;
            }
        }

        public override void ReadRaw(byte[] raw)
        {
            throw new NotImplementedException();
        }

        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }
    }
}