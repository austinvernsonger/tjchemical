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

public partial class Engineering_AdminBakMag_ApplyInfoManagement : System.Web.UI.Page
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
            //绑定处于学籍变动中学籍信息
            BindApplyRecord();
            //绑定待处理的学籍变动信息
            bindUnhandleStatusApp();
        }
    }
    protected void btQuery_Click(object sender, EventArgs e)
    {
        if (ddlSchoolStatus.SelectedIndex == 0 && ddlActivity.SelectedIndex == 0 )
        {
            Response.Write("<script>alert('请输入查询条件！')</script>");
            return;
        }
        ViewState["qInfo"] = null;
        QueryInfo qInfo = new QueryInfo();
        if (ddlSchoolStatus.SelectedIndex != 0)
        {
            qInfo.SchoolStatus = ddlSchoolStatus.Text;
        }
        if (ddlActivity.SelectedIndex != 0)
        {
            qInfo.ActivityStatus = ddlActivity.SelectedIndex;
        }
        ViewState["qInfo"] = qInfo;
        BindApplyRecord();
    }
    protected void gvApplyRecord_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (Convert.ToInt32(drv["Activiy"]) == 0 && Convert.ToInt32(drv["ApplyResult"]) != 0)
            {
                Button bt = (Button)e.Row.FindControl("btBackSchool");
                bt.Visible = true;
                bt.Attributes.Add("onclick", "javascript:return confirm('你确认该学生已经返校了吗?')");
            }
            int applyID = Convert.ToInt32(gvApplyRecord.DataKeys[e.Row.RowIndex].Value);
            LinkButton lbViewDetail = (LinkButton)e.Row.FindControl("lbViewDetails");
            lbViewDetail.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + applyID + "',550,500)"); 
        }
    }
    protected void gvApplyRecord_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "backschool")
        {
            int ID =   Convert.ToInt32(e.CommandArgument);
            StatusChgAppMgr sca = new StatusChgAppMgr();
            if (sca.UpdateAppStatusActivityAndBackTime(ID) == true)
            {
                BindApplyRecord();
             }
            else
            {
                BindApplyRecord();
            }
        }
    }
    public string GetStatus(int activity, int applyResult)
    {
        if (applyResult == 0)
        {
            return "等待处理";
        }
        else if (activity == 1)
        {
            return "历史记录";
        }
        else if (activity == 2)
        {
            return "历史记录";
        }
        return "活动中";
    }
    public void BindApplyRecord()
    {
        StatusChgAppMgr scm = new StatusChgAppMgr();
        DataSet ds = null;
        if (ViewState["qInfo"] != null)
        {
            //查询结果
            QueryInfo qInfo = (QueryInfo)ViewState["qInfo"];
            ds = scm.GetStatusChgRecord(qInfo);
        }
        else
        { 
            //首次加载
            ds = scm.GetStatusChgRecord();
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            div_ApplyRecord.Visible = true;
        }
        else
        {
            div_ApplyRecord.Visible = false;
        }
        gvApplyRecord.DataSource = ds.Tables[0];
        gvApplyRecord.DataBind();
    }
    protected void gvApplyRecord_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void ddlActivity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void bindUnhandleStatusApp()
    {
        StatusChgAppMgr scm = new StatusChgAppMgr();
        DataSet ds = scm.GetUnhandleStatusApp();
        gvAppInfomation.DataSource = ds.Tables[0];
        gvAppInfomation.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbRestult.Text = "有 " + ds.Tables[0].Rows.Count + " 个学籍变动申请待处理:";
            lbRestult.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lbRestult.Text = "没有学籍变动信息需要你受理:-)";
        }
    }
    protected void gvApplyRecord_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
