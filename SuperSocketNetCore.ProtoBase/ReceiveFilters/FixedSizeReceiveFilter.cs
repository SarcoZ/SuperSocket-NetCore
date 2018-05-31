﻿namespace SuperSocket.ProtoBase
{
    /// <summary>
    /// The receive filter which is designed for the protocol all messages are in the same fixed size
    /// </summary>
    /// <typeparam name="TPackageInfo">The type of the package info.</typeparam>
    public abstract class FixedSizeReceiveFilter<TPackageInfo> : IReceiveFilter<TPackageInfo>, IPackageResolver<TPackageInfo>
        where TPackageInfo : IPackageInfo
    {
        private int m_OriginalSize;
        private int m_Size;

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedSizeReceiveFilter{TPackageInfo}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public FixedSizeReceiveFilter(int size)
        {
            m_OriginalSize = size;
            m_Size = size;
        }

        /// <summary>
        /// Filters the received data.
        /// </summary>
        /// <param name="data">The received data.</param>
        /// <param name="rest">The length of the rest data after filtering.</param>
        /// <returns>the received packageInfo instance</returns>
        public virtual TPackageInfo Filter(BufferList data, out int rest)
        {
            rest = 0;
            var total = data.Total;

            //Haven't received a full request package
            if (total < m_Size)
                return default(TPackageInfo);

            //There is more data after parse one request
            if (total > m_Size)
            {
                rest = total - m_Size;
                data.SetLastItemLength(data.Last.Count - rest);
            }

            var bufferStream = this.GetBufferStream(data);

            if (!CanResolvePackage(bufferStream))
                return default(TPackageInfo);

            return ResolvePackage(bufferStream);
        }

        /// <summary>
        /// Gets or sets the next receive filter which will be used when the next network data is received.
        /// </summary>
        /// <value>
        /// The next receive filter.
        /// </value>
        public IReceiveFilter<TPackageInfo> NextReceiveFilter { get; protected set; }

        /// <summary>
        /// Gets/sets the state of the current filter.
        /// </summary>
        /// <value>
        /// The filter state.
        /// </value>
        public FilterState State { get; protected set; }

        /// <summary>
        /// Resets the size.
        /// </summary>
        /// <param name="newSize">The new size.</param>
        protected void ResetSize(int newSize)
        {
            m_Size = newSize;
        }

        /// <summary>
        /// Resets this receive filter.
        /// </summary>
        public virtual void Reset()
        {
            if (m_Size != m_OriginalSize)
                m_Size = m_OriginalSize;

            NextReceiveFilter = null;
            State = FilterState.Normal;
        }

        /// <summary>
        /// Determines whether this instance [can resolve package] the specified package data.
        /// </summary>
        /// <param name="bufferStream">The received buffer stream.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can resolve package] the specified package data; otherwise, <c>false</c>.
        /// </returns>
        protected virtual bool CanResolvePackage(IBufferStream bufferStream)
        {
            return true;
        }

        /// <summary>
        /// Resolves the package binary data to package instance
        /// </summary>
        /// <param name="bufferStream">The received buffer stream.</param>
        /// <returns>the resolved package instance</returns>
        public abstract TPackageInfo ResolvePackage(IBufferStream bufferStream);
    }
}
