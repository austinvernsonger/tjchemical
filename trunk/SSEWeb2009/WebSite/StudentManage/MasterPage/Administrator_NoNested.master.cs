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

public partial class StudentManage_MasterPage_Administrator_NoNested : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton17_OnClick(object sender, EventArgs e)
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
    protected void LinkButton5_OnClick(object sender, EventArgs e)
    {

    }
    protected void LinkButton6_OnClick(object sender, EventArgs e)
    {

    }
    protected void LinkButton7_OnClick(object sender, EventArgs e)
    {

    }
    protected void LinkButton8_OnClick(object sender, EventArgs e)
    {

    }
    protected void LinkButton9_OnClick(object sender, EventArgs e)
    {
        string toURL = HttpContext.Current.Request.ApplicationPath + "/StudentManage/AdministratorContestMaintain.aspx";
        this.Response.Redirect(toURL);
    }
    protected void LinkButton10_OnClick(object sender, EventArgs e)
    {
        string toURL = HttpContext.Current.Request.ApplicationPath + "/StudentManage/AdministratorContestVerify.aspx";
        this.Response.Redirect(toURL);
    }
    protected void LinkButton11_OnClick(object sender, EventArgs e)
    {
        string toURL = HttpContext.Current.Request.ApplicationPath + "/StudentManage/AdministratorScholarshipVerify.aspx";
        this.Response.Redirect(toURL);
    }
    protected void LinkButton12_OnClick(object sender, EventArgs e)
    {

    }
    protected void LinkButton13_OnClick(object sender, EventArgs e)
    {

    }
    protected void LinkButton14_OnClick(object sender, EventArgs e)
    {

    }
    protected void LinkButton15_OnClick(object sender, EventArgs e)
    {

    }
    protected void LinkButton16_OnClick(object sender, EventArgs e)
    {

    }
}
