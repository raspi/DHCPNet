using System;
using DHCPNet;
using DHCPNet.v4.Option;
using Xunit;
using Xunit.Extensions;

namespace IPv4AddressTest
{
    public class All
    {
        [Fact]
        public void TestEmpty()
        {
            Assert.Throws<IPv4AddressException>(
                () => new IPv4Address(new byte[] { })
            );
        }

        [Fact]
        public void TestTooLong()
        {
            Assert.Throws<IPv4AddressException>(
                () => new IPv4Address(new byte[] { 0, 0, 0, 0, 0 })
            );
        }

        [Fact]
        public void TestFFFFFFFF()
        {
            IPv4Address IP = new IPv4Address(new byte[] { 255, 255, 255, 255 });
            Assert.Equal(0xffffffff, IP.ToUInt32());
        }

        [Fact]
        public void Test0()
        {
            IPv4Address IP = new IPv4Address(new byte[] { 0, 0, 0, 0 });
            Assert.Equal((UInt32)0, IP.ToUInt32());
        }

        [Fact]
        public void TestToString()
        {
            IPv4Address IP = new IPv4Address(new byte[] { 123, 123, 123, 123 });
            Assert.Equal("123.123.123.123", IP.ToString());
        }

    }
}
