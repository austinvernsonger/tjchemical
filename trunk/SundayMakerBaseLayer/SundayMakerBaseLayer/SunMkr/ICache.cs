using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SunMkr
{
    /// <summary>
    /// Interface of Cache.
    /// </summary>
    /// <typeparam name="Key">Key Type</typeparam>
    /// <typeparam name="Value">Value Type</typeparam>
    public interface ICache<Key, Value> : IContainer
    {
        /// <summary>
        /// Add an pair of Key-Value to the cache.
        /// </summary>
        /// <param name="_key"></param>
        /// <param name="_val"></param>
        void Add(Key _key, Value _val);

        /// <summary>
        /// Get the cached value by the key
        /// </summary>
        /// <param name="_key">Key specified</param>
        /// <returns>The value specified by the key</returns>
        Value Get(Key _key);

        /// <summary>
        /// Remove the item in the cache
        /// </summary>
        /// <param name="_key">Key specified</param>
        void Remove( Key _key );
    }
}
