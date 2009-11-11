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

public partial class Engineering_AdminBakMag_ScoreViewManagement : System.Web.UI.Page
{
    public string[] sProperty = new string[] { "学位课", "非学位课", "必修环节", "其他" };
    public string[] sCategory = new string[] { "必修", "选修", "其他" };
    private bool isModify = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["IdentifyNumber"] == null)
        //{
        //    SysCom.Login.LoginRedirect(Request.Url.ToString());
        //}
        
        if (!IsPostBack)
        {
            TabContainer1.ActiveTabIndex = 0;
            BindGVCourseScore();
            btSave.Visible = false;
        }
    }
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGrade.SelectedIndex == 0)
        {
            ddlSchool.Items.Clear();
            ddlSchool.Items.Add("--请选择教学点--");
        }
    }
    protected void btQuery_Click(object sender, EventArgs e)
    {
        QueryInfo qInfo = new QueryInfo();
        if (ddlGrade.SelectedIndex != 0)
        {
            qInfo.Grade = ddlGrade.SelectedValue;
        }
        if (ddlSchool.SelectedIndex != 0)
        {
            qInfo.TSchoolID = ddlSchool.SelectedValue;
        }
        if (ddlTerm.SelectedIndex != 0)
        {
            qInfo.Time = ddlTerm.SelectedValue;
        }
        ViewState["qInfo"] = qInfo;
        BindGVCourseScore();
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
    protected void gvCourseScore_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int num = 0;
            HyperLink hlOperate = (HyperLink)e.Row.FindControl("hlOperate");
            int courseid = Convert.ToInt32(gvCourseScore.DataKeys[e.Row.RowIndex].Value);
            CourseManage cMag = new CourseManage();
            DataSet ds = null;
            ds = cMag.GetCourseInformation(courseid);
            if (ds.Tables[0].Rows.Count == 1)
            {
                //只有一位老师授课
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"] != "")
                {
                    e.Row.Cells[4].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                }
            }
            if (ds.Tables[0].Rows.Count == 2)
            { 
                //有两位老师授课
                string name = "";
                name = ds.Tables[0].Rows[0]["Name"].ToString();
                name = name + " " + ds.Tables[0].Rows[1]["Name"].ToString();
                e.Row.Cells[4].Text = name;
            }
            ds = cMag.GetChoosingCourseInfoByCourID(courseid);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["IsOk"]) == 1)
                {
                    num++;
                }
            }
            if (num == ds.Tables[0].Rows.Count)
            {
                e.Row.Cells[7].Text = "已核对";
                hlOperate.Text = "查看成绩";
            }
            else
            {
                e.Row.Cells[7].Text = "未核对";
                e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                hlOperate.Text = "核对成绩";
            }
        }
    }
    protected void BindGVCourseScore()
    {
        if (ViewState["qInfo"] != null)
        {
            QueryInfo qInfo = (QueryInfo)ViewState["qInfo"];
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseScoreInfo(qInfo);
            gvCourseScore.DataSource = ds.Tables[0];
            gvCourseScore.DataBind();
        }
        else
        {
            //首次加载
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseScoreInfo();
            gvCourseScore.DataSource = ds.Tables[0];
            gvCourseScore.DataBind();
        }
    }
    protected void btStuIDQuery_Click(object sender, EventArgs e)
    {
        if (tbStuID.Text.Trim().Length == 10)
        {
            RoleManage rMag = new RoleManage();
            DataSet ds = rMag.GetUsersFromMSE(tbStuID.Text.Trim());
            if (ds.Tables[0].Rows.Count == 0)
            { 
                //该账号不属于MSE部门
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('该学生账号不存在')</script>", false);
                //return;
                lblRes.Text = "该学生账号不存在";
                lblRes.Visible = true;
                return;
            }
            ViewState["studentID"] = tbStuID.Text.Trim();
            bindStuScore();
        }
        else
        {
            lblRes.Text = "该学生账号不存在";
            lblRes.Visible = true;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('该学生账号不存在')</script>", false);
            //return;
        }
    }
    protected void gvStuScore_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void btPrint_Click(object sender, EventArgs e)
    {

    }
    protected void btModify_Click(object sender, EventArgs e)
    {
        isModify = true;
        btModify.Visible = false;
        btSave.Visible = true;
        bindStuScore();
    }
    protected void bindStuScore()
    {
        if (ViewState["studentID"] != null)
        {
            string stuID = ViewState["studentID"].ToString().Trim();
            StudentManage sMag = new StudentManage();
            DataSet ds = sMag.GetExamResultByStuID(stuID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblName.Text = "学号：<span  style='font-size:large; font-weight:bold; color:Red'>" +
                    ds.Tables[0].Rows[0]["StudentID"].ToString() + "</span> 姓名：<span  style='font-size:large; font-weight:bold; color:Red'>" +
                    ds.Tables[0].Rows[0]["Name"].ToString() + "</span>";
                lblGrade.Text = " 年级：<span  style='font-size:large; font-weight:bold; color:Red'>" +
                    ds.Tables[0].Rows[0]["Grade"].ToString() + "</span> 教学点：<span  style='font-size:large; font-weight:bold; color:Red'>" +
                    ds.Tables[0].Rows[0]["TeaSchoolName"].ToString() + "</span>";
                Panel1.Visible = true;
                lblRes.Visible = false;
            }
            else
            {
                Panel1.Visible = false;
                lblRes.Visible = true;
            }
            gvStuScore.DataSource = ds.Tables[0];
            gvStuScore.DataBind();
        }
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        isModify = false;
        StudentManage sMag = new StudentManage();
        for (int i = 0; i < gvStuScore.Rows.Count; i++)
        {
            int courseid = Convert.ToInt32(gvStuScore.DataKeys[i].Value);
            string studentID = ViewState["studentID"].ToString().Trim();
            TextBox tb = (TextBox)gvStuScore.Rows[i].FindControl("tbRes");
            if (tb.Text.Trim() != "")
            {
                //更新成绩
                sMag.UpdateStudentResult(studentID, courseid, tb.Text.Trim());
            }
        }
        btSave.Visible = false;
        btModify.Visible = true;
        bindStuScore();
    }
}
