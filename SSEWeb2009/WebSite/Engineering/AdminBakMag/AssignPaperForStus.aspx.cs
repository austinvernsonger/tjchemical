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

public partial class Engineering_AdminBakMag_AssignPaperForStus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["IdentifyNumber"] == null)
        //{
        //    SysCom.Login.LoginRedirect(Request.Url.ToString());
        //}
        bindData();

    }
    protected void bindData()
    {
        DocumentManage dMag = new DocumentManage();
        DataSet ds = dMag.GetSqlPrejudicationStatus();
        gvPaperInfo.DataSource = ds.Tables[0];
        gvPaperInfo.DataBind();
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            lblResult.Text = "占时没有要预审的论文需要你分配:-)";
            div_remark.Visible = false;
        }
        else
        {
            lblResult.Text = "当前有 " + count + " 个预审论文等待分配：";
            lblResult.ForeColor = System.Drawing.Color.Red;
            div_remark.Visible = true;
        }
    }
    protected void gvPaperInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            LinkButton lb = (LinkButton)e.Row.FindControl("lbName");
            string studentID = e.Row.Cells[1].Text;
            lb.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + studentID + "',650,500,0)");
            Button btAgree = (Button)e.Row.FindControl("btAgree");
            btAgree.PostBackUrl = "AssignPaperDetails.aspx?id="+studentID;
            Button btDisagree = (Button)e.Row.FindControl("btDisagree");
            btDisagree.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + studentID + "',550,500,1)");
        }
    }
    protected void gvPaperInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
    }
}