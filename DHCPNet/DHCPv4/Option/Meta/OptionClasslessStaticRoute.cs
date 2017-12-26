namespace DHCPNet.v4.Option
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// https://tools.ietf.org/html/rfc3442
    /// </summary>
    public class OptionClasslessStaticRoute : Option
    {
        public List<ClasslessStaticRoute> Routes { get; set; }

        public override byte Code
        {
            get
            {
                return 121;
            }
        }

        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length < 5)
            {
                throw new OptionException("Length less than 5 bytes");
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

                Routes.Add(
                    new ClasslessStaticRoute()
                        {
                            Netmask = mask_width,
                            Destination = destination,
                            Gateway = gw,
                        });
            }
            while (i < raw.Length);
        }


        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }
    }
}