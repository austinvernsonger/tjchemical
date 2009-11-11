using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teaching_BackEnd_NewCourseApplicationList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        LinkListEx.QuerySQL = "select RequestID as [ID],2 as [ContentType],''as [Content],'课程名：'+CourseName as [Title],ExamApproval as [FS]  from [NewCourseApplication] where TeacherID='" + Session["IdentifyNumber"]+"'"; 
    }
}
