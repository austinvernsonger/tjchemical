using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// 页面：ManageSite - 后台管理MasterPage
/// 作者：Constantine
/// 最近一次修改时间：2009-6-24
/// </summary>
public partial class ManageSite : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        if (Session["IdentifyNumber"].ToString()!="sa")
        {
            Response.Redirect("../Default.aspx");
        }
    }
}
