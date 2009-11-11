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
using Department.Engineering;

public partial class Engineering_AdminBakMag_StudentChoosingCourseDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["courseid"] != null)
        {
            int courseid = Convert.ToInt32(Request["courseid"]);
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetChoosingCourseInfoByCourID(courseid);
            gvStudentInfo.DataSource = ds.Tables[0];
            gvStudentInfo.DataBind();
            if (ds.Tables[0].Rows.Count == 0)
            {
                lblCourseName.Text = "这门课程没有学生选:-(";
            }
            else
            {
                lblCourseName.Text = "课程名称：" + ds.Tables[0].Rows[0]["CourseName"].ToString();
            }
        }
    }
}
