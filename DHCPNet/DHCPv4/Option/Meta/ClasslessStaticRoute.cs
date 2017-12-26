namespace DHCPNet.v4.Option
{
    public class ClasslessStaticRoute
    {
        public byte Netmask { get; set; }
        public IPv4Address Destination { get; set; }
        public IPv4Address Gateway { get; set; }
    }
}