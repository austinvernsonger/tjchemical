using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;

namespace SunMkr.Kernel.CfgElem
{
    /// <summary>
    /// Cache Group
    /// </summary>
    public class CacheGroup : ICloneable, ICfgElem
    {
        /// <summary>
        /// Internal Class: CachePage.
        /// As a child node of CacheGroup.
        /// </summary>
        internal class CachePage : ICloneable, ICfgElem
        {
            string m_relative = string.Empty;
            /// <summary>
            /// Relative Path
            /// </summary>
            public string RelativePath
            {
                get { return m_relative; }
                set { m_relative = value.Clone( ) as string; }
            }

            int m_timeout = 0;
            /// <summary>
            /// Time Out of the cache.
            /// </summary>
            public int TimeOut
            {
                get { return m_timeout; }
                set { m_timeout = value; }
            }

            #region ICloneable Members

            /// <summary>
            /// Clone a Cache Page
            /// </summary>
            /// <returns></returns>
            public object Clone( )
            {
                //throw new NotImplementedException( );
                CachePage cp = new CachePage( );
                cp.m_timeout = this.m_timeout;
                cp.m_relative = this.m_relative.Clone( ) as string;
                return cp;
            }

            #endregion

            #region ICfgElem Members

            /// <summary>
            /// To XmlNode
            /// </summary>
            /// <returns></returns>
            public XmlNode ToXmlNode( )
            {
                //throw new NotImplementedException( );
                XmlDocument xml = new XmlDocument( );
                XmlElement xmlPage = xml.CreateElement( "Page" );
                xmlPage.Attributes ["Relative"].InnerText = this.RelativePath;
                xmlPage.Attributes ["TimeOut"].InnerText = this.TimeOut.ToString( );

                return xmlPage;
            }

            public void FromXmlNode( XmlNode node )
            {
                //throw new NotImplementedException( );
                if ( node == null ) throw new NullReferenceException( "Node can not be null." );
                // Check Node Name
                if ( node.Name != "Page" )
                    throw new ArgumentException( "The node is not CacheGroup/Page." );

                this.RelativePath = node.Attributes ["Relative"].InnerText;
                this.TimeOut = Convert.ToInt32( node.Attributes ["TimeOut"].InnerText );
            }

            /// <summary>
            /// The keyword
            /// </summary>
            public string KeyWord
            {
                get { return this.RelativePath; }
            }

            #endregion
        }

        string m_id = string.Empty;
        /// <summary>
        /// Cache Group ID
        /// </summary>
        public string ID
        {
            get { return m_id; }
            set { m_id = value.Clone( ) as string; }
        }
        string m_name = string.Empty;
        /// <summary>
        /// Cache Group Name
        /// </summary>
        public string Name
        {
            get { return m_name; }
            set { m_name = value.Clone( ) as string; }
        }
        int m_groupSize = 0;
        /// <summary>
        /// Group Size
        /// </summary>
        public int GroupSize
        {
            get { return m_groupSize; }
            set { m_groupSize = value; }
        }

        Hashtable m_pages = null;
        /// <summary>
        /// Gets or sets the timeout of a cached page.
        /// </summary>
        /// <param name="Relative"></param>
        /// <returns></returns>
        public int this [string Relative]
        {
            get
            {
                if ( m_pages.ContainsKey( Relative ) )
                    return ( m_pages [Relative] as CachePage ).TimeOut;
                return 0;
            }
            set
            {
                if ( m_pages.ContainsKey( Relative ) )
                    ( m_pages [Relative] as CachePage ).TimeOut = value;
            }
        }

        /// <summary>
        /// Remove the cached page.
        /// </summary>
        /// <param name="Relative"></param>
        public void Remove( string Relative )
        {
            try
            {
                m_pages.Remove( Relative );
            }
            catch { }
        }

        /// <summary>
        /// Add a cached page element.
        /// </summary>
        /// <param name="Relative"></param>
        /// <param name="TimeOut"></param>
        public void Add( string Relative, int TimeOut )
        {
            CachePage cp = new CachePage( );
            cp.RelativePath = Relative;
            cp.TimeOut = TimeOut;
            try
            {
                m_pages.Add( Relative, cp );
            }
            catch { }
        }

        /// <summary>
        /// Default Construction
        /// </summary>
        public CacheGroup( )
        {
            this.m_pages = new Hashtable( );
        }

        #region ICloneable Members

        /// <summary>
        /// Clone a CacheGroup
        /// </summary>
        /// <returns></returns>
        public object Clone( )
        {
            //throw new NotImplementedException( );
            CacheGroup cg = new CacheGroup( );
            cg.ID = this.m_id;
            cg.Name = this.m_name;
            cg.GroupSize = this.m_groupSize;
            cg.m_pages = this.m_pages.Clone( ) as Hashtable;

            return cg;
        }

        #endregion

        #region ICfgElem Members

        /// <summary>
        /// To XmlNode
        /// </summary>
        /// <returns></returns>
        public XmlNode ToXmlNode( )
        {
            //throw new NotImplementedException( );
            XmlDocument xml = new XmlDocument( );
            XmlNode xmlCacheGroup = xml.CreateElement( "CacheGroup" );
            xmlCacheGroup.Attributes ["ID"].InnerText = this.ID;
            xmlCacheGroup.Attributes ["Name"].InnerText = this.Name;
            xmlCacheGroup.Attributes ["GroupSize"].InnerText = this.GroupSize.ToString( );

            foreach ( CachePage cp in this.m_pages.Values )
            {
                xmlCacheGroup.AppendChild( cp.ToXmlNode( ) );
            }

            return xmlCacheGroup;
        }

        /// <summary>
        /// Generate a CacheGroup from XmlNode.
        /// </summary>
        /// <param name="node"></param>
        /// <exception cref="ArgumentException">Repeat Page ID</exception>
        public void FromXmlNode( System.Xml.XmlNode node )
        {
            //throw new NotImplementedException( );
            if ( node == null ) throw new NullReferenceException( "Node can not be null." );
            // Check Node Name
            if ( node.Name != "CacheGroup" )
                throw new ArgumentException( "The node is not CacheGroup." );

            this.ID = node.Attributes ["ID"].InnerText;
            this.Name = node.Attributes ["Name"].InnerText;
            this.GroupSize = Convert.ToInt32( node.Attributes ["GroupSize"].InnerText );

            foreach ( XmlNode xmlCP in node.ChildNodes )
            {
                CachePage cp = new CachePage( );
                cp.FromXmlNode( xmlCP );
                m_pages.Add( cp.RelativePath, cp );
            }
        }

        /// <summary>
        /// The keyword
        /// </summary>
        public string KeyWord
        {
            get { return this.ID; }
        }

        #endregion
    }
}
