using SuperSocket.SocketBase;
using System;
using System.Net.Sockets;

namespace SuperSocket.SocketEngine.AsyncSocket
{
    /// <summary>
    /// Socket async eventArgs proxy
    /// </summary>
    class SocketAsyncEventArgsProxy
    {
        /// <summary>
        /// SocketAsyncEventArgs
        /// </summary>
        public SocketAsyncEventArgs SocketEventArgs { get; private set; }

        /// <summary>
        /// Original offset
        /// </summary>
        public int OrigOffset { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsRecyclable { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        private SocketAsyncEventArgsProxy()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="socketEventArgs"></param>
        public SocketAsyncEventArgsProxy(SocketAsyncEventArgs socketEventArgs)
            : this(socketEventArgs, true)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="socketEventArgs"></param>
        /// <param name="isRecyclable"></param>
        public SocketAsyncEventArgsProxy(SocketAsyncEventArgs socketEventArgs, bool isRecyclable)
        {
            SocketEventArgs = socketEventArgs;
            OrigOffset = socketEventArgs.Offset;
            SocketEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(SocketEventArgs_Completed);
            IsRecyclable = isRecyclable;
        }

        /// <summary>
        /// SocketEventArgs completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void SocketEventArgs_Completed(object sender, SocketAsyncEventArgs e)
        {
            var socketSession = e.UserToken as IAsyncSocketSession;

            if (socketSession == null)
                return;

            if (e.LastOperation != SocketAsyncOperation.Receive)
                throw new ArgumentException("The last operation completed on the socket was not a receive");

            socketSession.AsyncRun(() => socketSession.ProcessReceive(e));
        }

        /// <summary>
        /// Initialize socketEventArgs
        /// </summary>
        /// <param name="socketSession"></param>
        public void Initialize(IAsyncSocketSession socketSession) => SocketEventArgs.UserToken = socketSession;

        /// <summary>
        /// Reset socketEventArgs
        /// </summary>
        public void Reset() => SocketEventArgs.UserToken = null;
    }
}
