using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr
{
    /// <summary>
    /// The abstract class version of ICache
    /// </summary>
    /// <typeparam name="Key">Key Type</typeparam>
    /// <typeparam name="Value">Value Type</typeparam>
    public abstract class ACache<Key, Value> : ICache<Key, Value>
    {

        #region ICache<Key,Value> Methods

        /// <summary>
        /// Add new object to the cache
        /// </summary>
        /// <param name="_key">Key to the object</param>
        /// <param name="_val">The object value</param>
        public abstract void Add( Key _key, Value _val );

        /// <summary>
        /// Get the object form the cache
        /// </summary>
        /// <param name="_key">The key specified the value object</param>
        /// <returns>The value object</returns>
        public abstract Value Get( Key _key );

        /// <summary>
        /// Remove the Item in the cache.
        /// </summary>
        /// <param name="_key">Key specified</param>
        public abstract void Remove( Key _key );

        /// <summary>
        /// Clear the cache.
        /// </summary>
        public abstract void Clear( );

        /// <summary>
        /// If the cache is empty
        /// </summary>
        public abstract bool IsEmpty
        {
            get; 
        }

        /// <summary>
        /// If the cache is full
        /// </summary>
        public abstract bool IsFull
        {
            get ;
        }

        #endregion
    }
}
