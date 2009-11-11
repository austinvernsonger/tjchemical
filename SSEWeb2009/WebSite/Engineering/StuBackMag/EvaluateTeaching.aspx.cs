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

public partial class Engineering_StuBackMag_EvaluateTeaching : System.Web.UI.Page
{
    public string[] sProperty = new string[] { "学位课", "非学位课", "必修环节", "其他" };
    public string[] sCategory = new string[] { "必修", "选修", "其他" };
    private string studentID;

    protected void Page_Load(object sender, EventArgs e)
    {  

        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }     
        studentID = Session["IdentifyNumber"].ToString();
        bindEvaluationInfo();
    }
    protected void gvEvaluating_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
                int courseid = Convert.ToInt32(gvEvaluating.DataKeys[e.Row.RowIndex].Value);
                DataSet ds = null;
                CourseManage cMag = new CourseManage();
                ds = cMag.GetCourseTeacherInfo(courseid);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    e.Row.Cells[3].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows.Count == 2)
                {
                    e.Row.Cells[3].Text = ds.Tables[0].Rows[0]["Name"].ToString() + " " + ds.Tables[0].Rows[1]["Name"].ToString();
                }
                StudentManage sMag = new StudentManage();
                ds = sMag.GetStuEvaluation(courseid, studentID);
                if (ds.Tables[0].Rows.Count > 0 && Convert.ToInt32(ds.Tables[0].Rows[0][0])%10 == 1)
                {
                    //已评教
                    l.Attributes.Add("onclick", "javascript:alert('课程：" + DataBinder.Eval(e.Row.DataItem, "CourseName") + " 已评估过')");
                }
                else
                {
                    //未评教
                    l.PostBackUrl = "EvaluatingInfo.aspx?id=" + courseid;
                }
               
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
            courseTime = courseTime + "秋";
        }
        else
        {
            courseTime = courseTime + "春";
        }
        return courseTime;
    }
    protected void bindEvaluationInfo()
    {
        TeachingAgendaManage taMag = new TeachingAgendaManage();
        CourseManage cMag = new CourseManage();
        DataSet ds = null;
        ds = taMag.GetStuEvaluationAgenda(studentID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string res = "";
            res = GetCourseTime(ds.Tables[0].Rows[0]["Term"].ToString());
            res = res + "学期教学评估工作已经开始，时间:";
            res = res + Convert.ToDateTime(ds.Tables[0].Rows[0]["StartTime"]).ToString("yyyy-MM-dd") + "到" + Convert.ToDateTime(ds.Tables[0].Rows[0]["EndTime"]).ToString("yyyy-MM-dd");
            lblResult.Text = res;
            lblResult.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lblResult.Text = "当前你没有需要进行评估课程";
        }
        ds = cMag.GetMyLastestCourse(studentID);
        int count = ds.Tables[0].Rows.Count;
        gvEvaluating.DataSource = ds.Tables[0];
        gvEvaluating.DataBind();
        if (count == 0)
        {
            lblResult.Visible = true;
        }
    }
}
