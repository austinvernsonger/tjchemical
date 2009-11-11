using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AlumnusRecord_showInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        view.MMTID = Request.Params["MMTID"];
       
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.RegisterClientScriptBlock("e", "<script language=javascript>history.go(-2);</script>");

    }
}
