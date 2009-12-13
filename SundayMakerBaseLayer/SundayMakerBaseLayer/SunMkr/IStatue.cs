using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr
{
    /// <summary>
    /// The interface defined the methods used by
    /// the system to gather the information from all the 
    /// subsystems.
    /// </summary>
    public interface IStatue
    {
        /// <summary>
        /// Get current statue
        /// </summary>
        /// <returns></returns>
        string CurrentStatue ( );

        /// <summary>
        /// Get the statue during the Start and End mark.
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <returns></returns>
        IDictionary<string, object> History ( string Start, string End );

        /// <summary>
        /// Clear the histroy log.
        /// </summary>
        void ClearHistory ( );
    }
}
