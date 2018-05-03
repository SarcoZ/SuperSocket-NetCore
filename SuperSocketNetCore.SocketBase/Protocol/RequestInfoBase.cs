using System;

using Microsoft.Extensions.DependencyInjection;

namespace SuperSocket.SocketBase.Protocol
{
    public abstract class RequestInfoBase : IRequestInfo
    {
        private bool _disposed = false;
        private readonly IServiceScope _serviceScope;

        protected RequestInfoBase(IServiceScope serviceScope)
        {
            _serviceScope = serviceScope;
        }

        public abstract string Key { get; protected set; }

        public IServiceProvider ServiceProvider => _serviceScope.ServiceProvider;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose any managed objects
                    _serviceScope.Dispose();
                }

                // Now disposed of any unmanaged objects
                _disposed = true;
            }
        }

        // Destructor
        ~RequestInfoBase()
        {
            Dispose(false);
        }
    }
}