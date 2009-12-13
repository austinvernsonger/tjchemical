using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.SessionState;
using SunMkr.Kernel.Handler;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Reflection;

namespace SunMkr.Kernel
{
    /// <summary>
    /// Handler to process *.sm
    /// </summary>
    public class SunMkrHandler : IHttpHandler, IRequiresSessionState
    {
        static Hashtable m_PageMap;
        //static bool m_bInited = false;

        /// <summary>
        /// Initialize the Hanlder
        /// </summary>
        static protected void Initialize(HttpContext context)
        {
            // Web Resource
            HtmlPage.SunMkrCss = GetWebResourceUrl(typeof(SunMkrHandler), "SunMkr.SunMkr.css");
            m_PageMap = new Hashtable();
            m_PageMap["error.sm"] = new ErrorHandler();
            m_PageMap["login.sm"] = new LoginHandler();
            m_PageMap["admin.sm"] = new AdminHandler();
            m_PageMap["logout.sm"] = new LogoutHandler();
            m_PageMap["administrators.sm"] = new AdministratorsHandler();
            m_PageMap["modules.sm"] = new ModulesHandler();
            m_PageMap["recenterrors.sm"] = new RecentErrorsHandler();
            m_PageMap["websitesettings.sm"] = new WebsiteSettingsHandler();
        }

        #region IHttpHandler Members

        /// <summary>
        /// Interface of IHttpHandler
        /// </summary>
        public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        /// Process Request Method
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            if (m_PageMap == null) Initialize(context);
            string _page = context.Request.Path.Substring(context.Request.Path.LastIndexOf('/') + 1);
            if ( !m_PageMap.ContainsKey( _page ) )
                ( m_PageMap ["error.sm"] as ISunMkrHandler ).SunMkrHandler( context );
            else if ( _page == "error.sm" )
                context.Response.Redirect( "admin.sm" );
            else
            {
                if ( context.Session ["_sm_admin"] == null ||
                    string.IsNullOrEmpty( context.Session ["_sm_admin"] as string ) )
                    ( m_PageMap ["login.sm"] as ISunMkrHandler ).SunMkrHandler( context );
                else
                    ( m_PageMap [_page] as ISunMkrHandler ).SunMkrHandler( context );
            }
        }

        #endregion

        /// <summary>
        /// <para>
        ///	Composes a full url to be used when referencing a	resource of this type
        ///	and with the specified name.
        /// </para>
        /// </summary>
        /// <param name="type">Type of the resource.</param>
        /// <param name="resourceName">Name of the embedded resource.</param>
        /// <returns>Url to retrieve this particular resource.</returns>
        public static string GetWebResourceUrl(Type type, string resourceName)
        {
            Type t = typeof(System.Web.Handlers.AssemblyResourceLoader);
            object[] args = new object[] { type, resourceName, true };

            BindingFlags bindingFlags = 
                BindingFlags.DeclaredOnly | 
                BindingFlags.Static | 
                BindingFlags.NonPublic | 
                BindingFlags.InvokeMethod;

            return (string)(t.InvokeMember("GetWebResourceUrl", bindingFlags, null, null, args));
        }

        /// <summary>
        /// Get Manifest Resource Stream
        /// </summary>
        /// <param name="ResourceName"></param>
        /// <returns></returns>
        public static Stream GetManifestResourceStream( string ResourceName )
        {
            Assembly _a = typeof( SunMkrHandler ).Assembly;
            return _a.GetManifestResourceStream( ResourceName );
        }
    }
}
