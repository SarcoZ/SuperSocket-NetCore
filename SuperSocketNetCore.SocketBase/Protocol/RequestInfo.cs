using Microsoft.Extensions.DependencyInjection;

namespace SuperSocket.SocketBase.Protocol
{
    /// <summary>
    /// RequestInfo basic class
    /// </summary>
    /// <typeparam name="TRequestBody">The type of the request body.</typeparam>
    public abstract class RequestInfo<TRequestBody> : RequestInfoBase, IRequestInfo<TRequestBody>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestInfo&lt;TRequestBody&gt;"/> class.
        /// </summary>
        /// <param name="serviceScope">A container for service objects with a scope for this request.</param>
        protected RequestInfo(IServiceScope serviceScope)
            : base(serviceScope)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestInfo&lt;TRequestBody&gt;"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="body">The body.</param>
        /// <param name="serviceScope">A container for service objects with a scope for this request.</param>
        public RequestInfo(string key, TRequestBody body, IServiceScope serviceScope)
            : this(serviceScope)
        {
            Initialize(key, body);
        }

        /// <summary>
        /// Initializes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="body">The body.</param>
        protected void Initialize(string key, TRequestBody body)
        {
            Key = key;
            Body = body;
        }

        /// <summary>
        /// Gets the key of this request.
        /// </summary>
        public override string Key { get; protected set; }

        /// <summary>
        /// Gets the body.
        /// </summary>
        public TRequestBody Body { get; private set; }
    }

    /// <summary>
    /// RequestInfo with header
    /// </summary>
    /// <typeparam name="TRequestHeader">The type of the request header.</typeparam>
    /// <typeparam name="TRequestBody">The type of the request body.</typeparam>
    public abstract class RequestInfo<TRequestHeader, TRequestBody> : RequestInfo<TRequestBody>, IRequestInfo<TRequestHeader, TRequestBody>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestInfo&lt;TRequestHeader, TRequestBody&gt;"/> class.
        /// </summary>
        /// <param name="serviceScope">A container for service objects with a scope for this request.</param>
        public RequestInfo(IServiceScope serviceScope)
            : base(serviceScope)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestInfo&lt;TRequestHeader, TRequestBody&gt;"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="header">The header.</param>
        /// <param name="body">The body.</param>
        /// <param name="serviceScope">A container for service objects with a scope for this request.</param>
        public RequestInfo(string key, TRequestHeader header, TRequestBody body, IServiceScope serviceScope)
            : base(key, body, serviceScope)
        {
            Header = header;
        }

        /// <summary>
        /// Initializes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="header">The header.</param>
        /// <param name="body">The body.</param>
        public void Initialize(string key, TRequestHeader header, TRequestBody body)
        {
            base.Initialize(key, body);
            Header = header;
        }
        /// <summary>
        /// Gets the header.
        /// </summary>
        public TRequestHeader Header { get; private set; }
    }
}
