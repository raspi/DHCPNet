using System;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option is used by DHCP clients to optionally 
    /// identify the vendor type and configuration of a 
    /// DHCP client. The information is a string of n octets, 
    /// interpreted by servers. 
    /// Vendors may choose to define specific vendor class 
    /// identifiers to convey particular configuration or other 
    /// identification information about a client.
    /// 
    /// For example, the identifier may encode the client's 
    /// hardware configuration. 
    /// 
    /// Servers not equipped to interpret the class-specific
    /// information sent by a client MUST ignore it (although 
    /// it may be reported). 
    /// 
    /// Servers that respond SHOULD only use option 43 to 
    /// return the vendor-specific information to the client.
    ///
    /// Minimum length 1 byte.
    /// </summary>
    class OptionVendorClassIdentifier : AOptionString
    {
        public override byte Code
        {
            get
            {
                return 60;
            }
        }
    }
}

