namespace DHCPNet.v4.Option
{
    /// <summary>
    /// The Impress server option specifies a list of
    /// Imagen Impress servers available to the client.
    /// Servers SHOULD be listed in order of preference.
    /// </summary>
    public class OptionImpressServer : AOptionIPAddresses
    {
        public OptionImpressServer()
        {
        }

        public override byte Code
        {
            get
            {
                return 10;
            }
        }
    }
}