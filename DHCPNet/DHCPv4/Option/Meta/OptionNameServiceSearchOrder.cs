﻿using System;
using System.Collections.Generic;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This document defines a new Dynamic Host Configuration Protocol
    /// (DHCP) option which is passed from the DHCP Server to the DHCP Client
    /// to specify the order in which name services should be consulted when
    /// resolving hostnames and other information.
    /// 
    /// https://tools.ietf.org/html/rfc2937
    /// </summary>
    public class OptionNameServiceSearchOrder : Option
    {
        /// <inheritdoc />
        public override byte Code
        {
            get
            {
                return 117;
            }
        }

        /// <inheritdoc />
        public List<ushort> RequestList = new List<ushort>();

        /// <inheritdoc />
        public OptionNameServiceSearchOrder()
        {
        }

        /// <summary>
        /// Generate request list from Option list.
        /// </summary>
        public OptionNameServiceSearchOrder(Option[] opts)
        {
            foreach (Option i in opts)
            {
                RequestList.Add(i.Code);
            }
        }

        /// <inheritdoc />
        public override byte[] GetRawBytes()
        {
            ushort[] source = this.RequestList.ToArray();
            byte[] target = new byte[source.Length * 2];
            Buffer.BlockCopy(source, 0, target, 0, source.Length * 2);
            return target;
        }

        /// <inheritdoc />
        public override void ReadRaw(byte[] raw)
        {
            if (raw.Length == 0)
            {
                throw new OptionLengthZeroException();
            }

            if (raw.Length % 2 != 0)
            {
                throw new OptionLengthNotMultipleOfException("Length not multiple of 2.");
            }

            for (int i = 0; i < raw.Length; i += 2)
            {
                this.RequestList.Add(BitConverter.ToUInt16(raw, i));
            }
        }
    }
}