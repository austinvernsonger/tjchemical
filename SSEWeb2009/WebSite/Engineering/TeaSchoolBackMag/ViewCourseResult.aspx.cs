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
using System.Text;

public partial class Engineering_TeaSchoolBackMag_ViewCourseResult : System.Web.UI.Page
{
    int teaSchoolID = 34;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (PreviousPage != null)
        //{

        //}
    }

    protected void gvCourseList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int courseid = Convert.ToInt32(gvCourseList.DataKeys[e.Row.RowIndex].Value);
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseInformation(courseid);
            if (ds.Tables[0].Rows.Count == 1)
            {
                //只有一位老师授课
                e.Row.Cells[2].Text = ds.Tables[0].Rows[0]["Name"].ToString();
            }
            if (ds.Tables[0].Rows.Count == 2)
            {
                //有两位老师授课
                string name = "";
                name = ds.Tables[0].Rows[0]["Name"].ToString();
                name = name + " " + ds.Tables[0].Rows[1]["Name"].ToString();
                e.Row.Cells[2].Text = name;
            }
        }
    }

    public string GetCourseTime(string cTime)
    {
        string courseTime = "";
        courseTime = cTime.Substring(0, 4);
        int term = Convert.ToInt32(cTime.Substring(4, 1));
        if (term == 0)
        {
            courseTime = courseTime + "年秋学期";
        }
        else
        {
            courseTime = courseTime + "年春学期";
        }
        return courseTime;
    }

    protected void btn_Query_Click(object sender, EventArgs e)
    {
        QueryInfo qInfo = new QueryInfo();
        if (ddlGrade.SelectedIndex == 0 && ddlSmaster.SelectedIndex == 0)
        {
            Response.Write("<script language='javascript'>alert('请选择查询条件！')</script>");
            return;
        }
        qInfo.TSchoolID = teaSchoolID.ToString();
        if (ddlGrade.SelectedIndex != 0)
        {
            qInfo.Grade = ddlGrade.SelectedValue;
        }        
        if (ddlSmaster.SelectedIndex != 0)
        {
            qInfo.Time = ddlSmaster.SelectedValue;
        }
        BindGVCourseList(qInfo);
    }

    private void BindGVCourseList(QueryInfo qInfo)
    {
        CourseManage cMag = new CourseManage();
        DataSet ds = cMag.GetCourseScoreInfo(qInfo);
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblResult2.Text = "对不起本教学点该年级没有开设课程！";           
        }
        gvCourseList.DataSource = ds.Tables[0];
        gvCourseList.DataBind();
        
    }
}
