using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DHCPNet.v4.Option;
using Xunit;

namespace UnitTest.OptionCodes
{
    using Option = DHCPNet.v4.Option.Option;

    public class All
    {
        [Fact]
        public void RFC2132Codes()
        {
            byte[] rfc2132codes = {
                    0, 255, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25,
                    26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 64,
                    65, 68, 69, 70, 71, 72, 73, 74, 75, 76, 50, 51, 52, 66, 67, 54, 55, 56, 57, 58, 59, 60, 61
                };

            foreach (byte code in rfc2132codes)
            {
                Option o = OptionFactory.GetOption(code);
                Assert.True(code == o.Code,
                    String.Format("Expected {0} Actual: {1}", code, o.Code)
                );
            }
        }

        [Fact]
        public void RFC2132Booleans()
        {
            byte[] rfc2132codes = { 19, 20, 27, 29, 30, 31, 34, 36, 39 };

            foreach (byte code in rfc2132codes)
            {
                Option o = OptionFactory.GetOption(code);

                Assert.True(o is AOptionBoolean,
                    String.Format("Expected Boolean type Actual: {0}", o.GetType())
                );
            }
        }

        [Fact]
        public void Codes()
        {
            // https://www.iana.org/assignments/bootp-dhcp-parameters/bootp-dhcp-parameters.xhtml
            //
            // Import-Csv .\options.csv | foreach { 
            //   $tag = $_.Tag.Trim(); 
            //   $mean = $_.Meaning.Trim() -replace "\n",""; 
            //   $len = $_.Len; 
            //   $ref = $_.Reference.Trim(); 
            //   $name = $_.Name - replace "\n",""; 
            //   Write-Output "$tag`, // $ref $name (Len: $len) $mean" 
            // }
            byte[] rfc2132codes = {
                0, // [RFC2132] Pad (Len: 0) None
                1, // [RFC2132] Subnet Mask (Len: 4) Subnet Mask Value
                // 2, // [RFC2132] Time Offset (Len: 4) Time Offset in Seconds from UTC (note: deprecated by 100 and 101)
                3, // [RFC2132] Router (Len: N) N/4 Router addresses
                4, // [RFC2132] Time Server (Len: N) N/4 Timeserver addresses
                5, // [RFC2132] Name Server (Len: N) N/4 IEN-116 Server addresses
                6, // [RFC2132] Domain Server (Len: N) N/4 DNS Server addresses
                7, // [RFC2132] Log Server (Len: N) N/4 Logging Server addresses
                8, // [RFC2132] Quotes Server (Len: N) N/4 Quotes Server addresses
                9, // [RFC2132] LPR Server (Len: N) N/4 Printer Server addresses
                10, // [RFC2132] Impress Server (Len: N) N/4 Impress Server addresses
                11, // [RFC2132] RLP Server (Len: N) N/4 RLP Server addresses
                12, // [RFC2132] Hostname (Len: N) Hostname string
                13, // [RFC2132] Boot File Size (Len: 2) Size of boot file in 512 byte chunks
                14, // [RFC2132] Merit Dump File (Len: N) Client to dump and name the file to dump it to
                15, // [RFC2132] Domain Name (Len: N) The DNS domain name of the client
                16, // [RFC2132] Swap Server (Len: N) Swap Server address
                17, // [RFC2132] Root Path (Len: N) Path name for root disk
                18, // [RFC2132] Extension File (Len: N) Path name for more BOOTP info
                19, // [RFC2132] Forward On/Off (Len: 1) Enable/Disable IP Forwarding
                20, // [RFC2132] SrcRte On/Off (Len: 1) Enable/Disable Source Routing
                21, // [RFC2132] Policy Filter (Len: N) Routing Policy Filters
                22, // [RFC2132] Max DG Assembly (Len: 2) Max Datagram Reassembly Size
                23, // [RFC2132] Default IP TTL (Len: 1) Default IP Time to Live
                24, // [RFC2132] MTU Timeout (Len: 4) Path MTU Aging Timeout
                25, // [RFC2132] MTU Plateau (Len: N) Path MTU  Plateau Table
                26, // [RFC2132] MTU Interface (Len: 2) Interface MTU Size
                27, // [RFC2132] MTU Subnet (Len: 1) All Subnets are Local
                28, // [RFC2132] Broadcast Address (Len: 4) Broadcast Address
                29, // [RFC2132] Mask Discovery (Len: 1) Perform Mask Discovery
                30, // [RFC2132] Mask Supplier (Len: 1) Provide Mask to Others
                31, // [RFC2132] Router Discovery (Len: 1) Perform Router Discovery
                32, // [RFC2132] Router Request (Len: 4) Router Solicitation Address
                33, // [RFC2132] Static Route (Len: N) Static Routing Table
                34, // [RFC2132] Trailers (Len: 1) Trailer Encapsulation
                35, // [RFC2132] ARP Timeout (Len: 4) ARP Cache Timeout
                36, // [RFC2132] Ethernet (Len: 1) Ethernet Encapsulation
                37, // [RFC2132] Default TCP TTL (Len: 1) Default TCP Time to Live
                38, // [RFC2132] Keepalive Time (Len: 4) TCP Keepalive Interval
                39, // [RFC2132] Keepalive Data (Len: 1) TCP Keepalive Garbage
                40, // [RFC2132] NIS Domain (Len: N) NIS Domain Name
                41, // [RFC2132] NIS Servers (Len: N) NIS Server Addresses
                42, // [RFC2132] NTP Servers (Len: N) NTP Server Addresses
                43, // [RFC2132] Vendor Specific (Len: N) Vendor Specific Information
                44, // [RFC2132] NETBIOS Name Srv (Len: N) NETBIOS Name Servers
                45, // [RFC2132] NETBIOS Dist Srv (Len: N) NETBIOS Datagram Distribution
                46, // [RFC2132] NETBIOS Node Type (Len: 1) NETBIOS Node Type
                47, // [RFC2132] NETBIOS Scope (Len: N) NETBIOS Scope
                48, // [RFC2132] X Window Font (Len: N) X Window Font Server
                49, // [RFC2132] X Window Manager (Len: N) X Window Display Manager
                50, // [RFC2132] Address Request (Len: 4) Requested IP Address
                51, // [RFC2132] Address Time (Len: 4) IP Address Lease Time
                52, // [RFC2132] Overload (Len: 1) Overload "sname" or "file"
                53, // [RFC2132] DHCP Msg Type (Len: 1) DHCP Message Type
                54, // [RFC2132] DHCP Server Id (Len: 4) DHCP Server Identification
                55, // [RFC2132] Parameter List (Len: N) Parameter Request List
                56, // [RFC2132] DHCP Message (Len: N) DHCP Error Message
                57, // [RFC2132] DHCP Max Msg Size (Len: 2) DHCP Maximum Message Size
                58, // [RFC2132] Renewal Time (Len: 4) DHCP Renewal (T1) Time
                59, // [RFC2132] Rebinding Time (Len: 4) DHCP Rebinding (T2) Time
                60, // [RFC2132] Class Id (Len: N) Class Identifier
                61, // [RFC2132] Client Id (Len: N) Client Identifier
                62, // [RFC2242] NetWare/IP Domain (Len: N) NetWare/IP Domain Name
                63, // [RFC2242] NetWare/IP Option (Len: N) NetWare/IP sub Options
                64, // [RFC2132] NIS-Domain-Name (Len: N) NIS+ v3 Client Domain Name
                65, // [RFC2132] NIS-Server-Addr (Len: N) NIS+ v3 Server Addresses
                66, // [RFC2132] Server-Name (Len: N) TFTP Server Name
                67, // [RFC2132] Bootfile-Name (Len: N) Boot File Name
                68, // [RFC2132] Home-Agent-Addrs (Len: N) Home Agent Addresses
                69, // [RFC2132] SMTP-Server (Len: N) Simple Mail Server Addresses
                70, // [RFC2132] POP3-Server (Len: N) Post Office Server Addresses
                71, // [RFC2132] NNTP-Server (Len: N) Network News Server Addresses
                72, // [RFC2132] WWW-Server (Len: N) WWW Server Addresses
                73, // [RFC2132] Finger-Server (Len: N) Finger Server Addresses
                74, // [RFC2132] IRC-Server (Len: N) Chat Server Addresses
                75, // [RFC2132] StreetTalk-Server (Len: N) StreetTalk Server Addresses
                76, // [RFC2132] STDA-Server (Len: N) ST Directory Assist. Addresses
                77, // [RFC3004] User-Class (Len: N) User Class Information
                78, // [RFC2610] Directory Agent (Len: N) directory agent information
                79, // [RFC2610] Service Scope (Len: N) service location agent scope
                80, // [RFC4039] Rapid Commit (Len: 0) Rapid Commit
                81, // [RFC4702] Client FQDN (Len: N) Fully Qualified Domain Name
                82, // [RFC3046] Relay Agent Information (Len: N) Relay Agent Information
                83, // [RFC4174] iSNS (Len: N) Internet Storage Name Service
                // 84, // [RFC3679] REMOVED/Unassigned
                85, // [RFC2241] NDS Servers (Len: N) Novell Directory Services
                86, // [RFC2241] NDS Tree Name (Len: N) Novell Directory Services
                87, // [RFC2241] NDS Context (Len: N) Novell Directory Services
                88, // [RFC4280] BCMCS Controller Domain Name list
                89, // [RFC4280] BCMCS Controller IPv4 address option
                90, // [RFC3118] Authentication (Len: N) Authentication
                91, // [RFC4388] client-last-transaction-time option
                92, // [RFC4388] associated-ip option
                93, // [RFC4578] Client System (Len: N) Client System Architecture
                94, // [RFC4578] Client NDI (Len: N) Client Network Device Interface
                95, // [RFC3679] LDAP (Len: N) Lightweight Directory Access Protocol
                // 96, // [RFC3679] REMOVED/Unassigned 
                97, // [RFC4578] UUID/GUID (Len: N) UUID/GUID-based Client Identifier
                98, // [RFC2485] User-Auth (Len: N) Open Group's User Authentication
                99, // [RFC4776] GEOCONF_CIVIC
                100, // [RFC4833] PCode (Len: N) IEEE 1003.1 TZ String
                101, // [RFC4833] TCode (Len: N) Reference to the TZ Database
                // 102-107, // [RFC3679] REMOVED/Unassigned
                // 108, // [RFC3679] REMOVED/Unassigned
                // 109, // [RFC3679] Unassigned
                // 110, // [RFC3679] REMOVED/Unassigned
                // 111, // [RFC3679] Unassigned
                112, // [RFC3679] Netinfo Address (Len: N) NetInfo Parent Server Address
                113, // [RFC3679] Netinfo Tag (Len: N) NetInfo Parent Server Tag
                114, // [RFC3679] URL (Len: N) URL
                // 115, // [RFC3679] REMOVED/Unassigned
                116, // [RFC2563] Auto-Config (Len: N) DHCP Auto-Configuration
                117, // [RFC2937] Name Service Search (Len: N) Name Service Search
                118, // [RFC3011] Subnet Selection Option (Len: 4) Subnet Selection Option
                119, // [RFC3397] Domain Search (Len: N) DNS domain search list
                120, // [RFC3361] SIP Servers DHCP Option (Len: N) SIP Servers DHCP Option
                121, // [RFC3442] Classless Static Route Option (Len: N) Classless Static Route Option
                122, // [RFC3495] CCC (Len: N) CableLabs Client Configuration
                123, // [RFC6225] GeoConf Option (Len: 16) GeoConf Option
                124, // [RFC3925] V-I Vendor Class - Vendor-Identifying Vendor Class
                125, // [RFC3925] V-I Vendor-Specific Information - Vendor-Identifying Vendor-Specific Information
                // 126, // [RFC3679] Removed/Unassigned 
                // 127, // [RFC3679] Removed/Unassigned
                128, // [RFC4578] PXE - undefined (vendor specific)
                // 128, // Etherboot signature. 6 bytes:E4:45:74:68:00:00
                // 128, // DOCSIS "full security" server IP address
                // 128, // TFTP Server IP address (for IP Phone software load)
                129, // [RFC4578] PXE - undefined (vendor specific)
                // 129, // Kernel options. Variable length string
                // 129, // Call Server IP address
                130, // [RFC4578] PXE - undefined (vendor specific)
                // 130, // Ethernet interface. Variable length string.
                // 130, // Discrimination string (to identify vendor)
                131, // [RFC4578] PXE - undefined (vendor specific)
                // 131, // Remote statistics server IP address
                132, // [RFC4578] PXE - undefined (vendor specific)
                // 132, // IEEE 802.1Q VLAN ID
                133, // [RFC4578] PXE - undefined (vendor specific)
                // 133, // IEEE 802.1D/p Layer 2 Priority
                134, // [RFC4578] PXE - undefined (vendor specific)
                // 134, // Diffserv Code Point (DSCP) forVoIP signalling and media streams
                135, // [RFC4578] PXE - undefined (vendor specific)
                // 135, // HTTP Proxy for phone-specific applications
                136, // [RFC5192] OPTION_PANA_AGENT
                137, // [RFC5223] OPTION_V4_LOST
                138, // [RFC5417] OPTION_CAPWAP_AC_V4 (Len: N) CAPWAP Access Controller addresses
                139, // [RFC5678] OPTION-IPv4_Address-MoS (Len: N) a series of suboptions
                140, // [RFC5678] OPTION-IPv4_FQDN-MoS (Len: N) a series of suboptions
                141, // [RFC6011] SIP UA Configuration Service Domains (Len: N) List of domain names to search for SIP User Agent Configuration
                142, // [RFC6153] OPTION-IPv4_Address-ANDSF (Len: N) ANDSF IPv4 Address Option for DHCPv4
                // 143, // Unassigned
                144, // [RFC6225] GeoLoc (Len: 16) Geospatial Location with Uncertainty
                145, // [RFC6704] FORCERENEW_NONCE_CAPABLE (Len: N) Forcerenew Nonce Capable
                146, // [RFC6731] RDNSS Selection (Len: N) Information for selecting RDNSS
                // 147-149, // [RFC3942] Unassigned
                150, // [RFC5859] TFTP server address
                150, // Etherboot
                150, // GRUB configuration path name
                151, // [RFC6926] status-code (Len: N+1) Status code and optional N byte text message describing status.
                152, // [RFC6926] base-time (Len: 4) Absolute time (seconds since Jan 1, 1970) message was sent.
                153, // [RFC6926] start-time-of-state (Len: 4) Number of seconds in the past when client entered current state.
                154, // [RFC6926] query-start-time (Len: 4) Absolute time (seconds since Jan 1, 1970) for beginning of query.
                155, // [RFC6926] query-end-time (Len: 4) Absolute time (seconds since Jan 1, 1970) for end of query.
                156, // [RFC6926] dhcp-state (Len: 1) State of IP address.
                157, // [RFC6926] data-source (Len: 1) Indicates information came from local or remote server.
                158, // [RFC7291] OPTION_V4_PCP_SERVER (Len: Variable; the minimum length is 5.) Includes one or multiple lists of PCP server IP addresses; each list is treated as a separate PCP server.
                159, // [RFC7618] OPTION_V4_PORTPARAMS (Len: 4) This option is used to configure a set of ports bound to a shared IPv4 address.
                160, // [RFC7710] DHCP Captive-Portal (Len: N) DHCP Captive-Portal
                161, // [draft-ietf-opsawg-mud] OPTION_MUD_URL_V4 (TEMPORARY - registered 2016-11-17, extension registered 2017-10-02, expires 2018-11-17) (Len: N (variable)) Manufacturer Usage Descriptions
                // 162-174, // [RFC3942] Unassigned
                175, // Etherboot (Tentatively Assigned - 2005-06-23) 
                176, // IP Telephone (Tentatively Assigned - 2005-06-23)
                177, // Etherboot (Tentatively Assigned - 2005-06-23)
                // 177, // PacketCable and CableHome (replaced by 122)
                // 178-207, // [RFC3942] Unassigned
                // 208, // [RFC5071][Deprecated] PXELINUX Magic (Len: 4) magic string = F1:00:74:7E
                209, // [RFC5071] Configuration File (Len: N) Configuration file
                210, // [RFC5071] Path Prefix (Len: N) Path Prefix Option
                211, // [RFC5071] Reboot Time (Len: 4) Reboot Time
                212, // [RFC5969] OPTION_6RD (Len: 18 + N) OPTION_6RD with N/4 6rd BR addresses
                213, // [RFC5986] OPTION_V4_ACCESS_DOMAIN (Len: N) Access Network Domain Name
                // 214-219, // Unassigned
                220, // [RFC6656] Subnet Allocation Option (Len: N) Subnet Allocation Option
                221, // [RFC6607] Virtual Subnet Selection (VSS) Option
                // 222-223, // [RFC3942] Unassigned
                // 224-254, // Reserved (Private Use)
                255 // [RFC2132] End (Len: 0) None
            };

            foreach (byte code in rfc2132codes)
            {
                Option o = OptionFactory.GetOption(code);
                Assert.True(code == o.Code,
                    String.Format("Expected {0} Actual: {1}", code, o.Code)
                );
            }
        }


    }
}
