using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr
{
    /// <summary>
    /// Abstarct class version of the interface IContainer.
    /// </summary>
    public abstract class AContainer : IContainer
    {
        #region IContainer 成员

        /// <summary>
        /// Clear all elements in the container
        /// </summary>
        public abstract void Clear( );

        /// <summary>
        /// If the container is empty.
        /// </summary>
        public abstract bool IsEmpty
        {
            get;
        }

        /// <summary>
        /// If the container is full.
        /// </summary>
        public abstract bool IsFull
        {
            get;
        }

        #endregion
    }
}
