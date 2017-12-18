namespace DHCPNet
{
    /// <summary>
    /// Offsets for fields
    /// </summary>
    public enum EOffset
    {
        op = 0,
        htype = 1,
        hlen = 2,
        hops = 3,
        xid = 7,
        secs = 9,
        flags = 11,
        ciaddr = 15,
        yiaddr = 19,
        siaddr = 23,
        giaddr = 27,
        chaddr = 43,
        sname = 107,
        file = 235,
        cookie = 239,
        options,
    }


}
