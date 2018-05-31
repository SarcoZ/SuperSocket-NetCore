using SuperSocket.SocketBase.Protocol;
using System.Collections.Specialized;

using Microsoft.Extensions.DependencyInjection;

namespace SuperSocket.Facility.Protocol
{
    /// <summary>
    /// IHttpRequestInfo
    /// </summary>
    public interface IHttpRequestInfo : IRequestInfo
    {
        /// <summary>
        /// Gets the http header.
        /// </summary>
        NameValueCollection Header { get; }
    }

    /// <summary>
    /// HttpRequestInfoBase
    /// </summary>
    public abstract class HttpRequestInfoBase : RequestInfoBase, IHttpRequestInfo
    {
        /// <summary>
        /// Gets the http header.
        /// </summary>
        public NameValueCollection Header { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestInfoBase"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="header">The header.</param>
        /// <param name="serviceScope">A container for service objects with a scope for this request.</param>
        protected HttpRequestInfoBase(string key, NameValueCollection header, IServiceScope serviceScope)
            : base(serviceScope)
        {
            Key = key;
            Header = header;
        }
    }

    /// <summary>
    /// HttpRequestInfoBase
    /// </summary>
    /// <typeparam name="TRequestBody">The type of the request body.</typeparam>
    public abstract class HttpRequestInfoBase<TRequestBody> : HttpRequestInfoBase
    {
        /// <summary>
        /// Gets the body.
        /// </summary>
        public TRequestBody Body { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestInfoBase&lt;TRequestBody&gt;"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="header">The header.</param>
        /// <param name="body">The body.</param>
        /// <param name="serviceScope">A container for service objects with a scope for this request.</param>
        protected HttpRequestInfoBase(
            string key,
            NameValueCollection header,
            TRequestBody body,
            IServiceScope serviceScope)
            : base(key, header, serviceScope)
        {
            Body = body;
        }
    }
}
