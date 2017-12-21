using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies whether or not the client may assume that all
    /// subnets of the IP network to which the client is connected use the
    /// same MTU as the subnet of that network to which the client is
    /// directly connected.
    /// 
    /// A value of 1 indicates that all subnets share
    /// the same MTU. 
    /// 
    /// A value of 0 means that the client should assume that
    /// some subnets of the directly connected network may have smaller MTUs.
    /// </summary>
    public class OptionAllSubnetsAreLocal : AOptionBoolean
    {
        public OptionAllSubnetsAreLocal()
        {
        }

        public override byte Code
        {
            get
            {
                return 27;
            }
        }
    }
}