namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The Classless Static Route
    /// https://tools.ietf.org/html/rfc3442
    /// <see cref="OptionClasslessStaticRouteBase"/>
    /// <see cref="OptionMicrosoftClasslessStaticRoute"/>
    /// <see cref="ClasslessStaticRoute"/>
    /// </summary>
    public class OptionClasslessStaticRoute : OptionClasslessStaticRouteBase
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 121;
            }
        }

    }
}