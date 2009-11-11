using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SysCom.Ops;

public partial class Teaching_FrontEnd_Management : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] != null)
        {
            LinkListEx.QuerySQL = "select *,-1 as FS from [EducationRule] where [Type]=" + Request.QueryString["Type"];
            LinkListEx.ReBindData();
        }
    }
}
