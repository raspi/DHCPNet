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

                p.HardwareAddressType = (EHardwareType)(byte)reader.ReadByte(); // 1 (2)

                byte _hwaddrlen = (byte)reader.ReadByte(); // 1 (3)

                if (_hwaddrlen > 16)
                {
                    throw new DHCPException(String.Format("Malformed packet. Hardware address length was {0}.", _hwaddrlen));
                }

                p.Hops = (byte)reader.ReadByte(); // 1 (4)
                p.TransactionID = reader.ReadUInt32(); // 4 (8)
                p.Seconds = reader.ReadUInt16(); // 2 (10)
                p.Flags = reader.ReadUInt16(); // 2 (12)
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

                foreach (byte i in reader.ReadBytes(64)) // 64 (128)
                {
                    if (i == 0)
                    {
                        continue;
                    }

                    p.ServerHostName = (char)i + p.ServerHostName;
                }

                //reader.BaseStream.Seek(128, SeekOrigin.Begin);

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
                            throw new OptionException(string.Format("Raw code: {0} class: {1}.", code, o.GetType()));
                        }

                        Debug.WriteLine(o.GetType());

                        if (!(o is AOptionMetaData))
                        {
                            // Get length of data
                            int len = (int)reader.ReadByte();
                            Debug.WriteLine(string.Format("Option data length: {0}", len));

                            // Buffer for data
                            byte[] data = reader.ReadBytes(len);

                            if (data.Length != len)
                            {
                                throw new IndexOutOfRangeException();
                            }

#if DEBUG
                            string dtmp = string.Empty;
                            foreach (byte b in data)
                            {
                                dtmp += string.Format("{0:x2} ", b);
                            }    
                            
                            Debug.WriteLine("Data: " + dtmp);
                            Debug.WriteLine(string.Empty);
#endif
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

                            Debug.WriteLine(string.Format("Option: {0}", o.ToString()));
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