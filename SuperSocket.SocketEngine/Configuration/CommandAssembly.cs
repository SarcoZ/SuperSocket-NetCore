using SuperSocket.Common;
using SuperSocket.SocketBase.Config;
#if !NETSTANDARD2_0
using System.Configuration;
#else
using Microsoft.Extensions.Configuration;
#endif

namespace SuperSocket.SocketEngine.Configuration
{
#if !NETSTANDARD2_0
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
#else
    public class CommandAssembly : ICommandAssemblyConfig
    {
        /// <summary>
        /// Gets the assembly name.
        /// </summary>
        /// <value>
        /// The assembly.
        /// </value>       
        public string Assembly { get; set; }       
    }

    /// <summary>
    /// Command assembly configuation collection
    /// </summary>  
    public class CommandAssemblyCollection : GenericConfigurationElementCollectionBase<CommandAssembly, ICommandAssemblyConfig>
    {

    }


#endif
}
