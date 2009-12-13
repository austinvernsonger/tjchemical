using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr.Proc
{
    /// <summary>
    /// The Interface of Operation.
    /// </summary>
    /// <typeparam name="Provider"></typeparam>
    interface IOperation < Provider > where Provider : class, IProvider
    {
        /// <summary>
        /// My Processor.
        /// </summary>
        Provider myProc { get; set; }

        /// <summary>
        /// Process Under Control
        /// </summary>
        void processUnderControl();

        /// <summary>
        /// Do the operator
        /// </summary>
        /// <returns></returns>
        bool Do();

        /// <summary>
        /// My Bind String.
        /// </summary>
        string BindString { get; }

        /// <summary>
        /// The AS's Name.
        /// </summary>
        string ASName { get; }

        /// <summary>
        /// Get last error.
        /// </summary>
        /// <returns></returns>
        Exception GetLastError( );

        /// <summary>
        /// Set my Last error ID.
        /// </summary>
        string LastErrorID { set; }
    }
}
