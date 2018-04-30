using SuperSocket.SocketBase.Metadata;
using System;

namespace SuperSocket.SocketEngine
{
    [Serializable]
    class ServerTypeMetadata
    {
        public StatusInfoAttribute[] StatusInfoMetadata { get; set; }

        public bool IsServerManager { get; set; }
    }
}
