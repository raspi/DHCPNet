﻿using DHCPNet;
using DHCPNet.v4.Option;
using Xunit;
using System;

namespace UnitTest.Option.TestEmpty
{

    using Option = DHCPNet.v4.Option.Option;

    /// <summary>
    /// Test options with empty data.
    /// </summary>
    public class All
    {
        /// <summary>
        /// Test option with empty data.
        /// </summary>
        /// <param name="o">
        /// Option
        /// </param>
        [Theory]
        [InlineData(typeof(OptionSubnetMask))]
        [InlineData(typeof(OptionTimeOffset))]
        [InlineData(typeof(OptionGateway))]
        [InlineData(typeof(OptionTimeServer))]
        [InlineData(typeof(OptionNameServer))]
        [InlineData(typeof(OptionDomainNameServer))]
        [InlineData(typeof(OptionLogServer))]
        [InlineData(typeof(OptionCookieServer))]
        [InlineData(typeof(OptionLPRServer))]
        [InlineData(typeof(OptionImpressServer))]
        [InlineData(typeof(OptionResourceLocationServer))]
        [InlineData(typeof(OptionHostName))]
        [InlineData(typeof(OptionBootFileSize))]
        [InlineData(typeof(OptionMeritDumpFile))]
        [InlineData(typeof(OptionDomainName))]
        [InlineData(typeof(OptionSwapServer))]
        [InlineData(typeof(OptionRootPath))]
        [InlineData(typeof(OptionExtensionPath))]
        [InlineData(typeof(OptionUseIPForwarding))]
        [InlineData(typeof(OptionUseNonLocalSourceRouting))]
        [InlineData(typeof(OptionPolicyFilter))]
        [InlineData(typeof(OptionMaximumDatagramReassembly))]
        [InlineData(typeof(OptionDefaultIPTimeToLive))]
        [InlineData(typeof(OptionPathMTUAgingTimeout))]
        [InlineData(typeof(OptionPathMTUPlateauTable))]
        [InlineData(typeof(OptionInterfaceMTU))]
        [InlineData(typeof(OptionAllSubnetsAreLocal))]
        [InlineData(typeof(OptionBroadcastAddress))]
        [InlineData(typeof(OptionPerformMaskDiscovery))]
        [InlineData(typeof(OptionClientShouldRespondsToSubnetMaskICMPRequests))]
        [InlineData(typeof(OptionPerformRouterDiscovery))]
        [InlineData(typeof(OptionRouterSolicitationAddress))]
        [InlineData(typeof(OptionStaticRoute))]
        [InlineData(typeof(OptionUseTrailerEncapsulation))]
        [InlineData(typeof(OptionARPCacheTimeout))]
        [InlineData(typeof(OptionUseEthernetEncapsulation))]
        [InlineData(typeof(OptionTCPDefaultTTL))]
        [InlineData(typeof(OptionTCPKeepaliveInterval))]
        [InlineData(typeof(OptionSendTCPKeepaliveGarbageOctet))]
        [InlineData(typeof(OptionNetworkInformationServiceDomain))]
        [InlineData(typeof(OptionNetworkInformationServiceServers))]
        [InlineData(typeof(OptionNetworkTimeProtocolServers))]
        [InlineData(typeof(OptionVendorSpecificInformation))]
        [InlineData(typeof(OptionNetBIOSOverTCPIPNameServer))]
        [InlineData(typeof(OptionNetBIOSOverTCPIPDatagramDistributionServer))]
        [InlineData(typeof(OptionNetBIOSOverTCPIPNodeType))]
        [InlineData(typeof(OptionNetBIOSOverTCPIPScope))]
        [InlineData(typeof(OptionXWindowSystemFontServer))]
        [InlineData(typeof(OptionXWindowSystemDisplayManager))]
        [InlineData(typeof(OptionRequestedIPAddress))]
        [InlineData(typeof(OptionIPAddressLeaseTime))]
        [InlineData(typeof(OptionOverload))]
        [InlineData(typeof(OptionMessageType))]
        [InlineData(typeof(OptionServerIdentifier))]
        [InlineData(typeof(OptionParameterRequestList))]
        [InlineData(typeof(OptionMessage))]
        [InlineData(typeof(OptionMaximumDHCPMessageSize))]
        [InlineData(typeof(OptionRenewalTime))]
        [InlineData(typeof(OptionRebindingTime))]
        [InlineData(typeof(OptionVendorClassIdentifier))]
        [InlineData(typeof(OptionClientIdentifier))]
        [InlineData(typeof(OptionNetWareIpDomainName))]
        [InlineData(typeof(OptionNetWareIpInformation))]
        [InlineData(typeof(OptionNetworkInformationServicePlusDomain))]
        [InlineData(typeof(OptionNetworkInformationServicePlusServers))]
        [InlineData(typeof(OptionTFTPServerName))]
        [InlineData(typeof(OptionBootFileName))]
        [InlineData(typeof(OptionMobileIPHomeAgent))]
        [InlineData(typeof(OptionSimpleMailTransportProtocolServer))]
        [InlineData(typeof(OptionPostOfficeProtocolServer))]
        [InlineData(typeof(OptionNetworkNewsTransportProtocolServer))]
        [InlineData(typeof(OptionDefaultWorldWideWebServer))]
        [InlineData(typeof(OptionDefaultFingerServer))]
        [InlineData(typeof(OptionDefaultInternetRelayChat))]
        [InlineData(typeof(OptionStreetTalkServer))]
        [InlineData(typeof(OptionStreetTalkDirectoryAssistanceServer))]
        [InlineData(typeof(OptionUserClassIdentity))]
        [InlineData(typeof(OptionServiceLocationProtocolDirectoryAgent))]
        [InlineData(typeof(OptionServiceLocationProtocolServiceScope))]
        [InlineData(typeof(OptionRapidCommit))]
        [InlineData(typeof(OptionFullyQualifiedDomainName))]
        [InlineData(typeof(OptionRelayAgentCircuitInformation))]
        [InlineData(typeof(OptionInternetStorageNameServiceLocation))]
        [InlineData(typeof(OptionNovellDirectoryServicesServers))]
        [InlineData(typeof(OptionNovellDirectoryServicesTreeName))]
        [InlineData(typeof(OptionNovellDirectoryServicesContext))]
        [InlineData(typeof(OptionBroadcastAndMulticastServiceControllerDomainNameList))]
        [InlineData(typeof(OptionBroadcastAndMulticastServiceControllerIPv4Address))]
        [InlineData(typeof(OptionAuthentication))]
        [InlineData(typeof(OptionLeaseQueryClientLastTransactionTime))]
        [InlineData(typeof(OptionLeaseQueryAssociatedIpAddresses))]
        [InlineData(typeof(OptionClientSystemArchitectureType))]
        [InlineData(typeof(OptionClientNetworkInterfaceIdentifier))]
        [InlineData(typeof(OptionLightweightDirectoryAccessProtocolAddress))]
        [InlineData(typeof(OptionClientMachineIdentifier))]
        [InlineData(typeof(OptionOpenGroupUserAuthenticationProtocol))]
        [InlineData(typeof(OptionCivicLocation))]
        [InlineData(typeof(OptionTimezone))]
        [InlineData(typeof(OptionTimezoneDatabase))]
        [InlineData(typeof(OptionNetInfoParentServerAddress))]
        [InlineData(typeof(OptionNetInfoParentServerTag))]
        [InlineData(typeof(OptionUrl))]
        [InlineData(typeof(OptionUseStatelessAutoConfigure))]
        [InlineData(typeof(OptionNameServiceSearchOrder))]
        [InlineData(typeof(OptionIPv4SubnetSelection))]
        [InlineData(typeof(OptionDomainSearch))]
        [InlineData(typeof(OptionSessionInitiationProtocolServers))]
        [InlineData(typeof(OptionClasslessStaticRoute))]
        [InlineData(typeof(OptionCableLabsClientConfiguration))]
        [InlineData(typeof(OptionCoordinateBasedLocationConfigurationInformationConfiguration))]
        [InlineData(typeof(OptionVendorIdentifyingVendorClass))]
        [InlineData(typeof(OptionVendorIdentifyingVendorSpecificInformation))]
        [InlineData(typeof(OptionIntelPreBootExecutionEnvironment128))]
        [InlineData(typeof(OptionIntelPreBootExecutionEnvironment129))]
        [InlineData(typeof(OptionIntelPreBootExecutionEnvironment130))]
        [InlineData(typeof(OptionIntelPreBootExecutionEnvironment131))]
        [InlineData(typeof(OptionIntelPreBootExecutionEnvironment132))]
        [InlineData(typeof(OptionIntelPreBootExecutionEnvironment133))]
        [InlineData(typeof(OptionIntelPreBootExecutionEnvironment134))]
        [InlineData(typeof(OptionIntelPreBootExecutionEnvironment135))]
        [InlineData(typeof(OptionProtocolForCarryingAuthenticationForNetworkAccessAgent))]
        [InlineData(typeof(OptionLocationToServiceTranslationServerLocation))]
        [InlineData(typeof(OptionControlAndProvisioningOfWirelessAccessPointsAccessControllerAddresses))]
        [InlineData(typeof(OptionMobilityServicesDiscoveryServerAddresses))]
        [InlineData(typeof(OptionMobilityServicesDiscoveryServerDomainAddresses))]
        [InlineData(typeof(OptionSessionInitiationProtocolUserAgentConfigurationServiceDomains))]
        [InlineData(typeof(OptionAccessNetworkDiscoveryAndSelectionFunctionIPv4Addresses))]
        [InlineData(typeof(OptionCoordinateBasedLocationConfigurationInformationLocation))]
        [InlineData(typeof(OptionForceRenewNonceProtocolCapabilities))]
        [InlineData(typeof(OptionRecursiveDnsServersSelection))]
        [InlineData(typeof(OptionTftpServerAddresses))]
        [InlineData(typeof(OptionBulkLeaseQueryStatusCode))]
        [InlineData(typeof(OptionBulkLeaseQueryBaseTime))]
        [InlineData(typeof(OptionBulkLeaseQueryStateStartSeconds))]
        [InlineData(typeof(OptionBulkLeaseQueryStartTime))]
        [InlineData(typeof(OptionBulkLeaseQueryEndTime))]
        [InlineData(typeof(OptionBulkLeaseQueryDhcpState))]
        [InlineData(typeof(OptionBulkLeaseQueryDataSource))]
        [InlineData(typeof(OptionPortControlProtocolServers))]
        [InlineData(typeof(OptionDynamicAllocationOfSharedIpv4AddressesPortParameters))]
        [InlineData(typeof(OptionCaptivePortalIdentificationUri))]
        [InlineData(typeof(OptionManufacturerUsageDescriptionUrl))]
        [InlineData(typeof(OptionLinuxPreBootExecutionEnvironmentConfigurationFile))]
        [InlineData(typeof(OptionLinuxPreBootExecutionEnvironmentPathPrefix))]
        [InlineData(typeof(OptionLinuxPreBootExecutionEnvironmentRebootTimeSeconds))]
        [InlineData(typeof(OptionIpv6RapidDeploymentAddresses))]
        [InlineData(typeof(OptionLocalLocationInformationServerAccessNetworkDomainName))]
        [InlineData(typeof(OptionCiscoSystemsSubnetAllocation))]
        [InlineData(typeof(OptionVirtualSubnetSelectionInformation))]
        [InlineData(typeof(OptionMicrosoftClasslessStaticRoute))]
        public void TestEmptyOption(Type o)
        {
            Option opt = (Option)Activator.CreateInstance(o);
            Exception ex = Record.Exception(() => opt.ReadRaw(new byte[] { }));
            Assert.NotNull(ex);
            Assert.IsType<OptionLengthZeroException>(ex);
        }
    }
}
