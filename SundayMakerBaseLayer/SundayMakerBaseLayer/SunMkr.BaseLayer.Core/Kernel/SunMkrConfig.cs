using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using SunMkr.Com.Literal;
using SunMkr.Kernel.CfgElem;

namespace SunMkr.Kernel
{
    /// <summary>
    /// SunMkr Config.xml
    /// </summary>
    public class SunMkrConfig : ILifeCycle
    {
        static SunMkrConfig m_instance = new SunMkrConfig( );
        XmlDocument xmlConfig = null;
        XmlNode xmlSunMkrCfg = null;

        List<CfgElem.ICfgElem> m_elements;

        /// <summary>
        /// Private Construction.
        /// </summary>
        private SunMkrConfig( )
        {
            xmlConfig = new XmlDocument( );
            m_elements = new List<ICfgElem>( );
        }

        /// <summary>
        /// Get the instance of the SunMkrConfig.
        /// </summary>
        public static SunMkrConfig Instance
        {
            get { return m_instance; }
        }

        #region ILifeCycle Members

        /// <summary>
        /// Load the configuration file
        /// </summary>
        /// <returns></returns>
        public bool Start( )
        {
            if ( m_elements != null )
                m_elements.Clear( );
            m_elements = new List<ICfgElem>( );
            //throw new NotImplementedException( );
            string _name = MD5Hash.GetMD5Hash("Config.xml");
            string _path = AppDomain.CurrentDomain.BaseDirectory + _name;
            FileInfo fi = new FileInfo( _path );
            // Check the config.xml
            if ( !fi.Exists )
            {
                StreamReader sr = new StreamReader(
                    SunMkrHandler.GetManifestResourceStream( "SunMkr.Config.xml" ) );
                StreamWriter sw = new StreamWriter( _path );
                try
                {
                    sw.Write( sr.ReadToEnd( ) );
                    sw.Close( );
                }
                catch { return false; }
            }
            // Load the xml
            xmlConfig.Load( _path );
            try
            {
                foreach ( XmlNode _1st in xmlConfig.ChildNodes )
                {
                    if ( _1st.Name != "SunMkrCfg" ) continue;
                    xmlSunMkrCfg = _1st;
                    foreach ( XmlNode cfg in _1st.ChildNodes )
                    {
                        if ( cfg.Name == "DBProvider" )
                        {
                            DBProvider dbp = new DBProvider( );
                            dbp.FromXmlNode( cfg );
                            m_elements.Add( dbp );
                        }
                        else if ( cfg.Name == "DBBackUp" )
                        {
                            DBBackUp dbb = new DBBackUp( );
                            dbb.FromXmlNode( cfg );
                            m_elements.Add( dbb );
                        }
                        else if ( cfg.Name == "FileLocation" )
                        {
                            FileLocation fl = new FileLocation( );
                            fl.FromXmlNode( cfg );
                            m_elements.Add( fl );
                        }
                        else if ( cfg.Name == "CacheGroup" )
                        {
                            CacheGroup cg = new CacheGroup( );
                            cg.FromXmlNode( cfg );
                            m_elements.Add( cg );
                        }
                    }
                    break;
                }
            }
            catch { return false; }

            return true;
        }

        /// <summary>
        /// Release the source
        /// </summary>
        /// <returns></returns>
        public bool End( )
        {
            //throw new NotImplementedException( );
            m_elements.Clear( );
            return true;
        }

        /// <summary>
        /// Reload the resource
        /// </summary>
        /// <returns></returns>
        public bool Restart( )
        {
            //throw new NotImplementedException( );
            this.End( );
            return this.Start( );
        }

        #endregion

        /// <summary>
        /// Save the config.xml
        /// </summary>
        public void Save( )
        {
            xmlConfig.Save( AppDomain.CurrentDomain.BaseDirectory + 
                MD5Hash.GetMD5Hash( "Config.xml" ) );
        }

        /// <summary>
        /// Get the Element.
        /// </summary>
        /// <param name="elemType"></param>
        /// <param name="KeyWord"></param>
        /// <returns></returns>
        public ICfgElem GetElement( Type elemType, string KeyWord )
        {
            foreach ( ICfgElem elem in m_elements )
            {
                if ( elem.GetType( ).Equals( elemType ) )
                {
                    if ( elem.KeyWord == KeyWord ) return elem;
                }
            }
            return null;
        }

        /// <summary>
        /// Add Element
        /// </summary>
        /// <param name="elem"></param>
        public void AddElement( ICfgElem elem )
        {
            m_elements.Add( elem );
        }

        /// <summary>
        /// Remove a specified element.
        /// </summary>
        /// <param name="elemToRemove"></param>
        public void RemoveElement( ICfgElem elemToRemove )
        {
            try
            {
                m_elements.Remove( elemToRemove );
            }
            catch { }
        }
    }
}
