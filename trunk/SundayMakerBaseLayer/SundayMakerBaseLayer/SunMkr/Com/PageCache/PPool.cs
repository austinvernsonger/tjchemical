using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace SunMkr.Com.PageCache
{
    /// <summary>
    /// Page Pool
    /// </summary>
    public class PPool : IContainer
    {
        object lockObj = null;

        /// <summary>
        /// Default Pool Size, 30 pages.
        /// </summary>
        public static int DefaultPoolSize = 30;

        /// <summary>
        /// Default Timeout, 15 minutes.
        /// </summary>
        public static int DefaultTimeOut = 15;

        int m_poolSize = 0;
        /// <summary>
        /// Pool size.
        /// </summary>
        /// <exception cref="Exception">Too Small Pool Size</exception>
        public int PoolSize
        {
            get { return m_poolSize; }
            set 
            {
                lock ( lockObj )
                {
                    if ( value < m_hashPool.Count )
                        throw new Exception( "New pool size is to small to contain all cached pages." );
                    m_poolSize = value;
                }
            }
        }

        Hashtable m_hashPool = null;
        Hashtable m_cacheTime = null;
        Hashtable m_lastActive = null;

        #region IContainer Members

        /// <summary>
        /// Clear the pool
        /// </summary>
        public void Clear( )
        {
            lock ( lockObj )
            {
                m_hashPool.Clear( );
            }
            //throw new NotImplementedException( );
        }

        /// <summary>
        /// If Is Empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                lock ( lockObj )
                {
                    return m_hashPool.Count == 0;
                }
            }
        }

        /// <summary>
        /// If Full
        /// </summary>
        public bool IsFull
        {
            get 
            {
                lock ( lockObj )
                {
                    return m_hashPool.Count == m_poolSize;
                }
            }
        }

        #endregion

        /// <summary>
        /// Construction
        /// </summary>
        public PPool( )
        {
            lockObj = new object( );
            m_poolSize = DefaultPoolSize;
            m_hashPool = new Hashtable( );
            m_cacheTime = new Hashtable( );
            m_lastActive = new Hashtable( );
        }

        /// <summary>
        /// Pool's Construction
        /// </summary>
        /// <param name="PoolSize"></param>
        public PPool( int PoolSize )
        {
            lockObj = new object( );
            m_poolSize = PoolSize;
            m_hashPool = new Hashtable( );
            m_cacheTime = new Hashtable( );
            m_lastActive = new Hashtable( );
        }

        /// <summary>
        /// Add a URL to the pool.
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="TimeOut"></param>
        public void Add( string Url, int TimeOut )
        {
            try
            {
                lock ( lockObj )
                {
                    if ( m_hashPool.ContainsKey( Url ) )
                        throw new Exception( string.Format( "'{0}' has existed in the pool.", Url ) );
                }
                if ( this.IsFull )
                    throw new Exception( "Pool is full." );
                // Open the query page in the background.
                WebResponse rtnResponse = WebRequest.Create( Url ).GetResponse( );
                StreamReader stmReader = new StreamReader( rtnResponse.GetResponseStream( ) );
                lock ( lockObj )
                {
                    m_hashPool.Add( Url, stmReader.ReadToEnd( ) );
                    m_cacheTime.Add( Url, TimeOut );
                    m_lastActive [Url] = DateTime.Now;
                }
            }
            catch
            {
                // On error return empty string.
                // return null;
                throw new Exception( string.Format( "'{0}' can not accessed.", Url ) );
            }
        }

        /// <summary>
        /// Add a URL to the pool.
        /// </summary>
        /// <param name="Url"></param>
        /// <exception cref="Exception">Pool size full</exception>
        /// <exception cref="Exception">Unreachable URL</exception>
        /// <exception cref="Exception">URL existed in pool</exception>
        public void Add( string Url )
        {
            this.Add( Url, DefaultTimeOut );
        }

        /// <summary>
        /// Get all URLs in the pool
        /// </summary>
        /// <returns></returns>
        public string [] GetUrls( )
        {
            lock ( lockObj )
            {
                ArrayList _ = new ArrayList(m_hashPool.Keys);
                //m_hashPool
                return _.ToArray( ) as string [];
            }
        }

        /// <summary>
        /// Remove the Url.
        /// </summary>
        /// <param name="Url"></param>
        public void Remove( string Url )
        {
            lock ( lockObj )
            {
                try
                {
                    m_hashPool.Remove( Url );
                    m_cacheTime.Remove( Url );
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Return the page.
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public string this [string Url]
        {
            get
            {
                lock ( lockObj )
                {
                    if ( !m_hashPool.ContainsKey( Url ) )
                        return string.Empty;
                    // The page never expired.
                    if ( (int)m_cacheTime [Url] == 0 )
                        return m_hashPool [Url] as string;
                }
                TimeSpan ts = DateTime.Now - ( (DateTime)m_lastActive [Url] );
                if ( ts.Minutes > (int)m_cacheTime [Url] )
                    this.ForceRefresh( Url );
                lock(lockObj)
                {
                    return m_hashPool [Url] as string;
                }
            }
        }

        /// <summary>
        /// Force the cache to refresh the page.
        /// </summary>
        /// <param name="Url"></param>
        /// <exception cref="Exception">Pool size full</exception>
        /// <exception cref="Exception">Unreachable URL</exception>
        /// <exception cref="Exception">URL existed in pool</exception>
        public void ForceRefresh( string Url )
        {
            int nTimeOut = DefaultTimeOut;
            lock ( lockObj )
            {
                if ( !m_hashPool.ContainsKey( Url ) ) return;
                m_hashPool.Remove( Url );
                // Remove TimeOut
                nTimeOut = (int)m_cacheTime [Url];
                m_cacheTime.Remove( Url );
            }
            this.Add( Url, nTimeOut );
        }

        /// <summary>
        /// Refresh All
        /// </summary>
        public void RefreshAll( )
        {
            Array _keys = this.GetUrls( );
            lock ( lockObj )
            {
                m_hashPool.Clear( );
            }
            foreach ( string _key in _keys )
            {
                int nTimeOut = (int)m_cacheTime [_key];
                m_cacheTime.Remove( _key );
                this.Add( _key, nTimeOut );
            }
        }
    }
}
