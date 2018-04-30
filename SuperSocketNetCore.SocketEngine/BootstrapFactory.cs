﻿using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketEngine.Configuration;
using System;
using System.Linq;
using System.Threading;
#if !NETSTANDARD2_0
using System.Configuration;
#else
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
#endif

namespace SuperSocket.SocketEngine
{
    /// <summary>
    /// Bootstrap Factory
    /// </summary>
    public static class BootstrapFactory
    {
        /// <summary>
        /// Creates the bootstrap.
        /// </summary>
        /// <param name="config">The config.</param>
        /// <returns></returns>
        public static IBootstrap CreateBootstrap(SocketBase.Config.IConfigurationSource config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            IBootstrap bootstrap;

            if (config.Isolation == IsolationMode.AppDomain)
                bootstrap = new AppDomainBootstrap(config);
            else if (config.Isolation == IsolationMode.Process)
                bootstrap = new ProcessBootstrap(config);
            else
                bootstrap = new DefaultBootstrap(config);


#if !NETSTANDARD2_0
            var section = config as ConfigurationSection;

            if (section != null)
                ConfigurationWatcher.Watch(section, bootstrap);
#endif

            return bootstrap;
        }

        /// <summary>
        /// Creates the bootstrap from app configuration's socketServer section.
        /// </summary>
        /// <returns></returns>
        public static IBootstrap CreateBootstrap()
        {
#if !NETSTANDARD2_0
            var configSection = ConfigurationManager.GetSection("superSocket");

            if (configSection == null)//to keep compatible with old version
                configSection = ConfigurationManager.GetSection("socketServer");

            if (configSection == null)
                throw new ConfigurationErrorsException("Missing 'superSocket' or 'socketServer' configuration section.");

            var configSource = configSection as IConfigurationSource;
            if (configSource == null)
                throw new ConfigurationErrorsException("Invalid 'superSocket' or 'socketServer' configuration section.");

            return CreateBootstrap(configSource);
#else
            var configFile = System.Reflection.Assembly.GetCallingAssembly().GetName().Name + ".dll.config";           
            return CreateBootstrapFromConfigFile(configFile);
#endif
        }

        /// <summary>
        /// Creates the bootstrap.
        /// </summary>
        /// <param name="configSectionName">Name of the config section.</param>
        /// <returns></returns>
        public static IBootstrap CreateBootstrap(string configSectionName)
        {
#if !NETSTANDARD2_0
            var configSource = ConfigurationManager.GetSection(configSectionName) as SocketBase.Config.IConfigurationSource;

            if (configSource == null)
                throw new ArgumentException("Invalid section name.");

            return CreateBootstrap(configSource);
#else

            var configFile = System.Reflection.Assembly.GetCallingAssembly().GetName().Name + ".dll.config";         
            return CreateBootstrapFromConfigFile(configFile, configSectionName);
#endif
        }

        /// <summary>
        /// Creates the bootstrap from configuration file.
        /// </summary>
        /// <param name="configFile">The configuration file.</param>
        /// <returns></returns>
        public static IBootstrap CreateBootstrapFromConfigFile(string configFile, string configSectionName = "")
        {
#if !NETSTANDARD2_0
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = configFile;

            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            var configSection = config.GetSection("superSocket");

            if (configSection == null)
                configSection = config.GetSection("socketServer");

            return CreateBootstrap(configSection as SocketBase.Config.IConfigurationSource);
#else            
            IBootstrap bootstrap;
            var configurationRoot = new ConfigurationBuilder()
                        .SetBasePath(AppContext.BaseDirectory)
                        .AddXmlFile(configFile, optional: true, reloadOnChange: true)
                        .Build();

            var configSource = new ConfigurationSource(new SocketServiceConfig(string.IsNullOrEmpty(configSectionName) ? (IConfiguration)configurationRoot
                : configurationRoot.GetSection(configSectionName)));
            if (configSource == null)
                throw new InvalidOperationException("Invalid 'superSocket' or 'socketServer' configuration section.");

            bootstrap = CreateBootstrap(configSource);

            ChangeToken.OnChange(
               () => configurationRoot.GetReloadToken(),
               () =>
               {
                   Thread.Sleep(5000);
                   OnSettingChanged(bootstrap, configurationRoot);
               });

            return bootstrap;
#endif
        }

#if NETSTANDARD2_0     
        /// <summary>
        /// Configuration changed callback
        /// </summary>
        /// <param name="state"></param>
        private static void OnSettingChanged(IBootstrap bootstrap,IConfigurationRoot configurationRoot)
        {
            var configSource = new ConfigurationSource(new SocketServiceConfig(configurationRoot));
            if (configSource == null)
                return;
          
            foreach (var serverConfig in configSource.Servers)
            {
                var server = bootstrap.AppServers.FirstOrDefault(x =>
                        x.Name.Equals(serverConfig.Name, StringComparison.OrdinalIgnoreCase));

                if (server == null)
                    continue;

                server.ReportPotentialConfigChange(new ServerConfig(serverConfig));
            }

            var loggerProvider = bootstrap as ILoggerProvider;
            if (loggerProvider != null)
            {
                var logger = loggerProvider.Logger;

                if (logger != null)
                    logger.Info("Configuraton reloaded!");
            }
        }
#endif
    }
}
