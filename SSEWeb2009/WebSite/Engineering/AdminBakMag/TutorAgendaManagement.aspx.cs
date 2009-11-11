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

public partial class Engineering_AdminBakMag_TutorAgendaManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["IdentifyNumber"] == null)
        //{
        //    SysCom.Login.LoginRedirect(Request.Url.ToString());
        //}
        if (!IsPostBack)
        {
            TabContainer1.ActiveTabIndex = 0;
            bindTutorAgenda();
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
    
    protected void ddlViewGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlViewGrade.SelectedIndex == 0)
        {
            ddlViewSchool.Items.Clear();
            ddlViewSchool.Items.Add("--请选择教学点--");
        }
    }
    protected void tbSubmit_Click(object sender, EventArgs e)
    {
        QueryInfo qInfo = new QueryInfo();

        #region 验证合法性
        if (ddlGrade.SelectedIndex != 0)
        {
            qInfo.Grade = ddlGrade.SelectedValue;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择年级！')</script>", false);
            return;
        }
        if (ddlSchool.SelectedIndex != 0)
        {
            qInfo.TSchoolID = ddlSchool.SelectedValue;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择教学点！')</script>", false);
            return;
        }
        if (IsTimeValid(tbStartTime.Text.Trim()) == true)
        {
            if (Convert.ToDateTime(tbStartTime.Text.Trim()) < System.DateTime.Now.Date)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('选导师开始时间必须大于等于当前时间！')</script>", false);
                return;
            }
            else
            {
                qInfo.StartTime = tbStartTime.Text.Trim();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('输入开始时间不合法！')</script>", false);
            return;
        }
        if (IsTimeValid(tbEndTime.Text.Trim()) == true)
        {
            if (Convert.ToDateTime(tbStartTime.Text.Trim()) > Convert.ToDateTime(tbEndTime.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('选导师的结束时间必须大于等于开始时间！')</script>", false);
                return;
            }
            else
            {
                qInfo.EndTime = tbEndTime.Text.Trim();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('输入结束时间不合法！')</script>", false);
            return;
        }
       
        #endregion

        TeacherManage tMag = new TeacherManage();
        //判断该年级该教学的选导师日程是否已经存在
        DataSet ds = tMag.GetTeaChooseTimeByQInfo(qInfo);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string grade = ds.Tables[0].Rows[0]["Grade"].ToString();
            string teaSchoolName = ds.Tables[0].Rows[0]["TeaSchoolName"].ToString()+"教学点";
            string gschool = grade + teaSchoolName;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('" + gschool + "的选导师日程已经存在，本次添加失败，请确认！')</script>");
            return;
        }
        //将选导师日程添加进数据库
        if (true == tMag.AddTeacherChooseTime(qInfo))
        {
            bindTutorAgenda();
            ddlGrade.SelectedIndex = 0;
            ddlSchool.Items.Clear();
            ddlSchool.Items.Add("--请选择教学点--");
            tbStartTime.Text = "";
            tbEndTime.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('添加成功！')</script>", false);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('操作失败，请重试！')</script>", false);
            return;
        }
    }
    protected void btQuery_Click(object sender, EventArgs e)
    {
        QueryInfo qInfo = new QueryInfo();
        if (ddlViewGrade.SelectedIndex != 0)
        {
            qInfo.Grade = ddlViewGrade.SelectedValue;
        }
        if (ddlViewSchool.SelectedIndex != 0)
        {
            qInfo.TSchoolID = ddlViewSchool.SelectedValue;
        }
        ViewState["qInfo"] = qInfo;
        bindTutorAgenda();
    }
    protected void gvTutorTime_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            ((ImageButton)e.Row.FindControl("lnbDelete")).Attributes.Add("onclick", "javascript:return confirm('你确认要删除这条选导师日程？')");
        }
    }

    public string GetCurrentStatus(string time)
    {
        string[] sTime = time.Split('|');
        DateTime nowTime = System.DateTime.Now.Date;
        if (Convert.ToDateTime(sTime[0]) <= nowTime && nowTime <= Convert.ToDateTime(sTime[1]))
        {
            return "学生选导师中...";
        }
        if (nowTime > Convert.ToDateTime(sTime[1]))
        {
            TimeSpan ts = nowTime - Convert.ToDateTime(sTime[1]);
            if (ts.Days <= 15)
            {
                return "导师选学生中...";
            }
            else
            {
                return "历史记录";
            }
        }
        else
        {
            return "准备中...";
        }
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
    }
    protected void bindTutorAgenda()
    {
        TeacherManage tMag = new TeacherManage();
        DataSet ds = null;
        if (ViewState["qInfo"] != null)
        {
            QueryInfo qInfo = (QueryInfo)ViewState["qInfo"];
            ds = tMag.GetTeaChooseTimeByQInfo(qInfo);
        }
        else
        {
            ds = tMag.GetTeaChooseTimeByQInfo();  
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            div_Remark.Visible = true;
        }
        else
        {
            div_Remark.Visible = false;
        }
        gvTutorTime.DataSource = ds.Tables[0];
        gvTutorTime.DataBind();
    }
    protected bool IsTimeValid(string time)
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
    protected void gvTutorTime_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdDelete")
        {
            int TeaMagID = Convert.ToInt32(e.CommandArgument);
            TeachingAgendaManage taMag = new TeachingAgendaManage();
            if (taMag.DeleteTutorChoosingAgendaByTran(TeaMagID) == true)
            {
                //删除成功
                bindTutorAgenda();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('删除失败')</script>", false);
                return;
            }
        }
    }
    protected void gvTutorTime_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}
