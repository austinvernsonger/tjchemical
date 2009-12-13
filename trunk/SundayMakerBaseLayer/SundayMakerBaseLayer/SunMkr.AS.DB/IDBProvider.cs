using System;
using System.Collections.Generic;
using System.Text;
using SunMkr.Kernel.CfgElem;
using System.Data;
using SunMkr.Proc;

namespace SunMkr.AS
{
    /// <summary>
    /// The Delegate of the Call back function used in TransAction
    /// The function can only do the method provided by IProcessor,
    /// those are: Execute, Query, Producer(2), Transaction.
    /// @Author: Push
    /// </summary>
    /// <returns></returns>
    public delegate Boolean delDoTransaction( );

    /// <summary>
    /// Provider.
    /// </summary>
    public interface IDBProvider : IProvider
    {
        /// <summary>
        /// The connection.
        /// </summary>
        string ConnectionStr { set; }

        /// <summary>
        /// The flag of statue.
        /// </summary>
        bool IsStarted { get; }

        /// <summary>
        /// Generate the connection string.
        /// </summary>
        /// <param name="DBP"></param>
        void GenerateConnString( DBProvider DBP );

        /// <summary>
        /// Generate the backup connection string.
        /// </summary>
        /// <param name="DBB"></param>
        void GenerateBackUpString( DBBackUp DBB );
        /// <summary>
        /// Execute an SQL sentance.
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        object Execute( string Sql );

        /// <summary>
        /// Query the database.
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        DataSet Query( string Sql );

        /// <summary>
        /// Producer.
        /// </summary>
        /// <param name="ProducerName">Producer name</param>
        /// <param name="HasReturnValue">If has Return Value</param>
        /// <param name="ReturnValue">The object to recivie the return value.</param>
        /// <param name="Parameters">Parameters.</param>
        /// <returns></returns>
        DataSet Producer(
            string ProducerName,
            bool HasReturnValue,
            out object ReturnValue,
            params object [] Parameters
            );

        /// <summary>
        /// Producer.
        /// </summary>
        /// <param name="ProducerName">Producer name</param>
        /// <param name="ReturnValue">The object to recivie the return value.</param>
        /// <param name="Parameters">Parameters.</param>
        /// <returns></returns>
        DataSet Producer(
            string ProducerName,
            out object ReturnValue,
            params object [] Parameters
            );

        /// <summary>
        /// Producer.
        /// </summary>
        /// <param name="ProducerName">Producer name</param>
        /// <param name="Parameters">Parameters.</param>
        /// <returns></returns>
        DataSet Producer(
            string ProducerName,
            params object [] Parameters
            );

        /// <summary>
        /// Trans Action with the provider's connection and command
        /// </summary>
        /// <param name="DelegateTransaction"></param>
        /// <returns></returns>
        bool Transaction( delDoTransaction DelegateTransaction );
    }
}
