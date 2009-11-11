using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teaching_Enterprise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void bnSearch_Click(object sender, EventArgs e)
    {
        this.LinkListExContent.QuerySQL = "select *,-1 as FS  from [EnterpriseCooperation] where [Title] like '%" + EnterpriseName.Text + "%'";
        this.LinkListExContent.ReBindData();
    }
}
