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
    /// Base class
    /// Dynamic Host Configuration Protocol (DHCP)
    /// rfc2131
    /// 
    /// <see cref="DHCPPacketBootRequest"/>
    /// <see cref="DHCPPacketBootReply"/>
    /// 
    /// https://tools.ietf.org/html/rfc2131
    /// https://tools.ietf.org/html/rfc2132
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class DHCPPacketBase
    {
        /// <summary>
        /// Gets Debug string
        /// </summary>
        private string DebuggerDisplay
        {
            get
            {
                List<string> str = new List<string>
                                       {
                                           string.Format("{0}", this.GetType()),
                                           string.Format("htype:{0}", this.HardwareAddressType),
                                           string.Format("hops:{0:x2} ({0:D})", this.Hops),
                                           string.Format("xid:{0:x8} ({0:D})", this.TransactionID),
                                           string.Format("secs:{0:x4} ({0:D})", this.Seconds),
                                           string.Format("flags:{0:x4} ({0:D})", this.Flags),
                                           string.Format("ciaddr:{0}", this.ClientAddress),
                                           string.Format("yiaddr:{0}", this.YourAddress),
                                           string.Format("siaddr:{0}", this.ServerAddress),
                                           string.Format("giaddr:{0}", this.RelayAgentAddress),
                                           string.Format("chaddr:{0}", this.ClientHardwareAddress),
                                           string.Format("sname:'{0}'", this.ServerHostName),
                                           string.Format("file:'{0}'", this.File)
                                       };

                return string.Join(", ", str);
            }
        }

        private const ushort PacketMinimumLength = 265;

        private const ushort PacketMaxLength = 576;

        public bool ThrowExceptionOnParse = true;

        /// <summary>
        /// Gets or sets hardware address type.
        /// htype 1 byte, rfc1060 page 46
        /// See ARP section in "Assigned Numbers" RFC; e.g., 
        /// 1 = 10mb ethernet.
        /// </summary>
        public EHardwareType HardwareAddressType { get; set; }

        /// <summary>
        /// Gets hardware address length.
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
        /// optional server host name
        /// <see cref="ServerHostName"/>
        /// </summary>
        private byte[] _serverHostname = new byte[64];

        /// <summary>
        /// Gets or sets optional server host name, null terminated string.
        /// sname 64 bytes
        /// </summary>
        public byte[] ServerHostName
        {
            get
            {
                return this._serverHostname;
            }

            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentNullException();
                }

                if (value.Length > 64)
                {
                    throw new ArgumentOutOfRangeException();
                }

                Array.Copy(value, 0, this._serverHostname, 0, value.Length);
            }
        }

        /// <summary>
        /// file 128 bytes
        /// <see cref="File"/>
        /// </summary>
        private byte[] _fileName = new byte[128];

        /// <summary>
        /// file 128 bytes
        /// Boot file name, null terminated string; "generic"
        /// name or null in DHCPDISCOVER, fully qualified
        /// directory-path name in DHCPOFFER.
        /// </summary>
        public byte[] File
        {
            get
            {
                return this._fileName;
            }

            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentNullException();
                }

                if (value.Length > 128)
                {
                    throw new ArgumentOutOfRangeException();
                }

                Array.Copy(value, 0, this._fileName, 0, value.Length);
            }

        }

        /// <summary>
        /// Get or set DHCP Options and BOOTP Vendor Extensions
        /// https://www.iana.org/assignments/bootp-dhcp-parameters/bootp-dhcp-parameters.xhtml
        /// https://tools.ietf.org/html/rfc2132
        /// </summary>
        public List<Option> Options { get; set; }

        /// <summary>
        /// Get raw bytes of the packet
        /// </summary>
        public byte[] GetRawBytes()
        {
            NetworkBinaryWriter writer = new NetworkBinaryWriter(new MemoryStream());

            Debug.WriteLine("");
            Debug.WriteLine("--- Writing DHCP packet");
            Debug.WriteLine("");

            if (this is DHCPPacketBootRequest)
            {
                Debug.WriteLine(string.Format("Type boot request at offset {0:D4}", writer.BaseStream.Position));
                writer.Write((byte)EOpCode.BootRequest); // 1
            }
            else if (this is DHCPPacketBootReply)
            {
                Debug.WriteLine(string.Format("Type boot reply at offset {0:D4}", writer.BaseStream.Position));
                writer.Write((byte)EOpCode.BootReply); // 1
            }
            else
            {
                throw new DHCPException(string.Format("Invalid type: {0}", this.GetType()));
            }

            Debug.WriteLine(string.Format("Writing hardware address type at offset {0:D4}", writer.BaseStream.Position));
            writer.Write((byte)this.HardwareAddressType); // 1 (2)

            Debug.WriteLine(string.Format("Writing hardware address length at offset {0:D4}", writer.BaseStream.Position));
            writer.Write(this.HardwareAddressLength); // 1 (3)

            Debug.WriteLine(string.Format("Writing hop count at offset {0:D4}", writer.BaseStream.Position));
            writer.Write(this.Hops); // 1 (4)

            Debug.WriteLine(string.Format("Writing transaction ID at offset {0:D4}", writer.BaseStream.Position));
            writer.Write(this.TransactionID); // 4 (8)

            Debug.WriteLine(string.Format("Writing seconds at offset {0:D4}", writer.BaseStream.Position));
            writer.Write(this.Seconds); // 2 (10)

            Debug.WriteLine(string.Format("Writing flags at offset {0:D4}", writer.BaseStream.Position));
            writer.Write(this.Flags); // 2 (12)

            // IPv4 addresses
            Debug.WriteLine(string.Format("Writing IPv4 addresses at offset {0:D4}", writer.BaseStream.Position));
            writer.Write(this.ClientAddress.Address, 0, 4); // 4 (16)
            writer.Write(this.YourAddress.Address, 0, 4); // 4 (20)
            writer.Write(this.ServerAddress.Address, 0, 4); // 4 (24)
            writer.Write(this.RelayAgentAddress.Address, 0, 4); // 4 (28)

            Debug.WriteLine(string.Format("Writing client hardware address at offset {0:D4}", writer.BaseStream.Position));
            writer.Write(this.ClientHardwareAddress.Address, 0, 16); // 16 (44)

            //writer.Seek(44, SeekOrigin.Begin);

            Debug.WriteLine(string.Format("Writing server hostname at offset {0:D4}", writer.BaseStream.Position));
            writer.Write(this.ServerHostName, 0, 64); // 64 (108)

            //writer.Seek(108, SeekOrigin.Begin);

            Debug.WriteLine(string.Format("Writing file name at offset {0:D4}", writer.BaseStream.Position));
            writer.Write(this.File, 0, 128); // 128 (236)

            //writer.Seek(236, SeekOrigin.Begin);

            // Magic cookie
            Debug.WriteLine(string.Format("Writing magic cookie at offset {0:D4}", writer.BaseStream.Position));
            writer.Write((byte)99);
            writer.Write((byte)130);
            writer.Write((byte)83);
            writer.Write((byte)99);

            // Add DHCP options
            this.AddRawOptionsBytes(writer);

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

        /// <summary>
        /// Get raw bytes from DHCP options
        /// </summary>
        public void AddRawOptionsBytes(NetworkBinaryWriter writer)
        {
            if (writer.BaseStream.Length != 240)
            {
                throw new DHCPException(
                    string.Format("Packet size should be 240 bytes but it is {0} bytes.", writer.BaseStream.Length));
            }

            Debug.WriteLine("");
            Debug.WriteLine("--- Writing DHCP options");
            Debug.WriteLine("");

            if (this.Options.Count == 0)
            {
                throw new OptionException(string.Format("No options."));
            }

            // Find End
            bool endFound = false;
            foreach (Option i in this.Options)
            {
                if (i is OptionEnd)
                {
                    endFound = true;
                    break;
                }
            }

            if (!endFound)
            {
                if (this.ThrowExceptionOnParse)
                {
                    throw new OptionException(string.Format("End option was not found"));
                }
            }

            writer.Seek(240, SeekOrigin.Begin);

            foreach (Option i in this.Options)
            {
                Debug.WriteLine(string.Format("+{0} {1:D3} at offset {2:D4} (0x{2:x4})", i.GetType(), i.Code, writer.BaseStream.Position));
                writer.Write(new byte[] { i.Code }, 0, 1);

                if (i is AOptionMetaData)
                {
                    continue;
                }

                try
                {
                    byte[] data = i.GetRawBytes();

                    // Write to packet
                    Debug.WriteLine(string.Format("Writing option length byte: 0x{0:x2} ({0:D3})", data.Length));
                    writer.Write(new byte[] { (byte)data.Length }, 0, 1);

                    Debug.WriteLine(string.Format("Writing option data:"));
                    writer.Write(data, 0, data.Length);

                    Debug.WriteLine(String.Empty);

                    if (writer.BaseStream.Length > PacketMaxLength)
                    {
                        throw new DHCPException(
                            string.Format("Packet is too large ({0} / {1} bytes)", writer.BaseStream.Length, PacketMaxLength));
                    }

                }
                catch (OptionException e)
                {
                    Debug.WriteLine(e);

                    if (this.ThrowExceptionOnParse)
                    {
                        throw;
                    }
                } // catch
            } // foreach
        }

        /// <summary>
        /// 
        /// </summary>
        public DHCPPacketBase()
        {
        }

        /// <inheritdoc />
        public override string ToString()
        {
            List<string> str = new List<string>
                                   {
                                       string.Format("{0}", this.GetType()),
                                       string.Format("htype:{0}", this.HardwareAddressType),
                                       string.Format("hops:{0:x2} ({0:D})", this.Hops),
                                       string.Format("xid:{0:x8} ({0:D})", this.TransactionID),
                                       string.Format("secs:{0:x4} ({0:D})", this.Seconds),
                                       string.Format("flags:{0:x4} ({0:D})", this.Flags),
                                       string.Format("ciaddr:{0}", this.ClientAddress),
                                       string.Format("yiaddr:{0}", this.YourAddress),
                                       string.Format("siaddr:{0}", this.ServerAddress),
                                       string.Format("giaddr:{0}", this.RelayAgentAddress),
                                       string.Format("chaddr:{0}", this.ClientHardwareAddress),
                                       string.Format("sname:'{0}'", this.ServerHostName),
                                       string.Format("file:'{0}'", this.File)
                                   };


            return string.Join(", ", str);
        }
    }
}