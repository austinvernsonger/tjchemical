using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using SunMkr.Com.Literal;
using System.Reflection;
using System.IO;
using System.Collections;

namespace SunMkr.Kernel
{
    /// <summary>
    /// Authorization
    /// </summary>
    public static class Authorization
    {
        private static object lockObj = new object( );

        //private static bool bInited = false;
        private static XmlDocument m_Xml = null;
        private static XmlNode m_root = null;
        private static XmlNodeList m_xmlUsers = null;
        private static Hashtable m_UserInfo = null;

        /// <summary>
        /// Level of an administrator.
        /// </summary>
        public enum Lv
        {
            /// <summary>
            /// Root User. All permission.
            /// </summary>
            root,
            /// <summary>
            /// System User. System Statue, Database Provider, Mail Sender, Error Pool.
            /// </summary>
            system,
            /// <summary>
            /// Database Administrator. Database Provider.
            /// </summary>
            dba,
            /// <summary>
            /// Empty, Invalidate Level.
            /// </summary>
            empty
        }

        internal class UserInfo
        {
            public string UserName = string.Empty;
            public string Password = string.Empty;
            public Lv Level = Lv.empty;

            public UserInfo(string U, string P, Lv L)
            {
                UserName = U;
                Password = P;
                Level = L;
            }
        }

        private static void InitializeAuthorization()
        {
            // Check if Authorization.xml existed.
            string xmlPath = AppDomain.CurrentDomain.BaseDirectory + MD5Hash.GetMD5Hash("Authorization");
            FileInfo fiXml = new FileInfo( xmlPath );
            m_Xml = new XmlDocument();
            // Load the XML file
            lock (lockObj)
            {
                if (fiXml.Exists)
                {
                    m_Xml.Load(xmlPath);
                }
                else
                {
                    //Assembly a = typeof(Authorization).Assembly;
                    m_Xml.Load( SunMkrHandler.GetManifestResourceStream( "SunMkr.Authorization.xml" ) );
                    m_Xml.Save(xmlPath);
                }
            }
            // Get all children
            foreach (XmlNode _1st in m_Xml.ChildNodes)
            {
                if (_1st.Name != "SunMkrAuth") continue;
                m_xmlUsers = _1st.ChildNodes;
                m_root = _1st;
            }

            lock (lockObj)
            {
                m_UserInfo = new Hashtable();
                foreach (XmlNode _uer in m_xmlUsers)
                {
                    UserInfo u = new UserInfo(
                        _uer.Attributes ["username"].InnerText,
                        _uer.Attributes ["password"].InnerText,
                        (Lv)Enum.Parse( typeof( Lv ), _uer.Attributes ["level"].InnerText ) );
                    m_UserInfo.Add(u.UserName, u);
                }
                //bInited = true;
            }
        }

        /// <summary>
        /// Check the user.
        /// </summary>
        /// <param name="pUsrName"></param>
        /// <param name="pInPwd"></param>
        /// <returns></returns>
        public static bool Check( string pUsrName, string pInPwd )
        {
            if (m_UserInfo == null || m_UserInfo.Count == 0) InitializeAuthorization();

            bool rtnStatue = false;
            lock (lockObj)
            {
                if (m_UserInfo.ContainsKey(pUsrName))
                {
                    if ((m_UserInfo[pUsrName] as UserInfo).Password == MD5Hash.GetMD5Hash(pInPwd))
                        rtnStatue = true;
                }
            }
            //xml.Save( sXmlAuth );
            return rtnStatue;
        }

        /// <summary>
        /// Add a new user.
        /// </summary>
        /// <param name="pUsrName"></param>
        /// <param name="pInPwd"></param>
        /// <param name="pLevel"></param>
        /// <returns>Statue</returns>
        public static bool AddNewUser(string pUsrName, string pInPwd, Lv pLevel)
        {
            // Check Initialize
            if ( m_UserInfo == null || m_UserInfo.Count == 0 ) InitializeAuthorization( );

            if ( m_UserInfo.ContainsKey( pUsrName ) ) return false;

            // Create new node
            XmlElement newUser = m_Xml.CreateElement( "User" );
            newUser.SetAttribute( "username", pUsrName );
            newUser.SetAttribute( "password", MD5Hash.GetMD5Hash( pInPwd ) );
            newUser.SetAttribute( "level", pLevel.ToString( ) );

            lock (lockObj)
            {
                // Add to hashtable
                m_UserInfo.Add( pUsrName, new UserInfo( pUsrName, MD5Hash.GetMD5Hash( pInPwd ), pLevel ) );

                m_root.AppendChild( newUser );
            }
            // Save XML
            m_Xml.Save( AppDomain.CurrentDomain.BaseDirectory + MD5Hash.GetMD5Hash( "Authorization" ) );
            return true;
        }

        /// <summary>
        /// Delete a user.
        /// </summary>
        /// <param name="pUsrName"></param>
        /// <returns></returns>
        public static bool DeleteUser(string pUsrName)
        {
            // Check Initialize
            if (m_UserInfo == null || m_UserInfo.Count == 0) InitializeAuthorization();

            if (!m_UserInfo.ContainsKey(pUsrName)) return false;

            lock (lockObj)
            {
                //m_root.RemoveChild(
                foreach (XmlNode _rm in m_xmlUsers)
                {
                    if (_rm.Attributes["username"].InnerText == pUsrName)
                    {
                        m_root.RemoveChild(_rm);
                        break;
                    }
                }

                m_UserInfo.Remove(pUsrName);

                m_Xml.Save(AppDomain.CurrentDomain.BaseDirectory + MD5Hash.GetMD5Hash("Authorization"));
            }

            return true;
        }

        /// <summary>
        /// Change the password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static bool ChangePassword( string userName, string oldPassword, string newPassword )
        {
            // Verifired old password
            if ( Check( userName, oldPassword ) )
            {
                ForceResetPassword( userName, newPassword );
                return true;
            }
            return false;
        }

        /// <summary>
        /// Force to reset the password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="newPassword"></param>
        public static void ForceResetPassword( string userName, string newPassword )
        {
            //ChangePassword(userName, (m_UserInfo[userName] as UserInfo).Password
            lock ( lockObj )
            {
                ( m_UserInfo [userName] as UserInfo ).Password = MD5Hash.GetMD5Hash( newPassword );
                foreach ( XmlNode _rm in m_xmlUsers )
                {
                    if ( _rm.Attributes ["username"].InnerText == userName )
                    {
                        //m_root.RemoveChild( _rm );
                        _rm.Attributes ["password"].InnerText = MD5Hash.GetMD5Hash( newPassword );
                        break;
                    }
                }
                m_Xml.Save( AppDomain.CurrentDomain.BaseDirectory + MD5Hash.GetMD5Hash( "Authorization" ) );
                //return true;
            }
        }

        /// <summary>
        /// Change an administrator's level
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="newLevel"></param>
        /// <returns></returns>
        public static bool ChangeLevel( string userName, Lv newLevel )
        {
            lock ( lockObj )
            {
                ( m_UserInfo [userName] as UserInfo ).Level = newLevel;
                foreach ( XmlNode _rm in m_xmlUsers )
                {
                    if ( _rm.Attributes ["username"].InnerText == userName )
                    {
                        //m_root.RemoveChild( _rm );
                        _rm.Attributes ["level"].InnerText = newLevel.ToString( );
                        break;
                    }
                }
                m_Xml.Save( AppDomain.CurrentDomain.BaseDirectory + MD5Hash.GetMD5Hash( "Authorization" ) );
            }
            return false;
        }
    }
}
