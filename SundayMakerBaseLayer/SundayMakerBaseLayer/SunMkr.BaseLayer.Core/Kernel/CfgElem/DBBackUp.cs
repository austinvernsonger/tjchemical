using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SunMkr.Kernel.CfgElem
{
    /// <summary>
    /// Database Backup
    /// </summary>
    public class DBBackUp : ICloneable, ICfgElem
    {
        string m_name = string.Empty;
        /// <summary>
        /// Name of the element.
        /// </summary>
        public string Name
        {
            get { return m_name; }
            set { m_name = value.Clone( ) as string; }
        }
        string m_source = string.Empty;
        /// <summary>
        /// Source Provider.
        /// </summary>
        public string Source
        {
            get { return m_source; }
            set { m_source = value.Clone( ) as string; }
        }
        string m_dbpath = string.Empty;
        /// <summary>
        /// Database Path
        /// </summary>
        public string DBPath
        {
            get { return m_dbpath; }
            set { m_dbpath = value.Clone( ) as string; }
        }
        string m_dbname = string.Empty;
        /// <summary>
        /// Database's Name
        /// </summary>
        public string DBName
        {
            get { return m_dbname; }
            set { m_dbname = value.Clone( ) as string; }
        }
        string m_dbusername = string.Empty;
        /// <summary>
        /// Username of a database connection
        /// </summary>
        public string UserName
        {
            get { return m_dbusername; }
            set { m_dbusername = value.Clone( ) as string; }
        }
        string m_dbpassword = string.Empty;
        /// <summary>
        /// Password of a database connection
        /// </summary>
        public string Password
        {
            get { return m_dbpassword; }
            set { m_dbpassword = value.Clone( ) as string; }
        }

        #region ICloneable Members

        /// <summary>
        /// Clone the object
        /// </summary>
        /// <returns></returns>
        public object Clone( )
        {
            //throw new NotImplementedException( );
            DBBackUp bkupObj = new DBBackUp( );
            bkupObj.m_name = this.Name.Clone( ) as string;
            bkupObj.m_source = this.Source.Clone( ) as string;
            bkupObj.m_name = this.DBName.Clone( ) as string;
            bkupObj.m_dbpath = this.DBPath.Clone( ) as string;
            bkupObj.m_dbusername = this.UserName.Clone( ) as string;
            bkupObj.m_dbpassword = this.Password.Clone( ) as string;
            return bkupObj;
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
            XmlElement xmlDbBackup = xml.CreateElement( "DBBackUp" );
            xmlDbBackup.Attributes ["Name"].InnerText = this.Name;
            xmlDbBackup.Attributes ["Source"].InnerText = this.Source;
            // Child Nodes
            XmlElement xmlDBPath = xml.CreateElement( "DBPath" );
            XmlElement xmlDBName = xml.CreateElement( "DBName" );
            XmlElement xmlUserName = xml.CreateElement( "UserName" );
            XmlElement xmlPassword = xml.CreateElement( "Password" );
            xmlDBPath.InnerText = this.DBPath;
            xmlDBName.InnerText = this.DBName;
            xmlUserName.InnerText = this.UserName;
            xmlPassword.InnerText = this.Password;

            // Append Child Nodes.
            xmlDbBackup.AppendChild( xmlDBPath );
            xmlDbBackup.AppendChild( xmlDBName );
            xmlDbBackup.AppendChild( xmlUserName );
            xmlDbBackup.AppendChild( xmlPassword );

            // return
            return xmlDbBackup;
        }

        /// <summary>
        /// Generate the DBBackUp Element.
        /// </summary>
        /// <param name="node"></param>
        public void FromXmlNode( XmlNode node )
        {
            if ( node == null ) throw new NullReferenceException( "Node can not be null." );
            // Check Node Name
            if ( node.Name != "DBBackUp" )
                throw new ArgumentException( "The node is not DBBackUp." );

            // Get value.
            this.Name = node.Attributes ["Name"].InnerText;
            this.Source = node.Attributes ["Source"].InnerText;
            foreach ( XmlNode _n in node.ChildNodes )
            {
                if ( _n.Name == "DBPath" )
                    this.DBPath = _n.InnerText;
                else if ( _n.Name == "DBName" )
                    this.DBName = _n.InnerText;
                else if ( _n.Name == "UserName" )
                    this.UserName = _n.InnerText;
                else if ( _n.Name == "Password" )
                    this.Password = _n.InnerText;
            }
        }

        /// <summary>
        /// The keyword
        /// </summary>
        public string KeyWord
        {
            get { return this.Name; }
        }

        #endregion
    }
}
