namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Padding 0x00, metadata
    /// </summary>
    public class OptionPad : AOptionMetaData
    {
        public OptionPad()
        {
        }

        public override byte Code
        {
            get
            {
                return 0;
            }
        }
    }
}