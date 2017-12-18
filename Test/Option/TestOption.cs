using System;
using DHCPNet;
using DHCPNet.v4.Option;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TestOption
    {
        [TestMethod]
        [ExpectedException(typeof(OptionException))]
        public void TestCidrTooBig()
        {
            OptionSubnetMask o = new OptionSubnetMask(33);
        }

        [TestMethod]
        [ExpectedException(typeof(OptionException))]
        public void TestCidrTooBigProperty()
        {
            OptionSubnetMask o = new OptionSubnetMask(0)
            {
                CIDR = 33
            };
        }

    }
}