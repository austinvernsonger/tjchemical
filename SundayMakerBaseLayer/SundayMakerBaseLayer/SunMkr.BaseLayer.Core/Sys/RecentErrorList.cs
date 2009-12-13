using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr.Sys
{
    /// <summary>
    /// RecentError
    /// </summary>
    public struct RecentError
    {
        /// <summary>
        /// The message
        /// </summary>
        public string Message;

        /// <summary>
        /// The Target
        /// </summary>
        public string Target;

        /// <summary>
        /// The Exception ID;
        /// </summary>
        public string ID;

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="target"></param>
        /// <param name="id"></param>
        public RecentError( string msg, string target, string id )
        {
            Message = msg;
            Target = target;
            ID = id;
        }
    }
}
