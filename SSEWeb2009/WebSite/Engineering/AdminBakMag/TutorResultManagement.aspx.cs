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

public partial class Engineering_AdminBakMag_TutorResultManage : System.Web.UI.Page
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
            bindResult();
        }
    }
    protected void bindResult()
    {
        TeacherManage tMag = new TeacherManage();
        DataSet ds = tMag.GetCompleteTutorTime();
        gvChoosingResult.DataSource = ds.Tables[0];
        gvChoosingResult.DataBind();
        int num = ds.Tables[0].Rows.Count;
        if (num > 0)
        {
            lblDisposeRes.Text = "当前有"+num +"条消息等待处理：";
            lblDisposeRes.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lblDisposeRes.Text = "暂时没有记录需要你处理:)";
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
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择年级！')</script>");
            return;
        }
        if (ddlSchool.SelectedIndex != 0)
        {
            qInfo.TSchoolID = ddlSchool.SelectedValue;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择教学点！')</script>");
            return;
        }
        ViewState["qInfo"] = qInfo;
        bindStudentTutor();
    }
    protected void gvStuInfo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvStuInfo.EditIndex = e.NewEditIndex;
        bindStudentTutor();
    }
    protected void bindStudentTutor()
    {
        if (ViewState["qInfo"] != null)
        {
            QueryInfo qInfo = (QueryInfo)ViewState["qInfo"];
            TeacherManage tMag = new TeacherManage();
            //判断当前的分配结果是否已经被管理员确认
            DataSet ds = tMag.GetTutorChoosingStatus(qInfo);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //已被管理员确认，并公布
                lblResutl.Visible = true;
                StudentManage sMag = new StudentManage();
                DataSet ds1 = sMag.GetStusInfo(qInfo);
                int num = ds1.Tables[0].Rows.Count;
                lblResutl.Text = "该教学点共有" + num + "个学生，其导师分配情况如下：";
                gvStuInfo.DataSource = ds1.Tables[0];
                gvStuInfo.DataBind();
            }
            else
            {
                lblResutl.Visible = false;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该教学点的分配记录不存在或者尚处于分配中')</script>");
                gvStuInfo.DataSource = null;
                gvStuInfo.DataBind();
            }
        }
    }
    protected void gvStuInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvStuInfo.EditIndex = -1;
        bindStudentTutor();
    }
    protected void gvStuInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DropDownList dl = (DropDownList)gvStuInfo.Rows[e.RowIndex].FindControl("ddlTutor");
        string studentID = gvStuInfo.DataKeys[e.RowIndex].Value.ToString();
        StudentManage sMag = new StudentManage();
        if (dl.SelectedIndex != 0)
        {
            string teacherID = dl.SelectedValue;
            try
            {
                sMag.UpdateStusTutor(studentID, teacherID);
            }
            catch
            { 
                //更新失败
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('更新失败！')</script>");
            }
        }
        gvStuInfo.EditIndex = -1;
        bindStudentTutor();
    }
}
