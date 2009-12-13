using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SunMkr.Kernel.CfgElem
{
    /// <summary>
    /// Database Provider
    /// </summary>
    public class DBProvider : ICloneable, ICfgElem
    {
        string m_name = string.Empty;
        /// <summary>
        /// DBProvider's Name, Identify.
        /// </summary>
        public string Name
        {
            get { return m_name; }
            set { m_name = value.Clone( ) as string; }
        }
        int m_maxConn = 0;
        /// <summary>
        /// Max Connection Count.
        /// </summary>
        public int MaxConnection
        {
            get { return m_maxConn; }
            set { m_maxConn = value; }
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
        DatabaseType m_dbtype = DatabaseType.UnSupport;
        /// <summary>
        /// Database's Type
        /// </summary>
        public DatabaseType DBType
        {
            get { return m_dbtype; }
            set { m_dbtype = value; }
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
        /// Clone the object.
        /// </summary>
        /// <returns></returns>
        public object Clone( )
        {
            //throw new NotImplementedException( );
            DBProvider newProvider = new DBProvider( );
            newProvider.m_name = this.m_name.Clone( ) as string;
            newProvider.m_maxConn = this.m_maxConn;
            newProvider.m_dbpath = this.m_dbpath.Clone( ) as string;
            newProvider.m_dbname = this.m_dbname.Clone( ) as string;
            newProvider.m_dbtype = this.m_dbtype;
            newProvider.m_dbusername = this.m_dbusername.Clone( ) as string;
            newProvider.m_dbpassword = this.m_dbpassword.Clone( ) as string;
            return newProvider;
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

            XmlElement xmlDBProvider = xml.CreateElement( "DBProvider" );
            xmlDBProvider.Attributes ["Name"].InnerText = this.Name;
            xmlDBProvider.Attributes ["MaxConn"].InnerText = this.MaxConnection.ToString( );
            xmlDBProvider.Attributes ["Type"].InnerText = this.DBType.ToString( );

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
            xmlDBProvider.AppendChild( xmlDBPath );
            xmlDBProvider.AppendChild( xmlDBName );
            xmlDBProvider.AppendChild( xmlUserName );
            xmlDBProvider.AppendChild( xmlPassword );

            // return;
            return xmlDBProvider;
        }

        /// <summary>
        /// Generate a DBProvider from the XmlNode
        /// </summary>
        /// <param name="node"></param>
        public void FromXmlNode( XmlNode node )
        {
            if ( node == null ) throw new NullReferenceException( "Node can not be null." );
            // Check Node Name
            if ( node.Name != "DBProvider" )
                throw new ArgumentException( "The node is not DBProvider." );

            // Get value.
            this.Name = node.Attributes ["Name"].InnerText;
            this.MaxConnection = Convert.ToInt32( node.Attributes ["MaxConn"].InnerText );
            this.DBType = (DatabaseType) Enum.Parse( 
                typeof( DatabaseType ), node.Attributes ["Type"].InnerText );
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
