using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DHCPNet.v4.Option;
using Xunit;

namespace UnitTest.OptionCodes
{
    using Option = DHCPNet.v4.Option.Option;

    public class All
    {
        [Fact]
        public void RFC2132Codes()
        {
            byte[] rfc2132codes = {
                    0, 255, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25,
                    26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 64,
                    65, 68, 69, 70, 71, 72, 73, 74, 75, 76, 50, 51, 52, 66, 67, 54, 55, 56, 57, 58, 59, 60, 61
                };

            foreach (byte code in rfc2132codes)
            {
                Option o = OptionFactory.GetOption(code);
                Assert.True(code == o.Code,
                    String.Format("Expected {0} Actual: {1}", code, o.Code)
                );
            }
        }

        [Fact]
        public void RFC2132Booleans()
        {
            byte[] rfc2132codes = { 19, 20, 27, 29, 30, 31, 34, 36, 39 };

            foreach (byte code in rfc2132codes)
            {
                Option o = OptionFactory.GetOption(code);

                Assert.True(o is AOptionBoolean,
                    String.Format("Expected Boolean type Actual: {0}", o.GetType())
                );
            }
        }

    }
}
