namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The Location-to-Service Translation (LoST) Protocol describes an XML-
    /// based protocol for mapping service identifiers and geospatial or
    /// civic location information to service contact Uniform Resource
    /// Locators (URLs).  LoST servers can be located anywhere, but a
    /// placement closer to the end host, e.g., in the access network, is
    /// desirable. In disaster situations with intermittent network
    /// connectivity, such a LoST server placement provides benefits
    /// regarding the resiliency of emergency service communication.
    /// 
    /// Server is fully-qualified domain name (FQDN).
    /// 
    /// https://tools.ietf.org/html/rfc5223
    /// </summary>
    public class OptionLocationToServiceTranslationServerLocation : AOptionString
    {
        public override byte Code
        {
            get
            {
                return 137;
            }
        }
    }
}