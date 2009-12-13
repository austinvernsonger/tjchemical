using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr
{
    /// <summary>
    /// Interface of a queue. Act as FIFO.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueue<T> : IContainer
    {
        /// <summary>
        /// Add an object to the queue.
        /// </summary>
        /// <param name="obj">The object to be add.</param>
        /// <returns>Add Statue</returns>
        bool Add( ref T obj );

        /// <summary>
        /// Get the object from the queue.
        /// The object should be remove from the queue.
        /// </summary>
        /// <returns>The object</returns>
        T Get( );
    }
}
