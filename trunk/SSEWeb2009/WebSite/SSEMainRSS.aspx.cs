using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SysCom;

public partial class SSEMainRSS : System.Web.UI.Page
{
    protected void Page_Load( object sender, EventArgs e )
    {
        RSSFeed.Rss("同济大学通知RSS",ConstValue.PureURL+"NoticeDetail.aspx" ,0,"Notice");
    }
}
