using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web;
using System.Data;
using SunMkr.Com.Literal;

namespace SysCom
{
    /// <summary>
    /// Rss Itom Class
    /// </summary>
    public class RssItom
    {
        public string RssTitle;
        public string WebURL;
        public string RssDescription;
        public string RssCopyRight;
        public string ItemLinkPage;
    }

    /// <summary>
    /// RSS Feed
    /// </summary>
    public static class RSSFeed
    {
        private static void getFeed( ref DataTable dtRss, RssItom Itom )
        {
            // Get the response
            HttpResponse Response = HttpContext.Current.Response;

            // Clean All Old Output
            Response.Clear( );
            Response.ContentType = "text/xml";
            XmlTextWriter xmlFeed = new XmlTextWriter( Response.OutputStream, Encoding.UTF8 );

            xmlFeed.WriteStartDocument( );
            xmlFeed.WriteStartElement( "rss" );
            xmlFeed.WriteAttributeString( "version", "2.0" );
            // The channel tag contains RSS feed details
            xmlFeed.WriteStartElement( "channel" );
            xmlFeed.WriteElementString( "title", Itom.RssTitle );
            xmlFeed.WriteElementString( "link", Itom.WebURL );
            xmlFeed.WriteElementString( "description", Itom.RssDescription );
            xmlFeed.WriteElementString( "copyright", Itom.RssCopyRight );

            foreach ( DataRow row in dtRss.Rows )
            {
                MMT mmt = new MMT( row [ "ID" ].ToString( ) );
                xmlFeed.WriteElementString( "title", mmt.Title );
                xmlFeed.WriteElementString( "description", Validate.XHtml.Replace( mmt.Content, "" ) );
                xmlFeed.WriteElementString( "link", string.Format( "{0}?MMTID={1}", Itom.ItemLinkPage, mmt.ID ) );
                xmlFeed.WriteElementString( "pubDate", mmt.LastModifyTime.ToString( "yyyy-MM-dd hh:mm" ) );
                xmlFeed.WriteEndElement( );
            }

            // Close all tags 
            xmlFeed.WriteEndElement( );
            xmlFeed.WriteEndElement( );
            xmlFeed.WriteEndDocument( );
            xmlFeed.Flush( );
            xmlFeed.Close( );
            Response.End( );

        }

        /// <summary>
        /// Get RSS Feed
        /// </summary>
        /// <param name="DepartmentID"></param>
        /// <param name="Mode"></param>
        /// <param name="Itom"></param>
        public static void GetFeed( int DepartmentID, PSGMODE Mode, RssItom Itom )
        {
            DataTable dtRss = MMTStatic.GetList( DepartmentID, Mode.ToString( ), null, false ).Tables [ 0 ];
            getFeed( ref dtRss, Itom );
        }

        /// <summary>
        /// Get notices RSS Feed, the label can be null
        /// </summary>
        /// <param name="DepartmentID"></param>
        /// <param name="Label"></param>
        /// <param name="Itom"></param>
        public static void GetNoticeFeed( int DepartmentID, string Label, RssItom Itom )
        {
            DataTable dtRSS = MMTStatic.GetNotice( DepartmentID, null, Label, false, false ).Tables [ 0 ];
            getFeed( ref dtRSS, Itom );
        }

        /// <summary>
        /// Get notices RSS Feed, the label is null.
        /// </summary>
        /// <param name="DepartmentID"></param>
        /// <param name="Itom"></param>
        public static void GetNoticeFeed( int DepartmentID, RssItom Itom )
        {
            GetFeed( DepartmentID, PSGMODE.Notice, Itom );
        }
    }
}
