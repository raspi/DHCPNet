using System;

namespace DHCPNet.v4.Option
{
/// <summary>
/// This option specifies the default time-to-live that
/// the client should use on outgoing datagrams. The TTL
/// is specified as an octet with a value between 1 and 255.
///
/// Length 1 byte
/// </summary>
public class OptionDefaultIPTimeToLive : AOptionUint8
{
    public override byte Code {
        get {
            return 23;
        }
    }
}

}

