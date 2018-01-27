using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

using DHCPNet.v4.Option;

namespace DHCPNet
{

    /// <summary>
    /// Generate DHCP Packet
    /// </summary>
    public static class DHCPPacketFactory
    {
        /// <summary>
        /// Packet's minimum size
        /// </summary>
        private const ushort PacketMinimumLength = 265;

        /// <summary>
        /// Packet's maximum size
        /// </summary>
        private const ushort PacketMaxLength = 576;

        /// <summary>
        /// Throw exceptions when parsing?
        /// </summary>
        public static bool ThrowExceptionOnParse = true;

        /// <summary>
        /// Read DHCP packet to object
        /// </summary>
        public static DHCPPacketBase Read(NetworkBinaryReader reader)
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            if (reader.BaseStream.Length < PacketMinimumLength)
            {
                throw new DHCPException(string.Format("Packet too small: {0} bytes", reader.BaseStream.Length));
            }

            if (reader.BaseStream.Length > PacketMaxLength)
            {
                throw new DHCPException(string.Format("Packet too large: {0} bytes", reader.BaseStream.Length));
            }

            DHCPPacketBase p;

            using (reader)
            {
                Debug.WriteLine("");
                Debug.WriteLine("--- Reading DHCP packet");
                Debug.WriteLine("");

                Debug.WriteLine(string.Format("Reading op code at offset {0:D4}", reader.BaseStream.Position));
                EOpCode PacketType = (EOpCode)(byte)reader.ReadByte(); // 1

                switch (PacketType)
                {
                    case EOpCode.BootReply:
                        p = new DHCPPacketBootReply();
                        break;
                    case EOpCode.BootRequest:
                        p = new DHCPPacketBootRequest();
                        break;
                    default:
                        throw new DHCPException("Unknown OpCode.");
                }

                Debug.WriteLine(string.Format("Reading hardware address type at offset {0:D4}", reader.BaseStream.Position));
                p.HardwareAddressType = (EHardwareType)(byte)reader.ReadByte(); // 1 (2)

                Debug.WriteLine(string.Format("Reading hardware address length at offset {0:D4}", reader.BaseStream.Position));
                byte _hwaddrlen = (byte)reader.ReadByte(); // 1 (3)

                if (_hwaddrlen > 16)
                {
                    throw new DHCPException(String.Format("Malformed packet. Hardware address length was {0}.", _hwaddrlen));
                }

                Debug.WriteLine(string.Format("Reading hops at offset {0:D4}", reader.BaseStream.Position));
                p.Hops = (byte)reader.ReadByte(); // 1 (4)

                Debug.WriteLine(string.Format("Reading transaction ID at offset {0:D4}", reader.BaseStream.Position));
                p.TransactionID = reader.ReadUInt32(); // 4 (8)

                Debug.WriteLine(string.Format("Reading seconds at offset {0:D4}", reader.BaseStream.Position));
                p.Seconds = reader.ReadUInt16(); // 2 (10)

                Debug.WriteLine(string.Format("Reading flags at offset {0:D4}", reader.BaseStream.Position));
                p.Flags = reader.ReadUInt16(); // 2 (12)

                Debug.WriteLine(string.Format("Reading IPv4 addresses at offset {0:D4}", reader.BaseStream.Position));
                p.ClientAddress = new IPv4Address(reader.ReadBytes(4)); // 4 (16)
                p.YourAddress = new IPv4Address(reader.ReadBytes(4)); // 4 (20)
                p.ServerAddress = new IPv4Address(reader.ReadBytes(4)); // 4 (24)
                p.RelayAgentAddress = new IPv4Address(reader.ReadBytes(4)); // 4 (28)

                // 16 (44)
                byte[] _clienthwaddr = { };

                if (_hwaddrlen > 0)
                {
                    _clienthwaddr = reader.ReadBytes(_hwaddrlen);
                }

                // Discard rest
                reader.BaseStream.Seek(44, SeekOrigin.Begin);

                p.ServerHostName = string.Empty;

                Debug.WriteLine(string.Format("Reading server host name at offset {0:D4}", reader.BaseStream.Position));
                foreach (byte i in reader.ReadBytes(64)) // 64 (128)
                {
                    if (i == 0)
                    {
                        break;
                    }

                    p.ServerHostName = (char)i + p.ServerHostName;
                }

                reader.BaseStream.Seek(108, SeekOrigin.Begin);

                p.File = string.Empty;

                Debug.WriteLine(string.Format("Reading file name at offset {0:D4}", reader.BaseStream.Position));
                foreach (byte i in reader.ReadBytes(128)) // 128 (236)
                {
                    if (i == 0)
                    {
                        break;
                    }

                    p.File = (char)i + p.File;
                }

                if (_hwaddrlen == 0)
                {
                    p.ClientHardwareAddress = new HardwareAddress(new byte[] { });
                }
                else if (_hwaddrlen == 6)
                {
                    byte[] macaddr = new byte[6];
                    Array.Copy(_clienthwaddr, 0, macaddr, 0, 6);
                    p.ClientHardwareAddress = new HardwareAddress(new MacAddress(macaddr));
                }
                else
                {
                    p.ClientHardwareAddress = new HardwareAddress(_clienthwaddr);
                }

                if (reader.BaseStream.Position != 236)
                {
                    throw new DHCPException(
                        string.Format("Packet position should be at 236 bytes but it is {0}.", reader.BaseStream.Position));
                }

                bool validCookie = true;

                if (reader.ReadByte() != 99)
                {
                    validCookie = false;
                }

                if (reader.ReadByte() != 130)
                {
                    validCookie = false;
                }

                if (reader.ReadByte() != 83)
                {
                    validCookie = false;
                }

                if (reader.ReadByte() != 99)
                {
                    validCookie = false;
                }

                if (!validCookie)
                {
                    throw new DHCPException(String.Format("Malformed packet: Magic cookie not found."));
                }

                if (reader.BaseStream.Position != 240)
                {
                    throw new DHCPException(
                        string.Format("Packet position should be at 240 bytes but it is {0}.", reader.BaseStream.Position));
                }

                // Options
                p.Options = ReadOptions(reader);
            }

            return p;
        }

        /// <summary>
        /// Read DHCP packet to object
        /// </summary>
        public static DHCPPacketBase Read(byte[] raw)
        {
            NetworkBinaryReader reader = new NetworkBinaryReader(new MemoryStream(raw, 0, raw.Length));
            return Read(reader);
        }

        /// <summary>
        /// Read DHCP packet options to objects
        /// </summary>
        public static List<Option> ReadOptions(NetworkBinaryReader reader)
        {
            List<Option> options = new List<Option>();

            using (reader)
            {

                Debug.WriteLine("");
                Debug.WriteLine("--- Reading DHCP options");
                Debug.WriteLine("");

                try
                {
                    // Format:
                    // Code | Length | Data 
                    // byte | byte   | n bytes (determined by length)
                    // Except metadata code (0 and 255) is only 1 byte
                    do
                    {
                        // Get code
                        byte code = reader.ReadByte();
                        Option o = OptionFactory.GetOption(code);

                        if (code != o.Code)
                        {
                            throw new OptionException(string.Format("Invalid option code: '{0}' class: '{1}'.", code, o.GetType()));
                        }

                        if (!(o is AOptionMetaData))
                        {
                            // Get length of data
                            byte len = reader.ReadByte();

                            // Buffer for data
                            byte[] data = reader.ReadBytes(len);

                            if (data.Length != len)
                            {
                                throw new IndexOutOfRangeException();
                            }

                            try
                            {
                                o.ReadRaw(data);
                            }
                            catch (OptionException e)
                            {
                                Debug.WriteLine(e);
                                if (ThrowExceptionOnParse)
                                {
                                    throw;
                                }
                            }

                        }

                        options.Add(o);
                    }
                    while (reader.BaseStream.Position < reader.BaseStream.Length);
                }
                catch (EndOfStreamException e)
                {
                    if (ThrowExceptionOnParse)
                    {
                        string err = string.Format(
                            "Error reading: position: {0} len: {1}. Options read: {2}",
                            reader.BaseStream.Position,
                            reader.BaseStream.Length,
                            options.Count
                        );

                        throw new OptionException(err, e);
                    }
                }


            }

            return options;
        }

        /// <summary>
        /// Read DHCP packet options to objects
        /// </summary>
        public static List<Option> ReadOptions(byte[] raw)
        {
            NetworkBinaryReader reader = new NetworkBinaryReader(new MemoryStream(raw, 0, raw.Length));
            return ReadOptions(reader);
        }

    }
}