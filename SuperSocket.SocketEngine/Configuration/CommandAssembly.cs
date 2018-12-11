using SuperSocket.Common;
using SuperSocket.SocketBase.Config;
using System.Configuration;

namespace SuperSocket.SocketEngine.Configuration
{
    /// <summary>
    /// Command assembly configuration element
    /// </summary>
    public class CommandAssembly : ConfigurationElement, ICommandAssemblyConfig
    {
        /// <summary>
        /// Gets the assembly name.
        /// </summary>
        /// <value>
        /// The assembly.
        /// </value>
        [ConfigurationProperty("assembly", IsRequired = false)]
        public string Assembly
        {
            get { return this["assembly"] as string; }
        }
    }

    /// <summary>
    /// Command assembly configuation collection
    /// </summary>
    [ConfigurationCollection(typeof(CommandAssembly))]
    public class CommandAssemblyCollection : GenericConfigurationElementCollectionBase<CommandAssembly, ICommandAssemblyConfig>
    {

    }
}
