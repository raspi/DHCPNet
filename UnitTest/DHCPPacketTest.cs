using System;
using DHCPNet;
using DHCPNet.v4.Option;
using Xunit;
using Xunit.Extensions;
using System.Collections.Generic;

using UnitTest.Raw;

namespace UnitTest.DHCPPacketTest
{

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

            DHCPPacketBase p = new DHCPPacketBootRequest()
            {
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
                ServerHostName = new byte[64],
                File = new byte[128],
            };

            p.Options = new List<Option>() { new OptionEnd() };

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
            Assert.Equal(new byte[64], p.ServerHostName);
            Assert.Equal(new byte[128], p.File);

            Assert.Equal(265, p.GetRawBytes().Length);

        }

    }
}
