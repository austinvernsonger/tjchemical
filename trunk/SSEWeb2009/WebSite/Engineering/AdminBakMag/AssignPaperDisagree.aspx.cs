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

public partial class Engineering_AdminBakMag_AssignPaperDisagree : System.Web.UI.Page
{
    private string studentID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null && Request["id"] != "")
        {
            studentID = Request["id"].ToString();
            StudentManage sMag = new StudentManage();
            DataSet ds = sMag.GetStusInfo(studentID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblName.Text = ds.Tables[0].Rows[0]["sName"].ToString();
                lblStuNo.Text = ds.Tables[0].Rows[0]["StudentID"].ToString();
            }
        }
    }
    protected void btOk_Click(object sender, EventArgs e)
    {
        if (tbReason.Text.Trim() == "")
        {
            lblMessage.Text = "请填写理由";
            return;
        }
        StudentManage sMag = new StudentManage();
        if (sMag.UpdateDefenceApply(studentID, 2, tbReason.Text.Trim()) == true)
        {
            lblMessage.Text = "操作成功";
        }
        else
        {
            lblMessage.Text = "操作失败";
        }
    }
}
