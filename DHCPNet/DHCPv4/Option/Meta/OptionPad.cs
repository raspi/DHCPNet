namespace DHCPNet.v4.Option
{
    /// <summary>
    /// Padding 0x00, metadata
    /// </summary>
    public class OptionPad : AOptionMetaData
    {
        /// <inheritdoc />
        public OptionPad()
        {
        }

        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 0;
            }
        }
    }
}