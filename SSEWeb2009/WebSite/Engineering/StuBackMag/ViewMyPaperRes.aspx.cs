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

public partial class Engineering_StuBackMag_ViewMyPaperRes : System.Web.UI.Page
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
    protected void bindData()
    { 
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetPaperJudgeRes(studentID);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            //还没有评审结果
            Label2.Visible = true;
            Panel1.Visible = false;
        }
        else
        {
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsCriterion"]) == 1)
            {
                lblResult.Text = "已达到标准";
            }
            else
            {
                lblResult.Text = "尚未达到标准";
            }
            if (ds.Tables[0].Rows[0]["JudgeResult"] != null
                && ds.Tables[0].Rows[0]["JudgeResult"].ToString().Trim() != "")
            {
                tbRemark.Text = ds.Tables[0].Rows[0]["JudgeResult"].ToString().Trim();
            }
        }
    }
}
