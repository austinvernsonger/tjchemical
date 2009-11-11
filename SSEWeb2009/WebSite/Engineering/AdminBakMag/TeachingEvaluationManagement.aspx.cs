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
using System.IO;

public partial class Engineering_AdminBakMag_TeachingEvaluationManagement : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["IdentifyNumber"] == null)
        //{
        //    SysCom.Login.LoginRedirect(Request.Url.ToString());
        //}
        if (!IsPostBack)
        {
            BindEvaluationRes();
            TabContainer1.ActiveTabIndex = 0;
        }
    }
    protected void ddlGrade1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGrade1.SelectedIndex == 0)
        {
            ddlSchool1.Items.Clear();
            ddlSchool1.Items.Add("--请选择教学点--");
        }
    }
    protected void btQuery_Click(object sender, EventArgs e)
    {
        QueryInfo qInfo = new QueryInfo();
        if (ddlGrade1.SelectedIndex != 0)
        {
            qInfo.Grade = ddlGrade1.SelectedValue;  
        }
        if (ddlSchool1.SelectedIndex != 0)
        {
            qInfo.TSchoolID = ddlSchool1.SelectedValue;
        }
        if (ddlTerm.SelectedIndex != 0)
        {
            qInfo.Time = ddlTerm.SelectedValue;
        }
        ViewState["sqInfo"] = qInfo;
        BindEvaluationRes();
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
    protected void lbNewAgenda_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 2;
    }
    public void BindEvaluationRes()
    {
        CourseManage cMag = new CourseManage();
        DataSet ds = null;
        if (ViewState["sqInfo"] != null)
        {
            QueryInfo qInfo = (QueryInfo)ViewState["sqInfo"];
            ds = cMag.GetCourseEvaluationInfo(qInfo);
        }
        else
        {
            // 首次加载
            ds = cMag.GetCourseEvaluationInfo();
        }
        gvEvaluaionRes.DataSource = ds.Tables[0];
        gvEvaluaionRes.DataBind();
    }
    protected void gvEvaluaionRes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                int courseid = Convert.ToInt32(gvEvaluaionRes.DataKeys[e.Row.RowIndex].Value);
                LinkButton lb = (LinkButton)e.Row.FindControl("lbResult");
                string path = Server.MapPath(@"../Resources/Xml/xmlEvaluationRes.xml");
                if (File.Exists(path) == false)
                {
                    //xmlEvaluationRes.xml文件不存在
                    lb.Attributes.Add("onclick", "javascript:alert('这门课没有测评信息')");
                }
                else
                {
                    DataSet dsXml = new DataSet();
                    dsXml.ReadXml(Server.MapPath(@"../Resources/Xml/xmlEvaluationRes.xml"));
                    int num = dsXml.Tables[0].Rows.Count;
                    int i;
                    for (i = 0; i < num; i++)
                    {
                        int courID = Convert.ToInt32(dsXml.Tables[0].Rows[i]["CourseID"]);
                        if (courID == courseid)
                        {
                            //有学生对该门课程进行了评教;
                            lb.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + courseid + "',650,550)");
                            break;
                        }
                    }
                    if (i == num)
                    {
                        //没有学生对这门课程进行评教
                        lb.Attributes.Add("onclick", "javascript:alert('这门课没有测评信息')");
                    }
                }

                DataSet ds = null;
                CourseManage cMag = new CourseManage();
                ds = cMag.GetCourseTeacherInfo(courseid);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    e.Row.Cells[2].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows.Count == 2)
                {
                    e.Row.Cells[2].Text = ds.Tables[0].Rows[0]["Name"].ToString() + " " + ds.Tables[0].Rows[1]["Name"].ToString();
                }
            }
        }
    }
    protected void btConfirm_Click(object sender, EventArgs e)
    {
        QueryInfo qInfo = new QueryInfo();
        if (ddlTerm2.SelectedIndex == 0)
        {
            Response.Write("<script>alert('请选择学期')</script>");
            return;
        }
        else
        {
            qInfo.Time = ddlTerm2.SelectedValue;
        }
        if (ddlGrade2.SelectedIndex == 0)
        {
            Response.Write("<script>alert('请选择年级')</script>");
            return;
        }
        else
        {
            qInfo.Grade = ddlGrade2.SelectedValue;
        }
        ViewState["qInfo"] = qInfo;
        bindTSchoolCourse();
    }
    protected void bindTSchoolCourse()
    {
        if (ViewState["qInfo"] != null)
        {
            QueryInfo qInfo = (QueryInfo)ViewState["qInfo"];
            CourseManage cMag = new CourseManage();
            DataView dv = cMag.GetCourseNum(qInfo);
            gvTSchoolCourse.DataSource = dv;
            gvTSchoolCourse.DataBind();
        }
    }
    protected void gvTSchoolCourse_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTSchoolCourse.EditIndex = e.NewEditIndex;
        bindTSchoolCourse();
    }
    protected void gvTSchoolCourse_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTSchoolCourse.EditIndex = -1;
        bindTSchoolCourse();
    }
    protected void gvTSchoolCourse_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string teaSchoolID = gvTSchoolCourse.DataKeys[e.RowIndex].Value.ToString();
        if (ViewState["qInfo"] != null)
        {
            QueryInfo qInfo = (QueryInfo)ViewState["qInfo"];
            qInfo.TSchoolID = teaSchoolID;
            TextBox tbStartTime = (TextBox)gvTSchoolCourse.Rows[e.RowIndex].FindControl("tbStartTimes");
            TextBox tbEndTime = (TextBox)gvTSchoolCourse.Rows[e.RowIndex].FindControl("tbEndTimes");
            if (tbStartTime.Text.Trim() != "" && tbEndTime.Text.Trim() != "")
            {
                if (isTimeValid(tbStartTime.Text.Trim()) == true
                    && isTimeValid(tbEndTime.Text.Trim()) == true)
                {
                    //开始时间和结束时间都合法
                    //评教开始时间必须大于等于当前时间
                    if (Convert.ToDateTime(tbStartTime.Text.Trim()) < System.DateTime.Now.Date)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('评教开始时间必须大于等于当前时间')</script>", false);
                        return;
                    }
                    TeachingAgendaManage taMag = new TeachingAgendaManage();
                    DataSet ds = taMag.GetTeachingEvaluationAgendaByQuery(qInfo);
                    if (Convert.ToDateTime(tbStartTime.Text.Trim()) <= Convert.ToDateTime(tbEndTime.Text.Trim()))
                    {
                        qInfo.StartTime = tbStartTime.Text.Trim();
                        qInfo.EndTime = tbEndTime.Text.Trim();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //当前教学点的评教日程已经存在，更新日程
                            if (taMag.UpdateTeachingEvaluationAgenda(qInfo) == true)
                            {
                                gvTSchoolCourse.EditIndex = -1;
                                bindTSchoolCourse();
                                BindEvaluationRes();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('更新失败，请重试')</script>", false);
                                return;
                            }
                        }
                        else
                        {
                            //当前教学点的评教日程不存在 ，添加新日程  
                            if (taMag.AddTeachingEvaluationAgenda(qInfo) == true)
                            {
                                //成功
                                gvTSchoolCourse.EditIndex = -1;
                                bindTSchoolCourse();
                                BindEvaluationRes();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('添加失败，请重试')</script>", false);
                                return;
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('时间不合法，结束时间必须大于等于开始时间')</script>", false);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('时间不合法，请重新输入')</script>", false);
                    return;
                }
            }
        }
    }
    protected bool isTimeValid(string time)
    {
        try
        {
            Convert.ToDateTime(time);
            return true;
        }
        catch
        {
            //不合法
            return false;
        }
    }
    public string GetEvaluationTime(DateTime dtStart, DateTime dtEnd)
    {
        
        string sStart = dtStart.ToString("yyyy-MM-dd");
        string sEnd = dtEnd.ToString("yyyy-MM-dd");
        return sStart + "至" + sEnd;
    }
}
