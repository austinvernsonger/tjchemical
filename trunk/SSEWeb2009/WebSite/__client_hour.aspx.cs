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

public partial class __client_hour : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["__clienthour"] != null)
        {
            Session["ClientHour"] = Request.Params["__clienthour"];
            Response.Write(Session["ClientHour"]);
        }
        if (Request.Params["toUrl"] != null)
            Response.Redirect(Request.Params["toUrl"].ToString());
    }
}
