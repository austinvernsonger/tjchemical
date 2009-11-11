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

public partial class Engineering_TeacherBackMag_ViewPaperFeedBack : System.Web.UI.Page
{
    private string teacherID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        teacherID = Session["IdentifyNumber"].ToString();
        if (!IsPostBack)
        {
            bindJudgeResult();
        }
        if (IsPostBack)
        {
            CreateGridControl();
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
        if (tbStuNo.Text.Trim() != "")
        {
            qInfo.AccountID = tbStuNo.Text.Trim();
        }
        ViewState["qInfo"] = qInfo;
        bindJudgeResult();
    }
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGrade.SelectedIndex == 0)
        {
            ddlSchool.Items.Clear();
            ddlSchool.Items.Add("--请选择教学点--");
        }
    }
    protected void bindJudgeResult()
    {
        if (ViewState["qInfo"] != null)
        {
            //查询条件
            QueryInfo qInfo =(QueryInfo)ViewState["qInfo"];
            StudentManage sMag = new StudentManage();
            DataSet ds = sMag.GetStudentsInfoByteaId(teacherID, qInfo);
            gvPaperJudgeRes.DataSource = ds.Tables[0];
            gvPaperJudgeRes.DataBind();
        }
        else
        {
            //首次加载
            StudentManage sMag = new StudentManage();
            DataSet ds = sMag.GetStudentsInfoByteaIdWithNoneQuery(teacherID);
            gvPaperJudgeRes.DataSource = ds.Tables[0];
            gvPaperJudgeRes.DataBind();
        }
    }
    protected void gvPaperJudgeRes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            string studentID = gvPaperJudgeRes.DataKeys[e.Row.RowIndex].Value.ToString().Trim();
            StudentManage sMag = new StudentManage();
            DataSet ds = sMag.GetPaperJudgeResultByStuID(studentID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                LinkButton lnbView = new LinkButton();
                lnbView.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + studentID + "',550,500)"); 
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsCriterion"]) == 1)
                {
                    lnbView.Text = "已达到标准";
                    lnbView.ForeColor = System.Drawing.Color.Blue; 
                }
                else
                {
                    lnbView.Text = "尚未达到标准";
                    lnbView.ForeColor = System.Drawing.Color.Red; 
                }
                e.Row.Cells[4].Controls.Add(lnbView);
            }
            else
            {
                Label lblJudgeRes = new Label();
                lblJudgeRes.Text = "尚未评审";
                lblJudgeRes.ForeColor = System.Drawing.Color.Black;
                e.Row.Cells[4].Controls.Add(lblJudgeRes);
            }
        }
    }
    protected void CreateGridControl()
    {
        foreach (GridViewRow row in gvPaperJudgeRes.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                string studentID = gvPaperJudgeRes.DataKeys[row.RowIndex].Value.ToString().Trim();
                StudentManage sMag = new StudentManage();
                DataSet ds = sMag.GetPaperJudgeResultByStuID(studentID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LinkButton lnbView = new LinkButton();
                    lnbView.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + studentID + "',550,500)");
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsCriterion"]) == 1)
                    {
                        lnbView.Text = "已达到标准";
                        lnbView.ForeColor = System.Drawing.Color.Blue;
                        row.Cells[4].Controls.Add(lnbView);
                    }
                    else
                    {
                        lnbView.Text = "尚未达到标准";
                        lnbView.ForeColor = System.Drawing.Color.Red;
                        row.Cells[4].Controls.Add(lnbView);
                    }
                }
                else
                {
                    Label lblJudgeRes = new Label();
                    lblJudgeRes.Text = "尚未评审";
                    lblJudgeRes.ForeColor = System.Drawing.Color.Black;
                    row.Cells[4].Controls.Add(lblJudgeRes);
                }
            }
        }
    }
}
