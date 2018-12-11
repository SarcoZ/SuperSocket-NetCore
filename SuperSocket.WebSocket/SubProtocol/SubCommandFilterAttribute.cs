using SuperSocket.SocketBase.Metadata;
using System;

namespace SuperSocket.WebSocket.SubProtocol
{
    /// <summary>
    /// SubCommandFilter Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class SubCommandFilterAttribute : CommandFilterAttribute
    {
        /// <summary>
        /// Gets or sets the sub protocol.
        /// </summary>
        /// <value>
        /// The sub protocol.
        /// </value>
        public string SubProtocol { get; set; }
    }
}
