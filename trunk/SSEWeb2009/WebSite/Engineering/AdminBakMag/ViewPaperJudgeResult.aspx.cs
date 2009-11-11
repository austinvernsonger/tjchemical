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

public partial class Engineering_AdminBakMag_ViewPaperJudgeResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindPaperJudgeRes();
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
        if (ddlStatus.SelectedIndex != 0)
        {
            qInfo.ActivityStatus = Convert.ToInt32(ddlStatus.SelectedValue);
           // qInfo.AccountID = tbStuNo.Text.Trim();
        }
        ViewState["qInfo"] = qInfo;
        bindPaperJudgeRes();
    }
    protected void bindPaperJudgeRes()
    {
        TeacherManage tMag = new TeacherManage();
        DataSet ds = null;
        if (ViewState["qInfo"] != null)
        {
            //条件查询
            QueryInfo qInfo = (QueryInfo)ViewState["qInfo"];
            ds = tMag.GetPaperJudgeResultByQueryInfo(qInfo);
        }
        else
        {
            // 首次加载
            ds = tMag.GetAllPaperJudgeResult();
        }
        gvPaperJudgeRes.DataSource = ds.Tables[0];
        gvPaperJudgeRes.DataBind();
    }
    protected void gvPaperJudgeRes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            string studentID = gvPaperJudgeRes.DataKeys[e.Row.RowIndex].Value.ToString().Trim();
            LinkButton lnbView = (LinkButton)e.Row.FindControl("lnbView");
            lnbView.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + studentID + "',550,500)"); 
        }
    }
    public string GetJudgeRes(object  status, object res)
    {
        int iStatus = Convert.ToInt32(status);
        int iRes = Convert.ToInt32(res);
        if (iStatus == 0)
        {
            return "尚未评审";
        }
        else 
        {
            if (iRes == 1)
            {
                return "已达到标准";
            }
            else
            {
                return "未达到标准";
            }
        }
    }
}
