using Microsoft.VisualStudio.TestTools.UnitTesting;
using DHCPNet;

namespace Test
{
    [TestClass]
    public class UnitTestDHCPPacket
    {
        [TestMethod]
        [ExpectedException(typeof(DHCPException))]
        public void TestEmpty()
        {
            DHCPPacket packet = new DHCPPacket(new byte[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(DHCPException))]
        public void TestTooShort()
        {
            DHCPPacket packet = new DHCPPacket(new byte[] { 0 });
        }

        [TestMethod]
        [ExpectedException(typeof(DHCPException))]
        public void TestTooLong()
        {
            byte[] b = new byte[577];
            DHCPPacket packet = new DHCPPacket(b);
        }

    }
}
