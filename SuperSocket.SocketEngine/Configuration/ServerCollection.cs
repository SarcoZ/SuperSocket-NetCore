using SuperSocket.Common;
using SuperSocket.SocketBase.Config;
#if !NETSTANDARD2_0
using System.Configuration;
#endif

namespace SuperSocket.SocketEngine.Configuration
{
#if !NETSTANDARD2_0
    /// <summary>
    /// Server configuration collection
    /// </summary>
    [ConfigurationCollection(typeof(Server), AddItemName = "server")]
    public class ServerCollection : GenericConfigurationElementCollection<Server, IServerConfig>
    {
        /// <summary>
        /// Adds the new server element.
        /// </summary>
        /// <param name="newServer">The new server.</param>
        public void AddNew(Server newServer)
        {
            base.BaseAdd(newServer);
        }

        /// <summary>
        /// Removes the specified server from the configuration.
        /// </summary>
        /// <param name="name">The name.</param>
        public void Remove(string name)
        {
            base.BaseRemove(name);
        }
    }
#endif  
}
