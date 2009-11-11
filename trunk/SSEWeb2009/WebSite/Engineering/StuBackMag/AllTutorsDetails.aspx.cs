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

public partial class Engineering_StuBackMag_AllTutorsDetails : System.Web.UI.Page
{
    public string teacherID ;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        if (Request["id"] != null && Request["id"] != "")
        {
            teacherID = Request["id"].ToString();
            if (!IsPostBack)
            {
                bindData();
            }
        } 
    }
    public void bindData()
    {
        TeacherManage tm = new TeacherManage();
        DataSet ds = tm.GetTeacherInfoByTeacherID(teacherID);
        dvTutorInfo.DataSource = ds.Tables[0];
        dvTutorInfo.DataBind();
    }
    protected void dvTutorInfo_DataBound(object sender, EventArgs e)
    {
        if (dvTutorInfo.CurrentMode == DetailsViewMode.ReadOnly)
        {
            string teacherID = dvTutorInfo.DataKey.Value.ToString();
            TeacherManage tMag = new TeacherManage();
            DataSet ds = tMag.GetTeacherInfoByTeacherID(teacherID);
            if (ds.Tables[0].Rows[0]["Telephone"] != null
                && ds.Tables[0].Rows[0]["Telephone"].ToString().Trim() != "")
            {
                Label lblTelephone = (Label)dvTutorInfo.FindControl("lblTelephone");
                lblTelephone.Text = "电话："+ds.Tables[0].Rows[0]["Telephone"].ToString();
            }
            if (ds.Tables[0].Rows[0]["Email"] != null 
                && ds.Tables[0].Rows[0]["Email"].ToString().Trim() != "")
            {
                Label lblEmail = (Label)dvTutorInfo.FindControl("lbEmail");
                lblEmail.Text = "Email："+ds.Tables[0].Rows[0]["Email"].ToString();
            }
            Label lblResAspect = (Label)dvTutorInfo.FindControl("lbResAspect");
            lblResAspect.Text = ds.Tables[0].Rows[0]["ResearchAspect"].ToString();
            Label lblCourse = (Label)dvTutorInfo.FindControl("lbCourse");
            lblCourse.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
            if (ds.Tables[0].Rows[0]["ThesisIssue"] != null 
                && ds.Tables[0].Rows[0]["ThesisIssue"].ToString().Trim() != "")
            {
                Label lblThesis = (Label)dvTutorInfo.FindControl("lbThesis");
                lblThesis.Text = "发表论文：<br>" + ds.Tables[0].Rows[0]["ThesisIssue"].ToString();
            }
            if (ds.Tables[0].Rows[0]["ResearchAward"] != null 
                && ds.Tables[0].Rows[0]["ResearchAward"].ToString().Trim() != "")
            {
                Label lblResAward = (Label)dvTutorInfo.FindControl("lbResAward");
                lblResAward.Text = "获奖情况：<br>" + ds.Tables[0].Rows[0]["ResearchAward"].ToString();
            }
            if ((ds.Tables[0].Rows[0]["CompetitiveCourse"] != null && ds.Tables[0].Rows[0]["CompetitiveCourse"].ToString().Trim() != "")
                || (ds.Tables[0].Rows[0]["StudentCompetition"] != null && ds.Tables[0].Rows[0]["StudentCompetition"].ToString().Trim() != ""))
            {
                Label lbCompetition = (Label)dvTutorInfo.FindControl("lbCompetition");
                lbCompetition.Text = "竞赛情况：<br>" + ds.Tables[0].Rows[0]["CompetitiveCourse"].ToString() + "<br />"
                                  + ds.Tables[0].Rows[0]["StudentCompetition"].ToString();
            }
            if (ds.Tables[0].Rows[0]["Post"] != null
                && ds.Tables[0].Rows[0]["Post"].ToString().Trim() != "")
            {
                Label lblRemark = (Label)dvTutorInfo.FindControl("lblRemark");
                lblRemark.Text = ds.Tables[0].Rows[0]["Post"].ToString();
            }
        }
    }
}
