using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr
{
    /// <summary>
    /// Abstract class version of the interface IQueue
    /// </summary>
    /// <typeparam name="T">Type of the object</typeparam>
    public abstract class AQueue<T> : IQueue<T>
    {
        /// <summary>
        /// Add an object to the Queue
        /// </summary>
        /// <param name="obj">The object to be added.</param>
        /// <returns>Add Statue</returns>
        public abstract bool Add( ref T obj );

        /// <summary>
        /// Get the first object in the queue.
        /// The object will be removed after the user get it.
        /// </summary>
        /// <returns>The first object.</returns>
        public abstract T Get( );

        /// <summary>
        /// Clear the Queue.
        /// </summary>
        public abstract void Clear( );

        /// <summary>
        /// If the queue is empty
        /// </summary>
        public abstract bool IsEmpty
        {
            get;
        }

        /// <summary>
        /// If the queue is full.
        /// </summary>
        public abstract bool IsFull
        {
            get;
        }
    }
}
