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

public partial class Engineering_StuBackMag_ChooseMyCourse : System.Web.UI.Page
{
    public string[] sProperty = new string[] { "学位课", "非学位课", "必修环节", "其他" };
    public string[] sCategory = new string[] { "必修", "选修", "其他" };
    private string studentid;

    protected void Page_Load(object sender, EventArgs e)
    {
            if (Session["IdentifyNumber"] == null)
            {
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            }
            studentid = Session["IdentifyNumber"].ToString();
            if (!IsPostBack)
            {

                DataSet ds = TeachingAgendaManage.GetCourTimeArrangedByStuID(studentid);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // 在选课日程内
                    string courseTime = GetChoosingTime(ds);
                    gvCourseInfo.Columns[6].Visible = true;
                    string message = "";
                    message = GetCourseTime(ds.Tables[0].Rows[0]["Term"].ToString()) + "选课已经开始，";
                    message = message + courseTime;
                    lblMessage.Text = message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    bindGvCourseInfo();
                    bindMyCourse();
                }
                else
                {
                    lblMessage.Text = "当前不在选课日程内:-)";
                }
            }
    }
    protected void gvMyCourse_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void bindGvCourseInfo()
    {
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetLatestCourseInfoByStuid(studentid);
        gvCourseInfo.DataSource = ds.Tables[0];
        gvCourseInfo.DataBind();
    }
    protected void bindMyCourse()
    {
        CourseManage cMag = new CourseManage();
        DataSet ds = cMag.GetChoosingCourseByStudent(studentid);
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblMsg.Text = "你还没有选择任何课程:-)";
        }
        else
        {
            lblMsg.Text = "";
        }
        gvMyCourse.DataSource = ds.Tables[0];
        gvMyCourse.DataBind();
    }
    protected void gvCourseInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int courseid = Convert.ToInt32(gvCourseInfo.DataKeys[e.Row.RowIndex].Value);
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseTeacherInfo(courseid);
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                if (count == 1)
                {
                    if (ds.Tables[0].Rows[0]["Name"] != System.DBNull.Value)
                    {
                        e.Row.Cells[5].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    }
                }
                if (count == 2)
                {
                    string str = ds.Tables[0].Rows[0]["Name"].ToString() + " " + ds.Tables[0].Rows[1]["Name"].ToString();
                    e.Row.Cells[5].Text = str;
                }
            }
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            Button bt = (Button)e.Row.FindControl("btSelect");
            if (CourseManage.GetCourseFromExamRes(courseid, studentid) == true)
            {
                bt.Text = "已选定";
                bt.Enabled = false;
            }
            else
            {
                bt.Enabled = true;
            }
        }

    }
    protected void gvCourseInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "xuanding")
        {
            Button btSelected = (Button)e.CommandSource;
            int courseid = Convert.ToInt32(e.CommandArgument);
            CourseManage sMag = new CourseManage();
            if (true == sMag.AddCoursesForStudentTran(courseid,studentid))
            {
                btSelected.Text = "已选定";
                btSelected.Enabled = false;
                bindGvCourseInfo();
                bindMyCourse();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<script language='javascript'>alert('操作有误，请重新选择!')</script>");
            }
        }
    }
    protected void gvMyCourse_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int courseid = Convert.ToInt32(gvMyCourse.DataKeys[e.RowIndex].Value);
        CourseManage cMag = new CourseManage();
        if (true == cMag.DelCoursesForStudentTran(courseid,studentid))
        {
            bindMyCourse();
            bindGvCourseInfo();
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<script language='javascript'>alert('退选失败，请重试!')</script>");
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
    protected void gvMyCourse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            int courseID = Convert.ToInt32(gvMyCourse.DataKeys[e.Row.RowIndex].Value);
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseTeacherInfo(courseID);
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                if (count == 1)
                {
                    if (ds.Tables[0].Rows[0]["Name"] != System.DBNull.Value)
                    {
                        e.Row.Cells[5].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    }
                }
                if (count == 2)
                {
                    string str = ds.Tables[0].Rows[0]["Name"].ToString() + " " + ds.Tables[0].Rows[1]["Name"].ToString();
                    e.Row.Cells[5].Text = str;
                }
            }
        }
    }
    public string GetChoosingTime(DataSet ds)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("选课时间：");
        string startTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartTime"]).ToString("yyyy年MM月dd日");
        string endTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndTime"]).ToString("yyyy年MM月dd日");
        sb.Append(startTime);
        sb.Append("--");
        sb.Append(endTime);
        return sb.ToString();
    }
}
