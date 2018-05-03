using System;

using Microsoft.Extensions.DependencyInjection;

namespace SuperSocket.SocketBase.Protocol
{
    /// <summary>
    /// Basic request info parser, which parse request info by separating
    /// </summary>
    public class BasicRequestInfoParser : IRequestInfoParser<StringRequestInfo>
    {
        private readonly string m_Spliter;

        private readonly IServiceProvider _serviceProvider;

        private readonly string[] m_ParameterSpliters;

        private const string m_OneSpace = " ";

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicRequestInfoParser"/> class.
        /// </summary>
        /// <param name="serviceProvider">A container for service objects.</param>
        public BasicRequestInfoParser(IServiceProvider serviceProvider)
            : this(m_OneSpace, m_OneSpace, serviceProvider)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicRequestInfoParser"/> class.
        /// </summary>
        /// <param name="spliter">The spliter between command name and command parameters.</param>
        /// <param name="parameterSpliter">The parameter spliter.</param>
        /// <param name="serviceProvider">A container for service objects.</param>
        public BasicRequestInfoParser(string spliter, string parameterSpliter, IServiceProvider serviceProvider)
        {
            m_Spliter = spliter;
            _serviceProvider = serviceProvider;
            m_ParameterSpliters = new string[] { parameterSpliter };
        }

        /// <summary>
        /// Parses the request info.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public StringRequestInfo ParseRequestInfo(string source)
        {
            int pos = source.IndexOf(m_Spliter);

            string name = string.Empty;
            string param = string.Empty;

            if (pos > 0)
            {
                name = source.Substring(0, pos);
                param = source.Substring(pos + m_Spliter.Length);
            }
            else
            {
                name = source;
            }

            return new StringRequestInfo(name, param,
                param.Split(m_ParameterSpliters, StringSplitOptions.RemoveEmptyEntries), _serviceProvider.CreateScope());
        }
    }
}
