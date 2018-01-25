namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The Location Configuration Information (LCI) includes
    /// Latitude, Longitude, and Altitude, with resolution or uncertainty
    /// indicators for each.Separate parameters indicate the reference
    /// datum for each of these values. 
    /// 
    /// Deprecates RFC 3825.
    /// 
    /// https://tools.ietf.org/html/rfc6225
    /// Old: https://tools.ietf.org/html/rfc3825
    /// </summary>
    public class OptionCoordinateBasedLocationConfigurationInformationConfiguration : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 123;
            }
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}