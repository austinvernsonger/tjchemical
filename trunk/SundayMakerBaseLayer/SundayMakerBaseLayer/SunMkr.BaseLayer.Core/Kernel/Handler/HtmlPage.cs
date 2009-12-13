using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.IO;

namespace SunMkr.Kernel.Handler
{
    /// <summary>
    /// An html page framework
    /// </summary>
    class HtmlPage
    {
        string m_html_begin;
        string m_html_end;
        string m_html_body;
        /// <summary>
        /// The Cache
        /// </summary>
        static PageCache m_cache = new PageCache( );

        static string m_SunMkrCss = string.Empty;
        /// <summary>
        /// SunMkr.css 's file Path
        /// </summary>
        public static string SunMkrCss
        {
            get { return m_SunMkrCss; }
            set { m_SunMkrCss = value; }
        }

        /// <summary>
        /// Default Construction with title 'Untitled Page'
        /// </summary>
        public HtmlPage() : this("Untitled Page")
        {
        }

        /// <summary>
        /// Construction.
        /// </summary>
        /// <param name="title"></param>
        public HtmlPage(string title)
            : this(title, string.Empty)
        {
        }

        /// <summary>
        /// Construction, Specified Page Title.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="action"></param>
        public HtmlPage(string title, string action)
        {
            // Get Html Begin
            m_html_begin = m_cache.Get( "HtmlBegin" );
            if ( string.IsNullOrEmpty( m_html_begin ) )
            {
                StreamReader sr = new StreamReader(
                    SunMkrHandler.GetManifestResourceStream( "SunMkr.HtmlBegin.code" ) );
                m_html_begin = sr.ReadToEnd( );
                m_cache.Add( "HtmlBegin", m_html_begin );
            }
            m_html_begin = string.Format( m_html_begin, title, m_SunMkrCss, action );

            // Get Html End
            m_html_end = m_cache.Get( "HtmlEnd" );
            if ( string.IsNullOrEmpty( m_html_end ) )
            {
                StreamReader sr = new StreamReader(
                    SunMkrHandler.GetManifestResourceStream( "SunMkr.HtmlEnd.code" ) );
                m_html_end = sr.ReadToEnd( );
                m_cache.Add( "HtmlEnd", m_html_end );
            }
        }

        /// <summary>
        /// Load Page from DLL
        /// </summary>
        /// <param name="PageName"></param>
        /// <param name="ReplaceStrings"></param>
        public void LoadPage( string PageName, params string [] ReplaceStrings )
        {
            m_html_body = m_cache.Get( PageName );
            if ( string.IsNullOrEmpty(m_html_body) )
            {
                // Get the Page from the Resource.
                StreamReader sr = new StreamReader(
                    SunMkrHandler.GetManifestResourceStream( "SunMkr." + PageName + ".sm" ) );
                m_html_body = sr.ReadToEnd( );
                // Add to the cache.
                m_cache.Add( PageName, m_html_body );
            }
            try
            {
                m_html_body = string.Format( m_html_body, ReplaceStrings );
            }
            catch { }
        }

        /// <summary>
        /// Get the begin string.
        /// </summary>
        public string Begin
        {
            get
            {
                return m_html_begin;
            }
        }

        /// <summary>
        /// Get the end string.
        /// </summary>
        public string End
        {
            get
            {
                return m_html_end;
            }
        }

        /// <summary>
        /// Return the page.
        /// </summary>
        /// <returns></returns>
        public override string ToString( )
        {
            //return base.ToString( );
            return m_html_begin + m_html_body + m_html_end;
        }

        /// <summary>
        /// Output the page.
        /// </summary>
        /// <param name="Response"></param>
        public void OutputPage( System.Web.HttpResponse Response )
        {
            Response.Write( m_html_begin + m_html_body + m_html_end );
        }
    }
}
