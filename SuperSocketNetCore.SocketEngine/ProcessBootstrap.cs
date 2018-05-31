using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
#if !NETSTANDARD2_0
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
#endif
using System.Text;

namespace SuperSocket.SocketEngine
{
    class DefaultBootstrapProcessWrap : DefaultBootstrapAppDomainWrap
    {
        public DefaultBootstrapProcessWrap(IBootstrap bootstrap, IConfigurationSource config, string startupConfigFile)
            : base(bootstrap, config, startupConfigFile)
        {

        }

        protected override IWorkItem CreateWorkItemInstance(
            string serviceTypeName,
            StatusInfoAttribute[] serverStatusMetadata)
        {
            return new ProcessAppServer(serviceTypeName, serverStatusMetadata, ServiceProvider);
        }
    }

    class ProcessBootstrap : AppDomainBootstrap
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessBootstrap" /> class.
        /// </summary>
        /// <param name="config">The config.</param>
        /// <param name="serviceProvider">A container for service objects.</param>
        public ProcessBootstrap(IConfigurationSource config, IServiceProvider serviceProvider)
            : base(config, serviceProvider)
        {
#if !NETSTANDARD2_0
            var clientChannel = ChannelServices.RegisteredChannels.FirstOrDefault(c => c is IpcClientChannel);

            if (clientChannel == null)
            {
                // Create the channel.
                clientChannel = new IpcClientChannel();
                // Register the channel.
                ChannelServices.RegisterChannel(clientChannel, false);
            }
#endif
        }

        protected override IBootstrap CreateBootstrapWrap(IBootstrap bootstrap, IConfigurationSource config, string startupConfigFile)
        {
            return new DefaultBootstrapProcessWrap(bootstrap, config, startupConfigFile);
        }
    }
}
