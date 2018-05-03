using System;
using System.Text;

namespace SuperSocket.SocketBase.Protocol
{
    /// <summary>
    /// CommandLine RequestFilter Factory
    /// </summary>
    public class CommandLineReceiveFilterFactory : TerminatorReceiveFilterFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineReceiveFilterFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">A container for service objects.</param>
        public CommandLineReceiveFilterFactory(IServiceProvider serviceProvider)
            : this(Encoding.ASCII, serviceProvider)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineReceiveFilterFactory"/> class.
        /// </summary>
        /// <param name="encoding">The encoding.</param>
        /// <param name="serviceProvider">A container for service objects.</param>
        public CommandLineReceiveFilterFactory(Encoding encoding, IServiceProvider serviceProvider)
            : this(encoding, new BasicRequestInfoParser(serviceProvider))
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineReceiveFilterFactory"/> class.
        /// </summary>
        /// <param name="encoding">The encoding.</param>
        /// <param name="requestInfoParser">The request info parser.</param>
        public CommandLineReceiveFilterFactory(Encoding encoding, IRequestInfoParser<StringRequestInfo> requestInfoParser)
            : base("\r\n", encoding, requestInfoParser)
        {

        }
    }
}
