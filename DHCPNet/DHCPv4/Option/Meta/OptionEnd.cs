namespace DHCPNet.v4.Option
{
    /// <summary>
    /// End 0xFF, metadata
    /// </summary>
    public class OptionEnd : AOptionMetaData
    {
        public override byte Code
        {
            get
            {
                return 255;
            }
        }

        public OptionEnd()
        {
        }

    }
}