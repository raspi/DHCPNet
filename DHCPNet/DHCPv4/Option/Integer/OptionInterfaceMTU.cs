using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option specifies the MTU to use on this interface.  The MTU is
    /// specified as a 16-bit unsigned integer.
    /// 
    /// The minimum legal value for the MTU is 68.
    ///
    /// Length 2 bytes.
    /// </summary>
    public class OptionInterfaceMTU : AOptionUint16
    {
        public override byte Code
        {
            get
            {
                return 26;
            }
        }
    }

}