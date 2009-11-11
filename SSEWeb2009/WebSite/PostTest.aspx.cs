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

public partial class PostTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
            //SysCom.Login.LoginRedirect(Request.Url.ToString());
            Session["IdentifyNumber"] = 070000;
        String prefix = Request.ApplicationPath;
        if (!prefix.EndsWith("/")) prefix += "/";
        EditMMT1.OnSuccessGoTo = prefix + "Default.aspx";

        if (Request.Params["MMTID"] != null)
        {
            EditMMT1.NewPost = false;
            EditMMT1.MMTID = Request.Params["MMTID"].ToString();
        }
        Response.Write(SMBL.Global.WebSite.AppPath);
    }
}
