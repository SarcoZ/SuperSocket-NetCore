using SuperSocket.SocketBase.Metadata;
using System.Collections.Generic;

namespace SuperSocket.SocketBase.Command
{
    /// <summary>
    /// The basic interface for CommandFilter
    /// </summary>
    public interface ICommandFilterProvider
    {
        /// <summary>
        /// Gets the filters which assosiated with this command object.
        /// </summary>
        /// <returns></returns>
        IEnumerable<CommandFilterAttribute> GetFilters();
    }
}
