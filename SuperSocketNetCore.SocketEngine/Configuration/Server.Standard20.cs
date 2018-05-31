#if NETSTANDARD2_0
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
#endif
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace SuperSocket.SocketEngine.Configuration
{
#if NETSTANDARD2_0
    public partial class Server : IServerConfig
    {
        public string Name { get; set; }

        /// <summary>
        /// Gets the name of the server type this appServer want to use.
        /// </summary>
        /// <value>
        /// The name of the server type.
        /// </value>     
        public string ServerTypeName { get; set; }

        /// <summary>
        /// Gets the type definition of the appserver.
        /// </summary>
        /// <value>
        /// The type of the server.
        /// </value>       
        public string ServerType { get; set; }

        /// <summary>
        /// Gets the Receive filter factory.
        /// </summary>     
        public string ReceiveFilterFactory { get; set; }

        /// <summary>
        /// Gets the ip.
        /// </summary>       
        public string Ip { get; set; }

        /// <summary>
        /// Gets the port.
        /// </summary>    
        public int Port { get; set; }

        /// <summary>
        /// Gets the mode.
        /// </summary>        
        public SocketMode Mode { get; set; } = SocketMode.Tcp;

        /// <summary>
        /// Gets a value indicating whether this <see cref="IServerConfig"/> is disabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disabled; otherwise, <c>false</c>.
        /// </value>      
        public bool Disabled { get; set; }

        /// <summary>
        /// Gets the send time out.
        /// </summary>      
        public int SendTimeOut { get; set; } = ServerConfig.DefaultSendTimeout;

        /// <summary>
        /// Gets the max connection number.
        /// </summary>       
        public int MaxConnectionNumber { get; set; } = ServerConfig.DefaultMaxConnectionNumber;

        /// <summary>
        /// Gets the size of the receive buffer.
        /// </summary>
        /// <value>
        /// The size of the receive buffer.
        /// </value>      
        public int ReceiveBufferSize { get; set; } = ServerConfig.DefaultReceiveBufferSize;

        /// <summary>
        /// Gets the size of the send buffer.
        /// </summary>
        /// <value>
        /// The size of the send buffer.
        /// </value>        
        public int SendBufferSize { get; set; } = ServerConfig.DefaultSendBufferSize;

        /// <summary>
        /// Gets a value indicating whether sending is in synchronous mode.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [sync send]; otherwise, <c>false</c>.
        /// </value>
        public bool SyncSend { get; set; } = false;

        /// <summary>
        /// Gets a value indicating whether log command in log file.
        /// </summary>
        /// <value><c>true</c> if log command; otherwise, <c>false</c>.</value>      
        public bool LogCommand { get; set; } = false;

        /// <summary>
        /// Gets a value indicating whether [log basic session activity like connected and disconnected].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [log basic session activity]; otherwise, <c>false</c>.
        /// </value>     
        public bool LogBasicSessionActivity { get; set; }

        /// <summary>
        /// Gets a value indicating whether [log all socket exception].
        /// </summary>
        /// <value>
        /// <c>true</c> if [log all socket exception]; otherwise, <c>false</c>.
        /// </value>       
        public bool LogAllSocketException { get; set; }

        /// <summary>
        /// Gets a value indicating whether clear idle session.
        /// </summary>
        /// <value><c>true</c> if clear idle session; otherwise, <c>false</c>.</value>       
        public bool ClearIdleSession { get; set; }

        /// <summary>
        /// Gets the clear idle session interval, in seconds.
        /// </summary>
        /// <value>The clear idle session interval.</value>       
        public int ClearIdleSessionInterval { get; set; } = ServerConfig.DefaultClearIdleSessionInterval;

        /// <summary>
        /// Gets the idle session timeout time length, in seconds.
        /// </summary>
        /// <value>The idle session time out.</value>       
        public int IdleSessionTimeOut { get; set; } = ServerConfig.DefaultIdleSessionTimeOut;

        /// <summary>
        /// Gets the certificate config.
        /// </summary>
        /// <value>The certificate config.</value>       
        public CertificateConfig CertificateConfig { get; set; }

        
        /// <summary>
        /// Gets the security protocol, X509 certificate.
        /// </summary>      
        public string Security { get; set; } = "None";

        /// <summary>
        /// Gets the max allowed length of request.
        /// </summary>
        /// <value>
        /// The max allowed length of request.
        /// </value>       
        public int MaxRequestLength { get; set; } = ServerConfig.DefaultMaxRequestLength;

        /// <summary>
        /// Gets a value indicating whether [disable session snapshot]
        /// </summary>       
        public bool DisableSessionSnapshot { get; set; }

        /// <summary>
        /// Gets the interval to taking snapshot for all live sessions.
        /// </summary>      
        public int SessionSnapshotInterval { get; set; } = ServerConfig.DefaultSessionSnapshotInterval;

        /// <summary>
        /// Gets the connection filters used by this server instance.
        /// </summary>
        /// <value>
        /// The connection filters's name list, seperated by comma
        /// </value>       
        public string ConnectionFilter { get; set; }

        /// <summary>
        /// Gets the command loader, multiple values should be separated by comma.
        /// </summary>        
        public string CommandLoader { get; set; }

        /// <summary>
        /// Gets the start keep alive time, in seconds
        /// </summary>       
        public int KeepAliveTime { get; set; } = ServerConfig.DefaultKeepAliveTime;

        /// <summary>
        /// Gets the keep alive interval, in seconds.
        /// </summary>       
        public int KeepAliveInterval { get; set; } = ServerConfig.DefaultKeepAliveInterval;

        /// <summary>
        /// Gets the backlog size of socket listening.
        /// </summary>      
        public int ListenBacklog { get; set; } = ServerConfig.DefaultListenBacklog;

        /// <summary>
        /// Gets the startup order of the server instance.
        /// </summary>      
        public int StartupOrder { get; set; }

        /// <summary>
        /// Gets/sets the size of the sending queue.
        /// </summary>
        /// <value>
        /// The size of the sending queue.
        /// </value>      
        public int SendingQueueSize { get; set; } = ServerConfig.DefaultSendingQueueSize;

        /// <summary>
        /// Gets the logfactory name of the server instance.
        /// </summary>      
        public string LogFactory { get; set; }

        /// <summary>
        /// Gets the default text encoding.
        /// </summary>
        /// <value>
        /// The text encoding.
        /// </value>     
        public string TextEncoding { get; set; }

        /// <summary>
        /// Gets the listeners' configuration.
        /// </summary>       
        public List<Listener> Listeners { get; set; }

        /// <summary>
        /// Gets the command assemblies configuration.
        /// </summary>
        /// <value>
        /// The command assemblies.
        /// </value>     
        public CommandAssemblyCollection CommandAssemblies { get; set; }

        public NameValueCollection Options { get; set; }

        public NameValueCollection OptionElements { get; set; }

        public string DefaultCulture { get; set; }

       
        public TConfig GetChildConfig<TConfig>(string childConfigName) where TConfig : class, new()
        {
            return GetChildConfig<TConfig>(childConfigName);
        }       
    }
#endif
}
