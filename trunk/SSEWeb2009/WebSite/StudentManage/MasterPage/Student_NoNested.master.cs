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

public partial class StudentManage_MasterPage_Student_NoNested : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LBtnApplyScholarship_OnClick(Object sender, EventArgs e)
    {
        string studentID = Convert.ToString(Session["IdentifyNumber"]);

        SDS_StudentScholar_GPA.SelectCommand = "select GPA from StudentScholarship where StudentID=" + studentID;

        DataView tmp = (DataView)SDS_StudentScholar_GPA.Select(new DataSourceSelectArguments());
        double gpa = Convert.ToDouble(tmp[0][0]);
        if (gpa < 3.5)
        {
            Response.Write("<script language=javascript>alert('你的绩点小于3.5,，没有申请资格')</script>");
        }
        else
        {
            string url = HttpContext.Current.Request.ApplicationPath + "/StudentManage/StudentApplyStudyAward.aspx";
            Response.Redirect(url);
        }
    }

    protected void GoToLogin_OnClick(Object sender, EventArgs e)
    {
        string toURL = HttpContext.Current.Request.ApplicationPath + "/Login/Login.aspx?toURL="+ HttpContext.Current.Request.ApplicationPath + "/StudentManage/LoginCheck.aspx";
        this.Response.Redirect(toURL);
    }

    protected void LinkButton5_OnClick(Object sender, EventArgs e)
    {
        string toURL = HttpContext.Current.Request.ApplicationPath + "/StudentManage/StudentInfo.aspx";
        this.Response.Redirect(toURL);
    }
}
