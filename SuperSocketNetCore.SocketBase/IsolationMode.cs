﻿namespace SuperSocket.SocketBase
{
    /// <summary>
    /// AppServer instance running isolation mode
    /// </summary>
    public enum IsolationMode
    {
        /// <summary>
        /// No isolation
        /// </summary>
        None,
        /// <summary>
        /// Isolation by AppDomain
        /// </summary>
        AppDomain,

        /// <summary>
        /// Isolation by process
        /// </summary>
        Process
    }
}
