using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Download : System.Web.UI.Page
{
    protected void Page_Load( object sender, EventArgs e )
    {
        Response.Clear( );
        if ( string.IsNullOrEmpty( Request.QueryString ["MMTID"] ) ||
            string.IsNullOrEmpty( Request.QueryString ["FileName"] ) )
        {
            Response.Write( "Parameters Error!" );
        }
        else
        {
            if ( !SysCom.MMTStatic.Download( Request.Params [ "MMTID" ],
                HttpUtility.UrlDecode(Request.Params [ "FileName" ]) ) )
            {
                Response.Write( "File Not Existed!" );
                return;
            }

            string path = string.Format( @"{0}\Files\Attachments\{1}\{2}",
                SMBL.Global.WebSite.AppPath,
                Request.Params [ "MMTID" ],
                HttpUtility.UrlDecode( Request.Params [ "FileName" ] ) );
            FileInfo fi = new FileInfo( path );
            
            // Start to download.
            Response.Clear( );
            Response.Charset = "utf-8";
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.AddHeader( "Content-Disposition",
                "attachment; filename=\"" + HttpUtility.UrlEncode( 
                HttpUtility.UrlDecode( Request.Params [ "FileName" ] ), 
                System.Text.Encoding.UTF8 ) + "\"" );
            Response.AddHeader( "Content-Length", fi.Length.ToString( ) );
            Response.AddHeader( "Content-Transfer-Encoding", "binary" );
            //Response.TransmitFile( string.Format( @"~/Files/Attachments/{0}/{1}",
            //    Request.QueryString [ "MMTID" ], Request.Params [ "FileName" ] ) );
            Response.WriteFile( fi.FullName );
            Response.Flush( );
            Response.End( );
        }
    }
}
