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

public partial class Engineering_TeacherBackMag_ViewOtherMemDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null && Request["id"] != "" && Request["teacherid"] != null && Request["teacherid"] != "")
        {
            string bNo = Request["id"].ToString();
            string teacherid = Request["teacherid"].ToString();
            TeacherManage tMag = new TeacherManage();
            DataSet ds = tMag.GetPaperJudgeByteaidAndbNo(teacherid, bNo);
            dvMemDetails.DataSource = ds.Tables[0];
            dvMemDetails.DataBind();
        }
    }
}
