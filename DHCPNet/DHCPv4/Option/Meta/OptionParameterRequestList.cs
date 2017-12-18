using System.Net;
using System;
using System.Collections.Generic;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// This option is used by a DHCP client to 
    /// request values for specified configuration 
    /// parameters. The list of requested parameters is
    /// specified as n octets, where each octet is a 
    /// valid DHCP option code as defined in RFC 2132.
    ///
    /// The client MAY list the options in order of preference.
    /// 
    /// The DHCP server is not required to return the options 
    /// in the requested order, but MUST try to insert the 
    /// requested options in the order requested by the client.
    /// 
    /// For example if [6, 3] is requested it means 
    /// Domain Name Server Option (3.8.)
    /// Router Option (3.5.)
    ///
    /// Minimum length is 1.
    /// </summary>
    public class OptionParameterRequestList : Option
    {
        public override byte Code
        {
            get
            {
                return 55;
            }
        }

        public List<byte> RequestList = new List<byte>();

        /// <summary>
        /// Generate request list from enum.
        /// </summary>
        public OptionParameterRequestList(EOption[] opts)
        {
            foreach (EOption i in opts)
            {
                Option o = OptionFactory.GetOption((uint)i);
                RequestList.Add(o.Code);
            }
        }

        /// <summary>
        /// Generate request list from Option list.
        /// </summary>
        public OptionParameterRequestList(Option[] opts)
        {
            foreach (Option i in opts)
            {
                RequestList.Add(i.Code);
            }
        }

        public override byte[] GetRawBytes()
        {
            return RequestList.ToArray();
        }

        public override void ReadRaw(byte[] raw)
        {
            RequestList = new List<byte>(raw);
        }
    }

}