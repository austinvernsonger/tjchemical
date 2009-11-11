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
using System.IO;
using System.Text;

public partial class Engineering_AdminBakMag_CoursesManagement : System.Web.UI.Page
{
    public string[] sProperty = new string[] { "学位课", "非学位课", "必修环节", "其他" };
    public string[] sCategory = new string[] { "必修", "选修", "其他" };
    private int num = 0;
    private bool uploadSuccess = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        //    if (Session["IdentifyNumber"] == null)
        //    {
        //        SysCom.Login.LoginRedirect(Request.Url.ToString());
        //    }
        if (!IsPostBack)
        {
            TabContainer1.ActiveTabIndex = 0;
            bindDate();
        }
        else
        {
            if (ViewState["Query"] != null)
            {
                //当模态窗口关闭时，重新绑定gvCourse();
                bindDate();
            }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        FileInfo file = new FileInfo(Server.MapPath("~/Engineering/Resources/Files/课程信息录入表.xls"));

        if (file.Exists)
        {
            FileManage.DownLoadFile(file);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('文件不存在！')</script>", false);
            return;
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
    protected void tbSubmit_Click(object sender, EventArgs e)
    {
        ViewState["courseInfo"] = null;
        ViewState["qInfo"] = null;
        QueryInfo qInfo = new QueryInfo();
        if (ddlGrade1.SelectedIndex != 0)
        {
            qInfo.Grade = ddlGrade1.SelectedValue;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择年级')</script>", false);
            return;
        }
        if (ddlSchool1.SelectedIndex != 0)
        {
            qInfo.TSchoolID = ddlSchool1.SelectedValue;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择教学点')</script>", false);
            return;
        }
        if (ddlTerm.SelectedIndex != 0)
        {
            qInfo.Time = ddlTerm.SelectedValue;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择开课学期')</script>", false);
            return;
        }
        if (cbNonSelectTime.Checked == false && cbSelectTime.Checked == false)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择是否要进行网上选课')</script>", false);
            return;
        }
        if (cbSelectTime.Checked == true)
        {
            #region 对输入时间进行验证
            if (tbStartTime.Text.Trim() == ""||tbEndtTime.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择选课时间')</script>", false);
                return;
            }
            if (isValidTime(tbStartTime.Text.Trim()) == false || isValidTime(tbEndtTime.Text.Trim()) == false)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('输入时间不合法，请重输')</script>", false);
                return;
            }
            if (Convert.ToDateTime(tbStartTime.Text.Trim()) < System.DateTime.Now.Date)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('选课的开始时间必须大于等于当前时间')</script>", false);
                return;
            }
            if (Convert.ToDateTime(tbStartTime.Text.Trim()) >Convert.ToDateTime(tbEndtTime.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('选课的结束时间必须大于等于选课的开始时间')</script>", false);
                return;
            }
            #endregion

            qInfo.StartTime = tbStartTime.Text.Trim();
            qInfo.EndTime = tbEndtTime.Text.Trim();
        }
        ViewState["qInfo"] = qInfo;
        if (FileUpload1.HasFile)
        {
            //选判断该年级该教学点该学期的课程信息是否存在
            CourseManage cMag = new CourseManage();
            DataSet ds = null;
            string file = FileUpload1.PostedFile.FileName;
            string extension = Path.GetExtension(file);
            if (extension != ".xls" && extension != ".xlsx")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('只支持excel格式')</script>", false);
                return;
            }
            ExcelEngine ee = new ExcelEngine();
            //将Excel中的课程信息导入进Dataset中
            ds = ee.WriteCourseInfoToDataset(file);
            if (ds.Tables[0].Rows.Count > 0)
            {
                div_courseInfo.Visible = true;
                lblGrade.Text = "年级：" + ddlGrade1.SelectedValue + " 教学点：" + ddlSchool1.SelectedItem.Text + " 学期：" + ddlTerm.SelectedItem.Text;
                if(cbNonSelectTime.Checked == true)
                {
                    //不用网上选课
                    lblMessage.Text = "开课课程如下，请确认信息<span style='color:Red'> (无需网上选课)</span>";
                }
                if (cbSelectTime.Checked == true)
                {
                    //需要网上选课
                    lblMessage.Text = "预开课程如下，选课时间：<span style='color:red'>" + tbStartTime.Text.Trim() + "--" + tbEndtTime.Text.Trim() + "</span>,请确认信息<span style='color:Red'>（需要进行网上选课）</span>";
                }
                ViewState["courseInfo"] = ds;
                bindgvCourseInfo();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('课程信息导入失败')</script>", false);
                gvCourseInfo.DataSource = null;
                gvCourseInfo.DataBind();
                div_courseInfo.Visible = false;
                return;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择课程信息表')</script>", false);
            return;
        }
    }
    protected void gvCourseInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
        if (e.Row.DataItem != null)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                Label lblCourseName = (Label)e.Row.FindControl("lblCourseNamev");
                Label lblCredit = (Label)e.Row.FindControl("lblCreditv");
                Label lblCreditHour = (Label)e.Row.FindControl("lblCreditHourv");
                Label lblProperty = (Label)e.Row.FindControl("lblPropertyv");
                Label lblCategory = (Label)e.Row.FindControl("lblCategoryv");
                QueryInfo qInfo = null;
                if (ViewState["qInfo"] != null)
                {
                    qInfo = (QueryInfo)ViewState["qInfo"];
                }
                CourseManage cMag = new CourseManage();
                DataSet ds = null;
                CourseInfo cInfo = new CourseInfo();
                cInfo.Grade = qInfo.Grade;
                cInfo.TeaSchoolID = qInfo.TSchoolID;
                cInfo.CourseTime = qInfo.Time;
                cInfo.CourseName = lblCourseName.Text.Trim();
                //判断该年级该教学点该学期该课程是否已经存在
                if (cMag.GetCourseInfoByCourseInfo(cInfo) ==true)
                { 
                    //该年级该教学点该学期该课程已存在
                    num++;
                    e.Row.BackColor = System.Drawing.Color.LightSkyBlue;
                }
                //判断学分输入是否合法
                if (isValidNum(lblCredit.Text.Trim()) == false)
                { 
                    //不合法
                    num++;
                    e.Row.Cells[2].BackColor = System.Drawing.Color.Red;
                }
                //判断学时输入是否合法
                if (isValidNum(lblCreditHour.Text.Trim()) == false)
                { 
                    //不合法
                    num++;
                    e.Row.Cells[3].BackColor = System.Drawing.Color.Red;
                }
                //判断课程性质输入是否合法
                if (lblProperty.Text.Contains("必修环节") == true)
                {
                    lblProperty.Text = "必修环节";
                }
                else if (lblProperty.Text.Contains("非学位") == true)
                {
                    lblProperty.Text = "非学位";
                }
                else if (lblProperty.Text.Contains("学位") == true && lblProperty.Text.Contains("非") == false)
                {
                    lblProperty.Text = "学位";
                }
                else
                {
                    num++;
                    e.Row.Cells[4].BackColor = System.Drawing.Color.Red;
                }
                //判断课程类别输入是否合法
                if (lblCategory.Text.Contains("必修") == true)
                {
                    lblCategory.Text = "必修";
                }
                else if (lblCategory.Text.Contains("选修") == true)
                {
                    lblCategory.Text = "选修";
                }
                else
                {
                    num++;
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
                }
                if (num > 0)
                {
                    ViewState["isOk"] = false;
                }
                else
                {
                    ViewState["isOk"] = true;
                }
            }
        }
    }
    protected void ddlGrade2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGrade2.SelectedIndex == 0)
        {
            ddlSchool2.Items.Clear();
            ddlSchool2.Items.Add("--请选择教学点--");
        }
    }
    protected void btQuery_Click(object sender, EventArgs e)
    {
        ViewState["Query"] = null;
        QueryInfo qInfo = new QueryInfo();
        if (ddlGrade2.SelectedIndex != 0)
        {
            qInfo.Grade = ddlGrade2.SelectedValue;
        }
        if (ddlSchool2.SelectedIndex != 0)
        {
            qInfo.TSchoolID = ddlSchool2.SelectedValue;
        }
        if (ddlCourseTerm.SelectedIndex != 0)
        {
            qInfo.Time = ddlCourseTerm.SelectedValue;
        }
        ViewState["Query"] = qInfo;
        bindDate();
    }
    protected void gvCourses_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
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
    
    protected void gvCourses_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            int courseid = Convert.ToInt32(gvCourses.DataKeys[e.Row.RowIndex].Value);
            Label lbCourseName = (Label)e.Row.FindControl("lbCourseName");
            ImageButton lnbEdit = (ImageButton)e.Row.FindControl("lnbEdit");
            lnbEdit.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + courseid + "',550,500)");
            ImageButton lnbDelete = (ImageButton)e.Row.FindControl("imgDelete");
            lnbDelete.Attributes.Add("onclick", "javascript:return confirm('你确认要删除 " + lbCourseName.Text+ " 这门课程吗?')");
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseTeacherInfo(courseid);
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                //上课时间和上课地点是否存在
                if ((ds.Tables[0].Rows[0]["ClassPeriod"] == System.DBNull.Value && ds.Tables[0].Rows[0]["Place"] == System.DBNull.Value)
                    || (ds.Tables[0].Rows[0]["ClassPeriod"].ToString().Trim() == "" && ds.Tables[0].Rows[0]["Place"].ToString().Trim()==""))
                {
                    //上课时间和上课地点不存在
                    Label lblText = (Label)e.Row.FindControl("lblTextDetails");
                    lblText.Visible = true;
                }
                else
                {
                    //上课时间或上课地点存在
                    LinkButton lb = (LinkButton)e.Row.FindControl("lbViewDetails");
                    lb.Visible = true;
                }
                //该门课程是否有任课教师
                if (count ==1)
                {
                    if (ds.Tables[0].Rows[0]["Name"] != System.DBNull.Value)
                    {
                        e.Row.Cells[5].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    }
                }
                if (count == 2)
                {
                    e.Row.Cells[5].Text = ds.Tables[0].Rows[0]["Name"].ToString() + "," + ds.Tables[0].Rows[1]["Name"].ToString();
                }
            }
        } 
    }
    protected void bindDate()
    {
        CourseManage cMag = new CourseManage();
        DataSet ds = null;
        if (ViewState["Query"] != null)
        {
            //查询结果
            QueryInfo qInfo = (QueryInfo)ViewState["Query"];    
            ds = cMag.GetCourseInfo(qInfo);
        }
        else
        { 
            //第一次加载或没有查询条件的时候
            ds = cMag.GetCourseInfo();  
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            btNewCourse.Visible = true;
            btNewCourse.Enabled = true;
        }
        else
        {
            btNewCourse.Visible = false;
            btNewCourse.Enabled = false;
        }
        gvCourses.DataSource = ds.Tables[0];
        gvCourses.DataBind();
    }
    protected void gvCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btCancel_Click(object sender, EventArgs e)
    {
        gvCourseInfo.DataSource = null;
        gvCourseInfo.DataBind();
        div_courseInfo.Visible = false;
        cbNonSelectTime.Checked = false;
        cbSelectTime.Checked = false;
        ddlGrade1.SelectedIndex = 0;
        ddlSchool1.SelectedIndex = 0;
        ddlTerm.SelectedIndex = 0;
        tbStartTime.Text = "";
        tbEndtTime.Text = "";
    }
    protected void btConfirm_Click(object sender, EventArgs e)
    {
        if (ViewState["isOk"] != null && (bool)ViewState["isOk"] == true)
        {
            DataSet ds = (DataSet)ViewState["courseInfo"];
            QueryInfo qInfo = (QueryInfo)ViewState["qInfo"];
            CourseManage cMag = new CourseManage();
            if (qInfo.StartTime == null && qInfo.EndTime == null)
            {
                //不需要网上选课
                if (cMag.AddCourseInfoWithoutNetChoosingByTran(ds, qInfo) == true)
                {
                    //上传成功
                    uploadSuccess = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('课程信息上传成功！')</script>", false);
                    return;
                }
                else
                {
                    //上传失败
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('课程信息上传失败，请重试！')</script>", false);
                    return;
                }
            }
            else
            {
                //需要网上选课
                // 将DateSet中的课程信息导入进数据库中
                if (cMag.AddCourseInformationByTran(ds, qInfo) == true)
                {
                    //上传成功
                    uploadSuccess = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('课程信息上传成功！')</script>", false);
                    return;
                }
                else
                {
                    //上传失败
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('课程信息上传失败，请重试！')</script>", false);
                    return;
                }
            }
        }
        else
        {
            //验证不通过
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('上传数据不合法，请更正后重新上传！')</script>", false);
            return;
        }
    }
    protected void gvCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCourses.PageIndex = e.NewPageIndex;
        bindDate();
    }
    protected bool isValidTime(string time)
    {
        try
        {
            Convert.ToDateTime(time);
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void bindgvCourseInfo()
    {
        if (ViewState["courseInfo"] != null)
        {
            DataSet ds = (DataSet)ViewState["courseInfo"];
            gvCourseInfo.DataSource = ds.Tables[0];
            gvCourseInfo.DataBind();
        }
    }
    protected bool isValidNum(string number)
    {
        try
        {
            Convert.ToInt32(number);
            return true;
        }
        catch {
            return false;
        }
    }
    protected void gvCourseInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (ViewState["courseInfo"] != null)
        {
            DataSet ds = (DataSet)ViewState["courseInfo"];
            ds.Tables[0].Rows[e.RowIndex].Delete();
            ds.AcceptChanges();
            ViewState["courseInfo"] = ds;
            bindgvCourseInfo();
        }
    }
    protected void gvCourseInfo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCourseInfo.EditIndex = e.NewEditIndex;
        bindgvCourseInfo();
    }
    protected void gvCourseInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (ViewState["courseInfo"] != null)
        {
            DataSet ds = (DataSet)ViewState["courseInfo"];
            TextBox tbCourseName = (TextBox)gvCourseInfo.Rows[e.RowIndex].FindControl("tbCourseNamei");
            TextBox tbCredit = (TextBox)gvCourseInfo.Rows[e.RowIndex].FindControl("tbCrediti");
            TextBox tbCreditHour = (TextBox)gvCourseInfo.Rows[e.RowIndex].FindControl("tbCreditHouri");
            TextBox tbProperty = (TextBox)gvCourseInfo.Rows[e.RowIndex].FindControl("tbPropertyi");
            TextBox tbCategory = (TextBox)gvCourseInfo.Rows[e.RowIndex].FindControl("tbCategoryi");
            TextBox tbExamMode = (TextBox)gvCourseInfo.Rows[e.RowIndex].FindControl("tbExamModei");
            TextBox tbIntruMode = (TextBox)gvCourseInfo.Rows[e.RowIndex].FindControl("tbIntruModei");
            TextBox tbClassPeriod = (TextBox)gvCourseInfo.Rows[e.RowIndex].FindControl("tbClassPeriodi");
            TextBox tbPlace = (TextBox)gvCourseInfo.Rows[e.RowIndex].FindControl("tbPlacei");
            DataRow dr = ds.Tables[0].Rows[e.RowIndex];
            dr["courseName"] = tbCourseName.Text.Trim();
            dr["credit"] = tbCredit.Text.Trim();
            dr["creditHour"] = tbCreditHour.Text.Trim();
            dr["property"] = tbProperty.Text.Trim();
            dr["category"] = tbCategory.Text.Trim();
            dr["examMode"] = tbExamMode.Text.Trim();
            dr["instruMode"] = tbIntruMode.Text.Trim();
            dr["classPeriod"] = tbClassPeriod.Text.Trim();
            dr["place"] = tbPlace.Text.Trim();
            ds.AcceptChanges();
            ViewState["courseInfo"] = ds;
            gvCourseInfo.EditIndex = -1;
            bindgvCourseInfo();
        }
    }
    protected void gvCourseInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCourseInfo.EditIndex = -1;
        bindgvCourseInfo();
    }
    protected void TabContainer1_PreRender(object sender, EventArgs e)
    {
        if (uploadSuccess == true)
        {
            ViewState["courseInfo"] = null;
            ViewState["qInfo"] = null;
            gvCourseInfo.DataSource = null;
            gvCourseInfo.DataBind();
            div_courseInfo.Visible = false;
            cbNonSelectTime.Checked = false;
            cbSelectTime.Checked = false;
            ddlGrade1.SelectedIndex = 0;
            ddlSchool1.SelectedIndex = 0;
            ddlTerm.SelectedIndex = 0;
            tbStartTime.Text = "";
            tbEndtTime.Text = "";
        }
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (TabContainer1.ActiveTabIndex == 0)
        {
            bindDate();
        }
    }
    protected void tbSubmit_Init(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this).RegisterPostBackControl(tbSubmit);
    }
    protected void lbCourseInfo_Init(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this).RegisterPostBackControl(lbCourseInfo);
    }
    protected void btQuery_PreRender(object sender, EventArgs e)
    {
      
    }
    protected void btQuery_Init(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this).RegisterPostBackControl(btQuery);
    }
    protected void gvCourses_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdDelete")
        {
            int courseID = Convert.ToInt32(e.CommandArgument);
            CourseManage cMag = new CourseManage();
            if (cMag.TransactionDeleteAllCourses(courseID) == true)
            {
                bindDate();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('删除失败，请重试')</script>", false);
            }
        }
    }
}
