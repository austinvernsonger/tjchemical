using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SunMkr.Kernel.CfgElem
{
    /// <summary>
    /// File Location
    /// </summary>
    public class FileLocation : ICloneable, ICfgElem
    {
        string m_id = string.Empty;
        /// <summary>
        /// Identify of File Location Element.
        /// </summary>
        public string ID
        {
            get { return m_id; }
            set { m_id = value.Clone( ) as string; }
        }

        string m_path = string.Empty;
        /// <summary>
        /// File Path.
        /// </summary>
        public string Path
        {
            get { return m_path; }
            set { m_path = value.Clone( ) as string; }
        }

        #region ICloneable Members

        /// <summary>
        /// Get a cloned object.
        /// </summary>
        /// <returns></returns>
        public object Clone( )
        {
            //throw new NotImplementedException( );
            FileLocation fl = new FileLocation( );
            fl.m_id = this.m_id.Clone( ) as string;
            fl.m_path = this.m_path.Clone( ) as string;
            return fl;
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
            XmlElement xmlFileLocation = xml.CreateElement( "FileLocation" );
            xmlFileLocation.Attributes ["ID"].InnerText = this.ID;
            xmlFileLocation.Attributes ["Path"].InnerText = this.Path;

            return xmlFileLocation;
        }

        /// <summary>
        /// Generate a FileLocation structure from a XmlNode
        /// </summary>
        /// <param name="node"></param>
        public void FromXmlNode( XmlNode node )
        {
            //throw new NotImplementedException( );
            if ( node == null ) throw new NullReferenceException( "Node can not be null." );
            // Check Node Name
            if ( node.Name != "FileLocation" )
                throw new ArgumentException( "The node is not FileLocation." );

            // Get value.
            this.ID = node.Attributes ["ID"].InnerText;
            this.Path = node.Attributes ["Path"].InnerText;
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
