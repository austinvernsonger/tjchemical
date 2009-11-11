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

public partial class Engineering_AdminBakMag_PaperJudgeDetails : System.Web.UI.Page
{
    private string studentID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null && Request["id"] != "")
        {
            studentID = Request["id"].ToString();
        }
        if (!IsPostBack)
        {
            bindPaperJudgeDetails();
        }
    }
    protected void bindPaperJudgeDetails()
    {
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetPaperJudgeResultByStuID(studentID);
        dvPaperJudgeDetails.DataSource = ds.Tables[0];
        dvPaperJudgeDetails.DataBind();
    }
    protected void dvPaperJudgeDetails_DataBound(object sender, EventArgs e)
    {
        if (dvPaperJudgeDetails.CurrentMode == DetailsViewMode.ReadOnly)
        {
            Label teacher2 = (Label)dvPaperJudgeDetails.FindControl("lblTeacher2");
            Label teacher3 = (Label)dvPaperJudgeDetails.FindControl("lblTeacher3");
            TeacherManage tMag = new TeacherManage();
            DataSet ds = tMag.GetOtherPaperJudgeMembers(studentID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                teacher2.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                teacher3.Text = ds.Tables[0].Rows[1]["Name"].ToString();
            }
        }
    }
}
