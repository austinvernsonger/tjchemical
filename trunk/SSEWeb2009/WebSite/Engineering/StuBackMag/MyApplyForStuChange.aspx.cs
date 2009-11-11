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

public partial class Engineering_StuBackMag_MyApplyForStuChange : System.Web.UI.Page
{
    private string studentID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        studentID = Session["IdentifyNumber"].ToString();
        if (!IsPostBack)
        {
            bindData();
        }
        
    }
    protected void btnCommit_Click(object sender, EventArgs e)
    {
        StatusChgAppMgr scm = new StatusChgAppMgr();
        if (dplApplyCategory.SelectedIndex == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择申请类别！')</script>");
            return;
        }
        string appType = dplApplyCategory.Text;
        if (tbApplyReason.Text.Trim() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请简短描述申请原因！')</script>");
            return;
        }
        string appReason = tbApplyReason.Text.Trim();
        if (scm.AddNewApply(studentID, appType, appReason) == false)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('申请失败，请重试！')</script>");
        }
        else
        {
            Panel2.Visible = true;
            Panel0.Visible = false;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }
    }
    protected void btApplyAgain_Click(object sender, EventArgs e)
    {
        if (ViewState["applyID"] != null)
        {
            int applyID = Convert.ToInt32(ViewState["applyID"]);
            StatusChgAppMgr scm = new StatusChgAppMgr();
            if (scm.UpdateAppStatusActivity(applyID) == true)
            {
                //操作成功
                Panel0.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = false;
            }
            else
            {
                //操作失败
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('申请失败，请重试！')</script>");
            }
        }
    }
    protected void btMyApply_Click(object sender, EventArgs e)
    {
        Panel0.Visible = false;
        Panel1.Visible = true;
    }
    protected void bindData()
    {
        StatusChgAppMgr sca = new StatusChgAppMgr();
        //判断当前学号的学生是否有申请记录并获取最新申请记录
        DataSet ds = sca.GetStudentAppInfo(studentID);
        if (ds.Tables[0].Rows[0][0] != System.DBNull.Value)
        {
            //获取当前学号学生的申请记录
            int applyID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            ViewState["applyID"] = applyID;
            DataSet ds1 = sca.GetUnhandleAppInfoByAppID(applyID);
            if (Convert.ToInt32(ds1.Tables[0].Rows[0]["ApplyResult"]) == 0)
            {
                //等待教务员确认
                Panel2.Visible = true;
          
            }
            if (Convert.ToInt32(ds1.Tables[0].Rows[0]["Activiy"]) == 1)
            {
                //该申请记录为历史记录
                Panel0.Visible = true;
   
            }
            if (Convert.ToInt32(ds1.Tables[0].Rows[0]["ApplyResult"]) == 1
                && Convert.ToInt32(ds1.Tables[0].Rows[0]["Activiy"]) == 0)
            {
                //该申请记录处于活动中
                Panel3.Visible = true;
          
                //  lbAppRes.Text = (Convert.ToInt32(ds1.Tables[0].Rows[0]["ApplyResult"]) == 1) ? "批准" : "不批准";
                tbApplyRemark.Text = ds1.Tables[0].Rows[0]["ApplyRemark"].ToString();
            }
            if (Convert.ToInt32(ds1.Tables[0].Rows[0]["Activiy"]) == 2)
            {
                //该申请记录被教务员拒绝
                Panel4.Visible = true;
                tbFailReason.Text = ds1.Tables[0].Rows[0]["ApplyRemark"].ToString();
                lblCategory.Text = ds1.Tables[0].Rows[0]["ApplyCategory"].ToString();
                lblApplyTime.Text = ds1.Tables[0].Rows[0]["ApplyTime"].ToString();
            }
        }
        else
        {
            Panel0.Visible = true;
            
        }
    }
}
