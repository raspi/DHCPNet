using System;
using System.Collections.Generic;

namespace DHCPNet.v4.Option
{
    public static class OptionFactory
        {

        /// <summary>
        /// Get all options
        /// </summary>
        public static List<Type> GetOptions()
        {
            // * = minimum needed
            List<Type> opts = new List<Type>
            {
                typeof(OptionPad), // 0*
                typeof(OptionSubnetMask), // 1*
                typeof(OptionTimeOffset), // 2
                typeof(OptionGateway), // 3* GW
                typeof(OptionTimeServer), // 4
                typeof(OptionNameServer), // 5
                typeof(OptionDomainNameServer), // 6* DNS
                typeof(OptionLogServer), // 7
                typeof(OptionCookieServer), // 8
                typeof(OptionLPRServer), // 9
                typeof(OptionImpressServer), // 10
                typeof(OptionResourceLocationServer), // 11
                typeof(OptionHostName), // 12
                typeof(OptionBootFileSize), // 13
                typeof(OptionMeritDumpFile), // 14
                typeof(OptionDomainName), // 15
                typeof(OptionSwapServer), // 16
                typeof(OptionRootPath), // 17
                typeof(OptionExtensionPath), // 18
                typeof(OptionIPForwarding), // 19
                typeof(OptionNonLocalSourceRouting), // 20
                typeof(OptionPolicyFilter), // 21
                typeof(OptionMaximumDatagramReassembly), // 22
                typeof(OptionDefaultIPTimeToLive), // 23
                typeof(OptionPathMTUAgingTimeout), // 24
                typeof(OptionPathMTUPlateauTable), // 25
                typeof(OptionInterfaceMTU), // 26
                typeof(OptionAllSubnetsAreLocal), // 27
                typeof(OptionBroadcastAddress), // 28
                typeof(OptionPerformMaskDiscovery), // 29
                typeof(OptionMaskSupplier), // 30
                typeof(OptionPerformRouterDiscovery), // 31
                typeof(OptionRouterSolicitationAddress), // 32
                typeof(OptionStaticRoute), // 33
                typeof(OptionTrailerEncapsulation), // 34
                typeof(OptionARPCacheTimeout), // 35
                typeof(OptionEthernetEncapsulation), // 36
                typeof(OptionTCPDefaultTTL), // 37
                typeof(OptionTCPKeepaliveInterval), // 38
                typeof(OptionTCPKeepaliveGarbage), // 39
                typeof(OptionNetworkInformationServiceDomain), // 40
                typeof(OptionNetworkInformationServiceServers), // 41
                typeof(OptionNetworkTimeProtocolServers), // 42
                typeof(OptionVendorSpecificInformation), // 43 see also 60
                typeof(OptionNetBIOSOverTCPIPNameServer), // 44
                typeof(OptionNetBIOSOverTCPIPDatagramDistributionServer), // 45
                typeof(OptionNetBIOSOverTCPIPNodeType), // 46
                typeof(OptionNetBIOSOverTCPIPScope), // 47
                typeof(OptionXWindowSystemFontServer), // 48
                typeof(OptionXWindowSystemDisplayManager), // 49
                typeof(OptionRequestedIPAddress), // 50*
                typeof(OptionIPAddressLeaseTime), // 51*
                typeof(OptionOverload), // 52
                typeof(OptionMessageType), // 53*
                typeof(OptionServerIdentifier), // 54*
                typeof(OptionParameterRequestList), // 55*
                typeof(OptionMessage), // 56
                typeof(OptionMaximumDHCPMessageSize), // 57
                typeof(OptionRenewalTime), // 58*
                typeof(OptionRebindingTime), // 59*
                typeof(OptionVendorClassIdentifier), // 60 see also 43
                typeof(OptionClientIdentifier), // 61*
                typeof(OptionNetworkInformationServicePlusDomain), // 64
                typeof(OptionNetworkInformationServicePlusServers), // 65
                typeof(OptionTFTPServerName), // 66
                typeof(OptionBootFileName), // 67
                typeof(OptionMobileIPHomeAgent), // 68
                typeof(OptionSimpleMailTransportProtocolServer), // 69 SMTP
                typeof(OptionPostOfficeProtocolServer), // 70 POP3
                typeof(OptionNetworkNewsTransportProtocolServer), // 71 NNTP
                typeof(OptionDefaultWorldWideWebServer), // 72
                typeof(OptionDefaultFingerServer), // 73
                typeof(OptionDefaultInternetRelayChat), // 74 IRC
                typeof(OptionStreetTalkServer), // 75
                typeof(OptionStreetTalkDirectoryAssistanceServer), // 76
                typeof(OptionEnd), // 255*

            };

            return opts;

        }

        /// <summary>
        /// Get empty option
        /// </summary>
        public static Option GetOption(uint code)
        {
            foreach (Type i in GetOptions())
            {
                Option o = (Option)Activator.CreateInstance(i);
                if (o.Code == code)
                {
                    return o;
                }
            }

            throw new OptionException(String.Format("No class found for option code: {0}", code));
        }

    }

}
