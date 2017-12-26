namespace DHCPNet.v4.Option
{
    public enum ENetWareIpInformation : byte
    {
        /// <summary>
        /// The responding DHCP server does not have any NetWare/IP
        /// information configured.
        /// </summary>
        DoesNotExist = 1,

        /// <summary>
        /// All NetWare/IP information is present in the 'options' area of the
        /// DHCP response packet.
        /// </summary>
        OptionsArea,

        /// <summary>
        /// All NetWare/IP information is present in the 'sname' and, if
        /// necessary, 'file' fields of the DHCP response packet. If used, the
        /// following DHCP server behavior is required: within the 'options'
        /// area, option 63 is present with its length field set to 2. The
        /// first byte of the value field is set to NWIP_EXIST_IN_SNAME_FILE
        /// tag and the second byte is set to zero.  Both option 62 and option
        /// 63 will be placed in the area covered by the sname and file
        /// fields. Option 62 is encoded normally. Option 63 is encoded with
        /// its tag, length and value. The value field does not contain any of
        /// the first four sub-options described herein.
        /// </summary>
        SnameFile,

        /// <summary>
        /// Neither 'options' area nor 'sname' field can accommodate the
        /// NetWare/IP information.
        /// </summary>
        TooBig,

        /// <summary>
        /// Length is 1 and a value of 1 or 0.  If the value is 1, the client
        /// SHOULD perform a NetWare Nearest Server Query to find out its
        /// nearest NetWare/IP server.
        /// </summary>
        NsqBroadcast,

        /// <summary>
        /// Length is (n * 4) and the value is an array of n IP addresses,
        /// each four bytes in length. The maximum number of addresses is 5
        /// and therefore the maximum length value is 20. The list contains
        /// the addresses of n NetWare Domain SAP/RIP Server (DSS).
        /// </summary>
        PreferredDss,

        /// <summary>
        /// Length is (n * 4) and the value is an array of n IP addresses,
        /// each four bytes in length. The maximum number of addresses is 5
        /// and therefore the maximum length value is 20. The list contains
        /// the addresses of n Nearest NetWare/IP servers.
        /// </summary>
        NearestServer,

        /// <summary>
        /// Length is 1 and the value is a one byte integer value indicating
        /// the number of times a NetWare/IP client should attempt to
        /// communicate with a given DSS server at startup.
        /// </summary>
        AutoRetries,

        /// <summary>
        /// Length is 1 and the value is a one byte integer value indicating
        /// the amount of delay in seconds in between each NetWare/IP client
        /// attempt to communicate with a given DSS server at startup.
        /// </summary>
        AutoRetrySeconds,

        /// <summary>
        /// Length is 1 and the value is 1 or 0.  If the value is 1, the
        /// NetWare/IP client SHOULD support NetWare/IP Version 1.1
        /// compatibility. A NetWare/IP client only needs this compatibility
        /// if it will contact a NetWare/IP version 1.1 server.
        /// </summary>
        Nwip11Compatibility,

        /// <summary>
        /// Length of 4, and the value is a single IP address.  This field
        /// identifies the Primary Domain SAP/RIP Service server (DSS) for
        /// this NetWare/IP domain. NetWare/IP administration utility uses
        /// this value as Primary DSS server when configuring a secondary DSS
        /// server.
        /// </summary>
        PrimaryDss
    }

}