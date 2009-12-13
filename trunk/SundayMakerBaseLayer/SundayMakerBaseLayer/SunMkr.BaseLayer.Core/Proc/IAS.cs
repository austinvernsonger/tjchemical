using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr.Proc
{
    /// <summary>
    /// Interface of Abstarct System.
    /// </summary>
    /// <typeparam name="Provider"></typeparam>
    public interface IAS<Provider> : ILifeCycle where Provider : class, IProvider
    {
        /// <summary>
        /// Get a provider via the specified keyword
        /// </summary>
        /// <param name="KeyWord"></param>
        /// <returns></returns>
        Provider GetProvider(string KeyWord);

        /// <summary>
        /// Release the provider.
        /// </summary>
        /// <param name="KeyWord"></param>
        /// <param name="UsedProvider"></param>
        void ReleaseProvider( string KeyWord, Provider UsedProvider );
        
        /// <summary>
        /// Start Current Provider.
        /// </summary>
        /// <param name="CurrentProvider"></param>
        /// <returns></returns>
        bool StartProvider( Provider CurrentProvider );

        /// <summary>
        /// The statue of current AS.
        /// </summary>
        ASStatue Statue { get; set; }
    }
}
