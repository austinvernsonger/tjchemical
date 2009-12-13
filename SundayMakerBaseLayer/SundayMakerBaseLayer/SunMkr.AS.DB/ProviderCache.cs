using System;
using System.Collections.Generic;
using System.Text;
using SunMkr;

namespace SunMkr.AS
{
    /// <summary>
    /// Provider's Cache.
    /// </summary>
    class ProviderCache : IQueue<IDBProvider>
    {
        Stack<IDBProvider> stackCache = null;
        int m_MaxCount = 0;
        int m_CurrentCount = 0;
        object lockObj = null;

        /// <summary>
        /// Construction.
        /// </summary>
        /// <param name="MaxCount"></param>
        public ProviderCache( int MaxCount )
        {
            m_MaxCount = MaxCount;
            stackCache = new Stack<IDBProvider>( );
            lockObj = new object( );
        }

        #region IQueue<IDBProvider> Members

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add( ref IDBProvider obj )
        {
            //throw new NotImplementedException( );
            if ( this.IsFull ) return false;
            lock ( lockObj )
            {
                stackCache.Push( obj );
                ++m_CurrentCount;
            }
            return true;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public IDBProvider Get( )
        {
            //throw new NotImplementedException( );
            if ( this.IsEmpty ) return null;
            lock ( lockObj )
            {
                --m_CurrentCount;
                return stackCache.Pop( );
            }
        }

        #endregion

        #region IContainer Members

        /// <summary>
        /// Cleare
        /// </summary>
        public void Clear( )
        {
            //throw new NotImplementedException( );
            lock ( lockObj )
            {
                stackCache.Clear( );
            }
        }

        /// <summary>
        /// Is Empty
        /// </summary>
        public bool IsEmpty
        {
            get 
            {
                lock ( lockObj )
                {
                    return stackCache.Count == 0;
                }
            }
        }

        /// <summary>
        /// Is Full.
        /// </summary>
        public bool IsFull
        {
            get
            {
                return m_CurrentCount == m_MaxCount;
            }
        }

        #endregion
    }
}
