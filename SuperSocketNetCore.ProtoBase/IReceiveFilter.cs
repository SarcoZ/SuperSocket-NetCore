﻿namespace SuperSocket.ProtoBase
{
    /// <summary>
    /// The receive filter interface
    /// </summary>
    /// <typeparam name="TPackageInfo">The type of the package info.</typeparam>
    public interface IReceiveFilter<out TPackageInfo>
        where TPackageInfo : IPackageInfo
    {
        /// <summary>
        /// Filters the received data.
        /// </summary>
        /// <param name="data">The received data.</param>
        /// <param name="rest">The length of the rest data after filtering.</param>
        /// <returns>the received packageInfo instance</returns>
        TPackageInfo Filter(BufferList data, out int rest);

        /// <summary>
        /// Gets the next receive filter which will be used when the next network data is received
        /// </summary>
        /// <value>
        /// The next receive filter.
        /// </value>
        IReceiveFilter<TPackageInfo> NextReceiveFilter { get; }

        /// <summary>
        /// Gets the state of the current filter.
        /// </summary>
        /// <value>
        /// The filter state.
        /// </value>
        FilterState State { get; }

        /// <summary>
        /// Resets this receive filter.
        /// </summary>
        void Reset();
    }

    /// <summary>
    /// the interface to support resolving the cached buffers into package without basic network protocol resolving
    /// </summary>
    /// <typeparam name="TPackageInfo"></typeparam>
    public interface ICleanupReceiveFilter<out TPackageInfo>
    {
        /// <summary>
        /// Resolves the package binary data to package instance
        /// </summary>
        /// <param name="data">The received buffer.</param>
        /// <returns>the resolved package instance</returns>
        TPackageInfo ResolvePackage(BufferList data);
    }
}
