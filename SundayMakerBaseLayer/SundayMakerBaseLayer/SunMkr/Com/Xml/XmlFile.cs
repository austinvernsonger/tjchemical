using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SunMkr.Com.Xml
{
    /// <summary>
    /// 
    /// </summary>
    public class XmlFile
    {
        /// <summary>
        /// Static Lock Object List.
        /// </summary>
        static Dictionary<string, object> s_FileLockObjects = new Dictionary<string, object>( );
        /// <summary>
        /// Static Adding Lock Object
        /// </summary>
        static object s_ListLockObj = new object( );

        bool            m_HasLoaded = false;
        StringBuilder   m_XmlCache;
        string          m_XmlFilePath = null;
        XmlDocument     m_XmlDoc = null;
        Dictionary<string, XmlElement> m_Nodes = null;

        /// <summary>
        /// The File Path of the XML file.
        /// Identify of XmlFile
        /// </summary>
        public string FilePah
        {
            get { return m_XmlFilePath; }
        }

        /// <summary>
        /// Get Nodes
        /// </summary>
        public Dictionary<string, XmlElement> Nodes
        {
            get { return m_Nodes; }
        }

        /// <summary>
        /// 
        /// </summary>
        public XmlFile( )
        {
            m_XmlCache = new StringBuilder( );
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="FilePath"></param>
        public XmlFile( string FilePath )
            : this( )
        {
            this.LoadXml( FilePath );
        }

        /// <summary>
        /// Load the XmL file.
        /// </summary>
        /// <param name="FilePath"></param>
        public void LoadXml( string FilePath )
        {
            if ( m_HasLoaded ) return;
            m_XmlFilePath = (string)FilePath.Clone( );
            // Add lock object.
            lock ( s_FileLockObjects )
            {
                if ( !s_FileLockObjects.ContainsKey( FilePah ) )
                    s_FileLockObjects.Add( FilePah, new object( ) );
            }
            this.ForceReload( );
            m_HasLoaded = true;
        }

        /// <summary>
        /// Force to reload the xml file.
        /// </summary>
        public void ForceReload( )
        {
            // lock and load the xml file.
            lock ( s_FileLockObjects [m_XmlFilePath] )
            {
                if ( m_XmlFilePath == string.Empty ) return;
                m_XmlDoc = new XmlDocument( );
                m_XmlDoc.Load( m_XmlFilePath );
                m_Nodes = new Dictionary<string, XmlElement>( );
                foreach ( XmlNode nodes in m_XmlDoc.ChildNodes )
                {
                    XmlElement elem = new XmlElement( nodes );
                    m_Nodes.Add( elem.Name, elem );
                }
            }
        }

        /// <summary>
        /// Save the Xml file according to the changes.
        /// </summary>
        /// <returns></returns>
        public bool SaveXml( )
        {
            lock ( s_FileLockObjects [m_XmlFilePath] )
            {
                m_XmlDoc.Save( m_XmlFilePath );
            }
            return true;
        }
    }
}
