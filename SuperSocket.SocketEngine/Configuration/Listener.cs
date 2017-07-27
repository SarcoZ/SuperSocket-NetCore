using SuperSocket.Common;
using SuperSocket.SocketBase.Config;
#if !NETSTANDARD2_0
using System.Configuration;
#else
using Microsoft.Extensions.Configuration;
#endif

namespace SuperSocket.SocketEngine.Configuration
{
    /// <summary>
    /// Listener configuration
    /// </summary>
#if !NETSTANDARD2_0
    public class Listener : ConfigurationElement, IListenerConfig
    {
        /// <summary>
        /// Gets the ip of listener
        /// </summary>
        [ConfigurationProperty("ip", IsRequired = true)]
        public string Ip
        {
            get { return this["ip"] as string; }
        }

        /// <summary>
        /// Gets the port of listener
        /// </summary>
        [ConfigurationProperty("port", IsRequired = true)]
        public int Port
        {
            get { return (int)this["port"]; }
        }

        /// <summary>
        /// Gets the backlog.
        /// </summary>
        [ConfigurationProperty("backlog", IsRequired = false, DefaultValue = 100)]
        public int Backlog
        {
            get { return (int)this["backlog"]; }
        }

        /// <summary>
        /// Gets the security option, None/Default/Tls/Ssl/...
        /// </summary>
        [ConfigurationProperty("security", IsRequired = false)]
        public string Security
        {
            get
            {
                return (string)this["security"];
            }
        }
    }

    /// <summary>
    /// Listener configuration collection
    /// </summary>
    [ConfigurationCollection(typeof(Listener))]
    public class ListenerConfigCollection : GenericConfigurationElementCollectionBase<Listener, IListenerConfig>
    {

    }
#else
    public class Listener : IListenerConfig
    {
        /// <summary>
        /// Gets the ip of listener
        /// </summary>       
        public string Ip { get; set; }

        /// <summary>
        /// Gets the port of listener
        /// </summary>       
        public int Port { get; set; }

        /// <summary>
        /// Gets the backlog.
        /// </summary>      
        public int Backlog { get; set; } = 100;

        /// <summary>
        /// Gets the security option, None/Default/Tls/Ssl/...
        /// </summary>     
        public string Security { get; set; }
    }
#endif
}
