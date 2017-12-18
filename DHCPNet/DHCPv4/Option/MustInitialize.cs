using System;

namespace DHCPNet.v4.Option
{
    public abstract class MustInitialize
    {
        public abstract void ReadRaw(byte[] raw);

    }

}
