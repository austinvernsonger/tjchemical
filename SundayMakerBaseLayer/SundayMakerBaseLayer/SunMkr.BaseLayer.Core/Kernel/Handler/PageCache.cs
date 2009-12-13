using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace SunMkr.Kernel.Handler
{
    class PageCache : ICache<string, string>
    {
        StringDictionary _page_pool = new StringDictionary( );
        object lockObj = new object( );

        #region ICache<string,string> Members

        /// <summary>
        /// Add Page
        /// </summary>
        /// <param name="_key"></param>
        /// <param name="_val"></param>
        public void Add( string _key, string _val )
        {
            //throw new NotImplementedException( );
            lock ( lockObj )
            {
                _page_pool [_key] = _val.Clone( ) as string;
            }
        }

        /// <summary>
        /// Get Page
        /// </summary>
        /// <param name="_key"></param>
        /// <returns></returns>
        public string Get( string _key )
        {
            //throw new NotImplementedException( );
            lock ( lockObj )
            {
                if ( _page_pool.ContainsKey( _key ) )
                    return _page_pool [_key].Clone( ) as string;
                else return string.Empty;
            }
        }

        /// <summary>
        /// Remove a page
        /// </summary>
        /// <param name="_key"></param>
        public void Remove( string _key )
        {
            //throw new NotImplementedException( );
            lock ( lockObj )
            {
                try
                {
                    _page_pool.Remove( _key );
                }
                catch { }
            }
        }

        #endregion

        #region IContainer Members

        /// <summary>
        /// Clear Cache
        /// </summary>
        public void Clear( )
        {
            //throw new NotImplementedException( );
            lock ( lockObj )
            {
                _page_pool.Clear( );
            }
        }

        /// <summary>
        /// Is Empty
        /// </summary>
        public bool IsEmpty
        {
            get 
            { 
                //throw new NotImplementedException( ); 
                lock ( lockObj )
                {
                    return _page_pool.Count == 0;
                }
            }
        }

        /// <summary>
        /// Is Full
        /// </summary>
        public bool IsFull
        {
            get 
            { 
                //throw new NotImplementedException( ); 
                return false;
            }
        }

        #endregion
    }
}
