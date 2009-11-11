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
using System.Collections.Generic;

public partial class Engineering_AdminBakMag_CourseViewManagemen : System.Web.UI.Page
{
    public string[] sProperty = new string[] { "学位课", "非学位课", "必修环节", "其他" };
    public string[] sCategory = new string[] { "必修", "选修", "其他" };

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["IdentifyNumber"] == null)
        //{
        //    SysCom.Login.LoginRedirect(Request.Url.ToString());
        //}
        if (!IsPostBack)
        {
            TabContainer1.ActiveTabIndex = 0;
            bindGvCourseResult();
            bindCourseAgenda();
        //    bindGradeCourse();
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
    protected void btQuery1_Click(object sender, EventArgs e)
    {
        //ViewState["qInfo"] = null;
        QueryInfo qInfo = new QueryInfo();
        if (ddlGrade1.SelectedIndex != 0)
        {
            qInfo.Grade = ddlGrade1.SelectedValue;
        }
        if (ddlSchool1.SelectedIndex != 0)
        {
            qInfo.TSchoolID = ddlSchool1.SelectedValue;
        }
        if (ddlTerm1.SelectedIndex != 0)
        {
            qInfo.Time = ddlTerm1.SelectedValue;
        }
        ViewState["qInfo"] = qInfo;
        bindGradeCourse();
    }
    protected void gvGradeCourse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int courseid = Convert.ToInt32(gvGradeCourse.DataKeys[e.Row.RowIndex].Value);
            LinkButton lb = (LinkButton)e.Row.FindControl("lbStuInfo");
            lb.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + courseid + "',560,500)"); 
            //lb.Attributes.Add("onclick", "window.open('CourseChoosingDetails.aspx?id=" + courseid + "',null,'width=560,height=500,top=150,left=200,scrollbars=yes')");
            Label l = (Label)e.Row.FindControl("lblCourseNum");
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseChoosingNum(courseid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                l.Text = ds.Tables[0].Rows[0]["num"].ToString();
            }
        }      
        
    }
    protected void btQuery2_Click(object sender, EventArgs e)
    {
        string studentID = tbStudentID.Text.Trim();
        RoleManage rMag = new RoleManage();
        //判断当前学号是否属于MSE
        DataSet ds = rMag.GetUsersFromMSE(studentID);
        //判断当前学号是否存在
        if (studentID.Length != 10||ds.Tables[0].Rows.Count ==0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "当前学生账号不存在";
            lblMsg.Visible = false;
            div_studCourse.Visible = false;
            return;
        }
        ViewState["studentID"] = studentID;
        bindStudentCourse();
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
    protected void gvStuCourse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbDelete = (LinkButton)e.Row.FindControl("lbDelete");
            string studentID = ViewState["studentID"].ToString();
            int courseID = Convert.ToInt32(gvStuCourse.DataKeys[e.Row.RowIndex].Value);
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetRecordFromExamResult(studentID, courseID);
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["CourResult"] != System.DBNull.Value
                && ds.Tables[0].Rows[0]["CourResult"].ToString().Trim() != "")
            {
                //该学生该门课程有成绩
                lbDelete.Attributes.Add("onclick", "javascript:alert('该门课程已有成绩不能退选')");   
            }
            else
            { 
                //还没有成绩
                lbDelete.Attributes.Add("onclick", "javascript:return confirm('你确定要退选：\"" + e.Row.Cells[0].Text + "\"这门课程吗?')");
            }
        }
    }  
    protected void bindGvCourseResult()
    {
        TeachingAgendaManage taMag = new TeachingAgendaManage();
        DataSet ds = taMag.GetUnhandleChoosingCourseArragement();
        gvCourseResult.DataSource = ds.Tables[0];
        gvCourseResult.DataBind();
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            lblMes.Text = "当前没有选课结果需要你处理:-)";
        }
        else
        {
            lblMes.Text = "当前有" + count + "条消息需要你处理：";
            lblMes.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void gvCourseResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCourseResult.PageIndex = e.NewPageIndex;
        bindGvCourseResult();
    }
    protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 3;
        if (ddlTerm.SelectedIndex != 0)
        {
            bindAllCourse(ddlTerm.SelectedValue);
        }
        if (ddlTerm.SelectedIndex == 0)
        {
            lblCourseMsg.Visible = false;
        }
    }
    protected void gvAllCourse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            if (ViewState["studentID"] != null)
            {
                string studentID = ViewState["studentID"].ToString();
                int courseID = Convert.ToInt32(gvAllCourse.DataKeys[e.Row.RowIndex].Value);
                if (CourseManage.GetCourseFromExamRes(courseID, studentID) == true)
                { 
                    //该生已经选了这门课
                    Button btSelect = (Button)e.Row.FindControl("btSelect");
                    btSelect.Enabled = false;
                    btSelect.Text = "已选定";
                }
            }
        }
    }
    protected void gvAllCourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdSelect")
        {
            if (ViewState["studentID"] != null)
            {
                string studentID = ViewState["studentID"].ToString();
                int courseID = Convert.ToInt32(e.CommandArgument);
                CourseManage cMag = new CourseManage();
                if (cMag.AddCoursesForStudentByAdmin(courseID, studentID) == false)
                {
                    Response.Write("<script language='javascript'>alert('选定失败，请重试')</script>");
                }
                else
                {
                    bindStudentCourse();
                    bindAllCourse(ddlTerm.SelectedValue);
                }
            }
        }
    }
    protected void bindStudentCourse()
    {
        if (ViewState["studentID"] != null)
        {
            string studentID = ViewState["studentID"].ToString();
            CourseManage cMag = new CourseManage();
            StudentManage sMag = new StudentManage();
            DataSet ds = null;
            ds = sMag.GetStusInfo(studentID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblNameAndID.Text = "学号：<span  style='font-size:large; font-weight:bold; color:Red'>" +
                   ds.Tables[0].Rows[0]["StudentID"].ToString() + "</span> 姓名：<span  style='font-size:large; font-weight:bold; color:Red'>" +
                   ds.Tables[0].Rows[0]["sName"].ToString() + "</span>";
                lblGradeAndSchool.Text = " 年级：<span  style='font-size:large; font-weight:bold; color:Red'>" +
                    ds.Tables[0].Rows[0]["Grade"].ToString() + "</span> 教学点：<span  style='font-size:large; font-weight:bold; color:Red'>" +
                    ds.Tables[0].Rows[0]["TeaSchoolName"].ToString() + "</span>";
            }
            ds = cMag.GetAllMyCourseInfo(studentID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMessage.Visible = false;
                div_studCourse.Visible = true;
                
                lblCourseMsg.Visible = false;
                lblMsg.Visible = false;
            }
            else
            {
                div_studCourse.Visible = true;
                lblMessage.Visible = false;
                lblMsg.Text = "课程记录不存在";
                lblMsg.Visible = true;
            }
            gvStuCourse.DataSource = ds.Tables[0];
            gvStuCourse.DataBind();
        }
    }
    protected void bindAllCourse(string term)
    {
        if (ViewState["studentID"] != null)
        {
            string studentID = ViewState["studentID"].ToString();
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseInfo(term, studentID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCourseMsg.Visible = false;
            }
            else
            {
                lblCourseMsg.Visible = true;
            }
            gvAllCourse.DataSource = ds.Tables[0];
            gvAllCourse.DataBind();
        }
    }
    protected void gvStuCourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdDelete")
        {
            if (ViewState["studentID"] != null)
            {
                string studentID = ViewState["studentID"].ToString();
                int courseID = Convert.ToInt32(e.CommandArgument);
                CourseManage cMag = new CourseManage();
                DataSet ds = cMag.GetRecordFromExamResult(studentID, courseID);
                //判断该学生该课程的考试成绩是否存在
                if (ds.Tables[0].Rows[0]["CourResult"] != System.DBNull.Value && ds.Tables[0].Rows[0]["CourResult"].ToString().Trim() != "")
                {
                    //表示该门课程已经有成绩
                    return;
                }
                //删除相关选课课程
                if (cMag.DelCoursesForStudent(courseID, studentID) == true)
                {
                    bindStudentCourse();
                    bindAllCourse(ddlTerm.SelectedValue);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('退选失败，请重试')</script>", false);
                    return;
                }
            }
        }
    }
    protected void bindGradeCourse()
    {
        if (ViewState["qInfo"] != null)
        {
            //查询
            QueryInfo qInfo = (QueryInfo)ViewState["qInfo"];
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseOfGradeInfo(qInfo);
            gvGradeCourse.DataSource = ds.Tables[0];
            gvGradeCourse.DataBind();
        }
        else
        {
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseOfGradeInfo();
            gvGradeCourse.DataSource = ds.Tables[0];
            gvGradeCourse.DataBind();
        }
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (TabContainer1.ActiveTabIndex == 2)
        {
            bindGradeCourse();
        }
    }
    protected void gvGradeCourse_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlTerm_Init(object sender, EventArgs e)
    {
    
    }
    protected void btQuery2_Init(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this).RegisterPostBackControl(btQuery2);
    }
    protected void bindCourseAgenda()
    {
        TeachingAgendaManage taMag = new TeachingAgendaManage();
        DataSet ds = taMag.GetAllChoosingCourseAgenda();
        if(ds.Tables[0].Rows.Count == 0)
        {
            lblAgendaMsg.Text = "当前还没有选课日程信息:-)";
            div_Agenda.Visible = false;
        }
        else
        {
            lblAgendaMsg.Text = "";
            div_Agenda.Visible = true;
        }
        gvCourseAgenda.DataSource = ds.Tables[0];
        gvCourseAgenda.DataBind();
    }
    protected string GetStatus(object sTime,object eTime)
    {
        DateTime startTime = Convert.ToDateTime(sTime);
        DateTime endTime = Convert.ToDateTime(eTime);
        DateTime now =  System.DateTime.Now.Date;
        if (startTime > now)
        {
            return "准备中";
        }
        else if (startTime <= now && endTime >= now)
        {
            return "选课中";
        }
        else
        {
            return "历史记录";
        }
    }
    protected void gvCourseAgenda_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            Button btNotChooseCourse = (Button)e.Row.FindControl("btNotChooseCourse");
            if (string.Compare(lblStatus.Text, "历史记录") == 0
                || string.Compare(lblStatus.Text, "选课中") == 0)
            {
                btNotChooseCourse.Visible = false;
                btNotChooseCourse.Enabled = false;
            }
            else
            {
                btNotChooseCourse.Attributes.Add("onclick", "javascript:return confirm('你确认要改为非网上选课吗？')");
            }
        }
    }
    protected void gvCourseAgenda_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Label lblStatus = (Label)gvCourseAgenda.Rows[e.NewEditIndex].FindControl("lblStatus");
        if (string.Compare(lblStatus.Text, "历史记录") == 0
            || string.Compare(lblStatus.Text, "选课中") == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('已经不能修改选课时间！')</script>", false);
            return;
        }
        gvCourseAgenda.EditIndex = e.NewEditIndex;
        bindCourseAgenda();
    }
    protected void gvCourseAgenda_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void gvCourseAgenda_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int teaMagID = Convert.ToInt32(gvCourseAgenda.DataKeys[e.RowIndex].Value);
        TextBox tbStartTime = (TextBox)gvCourseAgenda.Rows[e.RowIndex].FindControl("tbStartTime");
        TextBox tbEndTime = (TextBox)gvCourseAgenda.Rows[e.RowIndex].FindControl("tbEndTime");
        if(isTimeValid(tbStartTime.Text.Trim()) && isTimeValid(tbEndTime.Text.Trim()))
        {
            if(Convert.ToDateTime(tbStartTime.Text.Trim()) < System.DateTime.Now.Date)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('选课开始时间必须大于等于当前时间')</script>", false);
                return;
            }
            if(Convert.ToDateTime(tbStartTime.Text.Trim()) > Convert.ToDateTime(tbEndTime.Text.Trim()))
            {
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('选课开始时间必须小于等于选课结束时间')</script>", false);
                return;
            }
        }
        TeachingAgendaManage taMag = new TeachingAgendaManage();
        if (taMag.UpdateChoosingCourseAgenda(tbStartTime.Text.Trim(), tbEndTime.Text.Trim(), teaMagID) == true)
        {
            gvCourseAgenda.EditIndex = -1;
            bindCourseAgenda();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('更新失败，请重试')</script>", false);
            return;
        }
    }
    protected void gvCourseAgenda_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCourseAgenda.EditIndex = -1;
        bindCourseAgenda();
    }
    protected bool isTimeValid(string time)
    {
        try
        {
            Convert.ToDateTime(time.Trim());
            return true;
        }
        catch {
            return false;
        }
    }
    protected void gvCourseAgenda_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdModify")
        {
            int teaMagID = Convert.ToInt32(e.CommandArgument);
            TeachingAgendaManage taMag = new TeachingAgendaManage();
            CourseManage cMag =new CourseManage();
            List<int> courseID = new List<int>();
            QueryInfo qInfo = new QueryInfo();
            DataSet ds = null;
            ds = taMag.GetAgendaByTeaMagID(teaMagID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                DateTime startTime = Convert.ToDateTime(dr["StartTime"]);
                qInfo.Grade = dr["Grade"].ToString();
                qInfo.TSchoolID = dr["TeaSchoolID"].ToString();
                qInfo.Time = dr["Term"].ToString();
                if (startTime > System.DateTime.Now.Date)
                {
                    //将需要网上选课的课程改为不需要网上选课
                    ds = cMag.GetAllCourseInfoByAgendaID(teaMagID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            courseID.Add(Convert.ToInt32(ds.Tables[0].Rows[i]["CourseID"]));
                        }
                        if (cMag.UpdateNetChooseCourseToNotChooseCourseByTran(qInfo, courseID, teaMagID) == true)
                        {
                            bindCourseAgenda();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('操作成功')</script>", false);
                            return;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('操作失败，请重试')</script>", false);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('已经不能修改选课类型了')</script>", false);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('操作失败，请重试)</script>", false);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('操作失败，请重试)</script>", false);
                return;
            }
        }
    }
}
