﻿using System.Collections.Generic;

namespace SuperSocket.WebSocket.SubProtocol
{
    /// <summary>
    /// The basic interface of sub command filter loader
    /// </summary>
    public interface ISubCommandFilterLoader
    {
        /// <summary>
        /// Loads the sub command filters.
        /// </summary>
        /// <param name="globalFilters">The global filters.</param>
        void LoadSubCommandFilters(IEnumerable<SubCommandFilterAttribute> globalFilters);
    }
}
