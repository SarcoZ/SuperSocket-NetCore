using SuperSocket.SocketBase.Logging;

namespace SuperSocket.SocketBase.Config
{
    /// <summary>
    /// LogFactory Interface
    /// </summary>
    public interface ILogFactory
    {
        /// <summary>
        /// Gets the log by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        ILog GetLog(string name);
    }
}
