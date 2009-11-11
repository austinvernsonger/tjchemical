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

public partial class Engineering_FrontEndPageMag_NoticePost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["MMTID"] != null)
        {
            //更新通知
            EditMMT1.NewPost = false;
        }
        else
        {
            //发布新通知
            EditMMT1.NewPost = true;
        }
    }
}
