namespace DHCPNet
{
    /// <summary>
    /// op 1 byte
    /// Message op code / message type.
    /// 1 = BootRequest, 2 = BootReply
    /// </summary>
    public class DHCPPacketBootRequest : DHCPPacketBase
    {
        public DHCPPacketBootRequest()
        {

        }
    }
}