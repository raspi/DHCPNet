namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// This document describes the Dynamic Host Configuration Protocol
    /// (DHCP) option to allow Internet Storage Name Service(iSNS) clients
    /// to discover the location of the iSNS server automatically through the
    /// use of DHCP for IPv4.iSNS provides discovery and management
    /// capabilities for Internet SCSI (iSCSI) and Internet Fibre Channel
    /// Protocol (iFCP) storage devices in an enterprise-scale IP storage
    /// network. iSNS provides intelligent storage management services
    /// comparable to those found in Fibre Channel networks, allowing a
    /// 
    /// commodity IP network to function in a similar capacity to that of a
    /// storage area network.
    /// 
    /// https://tools.ietf.org/html/rfc4174
    /// </summary>
    public class OptionInternetStorageNameServiceLocation : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 83;
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