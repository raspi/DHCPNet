namespace DHCPNet.v4.Option
{
    using System;

    /// <summary>
    /// Newer high-speed public Internet access technologies call for a
    /// high-speed modem to have a local area network(LAN) attachment to one
    /// or more customer premise hosts.It is advantageous to use the
    /// Dynamic Host Configuration Protocol (DHCP) as defined in RFC 2131 to
    /// assign customer premise host IP addresses in this environment.
    /// However, a number of security and scaling problems arise with such
    /// "public" DHCP use.  This document describes a new DHCP option to
    /// address these issues.This option extends the set of DHCP options as
    /// defined in RFC 2132.
    /// 
    /// The new option is called the Relay Agent Information option and is
    /// inserted by the DHCP relay agent when forwarding client-originated
    /// DHCP packets to a DHCP server.Servers recognizing the Relay Agent
    /// Information option may use the information to implement IP address or
    /// other parameter assignment policies.The DHCP Server echoes the
    /// option back verbatim to the relay agent in server-to-client replies,
    /// and the relay agent strips the option before forwarding the reply to
    /// the client.
    /// 
    /// The "Relay Agent Information" option is organized as a single DHCP
    /// option that contains one or more "sub-options" that convey
    /// information known by the relay agent.  The initial sub-options are
    /// defined for a relay agent that is co-located in a public circuit
    /// access unit.These include a "circuit ID" for the incoming circuit,
    /// and a "remote ID" which provides a trusted identifier for the remote
    /// high-speed modem.
    /// https://tools.ietf.org/html/rfc3046
    /// </summary>
    public class OptionRelayAgentCircuitInformation : Option {

        public override void ReadRaw(byte[] raw)
        {
            throw new NotImplementedException();
        }

        public override byte Code
        {
            get
            {
                return 82;
            }
        }

        public override byte[] GetRawBytes()
        {
            throw new NotImplementedException();
        }
    }
}