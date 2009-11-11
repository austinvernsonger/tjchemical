using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching.Ops;

public partial class Teaching_Admin_Approve : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void bnAgree_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == null) return;
        if (Request.QueryString["Type"] == null) return;
        ExamApproval(Request.QueryString["Type"], true, Request.QueryString["ID"]);
        Response.Redirect("~/Teaching/Admin/AdminManagement.aspx?Type=" + Request.QueryString["Type"]);
    }
    protected void bnDisAgree_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == null) return;
        if (Request.QueryString["Type"] == null) return;
        ExamApproval(Request.QueryString["Type"], false, Request.QueryString["ID"]);
        Response.Redirect("~/Teaching/Admin/AdminManagement.aspx?Type=" + Request.QueryString["Type"]);
    }

    protected void ExamApproval(String Type, bool isAgree,String ID)
    {
        String Sql="";
        switch (Type){
            case "1":
                Sql = "update TravelApplication ";
                break;
            case "2":
                Sql = "update LectureApplication ";
                break;
            case "3":
                Sql = "update NewCourseApplication ";
                break;
        }
        Sql += "set ExamApproval = " + (isAgree ? "1" : "2") + " where RequestID=" +ID;
        opsTeachingExec Exec = new opsTeachingExec(Sql);
        Exec.Do();
    }
    protected void bnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Teaching/Admin/AdminManagement.aspx?Type=" + Request.QueryString["Type"]);
    }
}
