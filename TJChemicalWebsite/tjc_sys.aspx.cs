using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tjc_sys : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["IdentifyNumber"] == null)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            
        }

    }
}
