namespace DHCPNet.v4.Option
{
    /// <summary>
    /// DHCPv4 Option Code 249 (0xF9) - Microsoft Classless Static Route Option
    /// The length and the data format for the Microsoft Classless Static Route Option
    /// are exactly the same as those specified for the Classless Static Route Option
    /// in [RFC3442]; the only difference is that Option Code 249 SHOULD be used
    /// instead of or in addition to Option Code 121.
    /// </summary>
    public class OptionMicrosoftClasslessStaticRoute : OptionClasslessStaticRoute
    {
        public override byte Code
        {
            get
            {
                return 249;
            }
        }

    }
}