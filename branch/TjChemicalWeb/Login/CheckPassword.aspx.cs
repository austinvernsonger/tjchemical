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

public partial class Login_CheckPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginPassword"] == null)
        {
            Response.Write("0");
        }
        else
        {
            if (Request.QueryString["Password"] == Session["LoginPassword"].ToString())
                Response.Write("1");
            else
                Response.Write("0");
        }
    }
}
