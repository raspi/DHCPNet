namespace DHCPNet.v4.Option
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class OptionSessionInitiationProtocolServerBase
    {
        /// <inheritdoc />
        public SessionInitiationProtocolServerEncoding Type { get; set; }

        public abstract byte[] GetRawBytes();
    }
}