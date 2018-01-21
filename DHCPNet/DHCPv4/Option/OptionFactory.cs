using System;
using System.Collections.Generic;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// https://www.iana.org/assignments/bootp-dhcp-parameters/bootp-dhcp-parameters.xhtml
    /// </summary>
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
                typeof(OptionNetWareIpDomainName), // 62
                typeof(OptionNetWareIpInformation), // 63
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
                typeof(OptionUserClassIdentity), // 77
                typeof(OptionServiceLocationProtocolDirectoryAgent), // 78
                typeof(OptionServiceLocationProtocolServiceScope), // 79
                typeof(OptionRapidCommit), // 80
                typeof(OptionFullyQualifiedDomainName), // 81
                typeof(OptionRelayAgentCircuitInformation), // 82
                typeof(OptionInternetStorageNameServiceLocation), // 83
                typeof(OptionNovellDirectoryServicesServers), // 85
                typeof(OptionNovellDirectoryServicesTreeName), // 86
                typeof(OptionNovellDirectoryServicesContext), // 87
                typeof(OptionBroadcastAndMulticastServiceControllerDomainNameList), // 88
                typeof(OptionBroadcastAndMulticastServiceControllerIPv4Address), // 89
                typeof(OptionAuthentication), // 90
                typeof(OptionLeaseQueryClientLastTransactionTime), // 91
                typeof(OptionLeaseQueryAssociatedIpAddresses), // 92
                typeof(OptionClientSystemArchitectureType), // 93
                typeof(OptionClientNetworkInterfaceIdentifier), // 94
                typeof(OptionLightweightDirectoryAccessProtocolAddress), // 95
                typeof(OptionClientMachineIdentifier), // 97
                typeof(OptionOpenGroupUserAuthenticationProtocol), // 98
                typeof(OptionCivicLocation), // 99
                typeof(OptionTimezone), // 100
                typeof(OptionTimezoneDatabase), // 101
                typeof(OptionNetInfoParentServerAddress), // 112
                typeof(OptionNetInfoParentServerTag), // 113
                typeof(OptionUrl), // 114
                typeof(OptionUseStatelessAutoConfigure), // 116
                typeof(OptionNameServiceSearchOrder), // 117
                typeof(OptionIPv4SubnetSelection), // 118
                typeof(OptionDomainSearch), // 119
                typeof(OptionSessionInitiationProtocolServers), // 120
                typeof(OptionClasslessStaticRoute), // 121
                typeof(OptionCableLabsClientConfiguration), // 122
                typeof(OptionCoordinateBasedLocationConfigurationInformationConfiguration), // 123
                typeof(OptionVendorIdentifyingVendorClass), // 124
                typeof(OptionVendorIdentifyingVendorSpecificInformation), // 125
                typeof(OptionIntelPreBootExecutionEnvironment128), // 128 PXE
                typeof(OptionIntelPreBootExecutionEnvironment129), // 129 PXE
                typeof(OptionIntelPreBootExecutionEnvironment130), // 130 PXE
                typeof(OptionIntelPreBootExecutionEnvironment131), // 131 PXE
                typeof(OptionIntelPreBootExecutionEnvironment132), // 132 PXE
                typeof(OptionIntelPreBootExecutionEnvironment133), // 133 PXE
                typeof(OptionIntelPreBootExecutionEnvironment134), // 134 PXE
                typeof(OptionIntelPreBootExecutionEnvironment135), // 135 PXE
                typeof(OptionProtocolForCarryingAuthenticationForNetworkAccessAgent), // 136
                typeof(OptionLocationToServiceTranslationServerLocation), // 137
                typeof(OptionControlAndProvisioningOfWirelessAccessPointsAccessControllerAddresses), // 138
                typeof(OptionMobilityServicesDiscoveryServerAddresses), // 139
                typeof(OptionMobilityServicesDiscoveryServerDomainAddresses), // 140
                typeof(OptionSessionInitiationProtocolUserAgentConfigurationServiceDomains), // 141
                typeof(OptionAccessNetworkDiscoveryAndSelectionFunctionIPv4Addresses), // 142
                typeof(OptionCoordinateBasedLocationConfigurationInformationLocation), // 144
                typeof(OptionForceRenewNonceProtocolCapabilities), // 145
                typeof(OptionRecursiveDnsServersSelection), // 146
                typeof(OptionTftpServerAddresses), // 150
                typeof(OptionBulkLeaseQueryStatusCode), // 151
                typeof(OptionBulkLeaseQueryBaseTime), // 152
                typeof(OptionBulkLeaseQueryStateStartSeconds), // 153
                typeof(OptionBulkLeaseQueryStartTime), // 154
                typeof(OptionBulkLeaseQueryEndTime), // 155
                typeof(OptionBulkLeaseQueryDhcpState), // 156
                typeof(OptionBulkLeaseQueryDataSource), // 157
                typeof(OptionPortControlProtocolServers), // 158
                typeof(OptionDynamicAllocationOfSharedIpv4AddressesPortParameters), // 159
                typeof(OptionCaptivePortalIdentificationUri), // 160
                typeof(OptionManufacturerUsageDescriptionUrl), // 161
                typeof(OptionLinuxPreBootExecutionEnvironmentConfigurationFile), // 209
                typeof(OptionLinuxPreBootExecutionEnvironmentPathPrefix), // 210
                typeof(OptionLinuxPreBootExecutionEnvironmentRebootTimeSeconds), // 211
                typeof(OptionIpv6RapidDeploymentAddresses), // 212
                typeof(OptionLocalLocationInformationServerAccessNetworkDomainName), // 213
                typeof(OptionMicrosoftClasslessStaticRoute), // 249 see 121
                typeof(OptionEnd), // 255*
            };

            return opts;
        }

        /// <summary>
        /// Get empty option
        /// </summary>
        public static Option GetOption(byte code)
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