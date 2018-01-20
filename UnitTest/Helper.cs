using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DHCPNet;
using Xunit;
using DHCPNet.v4.Option;

namespace UnitTest.Helper
{

    public class All
    {
        [Fact]
        public void TestStringToCompressedBytes()
        {
            List<string> testList = new List<string> { "example.com", "example.net" };

            byte[] expectedResultBytes =
                {
                    7, (byte)'e', (byte)'x', (byte)'a', (byte)'m', (byte)'p', (byte)'l', (byte)'e', 3, (byte)'c',
                    (byte)'o', (byte)'m', 0, 7, (byte)'e', (byte)'x', (byte)'a', (byte)'m', (byte)'p', (byte)'l',
                    (byte)'e', 3, (byte)'n', (byte)'e', (byte)'t', 0,
                };

            byte[] b = DomainName.StringToCompressedBytes(testList);

            Assert.Equal(expectedResultBytes.Length, b.Length);

            for (int i = 0; i < expectedResultBytes.Length; i++)
            {
                byte expected = expectedResultBytes[i];
                byte actual = b[i];

                Assert.True(expected == actual, 
                    String.Format("Expected {0:x2} Actual: {1:x2}", expected, actual)
                );
            }


            //Encoding.ASCII.GetBytes("test");


            //Assert.Equal("foo", list[0]);
        }

        [Fact]
        public void TestCompressedBytesToString()
        {
            byte[] testBytes =
                {
                    7, (byte)'e', (byte)'x', (byte)'a', (byte)'m', (byte)'p', (byte)'l', (byte)'e', 3, (byte)'c',
                    (byte)'o', (byte)'m', 0, 7, (byte)'e', (byte)'x', (byte)'a', (byte)'m', (byte)'p', (byte)'l',
                    (byte)'e', 3, (byte)'n', (byte)'e', (byte)'t', 0,
                };

            List<string> expected = new List<string> { "example.com", "example.net" };

            List<string> actual = DomainName.CompressedBytesToString(testBytes);

            Assert.Equal(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.True(expected[i] == actual[i],
                    String.Format("Expected '{0}' Actual: '{1}'", expected[i], actual[i])
                );

            }

        }
    }
}