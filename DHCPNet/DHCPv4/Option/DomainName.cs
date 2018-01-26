using System;
using System.Collections.Generic;
using System.Text;

namespace DHCPNet
{
    /// <summary>
    /// Domain name compression
    /// 
    /// For example, a datagram might need to use the domain names F.ISI.ARPA,
    /// FOO.F.ISI.ARPA, ARPA, and the root.Ignoring the other fields of the
    /// message, these domain names might be represented as:
    ///
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    ///    20 |           1           |           F           |
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    ///    22 |           3           |           I           |
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    ///    24 |           S           |           I           |
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    ///    26 |           4           |           A           |
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    ///    28 |           R           |           P           |
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    ///    30 |           A           |           0           |
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    /// 
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    ///    40 |           3           |           F           |
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    ///    42 |           O           |           O           |
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    ///    44 | 1  1|                20                       |
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    ///
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    ///    64 | 1  1|                26                       |
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    ///
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    ///    92 |           0           |                       |
    ///       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
    ///
    /// The domain name for F.ISI.ARPA is shown at offset 20.  The domain name
    /// FOO.F.ISI.ARPA is shown at offset 40; this definition uses a pointer to
    /// concatenate a label for FOO to the previously defined F.ISI.ARPA.The
    /// domain name ARPA is defined at offset 64 using a pointer to the ARPA
    /// component of the name F.ISI.ARPA at 20; note that this pointer relies on
    /// ARPA being the last label in the string at 20.  The root domain name is
    /// defined by a single octet of zeros at 92; the root domain name has no
    /// labels.
    /// 
    /// https://tools.ietf.org/html/rfc1035#section-4.1.4
    /// </summary>
    public static class DomainName
    {
        /// <inheritdoc />
        public static List<string> CompressedBytesToString(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new Exception("Zero length");
            }

            List<string> addr = new List<string>();

            int offset = 0;

            string tmp = String.Empty;

            do
            {
                byte len = raw[offset];

                if (len == 0)
                {
                    throw new Exception("Zero length");
                }

                if (len > raw.Length)
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }

                if (len > (raw.Length - offset))
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }

                offset++;

                char[] c = new char[len];

                for (int i = 0; i < len; i++)
                {
                    c[i] = (char)raw[offset + i];
                }

                // Add part of domain
                tmp += new string(c);

                offset += len;

                if (raw[offset] != 0)
                {
                    // Add '.' to domain name
                    tmp += ".";
                }
                else
                {
                    // Next
                    addr.Add(tmp);
                    offset++;
                    tmp = String.Empty;
                }
            }
            while (offset < raw.Length);

            return addr;
        }

        /// <inheritdoc />
        public static byte[] StringToCompressedBytes(List<string> list)
        {
            List<byte> raw = new List<byte>();

            foreach (string domainstr in list)
            {
                foreach (string part in domainstr.Split('.'))
                {
                    raw.Add((byte)part.Length);

                    foreach (char c in part)
                    {
                        raw.Add((byte)c);
                    }
                }

                raw.Add(0);

            }

            return raw.ToArray();
        }
    }
}
