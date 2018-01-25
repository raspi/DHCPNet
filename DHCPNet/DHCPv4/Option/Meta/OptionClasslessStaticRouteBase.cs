namespace DHCPNet.v4.Option
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Classless Static Route
    /// <see cref="ClasslessStaticRoute"/>
    /// <see cref="OptionClasslessStaticRouteBase"/>
    /// <see cref="OptionMicrosoftClasslessStaticRoute"/>
    /// https://tools.ietf.org/html/rfc3442
    /// </summary>
    public abstract class OptionClasslessStaticRouteBase : Option
    {
        /// <inheritdoc />
        public List<ClasslessStaticRoute> Routes { get; set; }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            if (raw.Length < 5)
            {
                throw new OptionLengthException("Length less than 5 bytes.");
            }


            int i = 0;
            do
            {
                byte mask_width = raw[i];

                if (mask_width > 32)
                {
                    throw new OptionException("Netmask > 32");
                }

                i++;

                byte significant_bytes = 0;

                if (mask_width > 1)
                {
                    significant_bytes = 1;
                }
                else if (mask_width > 9)
                {
                    significant_bytes = 2;
                }
                else if (mask_width > 17)
                {
                    significant_bytes = 3;
                }
                else
                {
                    significant_bytes = 4;
                }

                byte[] tmp = new byte[4] { 0, 0, 0, 0 };

                for (int j = 0; j < significant_bytes; j++)
                {
                    tmp[j] = raw[i];
                    i++;
                }

                IPv4Address destination = new IPv4Address(tmp);

                tmp = new byte[4] { 0, 0, 0, 0 };

                for (int j = 0; j < 4; j++)
                {
                    tmp[j] = raw[i];
                    i++;
                }

                IPv4Address gw = new IPv4Address(tmp);

                this.Routes.Add(
                    new ClasslessStaticRoute()
                        {
                            Netmask = mask_width,
                            Destination = destination,
                            Gateway = gw,
                        });
            }
            while (i < raw.Length);
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            string tmp = string.Empty;

            foreach (var route in Routes)
            {
                

            }

            return tmp;
        }
    }
}