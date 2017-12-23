using System;
using DHCPNet;
using DHCPNet.v4.Option;
using Xunit;
using Xunit.Extensions;

namespace UnitTest.DHCPPacketTest
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;

    using UnitTest.Raw;

    using Option = DHCPNet.v4.Option.Option;

    public class All
    {
        [Fact]
        public void TestEmpty()
        {
            Assert.Throws<DHCPException>(
                () => DHCPPacketFactory.Read(new byte[] { })
            );
        }

        [Fact]
        public void TestTooShort()
        {
            Assert.Throws<DHCPException>(
                () => DHCPPacketFactory.Read(new byte[] { 0 })
            );
        }

        [Fact]
        public void TestTooLong()
        {
            byte[] b = new byte[577];

            Assert.Equal(577, b.Length);

            Assert.Throws<DHCPException>(
                () => DHCPPacketFactory.Read(b)
            );
        }

        [Fact]
        public void OnlyZeroesMaxLen()
        {
            byte[] b = new byte[576];

            Assert.Equal(576, b.Length);

            Assert.Throws<DHCPException>(
                () => DHCPPacketFactory.Read(b)
            );
        }

        [Fact]
        public void OnlyZeroesMinLen()
        {
            byte[] b = new byte[312];

            Assert.Equal(312, b.Length);

            Assert.Throws<DHCPException>(
                () => DHCPPacketFactory.Read(b)
            );
        }

        [Fact]
        public void Only0xFFMinLen()
        {
            byte[] b = new byte[312];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = 0xff;
            }

            Assert.Throws<DHCPException>(
                () => DHCPPacketFactory.Read(b)
            );
        }


        [Fact]
        public void Raw()
        {
            HardwareAddress ha = new HardwareAddress(new MacAddress(new byte[] { 00, 11, 22, 33, 44, 55 }));

            IPv4Address expectedIP = new IPv4Address(new byte[] { 1, 2, 3, 4 });

            DHCPPacket p = new DHCPPacket()
            {
                OpCode = EOpCode.BootRequest,
                HardwareAddressType = EHardwareType.Ethernet,
                Hops = 99,
                TransactionID = 0x12345678,
                Seconds = 0xf00f,
                Flags = 0,
                ClientAddress = expectedIP,
                YourAddress = expectedIP,
                ServerAddress = expectedIP,
                RelayAgentAddress = expectedIP,
                ClientHardwareAddress = ha,
                ServerHostName = String.Empty,
                File = String.Empty,
            };

            p.Options = new List<Option>() { new OptionEnd() };

            Assert.Equal(EOpCode.BootRequest, p.OpCode);
            Assert.Equal(EHardwareType.Ethernet, p.HardwareAddressType);
            Assert.Equal(99, p.Hops);
            Assert.Equal((uint)0x12345678, p.TransactionID);
            Assert.Equal((ushort)0xf00f, p.Seconds);
            Assert.Equal((ushort)0, p.Flags);
            Assert.Equal(expectedIP.ToString(), p.ClientAddress.ToString());
            Assert.Equal(expectedIP.ToString(), p.YourAddress.ToString());
            Assert.Equal(expectedIP.ToString(), p.ServerAddress.ToString());
            Assert.Equal(expectedIP.ToString(), p.RelayAgentAddress.ToString());
            Assert.Equal(ha.Address, p.ClientHardwareAddress.Address);
            Assert.Equal(String.Empty, p.ServerHostName);
            Assert.Equal(String.Empty, p.File);

            Assert.Equal(265, p.GetRawBytes().Length);

        }

        [Fact]
        public void RawDiscover()
        {
            byte[] b = RawData.Discover();
            byte[] pb = DHCPPacketFactory.Read(b).GetRawBytes();

            Assert.Equal(b.Length, pb.Length);

            for (int i = 0; i < b.Length; i++)
            {
                byte expected = b[i];
                byte actual = pb[i];

                Assert.True(expected == actual,
                    String.Format("Expected: '0x{0:x2}', Actual: '0x{1:x2}' at offset {2}.", (byte)expected, (byte)actual, i)
                );
            }
        }

        [Fact]
        public void RawDiscoverPacket()
        {
            DHCPPacket p = DHCPPacketFactory.Read(RawData.Discover());

            IPv4Address expectedIP = new IPv4Address(new byte[] { 0, 0, 0, 0 });

            Assert.True(EOpCode.BootRequest == p.OpCode, "Opcode wasn't BootRequest");
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

            HardwareAddress expectedHardwareAddress = new HardwareAddress(new MacAddress(new byte[]{ 0x00, 0x0b, 0x82, 0x01, 0xfc, 0x42 }));
            byte[] expectedMac = expectedHardwareAddress.Address;
            byte[] actualMac = p.ClientHardwareAddress.Address;

            for (int i = 0; i < expectedMac.Length; i++)
            {
                byte expected = expectedMac[i];
                byte actual = actualMac[i];

                Assert.True(expected == actual,
                    String.Format("Expected: '0x{0:x2}', Actual: '0x{1:x2}' at offset {2}. Expected: {3} Actual: {4}", (byte)expected, (byte)actual, i, expectedHardwareAddress, p.ClientHardwareAddress)
                );
            }

            Assert.Equal(String.Empty, p.ServerHostName);
            Assert.Equal(String.Empty, p.File);

        }

        [Fact]
        public void RawOffer()
        {
            byte[] b = RawData.Offer();
            byte[] pb = DHCPPacketFactory.Read(b).GetRawBytes();

            Assert.Equal(b.Length, pb.Length);

            for (int i = 0; i < b.Length; i++)
            {
                byte expected = b[i];
                byte actual = pb[i];

                Assert.True(expected == actual,
                    String.Format("Expected: '0x{0:x2}', Actual: '0x{1:x2}' at offset {2}.", (byte)expected, (byte)actual, i)
                );
            }
        }

        [Fact]
        public void RawOfferPacket()
        {
            DHCPPacket p = DHCPPacketFactory.Read(RawData.Offer());

            IPv4Address expectedClientIP = new IPv4Address(new byte[] { 0, 0, 0, 0 });
            IPv4Address expectedYourIP = new IPv4Address(new byte[] { 192, 168, 0, 10 });
            IPv4Address expectedServerIP = new IPv4Address(new byte[] { 192, 168, 0, 1 });
            IPv4Address expectedRelayIP = new IPv4Address(new byte[] { 0, 0, 0, 0 });

            Assert.True(EOpCode.BootReply == p.OpCode, "Opcode wasn't BootReply");
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

            HardwareAddress expectedHardwareAddress = new HardwareAddress(new MacAddress(new byte[] { 0x00, 0x0b, 0x82, 0x01, 0xfc, 0x42 }));
            byte[] expectedMac = expectedHardwareAddress.Address;
            byte[] actualMac = p.ClientHardwareAddress.Address;

            for (int i = 0; i < expectedMac.Length; i++)
            {
                byte expected = expectedMac[i];
                byte actual = actualMac[i];

                Assert.True(expected == actual,
                    String.Format("Expected: '0x{0:x2}', Actual: '0x{1:x2}' at offset {2}. Expected: {3} Actual: {4}", (byte)expected, (byte)actual, i, expectedHardwareAddress, p.ClientHardwareAddress)
                );
            }

            Assert.Equal(String.Empty, p.ServerHostName);
            Assert.Equal(String.Empty, p.File);

        }

    }
}
