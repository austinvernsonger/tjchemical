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

using SysCom;
public partial class SysMgr_MgrNewsAuthority : System.Web.UI.Page
{
    private void setbind()
    {
        GridView1.DataSource = NewsAuthority.GetNewsAuthorityList();
        GridView1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        setbind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }
    protected void 删除_Click(object sender, EventArgs e)
    {
    
    }
    protected void 删除_Command(object sender, CommandEventArgs e)
    {
        NewsAuthority.DeleteNewAuthority(e.CommandArgument.ToString());
        setbind();
    }
}
