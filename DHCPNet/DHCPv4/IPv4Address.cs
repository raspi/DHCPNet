using System;

namespace DHCPNet
{
    /// <summary>
    /// IPv4 Address
    /// </summary>
    public class IPv4Address
    {
        /// <summary>
        /// The _addr.
        /// </summary>
        protected byte[] _addr = { 0, 0, 0, 0 };

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <exception cref="IPv4AddressException">
        /// </exception>
        public byte[] Address
        {
            get
            {
                return _addr;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new IPv4AddressException("Zero length.");
                }

                if (value.Length != 4)
                {
                    throw new IPv4AddressException(string.Format("Invalid length: {0}.", value.Length));
                }

                _addr = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IPv4Address"/> class.
        /// </summary>
        /// <param name="v">
        /// The v.
        /// </param>
        public IPv4Address(byte[] v)
        {
            Address = v;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public IPv4Address(uint v)
        {
            Address = BitConverter.GetBytes(v);
        }

        /// <summary>
        /// 
        /// </summary>
        public uint ToUInt32()
        {
            return BitConverter.ToUInt32(Address, 0);
        }

        /// <summary>
        /// Convert IPv4 address to string
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}.{3}", Address[0], Address[1], Address[2], Address[3]);
        }
    }
}