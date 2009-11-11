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

public partial class Engineering_TeacherBackMag_ViewCourseDetails : System.Web.UI.Page
{
    public string courseName = "";
    private bool isModify = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Request["cid"] != null )
            {
                ViewState["courseID"] = Convert.ToInt32(Request["cid"]);
                bindgvMyCourse();
                btSave.Visible = false;
            }
        }
    }
    protected void btModify_Click(object sender, EventArgs e)
    {
        if (ViewState["ok"] != null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('管理员已经确认成绩，无法再对成绩进行修改')</script>");
            return;
        }
        else
        {
            btSave.Visible = true;
            btModify.Visible = false;
            isModify = true;
            bindgvMyCourse();
        }
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        isModify = false;
        StudentManage sMag = new StudentManage();
        int courseid = Convert.ToInt32(ViewState["courseID"]);
        for (int i = 0; i < gvMyCourse.Rows.Count; i++)
        {
            string stuid = gvMyCourse.DataKeys[i].Value.ToString();
            TextBox tb = (TextBox)gvMyCourse.Rows[i].FindControl("tbRes");
            if (tb.Text.Trim() != "")
            {
                //更新成绩
                sMag.UpdateStudentResult(stuid, courseid, tb.Text.Trim());
            }
        }
        btSave.Visible = false;
        btModify.Visible = true;
        bindgvMyCourse();
    }
    protected void bindgvMyCourse()
    {
        int courseID = (int)ViewState["courseID"];
        CourseManage cMage = new CourseManage();
        DataSet ds = cMage.GetChoosingCourseInfoByCourID(courseID);
        if(ds.Tables[0].Rows.Count >0)
        {
            lblCourseName.Text =ds.Tables[0].Rows[0]["CourseName"].ToString();
            lblGrade.Text = ds.Tables[0].Rows[0]["Grade"].ToString();
            lblSchool.Text = ds.Tables[0].Rows[0]["TeaSchoolName"].ToString();
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsOk"]) == 1)
            { 
                //该课程成绩已经被管理员确认，无法再修改
                ViewState["ok"] = true;
            }
        }
        gvMyCourse.DataSource = ds.Tables[0];
        gvMyCourse.DataBind();
    }
    protected void gvMyCourse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            if (isModify == true)
            {
                Label lb = (Label)e.Row.FindControl("lblRes");
                lb.Visible = false;
                TextBox tb = (TextBox)e.Row.FindControl("tbRes");
                tb.Visible = true;
            }
            else
            {
                Label lb = (Label)e.Row.FindControl("lblRes");
                lb.Visible = true;
                TextBox tb = (TextBox)e.Row.FindControl("tbRes");
                tb.Visible = false;
            }
        }
    }
    protected void gvMyCourse_DataBound(object sender, EventArgs e)
    {
        CourseManage cMag = new CourseManage();
        DataSet ds = null;
        int courseID = Convert.ToInt32(ViewState["courseID"]);
        for (int i = 0; i < gvMyCourse.Rows.Count; i++)
        {
            string studentID = gvMyCourse.DataKeys[i].Value.ToString();
            ds = cMag.GetRecordFromExamResult(studentID, courseID);
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsOk"]) == 3)
            {
                gvMyCourse.Rows[i].BackColor = System.Drawing.Color.Red;
            }
        }
    }
}
