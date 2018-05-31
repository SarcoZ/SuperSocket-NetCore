using Microsoft.Extensions.DependencyInjection;

namespace SuperSocket.SocketBase.Protocol
{
    /// <summary>
    /// Binary type request information
    /// </summary>
    public class BinaryRequestInfo : RequestInfo<byte[]>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryRequestInfo"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="body">The body.</param>
        /// <param name="serviceScope">A container for service objects with a scope for this request.</param>
        public BinaryRequestInfo(string key, byte[] body, IServiceScope serviceScope)
            : base(key, body, serviceScope)
        {

        }
    }
}
