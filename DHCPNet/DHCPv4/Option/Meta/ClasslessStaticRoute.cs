namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// Classless static route
    /// <see cref="OptionClasslessStaticRouteBase"/>
    /// <see cref="OptionClasslessStaticRoute"/>
    /// <see cref="OptionMicrosoftClasslessStaticRoute"/>
    /// </summary>
    public class ClasslessStaticRoute
    {
        /// <summary>
        /// CIDR Netmask 0-32
        /// </summary>
        protected byte _netmask;

        /// <summary>
        /// Gets or sets CIDR netmask
        /// </summary>
        public byte Netmask
        {
            get
            {
                return this._netmask;
            }

            set
            {
                if (value > 32)
                {
                    throw new Exception(string.Format("Invalid netmask: {0} Must be 0-32. ", value));
                }

                this._netmask = value;
            }
        }

        /// <summary>
        /// Gets or sets Destination IPv4 Address
        /// </summary>
        public IPv4Address Destination { get; set; }

        /// <summary>
        /// Gets or sets Gateway IPv4 Address
        /// </summary>
        public IPv4Address Gateway { get; set; }
    }
}