using SuperSocket.SocketBase.Config;
using System.Collections.Generic;


namespace SuperSocket.SocketEngine.Configuration
{
    /// <summary>
    /// SuperSocket's root configuration node
    /// </summary>
    public partial class SocketServiceConfig : IConfigurationSource
    {              
        IEnumerable<IServerConfig> IConfigurationSource.Servers
        {
            get
            {
                return this.Servers;
            }
        }

        IEnumerable<ITypeProvider> IConfigurationSource.ServerTypes
        {
            get
            {
                return this.ServerTypes;
            }
        }

        IEnumerable<ITypeProvider> IConfigurationSource.ConnectionFilters
        {
            get
            {
                return this.ConnectionFilters;
            }
        }

        IEnumerable<ITypeProvider> IConfigurationSource.LogFactories
        {
            get
            {
                return this.LogFactories;
            }
        }

        IEnumerable<ITypeProvider> IConfigurationSource.ReceiveFilterFactories
        {
            get
            {
                return this.ReceiveFilterFactories;
            }
        }


        IEnumerable<ITypeProvider> IConfigurationSource.CommandLoaders
        {
            get
            {
                return this.CommandLoaders;
            }
        }
    }
}
