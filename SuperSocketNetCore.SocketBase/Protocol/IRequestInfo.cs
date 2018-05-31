using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSocket.SocketBase.Protocol
{
    /// <summary>
    /// Request information interface
    /// </summary>
    /// <remarks>You need to dispose the RequestInfo objects.</remarks>
    public interface IRequestInfo : IDisposable
    {
        /// <summary>
        /// Gets the key of this request.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// A container for service objects with a scope for this request.
        /// </summary>
        IServiceProvider ServiceProvider { get; }
    }

    /// <summary>
    /// Request information interface
    /// </summary>
    /// <typeparam name="TRequestBody">The type of the request body.</typeparam>
    public interface IRequestInfo<TRequestBody> : IRequestInfo
    {
        /// <summary>
        /// Gets the body of this request.
        /// </summary>
        TRequestBody Body { get; }
    }


    /// <summary>
    /// Request information interface
    /// </summary>
    /// <typeparam name="TRequestHeader">The type of the request header.</typeparam>
    /// <typeparam name="TRequestBody">The type of the request body.</typeparam>
    public interface IRequestInfo<TRequestHeader, TRequestBody> : IRequestInfo<TRequestBody>
    {
        /// <summary>
        /// Gets the header of the request.
        /// </summary>
        TRequestHeader Header { get; }
    }
}
