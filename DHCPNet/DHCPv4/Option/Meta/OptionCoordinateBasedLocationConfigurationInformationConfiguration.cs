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
    /// </summary>
    public class OptionCoordinateBasedLocationConfigurationInformationConfiguration : Option
    {
        public override byte Code
        {
            get
            {
                return 123;
            }
        }

        public override void ReadRaw(byte[] raw)
        {
            throw new System.NotImplementedException();
        }

        public override byte[] GetRawBytes()
        {
            throw new System.NotImplementedException();
        }
    }
}