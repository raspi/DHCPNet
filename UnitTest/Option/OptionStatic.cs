using DHCPNet;
using DHCPNet.v4.Option;
using Xunit;

namespace UnitTest.Option.Static
{
    using Option = DHCPNet.v4.Option.Option;

    public class All
    {
        [Fact]
        public void MaskFFFFFFFF()
        {
            Assert.Equal(32, Option.GetCIDRFromBytes(new byte[] { 255, 255, 255, 255 }));
        }

        [Fact]
        public void Mask0()
        {
            Assert.Equal(0, Option.GetCIDRFromBytes(new byte[] { 0, 0, 0, 0 }));
        }

        [Fact]
        public void Cidr0()
        {
            Assert.Equal(new byte[] { 0, 0, 0, 0 }, Option.GetCIDRBytes(0));
        }

        [Fact]
        public void Cidr32()
        {
            Assert.Equal(new byte[] { 255, 255, 255, 255 }, Option.GetCIDRBytes(32));
        }

        [Fact]
        public void CidrTooBig()
        {
            Assert.Throws<OptionException>(
                () => Option.GetCIDRBytes(33)
            );
        }

        [Fact]
        public void CidrEmptyBytes()
        {
            Assert.Throws<OptionException>(
                () => Option.GetCIDRFromBytes(new byte[] {})
            );
        }

        [Fact]
        public void CidrToomanyBytes()
        {
            byte[] b = new byte[5];
            Assert.Throws<OptionException>(
                () => Option.GetCIDRFromBytes(b)
            );
        }

    }
}
