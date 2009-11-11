using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecruitmentNew_ViewStu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MmtContent.MMTID = Request.QueryString["type"];
    }
}
