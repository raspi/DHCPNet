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

    /// <summary>
    /// https://tools.ietf.org/html/rfc1035#section-4.1.4
    /// </summary>
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

        [Fact]
        public void TestCompressedBytesToStringInvalidLength()
        {
            byte[] testBytes =
                {
                    10, (byte)'a', 0,
                };

            Assert.Throws<IndexOutOfRangeException>(
                () => DomainName.CompressedBytesToString(testBytes)
            );

        }

        [Fact]
        public void TestCompressedBytesToStringInvalidLength2()
        {
            byte[] testBytes =
                {
                    2, (byte)'a', 0,
                };

            Assert.Throws<IndexOutOfRangeException>(
                () => DomainName.CompressedBytesToString(testBytes)
            );

        }

        [Fact]
        public void TestCompressedBytesToStringInvalidLength3()
        {
            byte[] testBytes =
                {
                    0, (byte)'a', 0,
                };

            Assert.Throws<Exception>(
                () => DomainName.CompressedBytesToString(testBytes)
            );

        }

    }
}