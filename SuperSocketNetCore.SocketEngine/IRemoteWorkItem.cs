﻿using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Provider;

namespace SuperSocket.SocketEngine
{
    /// <summary>
    /// IRemoteWorkItem
    /// </summary>
    public interface IRemoteWorkItem : IWorkItemBase, IStatusInfoSource
    {
        /// <summary>
        /// Setups the specified config.
        /// </summary>
        /// <param name="serverType">Type of the server.</param>
        /// <param name="bootstrapUri">The bootstrap URI.</param>
        /// <param name="assemblyImportRoot">The assembly import root.</param>
        /// <param name="config">The config.</param>
        /// <param name="factories">The factories.</param>
        /// <param name="startupConfigFile">The startup configuration file path</param>
        /// <returns></returns>
        bool Setup(string serverType, string bootstrapUri, string assemblyImportRoot, IServerConfig config, ProviderFactoryInfo[] factories, string startupConfigFile);
    }
}
