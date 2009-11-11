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

public partial class Engineering_TeacherBackMag_AboutPaperSubmitingRecorder : System.Web.UI.Page
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
            bindData();
        }
    }
    protected void bindData()
    {
        DiscussionInfo dInfo = new DiscussionInfo();
        DataSet ds = dInfo.GetDiscussionInfoByTeacherID(teacherID);
        gvRecorder.DataSource = ds.Tables[0];
        gvRecorder.DataBind();
    }
    protected void gvRecorder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            int itemID = Convert.ToInt32(gvRecorder.DataKeys[e.Row.RowIndex].Value);
            DataSet ds = null;
            DiscussionInfo dInfo = new DiscussionInfo();
            ds = dInfo.GetPaperDiscussionLatestTime(itemID);
            e.Row.Cells[3].Text = GetTimeString(Convert.ToDateTime(ds.Tables[0].Rows[0]["MaxTime"]));

            HyperLink lb = (HyperLink)e.Row.FindControl("hlTitle");
            lb.NavigateUrl = "PaperRecorderDetails.aspx?id=" + itemID;
            ds = dInfo.GetDiscussionByItemID(itemID);
            int status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"].ToString().Substring(1, 1));
            if (status == 0)
            {
                e.Row.Font.Bold = true;
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
    public string GetCategory(int category)
    {
        if (category == 1)
        {
            return "开题";
        }
        if (category == 2)
        {
            return "校导";
        }
        if (category == 3)
        {
            return "中期";
        }
        if (category == 4)
        {
            return "论文";
        }
        else
            return null;
    }
    public string GetTimeString(DateTime dt)
    {
        if (string.Compare(dt.ToString("yyyy-MM-dd"), System.DateTime.Now.ToString("yyyy-MM-dd")) == 0)
        {
            return dt.ToString("HH:mm");
        }
        else
        {
            return dt.ToString("MM月dd日");
        }
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedIndex == 0)
        {
            bindData();
        }
        else
        {
            DiscussionInfo dInfo = new DiscussionInfo();
            QueryInfo qInfo = new QueryInfo();
            qInfo.ActivityStatus = Convert.ToInt32(ddlStatus.SelectedValue);
            DataSet ds = dInfo.GetDiscussionByTeacherIDAndQuery(teacherID, qInfo);
            gvRecorder.DataSource = ds.Tables[0];
            gvRecorder.DataBind();
        }
    }
    protected void btQuery_Click(object sender, EventArgs e)
    {
        DiscussionInfo dInfo = new DiscussionInfo();
        QueryInfo qInfo = new QueryInfo();
        if (tbStuID.Text.Trim() != "")
        {
            qInfo.AccountID = tbStuID.Text.Trim();
        }
        if (ddlStatus.SelectedIndex != 0)
        {
            qInfo.ActivityStatus = Convert.ToInt32(ddlStatus.SelectedValue);
        }
        DataSet ds = dInfo.GetDiscussionByTeacherIDAndQuery(teacherID, qInfo);
        gvRecorder.DataSource = ds.Tables[0];
        gvRecorder.DataBind();
    }
}
