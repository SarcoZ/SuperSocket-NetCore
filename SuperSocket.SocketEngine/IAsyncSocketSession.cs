using SuperSocket.SocketBase;
using SuperSocket.SocketEngine.AsyncSocket;
using System.Net.Sockets;

namespace SuperSocket.SocketEngine
{
    interface IAsyncSocketSessionBase : ILoggerProvider
    {
        SocketAsyncEventArgsProxy SocketAsyncProxy { get; }

        Socket Client { get; }
    }

    interface IAsyncSocketSession : IAsyncSocketSessionBase
    {
        void ProcessReceive(SocketAsyncEventArgs e);
    }
}
