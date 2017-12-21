using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The NetBIOS node type option allows NetBIOS over TCP/IP clients which
    /// are configurable to be configured as described in RFC 1001/1002. 
    /// 
    /// The value is specified as a single octet which 
    /// identifies the client type as follows:
    /// 
    /// 0x1 B-node
    /// 0x2 P-node
    /// 0x4 M-node
    /// 0x8 H-node
    /// 
    /// Length 1 byte
    /// 
    /// https://tools.ietf.org/html/rfc1001
    /// https://tools.ietf.org/html/rfc1002
    /// </summary>
    public class OptionNetBIOSOverTCPIPNodeType : Option
    {
        public OptionNetBIOSOverTCPIPNodeType()
        {
        }

        public override byte Code
        {
            get
            {
                return 46;
            }
        }

        public ENetBIOSNodeType NodeType;

        public override byte[] GetRawBytes()
        {
            return new byte[] { (byte) NodeType};
        }

        public override void ReadRaw(byte[] raw)
        {
            NodeType = (ENetBIOSNodeType)raw[0];
        }
    }
}

