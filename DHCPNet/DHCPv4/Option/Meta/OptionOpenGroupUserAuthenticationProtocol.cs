namespace DHCPNet.v4.Option
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The Open Group's User Authentication Protocol
    /// https://tools.ietf.org/html/rfc2485
    /// </summary>
    public class OptionOpenGroupUserAuthenticationProtocol : Option
    {
        /// <inheritdoc />
        public List<string> Urls { get; set; }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 98;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            string tmp = Encoding.UTF8.GetString(raw, 0, raw.Length);

            foreach (string url in tmp.Split(' '))
            {
                Urls.Add(url);
            }
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}