namespace DHCPNet.v4.Option
{
    /// <summary>
    /// MUD URL is a URL. 
    /// 
    /// Maximum length 255 bytes
    /// 
    /// draft-ietf-opsawg-mud
    /// https://datatracker.ietf.org/doc/draft-ietf-opsawg-mud/?include_text=1
    /// </summary>
    public class OptionManufacturerUsageDescriptionUrl : AOptionString
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 161;
            }
        }
    }
}