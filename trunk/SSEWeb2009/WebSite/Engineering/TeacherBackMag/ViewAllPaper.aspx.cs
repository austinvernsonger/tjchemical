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

public partial class Engineering_TeacherBackMag_ViewAllPaper : System.Web.UI.Page
{
    private string teacherID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        teacherID = Session["IdentifyNumber"].ToString();
        TeacherManage tMag = new TeacherManage();
        DataSet ds = new DataSet();
        ds = tMag.GetAllPrePaper(teacherID);
        gvAllPrePaper.DataSource = ds.Tables[0];
        gvAllPrePaper.DataBind();
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            lblResult.Text = "当前还没有预审论文需要评阅!";
           
        }
        else
        {
            int hasJudage = 0;
            for (int i = 0; i < count; i++)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["JudgeStatue"]) == 1)
                {
                    hasJudage++;
                }
            }
            lblResult.Text = "当前有 " + count + " 篇论文需要评阅：";
            lblResult.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void gvAllPrePaper_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string bNo = e.Row.Cells[0].Text;
            HyperLink hl = (HyperLink)e.Row.FindControl("hlPaper");
            hl.NavigateUrl = "PreAllPaperDetails.aspx?id="+bNo;
            TeacherManage tMag = new TeacherManage();
            DataSet ds = tMag.GetAllPrePaperBybNo(bNo);
            int count = ds.Tables[0].Rows.Count;
            string isLeader = "";
            for (int i = 0; i < count; i++)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["IsLeader"]) == 1)
                {
                    if (string.Compare(ds.Tables[0].Rows[i]["TeacherID"].ToString(), teacherID) ==0)
                    {
                        isLeader = "我";
                    }
                    else
                    {
                        isLeader = ds.Tables[0].Rows[i]["Name"].ToString();
                    }
                    break;
                }
            }
            e.Row.Cells[3].Text = isLeader;
        }
    }
}
