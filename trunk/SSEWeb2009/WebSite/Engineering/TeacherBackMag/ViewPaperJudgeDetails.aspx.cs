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

public partial class Engineering_TeacherBackMag_ViewPaperJudgeDetails : System.Web.UI.Page
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
    protected void dvPaperJudgeDetails_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }
}
