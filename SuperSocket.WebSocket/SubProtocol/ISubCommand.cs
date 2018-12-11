using SuperSocket.SocketBase.Command;

namespace SuperSocket.WebSocket.SubProtocol
{
    /// <summary>
    /// SubCommand interface
    /// </summary>
    /// <typeparam name="TWebSocketSession">The type of the web socket session.</typeparam>
    public interface ISubCommand<TWebSocketSession> : ICommand
        where TWebSocketSession : WebSocketSession<TWebSocketSession>, new()
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="requestInfo">The request info.</param>
        void ExecuteCommand(TWebSocketSession session, SubRequestInfo requestInfo);
    }
}
