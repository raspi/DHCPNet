using System;
using DHCPNet;
using DHCPNet.v4.Option;
using Xunit;
using Xunit.Extensions;

namespace UnitTest.DHCPPacketTest
{
    using System.Collections.Generic;

    using Option = DHCPNet.v4.Option.Option;

    public class All
    {
        [Fact]
        public void TestEmpty()
        {
            Assert.Throws<DHCPException>(
                () => new DHCPPacket(new byte[] { })
            );
        }

        [Fact]
        public void TestTooShort()
        {
            Assert.Throws<DHCPException>(
                () => new DHCPPacket(new byte[] { 0 })
            );
        }

        [Fact]
        public void TestTooLong()
        {
            byte[] b = new byte[577];

            Assert.Equal(577, b.Length);

            Assert.Throws<DHCPException>(
                () => new DHCPPacket(b)
            );
        }

        [Fact]
        public void OnlyZeroesMaxLen()
        {
            byte[] b = new byte[576];

            Assert.Equal(576, b.Length);

            Assert.Throws<DHCPException>(
                () => new DHCPPacket(b)
            );
        }

        [Fact]
        public void OnlyZeroesMinLen()
        {
            byte[] b = new byte[312];

            Assert.Equal(312, b.Length);

            Assert.Throws<DHCPException>(
                () => new DHCPPacket(b)
            );
        }

        [Fact]
        public void Raw()
        {
            HardwareAddress ha = new HardwareAddress(new MacAddress(new byte[] { 00, 11, 22, 33, 44, 55 }));

            DHCPPacket p = new DHCPPacket()
            {
                OpCode = EOpCode.BootRequest,
                HardwareAddressType = EHardwareType.Ethernet,
                Hops = 0,
                TransactionID = 0,
                Seconds = 0,
                Flags = 0,
                ClientAddress = new IPv4Address(new byte[] { 0, 0, 0, 0 }),
                YourAddress = new IPv4Address(new byte[] { 0, 0, 0, 0 }),
                ServerAddress = new IPv4Address(new byte[] { 0, 0, 0, 0 }),
                RelayAgentAddress = new IPv4Address(new byte[] { 0, 0, 0, 0 }),
                ClientHardwareAddress = ha,
                ServerHostName = String.Empty,
                File = String.Empty,
            };

            p.Options = new List<Option>() { new OptionEnd() };

            Assert.Equal(EOpCode.BootRequest, p.OpCode);
            Assert.Equal(EHardwareType.Ethernet, p.HardwareAddressType);
            Assert.Equal(0, p.Hops);
            Assert.Equal((uint)0, p.TransactionID);
            Assert.Equal((ushort)0, p.Seconds);
            Assert.Equal((ushort)0, p.Flags);
            Assert.Equal(new IPv4Address(new byte[] { 0, 0, 0, 0 }).ToString(), p.ClientAddress.ToString());
            Assert.Equal(new IPv4Address(new byte[] { 0, 0, 0, 0 }).ToString(), p.YourAddress.ToString());
            Assert.Equal(new IPv4Address(new byte[] { 0, 0, 0, 0 }).ToString(), p.ServerAddress.ToString());
            Assert.Equal(new IPv4Address(new byte[] { 0, 0, 0, 0 }).ToString(), p.RelayAgentAddress.ToString());
            Assert.Equal(ha.Address, p.ClientHardwareAddress.Address);
            Assert.Equal(String.Empty, p.ServerHostName);
            Assert.Equal(String.Empty, p.File);

            byte[] expected = { 1, 1, 6, 0 };

            Assert.Equal(312, p.GetRawBytes().Length);

        }


    }
}
