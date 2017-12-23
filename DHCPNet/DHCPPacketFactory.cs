using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

using DHCPNet.v4.Option;

namespace DHCPNet
{

    public static class DHCPPacketFactory
    {
        private const ushort PacketMinimumLength = 265;
        private const ushort PacketMaxLength = 576;

        public static bool ThrowExceptionOnParse = true;


        /// <summary>
        /// Read DHCP packet to object
        /// </summary>
        public static DHCPPacket Read(NetworkBinaryReader reader)
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

            DHCPPacket p = new DHCPPacket();

            using (reader)
            {

                p.OpCode = (EOpCode)(byte)reader.ReadByte(); // 1
                p.HardwareAddressType = (EHardwareType)(byte)reader.ReadByte(); // 1 (2)

                byte _hwaddrlen = (byte)reader.ReadByte(); // 1 (3)

                p.Hops = (byte)reader.ReadByte(); // 1 (4)
                p.TransactionID = reader.ReadUInt32(); // 4 (8)
                p.Seconds = reader.ReadUInt16(); // 2 (10)
                p.Flags = reader.ReadUInt16(); // 2 (12)
                p.ClientAddress = new IPv4Address(reader.ReadUInt32()); // 4 (16)
                p.YourAddress = new IPv4Address(reader.ReadUInt32()); // 4 (20)
                p.ServerAddress = new IPv4Address(reader.ReadUInt32()); // 4 (24)
                p.RelayAgentAddress = new IPv4Address(reader.ReadUInt32()); // 4 (28)

                byte[] _clienthwaddr = reader.ReadBytes(16); // 16 (44)

                p.ServerHostName = string.Empty;

                foreach (byte i in reader.ReadBytes(64)) // 64 (128)
                {
                    if (i == 0)
                    {
                        continue;
                    }

                    p.ServerHostName = (char)i + p.ServerHostName;
                }

                p.File = string.Empty;

                foreach (byte i in reader.ReadBytes(128)) // 128 (236)
                {
                    if (i == 0)
                    {
                        continue;
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

                // Magic cookie 4 bytes
                uint cookie = reader.ReadUInt32(); // 4 (240)
                if (cookie != p.MagicCookie)
                {
                    throw new DHCPException(String.Format("Malformed packet: Magic cookie not found. Found: '{0:x}' instead of '{1:x}'.", cookie, p.MagicCookie));
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
        public static DHCPPacket Read(byte[] raw)
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
                            throw new OptionException(String.Format("Raw code: {0} class: {1}.", code, o.Code));
                        }

                        Debug.WriteLine(o.GetType());

                        if (!(o is AOptionMetaData))
                        {
                            // Get length of data
                            byte len = reader.ReadByte();
                            Debug.WriteLine(String.Format("Length: {0}", (byte)len));
                            byte[] data = new byte[len];
                            Array.Copy(reader.ReadBytes(len), 0, data, 0, len);
                            o.ReadRaw(data);
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