using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SunMkr.AS
{
    /// <summary>
    /// The global operation.
    /// </summary>
    public static class DbGOp
    {
        static string global_bound_provider = string.Empty;

        /// <summary>
        /// Execute the producer.
        /// </summary>
        /// <param name="ProviderName">DBProvider's Name</param>
        /// <param name="ProducerName">Producer's Name</param>
        /// <param name="Parameters">Parameters to be sent to the producer.</param>
        /// <returns>The dataset returned by the producer.</returns>
        public static DataSet Do(string ProviderName, string ProducerName, params object[] Parameters)
        {
            genericOp gOp = new genericOp(ProviderName);
            gOp.SetParameter(ProducerName, false, Parameters);
            return gOp.Do() ? gOp.Result : null;
        }

        /// <summary>
        /// Execute the producer.
        /// </summary>
        /// <param name="ProviderName">DBProvider's Name</param>
        /// <param name="ProducerName">Producer's Name</param>
        /// <param name="ReturnValue">The object to receive the return value of the producer.</param>
        /// <param name="Parameters">Parameters to be sent to the producer.</param>
        /// <returns>The dataset returned by the producer.</returns>
        public static DataSet Do(string ProviderName, string ProducerName, out object ReturnValue, params object[] Parameters)
        {
            genericOp gOp = new genericOp(ProviderName);
            gOp.SetParameter(ProducerName, true, Parameters);
            if (gOp.Do())
            {
                ReturnValue = gOp.ReturnValue;
                return gOp.Result;
            }
            ReturnValue = null;
            return null;
        }

        /// <summary>
        /// Execute the producer with the global bound provider.
        /// </summary>
        /// <param name="ProducerName">Producer's Name</param>
        /// <param name="ReturnValue">The object to receive the return value of the producer.</param>
        /// <param name="Parameters">Parameters to be sent to the producer.</param>
        /// <returns>The dataset returned by the producer.</returns>
        public static DataSet Do(string ProducerName, out object ReturnValue, params object[] Parameters)
        {
            return Do(global_bound_provider, ProducerName, out ReturnValue, Parameters);
        }

        /// <summary>
        /// Execute the producer with the global bound provider.
        /// </summary>
        /// <param name="UseGlobal">UseGlobal</param>
        /// <param name="ProducerName">Producer's Name</param>
        /// <param name="Parameters">Parameters to be sent to the producer.</param>
        /// <returns>The dataset returned by the producer.</returns>
        public static DataSet Do(bool UseGlobal, string ProducerName, params object[] Parameters)
        {
            return Do(global_bound_provider, ProducerName, Parameters);
        }

        /// <summary>
        /// Execute the producer with only return value.
        /// </summary>
        /// <param name="ProviderName">DBProvider's Name</param>
        /// <param name="ProducerName">Producer's Name</param>
        /// <param name="Parameters">Parameters to be sent to the producer.</param>
        /// <returns>The Return Value</returns>
        public static object Execute(string ProviderName, string ProducerName, params object[] Parameters)
        {
            genericOp gOp = new genericOp(ProviderName);
            gOp.SetParameter(ProducerName, true, Parameters);
            return gOp.Do() ? gOp.ReturnValue : null;
        }

        /// <summary>
        /// Execute the producer with only return value and global bound provider.
        /// </summary>
        /// <param name="UseGlobal">UseGlobal</param>
        /// <param name="ProducerName">Producer's Name</param>
        /// <param name="Parameters">Parameters to be sent to the producer.</param>
        /// <returns>he Return Value</returns>
        public static object Execute(bool UseGlobal, string ProducerName, params object[] Parameters)
        {
            return Execute(global_bound_provider, ProducerName, Parameters);
        }

        /// <summary>
        /// Bind a provider of the global use.
        /// </summary>
        /// <param name="ProviderName">DBProvider's Name</param>
        public static void GlobalBindSingleProvider(string ProviderName)
        {
            global_bound_provider = ProviderName;
        }
    }
}
