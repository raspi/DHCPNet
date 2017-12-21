using DHCPNet.v4.Option;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

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

        private const ushort PacketMinimumLength = 312;
        private const ushort PacketMaxLength = 576;

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
        /// n bytes
        /// DHCP Magic cookie before options
        /// </summary>
        public readonly byte[] MagicCookie = { 99, 130, 83, 99 };

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
            BinaryWriter writer = new BinaryWriter(new MemoryStream());

            writer.Write((byte)OpCode); // 1
            writer.Write((byte)HardwareAddressType); // 1
            writer.Write(HardwareAddressLength); // 1
            writer.Write(Hops); // 1
            writer.Write(TransactionID); // 4
            writer.Write(Seconds); // 2
            writer.Write(Flags); // 2
            writer.Write(ClientAddress.Address); // 4
            writer.Write(YourAddress.Address); // 4
            writer.Write(ServerAddress.Address); // 4
            writer.Write(RelayAgentAddress.Address); // 4
            writer.Write(ClientHardwareAddress.Address); // 16
            writer.Write(Option.StringToBytes(ServerHostName, 64)); // 64
            writer.Write(Option.StringToBytes(File, 128)); // 128
            writer.Write(MagicCookie);

            // Read options
            writer.Write(GetRawOptionsBytes());

            if (writer.BaseStream.Length > PacketMaxLength)
            {
                throw new DHCPException(String.Format("Packet is too large ({0} / {1} bytes)", writer.BaseStream.Length, PacketMaxLength));
            }

            // Add padding
            while (writer.BaseStream.Length < PacketMinimumLength)
            {
                writer.Write((byte)0);
            }

            writer.Seek(0, SeekOrigin.Begin);
            byte[] rawbytes = new byte[writer.BaseStream.Length];
            writer.BaseStream.Read(rawbytes, 0, (int)writer.BaseStream.Length);

            return rawbytes;

        }

        public byte[] GetRawOptionsBytes()
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());

            // Find End
            bool endFound = false;
            foreach (Option i in Options)
            {
                if (i.Code == (byte)EOption.End)
                {
                    endFound = true;
                    break;
                }
            }

            if (!endFound)
            {
                throw new DHCPException(String.Format("End option was not found"));
            }

            foreach (Option i in Options)
            {
                byte[] data = i.GetRawBytes();

                if (i is AOptionMetaData)
                {
                    writer.Write(data, 0, 1);
                }
                else
                {
                    writer.Write(i.Code);
                    writer.Write(data.Length);
                    writer.Write(data, 0, data.Length);
                }
            }

            writer.Seek(0, SeekOrigin.Begin);
            byte[] rawbytes = new byte[writer.BaseStream.Length];
            writer.BaseStream.Read(rawbytes, 0, (int)writer.BaseStream.Length);

            return rawbytes;
        }

        /// <summary>
        /// Read DHCP packet to object
        /// </summary>
        public void Read(BinaryReader reader)
        {
            if (reader.BaseStream.Length < PacketMinimumLength)
            {
                throw new DHCPException(String.Format("Packet too small: {0} bytes", reader.BaseStream.Length));
            }

            if (reader.BaseStream.Length > PacketMaxLength)
            {
                throw new DHCPException(String.Format("Packet too large: {0} bytes", reader.BaseStream.Length));
            }

            OpCode = (EOpCode)reader.ReadByte();
            HardwareAddressType = (EHardwareType)reader.ReadByte();
            Hops = reader.ReadByte();

            byte _hwaddrlen = reader.ReadByte();

            TransactionID = BitConverter.ToUInt32(reader.ReadBytes(4), 0);
            Seconds = BitConverter.ToUInt16(reader.ReadBytes(2), 0);
            Flags = BitConverter.ToUInt16(reader.ReadBytes(2), 0);
            ClientAddress = new IPv4Address(reader.ReadBytes(4));
            YourAddress = new IPv4Address(reader.ReadBytes(4));
            ServerAddress = new IPv4Address(reader.ReadBytes(4));
            RelayAgentAddress = new IPv4Address(reader.ReadBytes(4));

            byte[] _clienthwaddr = reader.ReadBytes(16);

            ServerHostName = Option.BytesToString(reader.ReadBytes(64));
            File = Option.BytesToString(reader.ReadBytes(128));

            if (_hwaddrlen == 0)
            {
                ClientHardwareAddress = new HardwareAddress(new byte[] { });
            }
            else if (_hwaddrlen == 6)
            {
                byte[] macaddr = new byte[6];
                Array.Copy(_clienthwaddr, 0, macaddr, 0, 6);
                ClientHardwareAddress = new HardwareAddress(new MacAddress(macaddr));
            }
            else
            {
                ClientHardwareAddress = new HardwareAddress(_clienthwaddr);
            }

            // Magic cookie
            byte[] cookie = reader.ReadBytes(4);

            if (!(
                cookie[0] == MagicCookie[0]
                && cookie[1] == MagicCookie[1]
                && cookie[2] == MagicCookie[2]
                && cookie[3] == MagicCookie[3]
                )
            )
            {
                throw new DHCPException("Malformed packet: Magic cookie not found.");
            }

            ReadOptions(reader);
        }

        /// <summary>
        /// Read DHCP packet to object
        /// </summary>
        public DHCPPacket(byte[] raw)
        {
            BinaryReader reader = new BinaryReader(new MemoryStream(raw, 0, raw.Length));
            Read(reader);
        }

        /// <summary>
        /// Read DHCP packet options to objects
        /// </summary>
        public bool ReadOptions(BinaryReader reader)
        {
            do
            {
                Option o = OptionFactory.GetOption(reader.ReadByte());

                if (!(o is AOptionMetaData))
                {
                    byte len = reader.ReadByte();
                    byte[] data = reader.ReadBytes(len);
                    o.ReadRaw(data);
                }

                // Add to this object
                Options.Add(o);
            } while (reader.BaseStream.CanRead);

            return true;

        }

        /// <summary>
        /// Read DHCP packet options to objects
        /// </summary>
        public void ReadOptions(byte[] raw)
        {
            BinaryReader reader = new BinaryReader(new MemoryStream(raw, 0, raw.Length));
            ReadOptions(reader);
        }

        public DHCPPacket()
        {
        }
    }
}
