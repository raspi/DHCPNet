using System;
using DHCPNet;
using DHCPNet.v4.Option;
using Xunit;
using Xunit.Extensions;

namespace DHCPPacketTest
{
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

            Assert.Throws<DHCPException>(
                () => new DHCPPacket(b)
            );
        }

    }
}
