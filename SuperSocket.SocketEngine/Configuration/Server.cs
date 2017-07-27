using SuperSocket.SocketBase.Config;
using System.Collections.Generic;

namespace SuperSocket.SocketEngine.Configuration
{
    /// <summary>
    /// Server configuration
    /// </summary>
    public partial class Server : IServerConfig
    {       
        /// <summary>
        /// Gets X509Certificate configuration.
        /// </summary>
        /// <value>
        /// X509Certificate configuration.
        /// </value>
        public ICertificateConfig Certificate
        {
            get { return CertificateConfig; }
        }
               
        /// <summary>
        /// Gets the listeners' configuration.
        /// </summary>
        IEnumerable<IListenerConfig> IServerConfig.Listeners
        {
            get
            {
                return this.Listeners;
            }
        }
      
        IEnumerable<ICommandAssemblyConfig> IServerConfig.CommandAssemblies
        {
            get { return this.CommandAssemblies; }
        }

        
    }
}
