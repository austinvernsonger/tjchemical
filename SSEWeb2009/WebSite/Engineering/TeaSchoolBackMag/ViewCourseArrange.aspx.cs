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

public partial class Engineering_TeaSchoolBackMag_ViewCourseArrange : System.Web.UI.Page
{
    //教学点测试编号
    int teaSchoolID = 34;

    public string[] sProperty = new string[] { "学位课", "非学位课", "必修环节", "其他" };
    public string[] sCategory = new string[] { "必修", "选修", "其他" };


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gvCourseArrange_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int courseid = Convert.ToInt32(gvCourseArrange.DataKeys[e.Row.RowIndex].Value);
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseInformation(courseid);
            if (ds.Tables[0].Rows.Count == 1)
            {
                //只有一位老师授课
                e.Row.Cells[6].Text = ds.Tables[0].Rows[0]["Name"].ToString();
            }
            if (ds.Tables[0].Rows.Count == 2)
            {
                //有两位老师授课
                string name = "";
                name = ds.Tables[0].Rows[0]["Name"].ToString();
                name = name + " " + ds.Tables[0].Rows[1]["Name"].ToString();
                e.Row.Cells[6].Text = name;
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

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        QueryInfo qInfo = new QueryInfo();
        qInfo.TSchoolID = teaSchoolID.ToString();
        if (ddlGrade.SelectedIndex == 0 && ddlSmaster.SelectedIndex == 0)
        {
            Response.Write("<script language='javascript'>alert('请选择查询条件！')</script>");
            return;
        }
        if (ddlGrade.SelectedIndex != 0)
        {
            qInfo.Grade = ddlGrade.SelectedValue;
        }
        if (ddlSmaster.SelectedIndex != 0)
        {
            qInfo.Time = ddlSmaster.SelectedValue;
        }
        ViewState["Query"] = qInfo;
        bindData();
    }

    protected void bindData()
    {
        QueryInfo qInfo = (QueryInfo)ViewState["Query"];
        CourseManage cMag = new CourseManage();
        DataSet ds = cMag.GetCourseInfo(qInfo);
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblResult2.Text = "对不起！本教学点" + ddlGrade.SelectedValue.ToString() + "年级在" + GetCourseTime(ddlSmaster.SelectedValue.ToString()) + "没有开设任何课程！"; 
        }
        gvCourseArrange.DataSource = ds.Tables[0];
        gvCourseArrange.DataBind();
        
    }
}
