namespace DHCPNet.v4.Option
{
/// <summary>
/// The log server option specifies a list of
/// MIT-LCS UDP log servers available to the client.
/// Servers SHOULD be listed in order of preference.
/// </summary>
class OptionLogServer : AOptionIPAddresses
{
    public override byte Code {
        get {
            return 7;
        }
    }
}


}