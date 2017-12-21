using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the name of the client's NIS+ domain.
    /// 
    /// The domain is formatted as a character string 
    /// consisting of characters from the NVT ASCII character set.
    /// 
    /// Minimum length 1 byte.
    /// </summary>
    public class OptionNetworkInformationServicePlusDomain : AOptionString
    {
        public OptionNetworkInformationServicePlusDomain()
        {
        }

        public override byte Code
        {
            get
            {
                return 64;
            }
        }
    }
}