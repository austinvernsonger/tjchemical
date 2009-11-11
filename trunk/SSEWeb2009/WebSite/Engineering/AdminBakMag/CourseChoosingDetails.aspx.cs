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

public partial class Engineering_AdminBakMag_CourseChoosingDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null && Request["id"] != "")
        {
            int courseID = Convert.ToInt32(Request["id"]);
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseInformation(courseID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTerm.Text = "选课学期：" + GetCourseTime(ds.Tables[0].Rows[0]["CourseTime"].ToString());
                lblGrade.Text = "年级：" + ds.Tables[0].Rows[0]["Grade"].ToString();
                lblSchool.Text = "教学点：" + ds.Tables[0].Rows[0]["TeaSchoolName"].ToString();

                DataSet dsRes = cMag.GetChoosingCourseInfoByCourID(courseID);
                if (dsRes.Tables[0].Rows.Count > 0)
                {
                    lblRes.Visible = false;
                }
                else
                {
                    lblRes.Visible = true;
                }
                gvStuInfo.DataSource = dsRes.Tables[0];
                gvStuInfo.DataBind();
            }

        }
    }
    protected void gvStuInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[3].Text = "总人数：" + gvStuInfo.Rows.Count;
        }
    }
    public string GetCourseTime(string cTime)
    {
        string courseTime = "";
        courseTime = cTime.Substring(0, 4);
        int term = Convert.ToInt32(cTime.Substring(4, 1));
        if (term == 0)
        {
            courseTime = courseTime + "年秋";
        }
        else
        {
            courseTime = courseTime + "年春";
        }
        return courseTime;
    }
}
