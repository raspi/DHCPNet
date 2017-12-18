using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the name of the client's NIS domain. 
    /// The domain is formatted as a character string consisting of 
    /// characters from the NVT ASCII character set.
    /// 
    /// Minimum length is 1.
    /// </summary>
    class OptionNetworkInformationServiceDomain : AOptionString
    {
        public override byte Code
        {
            get
            {
                return 40;
            }
        }
    }
}

