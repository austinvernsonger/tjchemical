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
public partial class SysMgr_NewNewsAuthority : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (NewsAuthority.CreateNewsAuthority(tbId.Text, tbName.Text))
        {
            Response.Write("<script>alert('添加成功')</script>");
        }
    }
}
