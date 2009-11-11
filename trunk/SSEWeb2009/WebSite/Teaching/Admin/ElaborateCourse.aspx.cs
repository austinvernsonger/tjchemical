using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teaching_Admin_ElaborateCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ElaborateCourseSearch_Click(object sender, EventArgs e)
    {
        string ResponsiblePerson = ElaborateCourse_Person.Text;
        string ProjectName = ElaborateCourse_ProjectName.Text;
        string Year = ElaborateCourse_Year.Text;
        this.LinkListExContent.QuerySQL = "select S.CourseID as ID,S.ProjectName as Title,T.CourseID as Content,0 as ContentType,-1 as FS  from [ElaborateCourse]as S,[ElaborateCourse]as T where S.CourseID = T.CourseID and S.AcademicYear like '%" + Year.Trim() + "%' and S.ResponsiblePerson like '%" + ResponsiblePerson.Trim() + "%' and S.ProjectName like '%" + ProjectName.Trim() + "%'";
        this.LinkListExContent.ReBindData();
    }
}
