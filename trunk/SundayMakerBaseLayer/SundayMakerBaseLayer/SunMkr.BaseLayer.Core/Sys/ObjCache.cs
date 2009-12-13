using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SunMkr.Sys
{
    class ObjCache : IQueue<XmlNode>
    {
        Queue<XmlNode> m_queue;
        object lockObj;
        int m_MaxCount;
        int m_CurrentCount = 0;

        /// <summary>
        /// Construction of ObjCache
        /// </summary>
        public ObjCache( ) : this(10)
        { }

        /// <summary>
        /// Construction with specified Max Count.
        /// </summary>
        /// <param name="MaxCount"></param>
        public ObjCache( int MaxCount )
        {
            m_queue = new Queue<XmlNode>( );
            m_MaxCount = MaxCount;
            lockObj = new object( );
        }

        #region IQueue<XmlNode> Members

        /// <summary>
        /// Add XmlNode to cache.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add( ref XmlNode obj )
        {
            //throw new NotImplementedException( );
            if ( this.IsFull ) return false;
            lock ( lockObj )
            {
                m_queue.Enqueue( obj );
                ++m_CurrentCount;
            }
            return true;
        }

        /// <summary>
        /// Get an XmlNode
        /// </summary>
        /// <returns></returns>
        public XmlNode Get( )
        {
            //throw new NotImplementedException( );
            if ( this.IsEmpty ) return null;
            lock ( lockObj )
            {
                --m_CurrentCount;
                return m_queue.Dequeue( );
            }
        }

        #endregion

        #region IContainer Members

        /// <summary>
        /// Clear the cache.
        /// </summary>
        public void Clear( )
        {
            //throw new NotImplementedException( );
            lock ( lockObj )
            {
                m_queue.Clear( );
            }
        }

        public bool IsEmpty
        {
            get 
            { 
                //throw new NotImplementedException( ); 
                lock ( lockObj )
                {
                    return m_queue.Count == 0;
                }
            }
        }

        public bool IsFull
        {
            get 
            { 
                // throw new NotImplementedException( ); 
                lock ( lockObj )
                {
                    return m_MaxCount == m_queue.Count;
                }
            }
        }

        #endregion
    }
}
