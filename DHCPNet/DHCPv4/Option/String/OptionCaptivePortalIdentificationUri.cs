namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The contact URI for the captive portal that the user 
    /// should connect to (encoded following the rules in [RFC3986]).
    /// 
    /// https://tools.ietf.org/html/rfc7710#section-2.1
    /// </summary>
    public class OptionCaptivePortalIdentificationUri : AOptionString
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 160;
            }
        }
    }
}