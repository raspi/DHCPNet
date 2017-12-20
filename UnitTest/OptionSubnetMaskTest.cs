using System;
using DHCPNet;
using DHCPNet.v4.Option;
using Xunit;

namespace UnitTest.OptionSubnetMaskTest
{
    public class All
    {
        [Fact]
        public void TestCidrTooBig()
        {
            Assert.Throws<OptionException>(
                () => new OptionSubnetMask(33)
            );
        }

        [Fact]
        public void TestCidrTooBigProperty()
        {
            OptionSubnetMask o = new OptionSubnetMask(0);
            Assert.Throws<OptionException>(
                () => o.CIDR = 33 
            );
        }

    }
}