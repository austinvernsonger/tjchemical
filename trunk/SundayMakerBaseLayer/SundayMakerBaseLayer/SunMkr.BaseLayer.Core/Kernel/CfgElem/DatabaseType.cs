using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr.Kernel.CfgElem
{
    /// <summary>
    /// Database Type.
    /// Used to identify a DBProvider
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// MS SQL Server
        /// </summary>
        SQLDB,
        /// <summary>
        /// MS Access Database
        /// </summary>
        ACCESS,
        /// <summary>
        /// Oracle Database
        /// </summary>
        ORACLE,
        /// <summary>
        /// My SQL Server
        /// </summary>
        MYSQL,
        /// <summary>
        /// IBM DB2 Database
        /// </summary>
        DB2,
        /// <summary>
        /// Unsupport database
        /// </summary>
        UnSupport
    }
}
