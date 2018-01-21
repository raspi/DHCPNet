using System;
using DHCPNet;
using DHCPNet.v4.Option;
using Xunit;
using Xunit.Extensions;
using System.Collections.Generic;
using UnitTest.Raw;

namespace UnitTest.RawPacketTest
{
    using Option = DHCPNet.v4.Option.Option;

    /// <summary>
    /// Test packet generated from raw bytes
    /// </summary>
    public class All
    {

        [Fact]
        public void RawDiscover()
        {
            byte[] b = RawData.Discover;
            byte[] pb = DHCPPacketFactory.Read(b).GetRawBytes();

            Assert.Equal(b.Length, pb.Length);

            for (int i = 0; i < b.Length; i++)
            {
                byte expected = b[i];
                byte actual = pb[i];

                Assert.True(
                    expected == actual,
                    String.Format(
                        "Expected: '0x{0:x2}', Actual: '0x{1:x2}' at offset {2}.",
                        (byte)expected,
                        (byte)actual,
                        i));
            }
        }

        [Fact]
        public void RawDiscoverPacket()
        {
            DHCPPacketBase p = DHCPPacketFactory.Read(RawData.Discover);

            Assert.IsType(typeof(DHCPPacketBootRequest), p);

            IPv4Address expectedIP = new IPv4Address(new byte[] { 0, 0, 0, 0 });

            Assert.True(EHardwareType.Ethernet == p.HardwareAddressType, "Address type wasn't Ethernet");
            Assert.True(6 == p.HardwareAddressLength, "Address length wasn't 6");
            Assert.True(0 == p.Hops, "Hops wasn't 0");
            Assert.True((uint)0x3d1d == p.TransactionID, String.Format("Transaction id was '{0:x}'", p.TransactionID));
            Assert.True(0 == p.Seconds, "Seconds wasn't 0");
            Assert.True(0 == p.Flags, "Flags wasn't 0");
            Assert.Equal(expectedIP.ToString(), p.ClientAddress.ToString());
            Assert.Equal(expectedIP.ToString(), p.YourAddress.ToString());
            Assert.Equal(expectedIP.ToString(), p.ServerAddress.ToString());
            Assert.Equal(expectedIP.ToString(), p.RelayAgentAddress.ToString());

            HardwareAddress expectedHardwareAddress =
                new HardwareAddress(new MacAddress(new byte[] { 0x00, 0x0b, 0x82, 0x01, 0xfc, 0x42 }));
            byte[] expectedMac = expectedHardwareAddress.Address;
            byte[] actualMac = p.ClientHardwareAddress.Address;

            for (int i = 0; i < expectedMac.Length; i++)
            {
                byte expected = expectedMac[i];
                byte actual = actualMac[i];

                Assert.True(
                    expected == actual,
                    String.Format(
                        "Expected: '0x{0:x2}', Actual: '0x{1:x2}' at offset {2}. Expected: {3} Actual: {4}",
                        (byte)expected,
                        (byte)actual,
                        i,
                        expectedHardwareAddress,
                        p.ClientHardwareAddress));
            }

            Assert.Equal(String.Empty, p.ServerHostName);
            Assert.Equal(String.Empty, p.File);

        }

        [Fact]
        public void RawOffer()
        {
            byte[] b = RawData.Offer;
            byte[] pb = DHCPPacketFactory.Read(b).GetRawBytes();

            Assert.Equal(b.Length, pb.Length);

            for (int i = 0; i < b.Length; i++)
            {
                byte expected = b[i];
                byte actual = pb[i];

                Assert.True(
                    expected == actual,
                    String.Format(
                        "Expected: '0x{0:x2}', Actual: '0x{1:x2}' at offset {2}.",
                        (byte)expected,
                        (byte)actual,
                        i));
            }
        }

        [Fact]
        public void RawOfferPacket()
        {
            DHCPPacketBase p = DHCPPacketFactory.Read(RawData.Offer);

            Assert.IsType(typeof(DHCPPacketBootReply), p);

            IPv4Address expectedClientIP = new IPv4Address(new byte[] { 0, 0, 0, 0 });
            IPv4Address expectedYourIP = new IPv4Address(new byte[] { 192, 168, 0, 10 });
            IPv4Address expectedServerIP = new IPv4Address(new byte[] { 192, 168, 0, 1 });
            IPv4Address expectedRelayIP = new IPv4Address(new byte[] { 0, 0, 0, 0 });

            Assert.True(EHardwareType.Ethernet == p.HardwareAddressType, "Address type wasn't Ethernet");
            Assert.True(6 == p.HardwareAddressLength, "Address length wasn't 6");
            Assert.True(0 == p.Hops, "Hops wasn't 0");
            Assert.True((uint)0x3d1d == p.TransactionID, String.Format("Transaction id was '{0:x}'", p.TransactionID));
            Assert.True(6 == p.HardwareAddressLength, "Address length wasn't 6");
            Assert.True(0 == p.Seconds, "Seconds wasn't 0");
            Assert.True(0 == p.Flags, "Flags wasn't 0");
            Assert.Equal(expectedClientIP.ToString(), p.ClientAddress.ToString());
            Assert.Equal(expectedYourIP.ToString(), p.YourAddress.ToString());
            Assert.Equal(expectedServerIP.ToString(), p.ServerAddress.ToString());
            Assert.Equal(expectedRelayIP.ToString(), p.RelayAgentAddress.ToString());

            HardwareAddress expectedHardwareAddress =
                new HardwareAddress(new MacAddress(new byte[] { 0x00, 0x0b, 0x82, 0x01, 0xfc, 0x42 }));
            byte[] expectedMac = expectedHardwareAddress.Address;
            byte[] actualMac = p.ClientHardwareAddress.Address;

            for (int i = 0; i < expectedMac.Length; i++)
            {
                byte expected = expectedMac[i];
                byte actual = actualMac[i];

                Assert.True(
                    expected == actual,
                    String.Format(
                        "Expected: '0x{0:x2}', Actual: '0x{1:x2}' at offset {2}. Expected: {3} Actual: {4}",
                        (byte)expected,
                        (byte)actual,
                        i,
                        expectedHardwareAddress,
                        p.ClientHardwareAddress));
            }

            Assert.Equal(String.Empty, p.ServerHostName);
            Assert.Equal(String.Empty, p.File);

        }

        [Fact]
        public void RawRequest()
        {
            byte[] b = RawData.Request;
            byte[] pb = DHCPPacketFactory.Read(b).GetRawBytes();

            Assert.Equal(b.Length, pb.Length);

            for (int i = 0; i < b.Length; i++)
            {
                byte expected = b[i];
                byte actual = pb[i];

                Assert.True(
                    expected == actual,
                    String.Format(
                        "Expected: '0x{0:x2}', Actual: '0x{1:x2}' at offset {2}.",
                        (byte)expected,
                        (byte)actual,
                        i));
            }
        }

        [Fact]
        public void RawRequestPacket()
        {
            DHCPPacketBase p = DHCPPacketFactory.Read(RawData.Request);

            Assert.IsType(typeof(DHCPPacketBootRequest), p);

            IPv4Address expectedIP = new IPv4Address(new byte[] { 0, 0, 0, 0 });

            Assert.True(EHardwareType.Ethernet == p.HardwareAddressType, "Address type wasn't Ethernet");
            Assert.True(6 == p.HardwareAddressLength, "Address length wasn't 6");
            Assert.True(0 == p.Hops, "Hops wasn't 0");
            Assert.True((uint)0x3d1e == p.TransactionID, String.Format("Transaction id was '{0:x}'", p.TransactionID));
            Assert.True(6 == p.HardwareAddressLength, "Address length wasn't 6");
            Assert.True(0 == p.Seconds, "Seconds wasn't 0");
            Assert.True(0 == p.Flags, "Flags wasn't 0");
            Assert.Equal(expectedIP.ToString(), p.ClientAddress.ToString());
            Assert.Equal(expectedIP.ToString(), p.YourAddress.ToString());
            Assert.Equal(expectedIP.ToString(), p.ServerAddress.ToString());
            Assert.Equal(expectedIP.ToString(), p.RelayAgentAddress.ToString());

            HardwareAddress expectedHardwareAddress =
                new HardwareAddress(new MacAddress(new byte[] { 0x00, 0x0b, 0x82, 0x01, 0xfc, 0x42 }));
            byte[] expectedMac = expectedHardwareAddress.Address;
            byte[] actualMac = p.ClientHardwareAddress.Address;

            for (int i = 0; i < expectedMac.Length; i++)
            {
                byte expected = expectedMac[i];
                byte actual = actualMac[i];

                Assert.True(
                    expected == actual,
                    String.Format(
                        "Expected: '0x{0:x2}', Actual: '0x{1:x2}' at offset {2}. Expected: {3} Actual: {4}",
                        (byte)expected,
                        (byte)actual,
                        i,
                        expectedHardwareAddress,
                        p.ClientHardwareAddress));
            }

            Assert.Equal(String.Empty, p.ServerHostName);
            Assert.Equal(String.Empty, p.File);

        }

        [Fact]
        public void RawAcknowledge()
        {
            byte[] b = RawData.Acknowledge;
            byte[] pb = DHCPPacketFactory.Read(b).GetRawBytes();

            Assert.Equal(b.Length, pb.Length);

            for (int i = 0; i < b.Length; i++)
            {
                byte expected = b[i];
                byte actual = pb[i];

                Assert.True(
                    expected == actual,
                    String.Format(
                        "Expected: '0x{0:x2}', Actual: '0x{1:x2}' at offset {2}.",
                        (byte)expected,
                        (byte)actual,
                        i));
            }
        }

        [Fact]
        public void RawAcknowledgePacket()
        {
            DHCPPacketBase p = DHCPPacketFactory.Read(RawData.Acknowledge);

            Assert.IsType(typeof(DHCPPacketBootReply), p);

            IPv4Address expectedClientIP = new IPv4Address(new byte[] { 0, 0, 0, 0 });
            IPv4Address expectedYourIP = new IPv4Address(new byte[] { 192, 168, 0, 10 });
            IPv4Address expectedServerIP = new IPv4Address(new byte[] { 0, 0, 0, 0 });
            IPv4Address expectedRelayIP = new IPv4Address(new byte[] { 0, 0, 0, 0 });

            Assert.True(EHardwareType.Ethernet == p.HardwareAddressType, "Address type wasn't Ethernet");
            Assert.True(6 == p.HardwareAddressLength, "Address length wasn't 6");
            Assert.True(0 == p.Hops, "Hops wasn't 0");
            Assert.True((uint)0x3d1e == p.TransactionID, String.Format("Transaction id was '{0:x}'", p.TransactionID));
            Assert.True(6 == p.HardwareAddressLength, "Address length wasn't 6");
            Assert.True(0 == p.Seconds, "Seconds wasn't 0");
            Assert.True(0 == p.Flags, "Flags wasn't 0");
            Assert.Equal(expectedClientIP.ToString(), p.ClientAddress.ToString());
            Assert.Equal(expectedYourIP.ToString(), p.YourAddress.ToString());
            Assert.Equal(expectedServerIP.ToString(), p.ServerAddress.ToString());
            Assert.Equal(expectedRelayIP.ToString(), p.RelayAgentAddress.ToString());

            HardwareAddress expectedHardwareAddress =
                new HardwareAddress(new MacAddress(new byte[] { 0x00, 0x0b, 0x82, 0x01, 0xfc, 0x42 }));
            byte[] expectedMac = expectedHardwareAddress.Address;
            byte[] actualMac = p.ClientHardwareAddress.Address;

            for (int i = 0; i < expectedMac.Length; i++)
            {
                byte expected = expectedMac[i];
                byte actual = actualMac[i];

                Assert.True(
                    expected == actual,
                    String.Format(
                        "Expected: '0x{0:x2}', Actual: '0x{1:x2}' at offset {2}. Expected: {3} Actual: {4}",
                        (byte)expected,
                        (byte)actual,
                        i,
                        expectedHardwareAddress,
                        p.ClientHardwareAddress));
            }

            Assert.Equal(String.Empty, p.ServerHostName);
            Assert.Equal(String.Empty, p.File);

        }
    }
}
