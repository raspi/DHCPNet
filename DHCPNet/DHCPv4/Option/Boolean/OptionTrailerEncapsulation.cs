using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies whether or not the client should negotiate the
    /// use of trailers (RFC 893) when using the ARP protocol.
    /// 
    /// 0 indicates that the client should not attempt to use trailers.
    /// 1 means that the client should attempt to use trailers.
    /// 
    /// Length 1 byte.
    /// </summary>
    public class OptionTrailerEncapsulation : AOptionBoolean
    {

        public override byte Code
        {
            get
            {
                return 34;
            }
        }
    }
}

