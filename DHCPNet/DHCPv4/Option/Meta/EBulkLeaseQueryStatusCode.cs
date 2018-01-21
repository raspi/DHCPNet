using System;
using System.Collections.Generic;
using System.Text;

namespace DHCPNet.v4.Option
{
    /// <summary>
    /// <see cref="OptionBulkLeaseQueryStatusCode"/>
    /// https://tools.ietf.org/html/rfc6926#section-6.2.2
    /// </summary>
    public enum EBulkLeaseQueryStatusCode : byte
    {
        /// <summary>
        /// Success. Also signaled by absence of a status-code option.
        /// </summary>
        Success,

        /// <summary>
        /// Failure, reason unspecified.
        /// </summary>
        UnspecifiedFailure,

        /// <summary>
        /// Indicates that the server is unable to perform a query or 
        /// has prematurely terminated the query for some reason 
        /// (which should be communicated in the text message).
        /// </summary>
        QueryTerminated,

        /// <summary>
        /// The query was not understood.
        /// </summary>
        MalformedQuery,

        /// <summary>
        /// The query or request was understood but 
        /// was not allowed in this context.
        /// </summary>
        NotAllowed,
    }
}
