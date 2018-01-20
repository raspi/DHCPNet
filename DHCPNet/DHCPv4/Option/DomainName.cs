using System;
using System.Collections.Generic;
using System.Text;

namespace DHCPNet
{
    /// <summary>
    /// https://tools.ietf.org/html/rfc1035#section-4.1.4
    /// </summary>
    public static class DomainName
    {
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

                if (len > raw.Length)
                {
                    throw new IndexOutOfRangeException("Index out of range");
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
