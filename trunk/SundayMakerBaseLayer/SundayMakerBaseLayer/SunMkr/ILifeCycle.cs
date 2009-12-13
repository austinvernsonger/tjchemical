using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr
{
    /// <summary>
    /// Life Cycle of an Server
    /// </summary>
    public interface ILifeCycle
    {
        /// <summary>
        /// Start the server.
        /// </summary>
        /// <returns></returns>
        bool Start();

        /// <summary>
        /// Terminate the server.
        /// </summary>
        /// <returns></returns>
        bool End();

        /// <summary>
        /// Restart the server.
        /// </summary>
        /// <returns></returns>
        bool Restart();
    }
}
