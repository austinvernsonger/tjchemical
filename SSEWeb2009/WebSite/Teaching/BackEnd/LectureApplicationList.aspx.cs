using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teaching_BackEnd_LectureApplicationList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        LinkListEx.QuerySQL = "select RequestID as [ID], '' as [Content],2 as [ContentType],'讲座名：'+Subject as [Title],ExamApproval as [FS] from LectureApplication where TeacherID='" + Session["IdentifyNumber"]+"'";
        
    
    }
}
