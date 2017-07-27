#if NETSTANDARD2_0
using Microsoft.Extensions.Configuration;
#endif
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace SuperSocket.SocketEngine.Configuration
{
#if NETSTANDARD2_0
    public partial class SocketServiceConfig : ConfigurationRoot, SuperSocket.SocketBase.Config.IConfigurationSource
    {
        /// <summary>
        /// Gets the max working threads.
        /// </summary>      
        public int MaxWorkingThreads { get; set; } = -1;

        /// <summary>
        /// Gets the min working threads.
        /// </summary>      
        public int MinWorkingThreads { get; set; } = -1;

        /// <summary>
        /// Gets the max completion port threads.
        /// </summary>     
        public int MaxCompletionPortThreads { get; set; } = -1;

        /// <summary>
        /// Gets the min completion port threads.
        /// </summary>        
        public int MinCompletionPortThreads { get; set; } = -1;

        /// <summary>
        /// Gets the performance data collect interval, in seconds.
        /// </summary>      
        public int PerformanceDataCollectInterval { get; set; } = 60;

        /// <summary>
        /// Gets a value indicating whether [disable performance data collector].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [disable performance data collector]; otherwise, <c>false</c>.
        /// </value>      
        public bool DisablePerformanceDataCollector { get; set; }

        /// <summary>
        /// Gets the isolation mode.
        /// </summary>      
        public IsolationMode Isolation { get; set; } = IsolationMode.None;

        /// <summary>
        /// Gets the logfactory name of the bootstrap.
        /// </summary>      
        public string LogFactory { get; set; }


        public List<Server> Servers { get; set; }

        public List<TypeProvider> ServerTypes { get; set; }

        public List<TypeProvider> ConnectionFilters { get; set; }

        public List<TypeProvider> LogFactories { get; set; }

        public List<TypeProvider> ReceiveFilterFactories { get; set; }

        public List<TypeProvider> CommandLoaders { get; set; }

        /// <summary>
        /// Gets the option elements.
        /// </summary>
        public NameValueCollection OptionElements { get; private set; }

        /// <summary>
        /// Gets/sets the default culture for all server instances.
        /// </summary>
        /// <value>
        /// The default culture.
        /// </value>     
        public string DefaultCulture { get; set; }


        public SocketServiceConfig(IConfiguration configuration)
            : base(new List<IConfigurationProvider>())
        {
            Servers = configuration.GetSection("supersocket:servers:server").Get<List<Server>>();
            ServerTypes = configuration.GetSection("supersocket:serverTypes:add").Get<List<TypeProvider>>();
            ConnectionFilters = configuration.GetSection("supersocket:connectionfilters:add").Get<List<TypeProvider>>();
            LogFactories = configuration.GetSection("supersocket:logfactories:add").Get<List<TypeProvider>>();
            ReceiveFilterFactories = configuration.GetSection("supersocket:receivefilterfactories:add").Get<List<TypeProvider>>();
            CommandLoaders = configuration.GetSection("supersocket:commandLoaders:add").Get<List<TypeProvider>>();
        }

        public TConfig GetChildConfig<TConfig>(string childConfigName) where TConfig : class, new()
        {
            return default(TConfig);
        }
    }
#endif
}
