using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class StudentManage_MasterPage_HeadTeacher_NoNested : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton4_OnClick(object sender, EventArgs e)
    {
        string toURL = HttpContext.Current.Request.ApplicationPath + "/Login/Login.aspx?toURL=" + HttpContext.Current.Request.ApplicationPath + "/StudentManage/LoginCheck.aspx";

        this.Response.Redirect(toURL);
    }
    protected void LinkButton1_OnClick(object sender, EventArgs e)
    {

    }
    protected void LinkButton2_OnClick(object sender, EventArgs e)
    {

    }
    protected void LinkButton3_OnClick(object sender, EventArgs e)
    {

    }
}
