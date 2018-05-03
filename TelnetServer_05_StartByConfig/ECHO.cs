using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace TelnetServer_05_StartByConfig
{
    public class ECHO : RequestScopeCommandBase<TelnetSession, StringRequestInfo>
    {
        private readonly ITest _test;

        public ECHO(ITest test)
        {
            _test = test;
        }

        public override void ExecuteCommand(TelnetSession session, StringRequestInfo requestInfo)
        {
            session.Send(requestInfo.Body);
        }
    }
}
