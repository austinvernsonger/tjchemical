using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr.Proc
{
    /// <summary>
    /// Lock the life cycle.
    /// </summary>
    public interface ILock
    {
        /// <summary>
        /// Lock the life cycle and return a token.
        /// </summary>
        /// <returns>The token.</returns>
        object LockLifeCycle( );

        /// <summary>
        /// Unlock the life cycle use the token.
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        bool UnLockLifeCycle( object Token );
    }
}
