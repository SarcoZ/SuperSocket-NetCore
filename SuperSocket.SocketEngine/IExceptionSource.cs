using SuperSocket.Common;
using System;

namespace SuperSocket.SocketEngine
{
    interface IExceptionSource
    {
        event EventHandler<ErrorEventArgs> ExceptionThrown;
    }
}
