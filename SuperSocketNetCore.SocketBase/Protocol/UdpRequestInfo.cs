using Microsoft.Extensions.DependencyInjection;

namespace SuperSocket.SocketBase.Protocol
{
    /// <summary>
    /// UdpRequestInfo, it is designed for passing in business session ID to udp request info
    /// </summary>
    public class UdpRequestInfo : RequestInfoBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UdpRequestInfo"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="sessionID">The session ID.</param>
        /// <param name="serviceScope">A container for service objects with a scope for this request.</param>
        public UdpRequestInfo(string key, string sessionID, IServiceScope serviceScope)
            : base(serviceScope)
        {
            Key = key;
            SessionID = sessionID;
        }

        /// <summary>
        /// Gets the key of this request.
        /// </summary>
        public override string Key { get; protected set; }

        /// <summary>
        /// Gets the session ID.
        /// </summary>
        public string SessionID { get; private set; }
    }
}
