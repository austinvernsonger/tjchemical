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

public partial class Engineering_StuBackMag_MyTutorInformation : System.Web.UI.Page
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
        DataSet ds = sMag.GetTeacherInfoByStuID(studentID);
        if (ds.Tables[0].Rows[0]["Name"] == System.DBNull.Value
            || ds.Tables[0].Rows[0]["Name"].ToString().Trim() =="")
        {
            div_tutor.Visible = false;
            lbMessage.Text = "你当前还没有导师:-)";
            lbMessage.Visible = true;
        }
        else
        {
            DataRow dr = ds.Tables[0].Rows[0];
            lblName.Text = dr["Name"].ToString();
            lblGender.Text = Convert.ToInt32(dr["Gender"]) == 0 ? "男" : "女";
            lblTitle.Text = dr["Title"].ToString();
            lblReasearch.Text = dr["ResearchAspect"].ToString();
            lblTelephone.Text = dr["Telephone"].ToString();
            lblEmail.Text = dr["Email"].ToString();
            tbProject.Text = dr["ResearchDuty"].ToString();
            tbRewards.Text = dr["ResearchAward"].ToString();
            div_tutor.Visible = true;
            lbMessage.Visible = false;
        }
    }
}
