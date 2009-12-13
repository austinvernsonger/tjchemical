using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr
{
    /// <summary>
    /// Interface of a container.
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Clear all elements in the container.
        /// </summary>
        void Clear( );

        /// <summary>
        /// If this container is empty.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// If this container is full.
        /// </summary>
        bool IsFull { get; }
    }
}
