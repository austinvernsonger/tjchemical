using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web;
using System.Data;
using SunMkr.Com.Literal;
using System.Globalization;
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

            for (int i=0;i<dtRss.Rows.Count&&i<20;i++)
            {
                MMT mmt = new MMT(dtRss.Rows[i]["ID"].ToString());
                xmlFeed.WriteStartElement("item");
                xmlFeed.WriteStartElement("title");
                xmlFeed.WriteRaw( mmt.Title );
                xmlFeed.WriteEndElement();
                xmlFeed.WriteStartElement("description");
                xmlFeed.WriteRaw("<![CDATA[" + mmt.Content + "]]>");
                xmlFeed.WriteEndElement();
                xmlFeed.WriteStartElement("link");
                xmlFeed.WriteRaw(string.Format("{0}?MMTID={1}", Itom.ItemLinkPage, mmt.ID));
                xmlFeed.WriteEndElement();
                xmlFeed.WriteStartElement("pubDate");
                xmlFeed.WriteRaw(mmt.LastModifyTime.ToString("ddd,d MMM yyyy HH:mm:ss", DateTimeFormatInfo.InvariantInfo) + " +0800");
                xmlFeed.WriteEndElement();
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
            DataTable dtRss = MMTStatic.GetList( DepartmentID, Mode.ToString( ), null, false ,false).Tables [ 0 ];
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
            DataTable dtRSS = MMTStatic.GetNotice( DepartmentID, null, Label, false, false,false).Tables [ 0 ];
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

        public static void Rss(String Title, String LinkPage,Int16 DepartmentID,String label,String mode)
        {
            RssItom itom = new RssItom();
            itom.RssTitle = Title;
            itom.ItemLinkPage = LinkPage;
            itom.RssCopyRight = "Copyright 2009 SSE of Tongji University. All rights reserved.";
            itom.WebURL = "http://sse.tongji.edu.cn";
            itom.RssDescription = "Provide By SSE RSS Feed.";
            string sMode = mode;
            sMode = sMode.Substring(0, 1).ToUpper() + sMode.Substring(1).ToLower();
            PSGMODE Mode = (PSGMODE)Enum.Parse(typeof(PSGMODE), sMode);
            int DepartmentId = DepartmentID;

            if (Mode == PSGMODE.Notice)
            {
                RSSFeed.GetNoticeFeed(DepartmentId, label, itom);
            }
            else
            {
                RSSFeed.GetFeed(DepartmentId, Mode, itom);
            }
        }

        public static void Rss(String Title, String LinkPage, Int16 DepartmentID, String mode)
        {
            RssItom itom = new RssItom();
            itom.RssTitle = Title;
            itom.ItemLinkPage = LinkPage;
            itom.RssCopyRight = "Copyright 2009 SSE of Tongji University. All rights reserved.";
            itom.WebURL = "http://sse.tongji.edu.cn";
            itom.RssDescription = "Provide By SSE RSS Feed.";
            string sMode = mode;
            sMode = sMode.Substring(0, 1).ToUpper() + sMode.Substring(1).ToLower();
            PSGMODE Mode = (PSGMODE)Enum.Parse(typeof(PSGMODE), sMode);
            int DepartmentId = DepartmentID;
            RSSFeed.GetFeed(DepartmentId, Mode, itom);
        }
    }
}
