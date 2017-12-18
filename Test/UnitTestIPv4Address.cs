using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DHCPNet;
using DHCPNet.v4.Option;

namespace Test
{
    [TestClass]
    public class UnitTestIPv4Address
    {
        [TestMethod]
        [ExpectedException(typeof(IPv4AddressException))]
        public void TestEmpty()
        {
            IPv4Address IP = new IPv4Address(new byte[] { });

        }

        [TestMethod]
        [ExpectedException(typeof(IPv4AddressException))]
        public void TestTooLong()
        {
            IPv4Address IP = new IPv4Address(new byte[] { 0, 0, 0, 0, 0});
        }

        [TestMethod]
        public void TestFFFFFFFF()
        {
            IPv4Address IP = new IPv4Address(new byte[] { 255, 255, 255, 255});
            Assert.AreEqual(0xffffffff, IP.ToUInt32());
        }

        [TestMethod]
        public void Test0()
        {
            IPv4Address IP = new IPv4Address(new byte[] { 0, 0, 0, 0 });
            Assert.AreEqual((UInt32)0, IP.ToUInt32());
        }

        [TestMethod]
        public void TestToString()
        {
            IPv4Address IP = new IPv4Address(new byte[] { 123, 123, 123, 123 });
            Assert.AreEqual("123.123.123.123", IP.ToString());
        }


    }
}
