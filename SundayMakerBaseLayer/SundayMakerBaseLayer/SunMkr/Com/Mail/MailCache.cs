using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using SunMkr;

namespace SunMkr.Com.Mail
{
    /// <summary>
    /// Mail Message Cache.
    /// </summary>
    class MailCache : IQueue<MailItem>
    {
        /// <summary>
        /// The mail queue.
        /// </summary>
        private Queue<MailItem> m_queue;

        /// <summary>
        /// The max number of the queue can contain.
        /// </summary>
        private int m_maxCount;

        /// <summary>
        /// Current elements the queue contained.
        /// </summary>
        private int m_currentCount;

        /// <summary>
        /// Object to use as lock object.
        /// </summary>
        private object lockObj;

        /// <summary>
        /// Construction of the mail cache.
        /// </summary>
        /// <param name="MaxCount"></param>
        public MailCache( int MaxCount )
        {
            m_maxCount = MaxCount;
            m_currentCount = 0;
            m_queue = new Queue<MailItem>( );
            lockObj = new object( );
        }

        /// <summary>
        /// Default Construction set the default max count to 20.
        /// </summary>
        public MailCache( )
            : this( 20 )
        { }

        #region IQueue<MailItem> 成员

        public bool Add( ref MailItem obj )
        {
            //throw new NotImplementedException( );
            if ( this.IsFull ) return false;
            lock ( lockObj )
            {
                m_queue.Enqueue( obj );
                ++m_currentCount;
            }
            return true;
        }

        public MailItem Get( )
        {
            //throw new NotImplementedException( );
            if ( this.IsEmpty ) return null;
            lock ( lockObj )
            {
                --m_currentCount;
                return m_queue.Dequeue( );
            }
        }

        #endregion

        #region IContainer 成员

        public void Clear( )
        {
            //throw new NotImplementedException( );
            lock ( lockObj )
            {
                m_queue.Clear( );
                m_currentCount = 0;
            }
        }

        public bool IsEmpty
        {
            get 
            {
                lock ( lockObj )
                {
                    return ( m_queue.Count == 0 );
                }
                //throw new NotImplementedException( ); 
            }
        }

        public bool IsFull
        {
            get 
            {
                lock ( lockObj )
                {
                    return ( m_currentCount >= m_maxCount );
                }
                //throw new NotImplementedException( ); 
            }
        }

        #endregion
    }
}
