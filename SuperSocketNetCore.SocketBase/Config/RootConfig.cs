﻿using SuperSocket.Common;
using System;
using System.Collections.Specialized;
using System.Threading;
using System.Collections.Generic;
#if !NETSTANDARD2_0
using System.Configuration;
#else
using Microsoft.Extensions.Configuration;
#endif

namespace SuperSocket.SocketBase.Config
{
    /// <summary>
    /// Root configuration model
    /// </summary>
    [Serializable]
#if !NETSTANDARD2_0
    public partial class RootConfig : IRootConfig
#else
    public partial class RootConfig : ConfigurationRoot, IRootConfig
#endif
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RootConfig"/> class.
        /// </summary>
        /// <param name="rootConfig">The root config.</param>
        public RootConfig(IRootConfig rootConfig)
#if NETSTANDARD2_0        
        :this()
#endif
        {
            rootConfig.CopyPropertiesTo(this);
            this.OptionElements = rootConfig.OptionElements;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RootConfig"/> class.
        /// </summary>
        public RootConfig()
#if NETSTANDARD2_0
        : base(new List<IConfigurationProvider>())
#endif
        {
            int maxWorkingThread, maxCompletionPortThreads;
            ThreadPool.GetMaxThreads(out maxWorkingThread, out maxCompletionPortThreads);
            MaxWorkingThreads = maxWorkingThread;
            MaxCompletionPortThreads = maxCompletionPortThreads;

            int minWorkingThread, minCompletionPortThreads;
            ThreadPool.GetMinThreads(out minWorkingThread, out minCompletionPortThreads);
            MinWorkingThreads = minWorkingThread;
            MinCompletionPortThreads = minCompletionPortThreads;

            PerformanceDataCollectInterval = 60;

            Isolation = IsolationMode.None;
        }

        #region IRootConfig Members

        /// <summary>
        /// Gets/Sets the max working threads.
        /// </summary>
        public int MaxWorkingThreads { get; set; }

        /// <summary>
        /// Gets/sets the min working threads.
        /// </summary>
        public int MinWorkingThreads { get; set; }

        /// <summary>
        /// Gets/sets the max completion port threads.
        /// </summary>
        public int MaxCompletionPortThreads { get; set; }

        /// <summary>
        /// Gets/sets the min completion port threads.
        /// </summary>
        public int MinCompletionPortThreads { get; set; }

        /// <summary>
        /// Gets/sets the performance data collect interval, in seconds.
        /// </summary>
        public int PerformanceDataCollectInterval { get; set; }

        /// <summary>
        /// Gets/sets a value indicating whether [disable performance data collector].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [disable performance data collector]; otherwise, <c>false</c>.
        /// </value>
        public bool DisablePerformanceDataCollector { get; set; }

        /// <summary>
        /// Gets/sets the isolation mode.
        /// </summary>
        public IsolationMode Isolation { get; set; }

        /// <summary>
        /// Gets/sets the log factory name.
        /// </summary>
        /// <value>
        /// The log factory.
        /// </value>
        public string LogFactory { get; set; }

        /// <summary>
        /// Gets/sets the option elements.
        /// </summary>
        public NameValueCollection OptionElements { get; set; }

        /// <summary>
        /// Gets the child config.
        /// </summary>
        /// <typeparam name="TConfig">The type of the config.</typeparam>
        /// <param name="childConfigName">Name of the child config.</param>
        /// <returns></returns>
#if !NETSTANDARD2_0
        public virtual TConfig GetChildConfig<TConfig>(string childConfigName)
            where TConfig : ConfigurationElement, new()
        {
            return OptionElements.GetChildConfig<TConfig>(childConfigName);
        }
#else
        public virtual TConfig GetChildConfig<TConfig>(string childConfigName)
                    where TConfig : class, new()
        {
            return GetSection(childConfigName).Get<TConfig>();        
        }

       
#endif

#if !NET40
        /// <summary>
        /// Gets or sets the default culture.
        /// </summary>
        /// <value>
        /// The default culture.
        /// </value>
        public string DefaultCulture { get; set; }
#endif

#endregion
    }
}
