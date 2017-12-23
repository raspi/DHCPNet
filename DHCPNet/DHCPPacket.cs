using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Diagnostics;

using DHCPNet.v4.Option;

namespace DHCPNet
{

    /// <summary>
    /// Dynamic Host Configuration Protocol (DHCP)
    /// rfc2131
    /// 
    /// https://tools.ietf.org/html/rfc2131
    /// https://tools.ietf.org/html/rfc2132
    /// </summary>
    public class DHCPPacket
    {
        private const ushort PacketMinimumLength = 265;

        private const ushort PacketMaxLength = 576;

        public bool ThrowExceptionOnParse = true;

        /// <summary>
        /// op 1 byte
        /// Message op code / message type.
        /// 1 = BootRequest, 2 = BootReply
        /// </summary>
        public EOpCode OpCode { get; set; }

        /// <summary>
        /// htype 1 byte, rfc1060 page 46
        /// See ARP section in "Assigned Numbers" RFC; e.g., 
        /// 1 = 10mb ethernet.
        /// </summary>
        public EHardwareType HardwareAddressType { get; set; }

        /// <summary>
        /// hlen 1 byte
        /// (e.g.  '6' for 10mb ethernet).
        /// mac = 00:11:22:33:44:55 = 6
        /// Set via ClientHardwareAddress
        /// <see cref="ClientHardwareAddress"/>
        /// </summary>
        public byte HardwareAddressLength
        {
            get
            {
                return (byte)this.ClientHardwareAddress.Length;
            }
        }

        /// <summary>
        /// hops 1 byte
        /// Client sets to zero, optionally used by relay agents
        /// </summary>
        public byte Hops { get; set; }

        /// <summary>
        /// xid 4 bytes
        /// Transaction ID, a random number chosen by the client, 
        /// used by the client and server to associate messages 
        /// and responses between a client and a server.
        /// </summary>
        public uint TransactionID { get; set; }

        /// <summary>
        /// secs 2 bytes
        /// Filled in by client, seconds elapsed since client 
        /// began address acquisition or renewal process.
        /// </summary>
        public ushort Seconds { get; set; }

        /// <summary>
        /// flags 2 bytes
        /// 
        ///                     1 1 1 1 1 1
        /// 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5
        /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        /// |B|             MBZ             |
        /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        ///
        /// B:  BROADCAST flag
        /// MBZ:  MUST BE ZERO(reserved for future use)        
        /// </summary>
        public ushort Flags { get; set; }

        /// <summary>
        /// ciaddr 4 bytes
        /// Client IP address; only filled in if client is in
        /// BOUND, RENEW or REBINDING state and can respond
        /// to ARP requests.
        /// </summary>
        public IPv4Address ClientAddress { get; set; }

        /// <summary>
        /// yiaddr 4 bytes
        /// 'your' (client) IP address.
        /// </summary>
        public IPv4Address YourAddress { get; set; }

        /// <summary>
        /// siaddr 4 bytes
        /// IP address of next server to use in bootstrap;
        /// returned in DHCPOFFER, DHCPACK by server.
        /// </summary>
        public IPv4Address ServerAddress { get; set; }

        /// <summary>
        /// giaddr 4 bytes
        /// Relay agent IP address, used in booting via a
        /// relay agent.
        /// </summary>
        public IPv4Address RelayAgentAddress { get; set; }

        /// <summary>
        /// chaddr 16 bytes
        /// Client hardware address.
        /// </summary>
        public HardwareAddress ClientHardwareAddress { get; set; }

        /// <summary>
        /// sname 64 bytes
        /// Optional server host name, null terminated string.
        /// </summary>
        public string ServerHostName { get; set; }

        /// <summary>
        /// file 128 bytes
        /// Boot file name, null terminated string; "generic"
        /// name or null in DHCPDISCOVER, fully qualified
        /// directory-path name in DHCPOFFER.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// DHCP Options and BOOTP Vendor Extensions
        /// https://tools.ietf.org/html/rfc2132
        /// </summary>
        public List<Option> Options = new List<Option>();

        /// <summary>
        /// Get raw bytes of the packet
        /// </summary>
        /// <returns></returns>
        public byte[] GetRawBytes()
        {
            NetworkBinaryWriter writer = new NetworkBinaryWriter(new MemoryStream());

            writer.Write((byte)this.OpCode); // 1
            writer.Write((byte)this.HardwareAddressType); // 1 (2)
            writer.Write(this.HardwareAddressLength); // 1 (3)
            writer.Write(this.Hops); // 1 (4)
            writer.Write(BitConverter.GetBytes(this.TransactionID)); // 4 (8)
            writer.Write(BitConverter.GetBytes(this.Seconds)); // 2 (10)
            writer.Write(BitConverter.GetBytes(this.Flags)); // 2 (12)

            // IPv4 addresses
            writer.Write(this.ClientAddress.Address, 0, 4); // 4 (16)
            writer.Write(this.YourAddress.Address, 0, 4); // 4 (20)
            writer.Write(this.ServerAddress.Address, 0, 4); // 4 (24)
            writer.Write(this.RelayAgentAddress.Address, 0, 4); // 4 (28)

            writer.Write(this.ClientHardwareAddress.Address, 0, 16); // 16 (44)
            writer.Write(Option.StringToBytes(this.ServerHostName, 64)); // 64 (108)
            writer.Write(Option.StringToBytes(this.File, 128)); // 128 (236)

            // Magic cookie
            writer.Write((byte)99);
            writer.Write((byte)130);
            writer.Write((byte)83);
            writer.Write((byte)99);

            if (writer.BaseStream.Length != 240)
            {
                throw new DHCPException(
                    string.Format("Packet size should be 240 bytes but it is {0} bytes.", writer.BaseStream.Length));
            }

            // Read options
            byte[] options = this.GetRawOptionsBytes();
            writer.Write(options, 0, options.Length);

            if (writer.BaseStream.Length > PacketMaxLength)
            {
                throw new DHCPException(
                    string.Format("Packet is too large ({0} / {1} bytes)", writer.BaseStream.Length, PacketMaxLength));
            }

            // Add padding
            while (writer.BaseStream.Length < PacketMinimumLength)
            {
                Debug.WriteLine("Adding padding..");
                writer.Write((byte)0);
            }

            writer.Seek(0, SeekOrigin.Begin);
            byte[] rawbytes = new byte[writer.BaseStream.Length];
            writer.BaseStream.Read(rawbytes, 0, (int)writer.BaseStream.Length);

            return rawbytes;
        }

        public byte[] GetRawOptionsBytes()
        {
            NetworkBinaryWriter writer = new NetworkBinaryWriter(new MemoryStream());

            if (this.Options.Count == 0)
            {
                throw new DHCPException(string.Format("No options."));
            }

            // Find End
            bool endFound = false;
            foreach (Option i in this.Options)
            {
                if (i.Code == (byte)EOption.End)
                {
                    endFound = true;
                    break;
                }
            }

            if (!endFound)
            {
                if (this.ThrowExceptionOnParse)
                {
                    throw new DHCPException(string.Format("End option was not found"));
                }
            }

            foreach (Option i in this.Options)
            {
                Debug.WriteLine(String.Format("Adding: {0} (0x{0:x2}) {1}", i.Code, i.GetType()));
                writer.Write(new byte[] { i.Code }, 0, 1);

                if (!(i is AOptionMetaData))
                {
                    byte[] data = i.GetRawBytes();
                    Debug.WriteLine(String.Format("Length: {0} ", (byte)data.Length));
                    writer.Write(new byte[] { (byte)data.Length }, 0, 1);
                    writer.Write(data, 0, data.Length);
                }
            }

            writer.Seek(0, SeekOrigin.Begin);
            byte[] rawbytes = new byte[writer.BaseStream.Length];
            writer.BaseStream.Read(rawbytes, 0, (int)writer.BaseStream.Length);

            return rawbytes;
        }

        public DHCPPacket()
        {
        }
    }
}