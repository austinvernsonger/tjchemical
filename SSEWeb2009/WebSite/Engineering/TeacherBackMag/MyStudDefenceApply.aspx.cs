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

public partial class Engineering_TeacherBackMag_MyStudDefenceApply : System.Web.UI.Page
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
        DataSet ds = tMag.GetDefenceApplyByTeaID(teacherID);
        gvDefenceApply.DataSource = ds.Tables[0];
        gvDefenceApply.DataBind();
        int count = ds.Tables[0].Rows.Count; 
        if (count > 0)
        {
            lblResult.Text = "当前有 " + count + " 个答辩申请等待处理：";
            lblResult.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lblResult.Text = "当前没有答辩申请需要处理:-)";
            
        }
    }
}
