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

public partial class Engineering_TeaSchoolBackMag_CourseScoreList : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["id"] != null && Request["id"] != "")
            {
                int courseid = Convert.ToInt32(Request["id"]);
                ViewState["CourseID"] = courseid;
                BindGvScoreList();
            }
        }
    }

    protected void BindGvScoreList()
    {
        int courseid = (int)ViewState["CourseID"];

        CourseManage cMag = new CourseManage();
        DataSet ds = cMag.GetChoosingCourseInfoByCourID(courseid);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblGrade.Text = ds.Tables[0].Rows[0]["Grade"].ToString();
            lblTeaSchool.Text = ds.Tables[0].Rows[0]["TeaSchoolName"].ToString();
            lblStdNum.Text = ds.Tables[0].Rows.Count.ToString();
            lblCourName.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
            lblTeachers.Text = GetCourseTeachers(courseid);
            //ViewState["_ds"] = ds;
            // _ds = ds;
        }

        gvScoreList.DataSource = ds.Tables[0];
        gvScoreList.DataBind();
    }

    protected string GetCourseTeachers(int courid)
    {
        string teaNames = "";
        CourseManage cMag = new CourseManage();
        DataSet ds = cMag.GetCourseInformation(courid);
        if (ds.Tables[0].Rows.Count == 1)
        {
            //只有一位老师授课
             teaNames = ds.Tables[0].Rows[0]["Name"].ToString();
        }
        if (ds.Tables[0].Rows.Count == 2)
        {
            //有两位老师授课
            string name = "";
            name = ds.Tables[0].Rows[0]["Name"].ToString();
            name = name + " " + ds.Tables[0].Rows[1]["Name"].ToString();
            teaNames = name;
        }
        return teaNames;
    }
}
