using log4net;
using log4net.Config;
using log4net.Repository;
using System.IO;
using System.Xml;

namespace SuperSocket.SocketBase.Logging
{
    /// <summary>
    /// Log4NetLogFactory
    /// </summary>
    public class Log4NetLogFactory : LogFactoryBase
    {
        private static ILoggerRepository m_LogRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetLogFactory"/> class.
        /// </summary>
        public Log4NetLogFactory()
            : this("log4net.config")
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetLogFactory"/> class.
        /// </summary>
        /// <param name="log4netConfig">The log4net config.</param>
        public Log4NetLogFactory(string log4netConfig)
            : base(log4netConfig)
        {
            if (m_LogRepository == null)
            {
                m_LogRepository = LogManager.CreateRepository("SuperSocket");
            }


            if (!IsSharedConfig)
            {
                XmlConfigurator.Configure(m_LogRepository, new FileInfo(ConfigFile));
            }
            else
            {
                //Disable Performance logger
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFile);
                var docElement = xmlDoc.DocumentElement;
                var perfLogNode = docElement.SelectSingleNode("logger[@name='Performance']");
                if (perfLogNode != null)
                    docElement.RemoveChild(perfLogNode);
                XmlConfigurator.Configure(m_LogRepository, docElement);
            }
        }

        /// <summary>
        /// Gets the log by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public override ILog GetLog(string name)
        {
            return new Log4NetLog(LogManager.GetLogger(m_LogRepository.Name, name));
        }
    }
}
