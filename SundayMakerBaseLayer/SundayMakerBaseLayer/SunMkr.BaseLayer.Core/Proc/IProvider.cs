using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr.Proc
{
    /// <summary>
    /// Provider.
    /// </summary>
    public interface IProvider : ILock, ILifeCycle
    {
        /// <summary>
        /// The key to identified the provider.
        /// </summary>
        Guid Key { get; }
    }
}
