using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace SunMkr.Com.PageCache
{
    /// <summary>
    /// QueryString
    /// </summary>
    public class QueryStrings : IContainer, ICache<string, string>, ICloneable
    {
        StringDictionary m_qstr = null;
        object lockObj;

        /// <summary>
        /// Default Construction.
        /// </summary>
        public QueryStrings( )
        {
            m_qstr = new StringDictionary( );
            lockObj = new object( );
        }

        /// <summary>
        /// Gets or sets Key and Value
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string this [string Key]
        {
            get 
            {
                lock ( lockObj )
                {
                    if ( m_qstr.ContainsKey( Key ) )
                        return m_qstr [Key];
                    else return string.Empty;
                }
            }
            set
            {
                lock ( lockObj )
                {
                    m_qstr [Key] = value;
                }
            }
        }

        #region IContainer Members

        /// <summary>
        /// Clear the container
        /// </summary>
        public void Clear( )
        {
            //throw new NotImplementedException( );
            lock ( lockObj )
            {
                m_qstr.Clear( );
            }
        }

        /// <summary>
        /// If empty
        /// </summary>
        public bool IsEmpty
        {
            get 
            {
                lock ( lockObj )
                {
                    return m_qstr.Count == 0;
                }
            }
        }

        /// <summary>
        /// If full
        /// </summary>
        public bool IsFull
        {
            get { /*throw new NotImplementedException( );*/ return false; }
        }

        #endregion

        #region ICache<string,string> Members

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="_key"></param>
        /// <param name="_val"></param>
        public void Add( string _key, string _val )
        {
            //throw new NotImplementedException( );
            this [_key] = _val;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="_key"></param>
        /// <returns></returns>
        public string Get( string _key )
        {
            //throw new NotImplementedException( );
            return this [_key];
        }

        /// <summary>
        /// Remove the item.
        /// </summary>
        /// <param name="_key"></param>
        public void Remove( string _key )
        {
            //throw new NotImplementedException( );
            lock ( lockObj )
            {
                m_qstr.Remove( _key );
            }
        }

        #endregion

        /// <summary>
        /// Generate the query string.
        /// </summary>
        /// <returns></returns>
        public override string ToString( )
        {
            string rtn = "?";
            lock ( lockObj )
            {
                foreach ( string _key in m_qstr.Keys )
                {
                    rtn += string.Format( "{0}={1}&", _key, m_qstr [_key] );
                }
            }
            // remove the last '&' or the only '?'
            rtn.Remove( rtn.Length - 1 );
            return rtn;
            //return base.ToString( );
        }

        #region ICloneable Members

        /// <summary>
        /// Clone the query string.
        /// </summary>
        /// <returns></returns>
        public object Clone( )
        {
            //throw new NotImplementedException( );
            QueryStrings obj = new QueryStrings( );
            lock ( lockObj )
            {
                foreach ( string _key in m_qstr.Keys )
                {
                    obj.m_qstr [_key] = m_qstr [_key];
                }
            }
            return obj;
        }

        #endregion
    }
}
