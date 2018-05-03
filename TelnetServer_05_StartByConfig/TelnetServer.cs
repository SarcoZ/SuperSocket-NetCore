using System;
using System.Collections.Generic;

using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;

namespace TelnetServer_05_StartByConfig
{
    public class TelnetServer : AppServer<TelnetSession>
    {
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

        protected override void OnStarted()
        {
            base.OnStarted();
        }

        protected override void OnStopped()
        {
            base.OnStopped();
        }

        protected override bool SetupCommandLoaders(List<ICommandLoader<ICommand<TelnetSession, StringRequestInfo>>> commandLoaders)
        {
            return base.SetupCommandLoaders(commandLoaders);
        }

        public TelnetServer(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public TelnetServer(IReceiveFilterFactory<StringRequestInfo> receiveFilterFactory, IServiceProvider serviceProvider)
            : base(receiveFilterFactory, serviceProvider)
        {
        }
    }
}
