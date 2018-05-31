#if !NETSTANDARD2_0
using System.Configuration;
#else
using Microsoft.Extensions.Configuration;
#endif

namespace SuperSocket.SocketBase.Config
{
    /// <summary>
    /// Type provider configuration
    /// </summary>
#if !NETSTANDARD2_0
    public class TypeProvider : ConfigurationElement, ITypeProvider
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return this["name"] as string; }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return this["type"] as string; }
        }
    }
#else
    public class TypeProvider : ITypeProvider
    {      
        /// <summary>
        /// Gets the name.
        /// </summary>     
        public string Name { get; set; }


        /// <summary>
        /// Gets the type.
        /// </summary>     
        public string Type { get; set; }      
    }    
#endif
}
