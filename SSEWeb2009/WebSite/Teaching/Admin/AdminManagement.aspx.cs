using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching.Ops;

public partial class Teaching_Admin_AdminManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["IdentifyNumber"] == null)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            opsTeachingQuery QueryName = new opsTeachingQuery("select * from TeacherAdministrator where TeacherID = '" + Session["IdentifyNumber"].ToString()+"'");
            QueryName.Do();
            if (QueryName.mResult.Tables.Count == 0 || QueryName.mResult.Tables[0].Rows.Count == 0)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
        } 
        if (Request.QueryString["Type"] != null)
        {
            switch (Request.QueryString["Type"])
            {
                case "1":
                    lbTitle.Text = "出差事务记录";
                    LinkListEx.TargetPage = "/Teaching/Admin/ApplicationContent.aspx?Type=1";
                    LinkListEx.DeleteString = "delete from [TravelApplication] where [RequestID]=";
                    LinkListEx.QuerySQL = "select RequestID as [ID],2 as [ContentType],''as [Content],'目的地：'+TravelPlace as [Title],ExamApproval as [FS]  from [TravelApplication]";
                    LinkListEx.TargetPageSE = "~/Teaching/Admin/ShowTravelSummary.aspx";
                    LinkListEx.TargetPageSEToolTip = "查看出差总结";
                    ibAdd.Visible = false;
                    break;
                case "2":
                    lbTitle.Text = "讲座申请记录";
                    LinkListEx.TargetPage = "/Teaching/Admin/ApplicationContent.aspx?Type=2";
                    LinkListEx.DeleteString = "delete from [LectureApplication] where [RequestID]=";
                    LinkListEx.QuerySQL = "select RequestID as [ID], '' as [Content],2 as [ContentType],'讲座名：'+Subject as [Title],ExamApproval as [FS] from [LectureApplication]";
                    ibAdd.Visible = false;
                    break;
                case "3":
                    lbTitle.Text = "新开课申请记录";
                    LinkListEx.TargetPage = "/Teaching/Admin/ApplicationContent.aspx?Type=3";
                    LinkListEx.DeleteString = "delete from [NewCourseApplication] where [RequestID]=";
                    LinkListEx.QuerySQL = "select RequestID as [ID],2 as [ContentType],''as [Content],'课程名：'+CourseName as [Title],ExamApproval as [FS]  from [NewCourseApplication]";
                    ibAdd.Visible = false;
                    break;
                case "4":
                    lbTitle.Text = "教学条例管理";
                    LinkListEx.TargetPage = "/Teaching/Admin/TeachingManagementMng.aspx";
                    LinkListEx.DeleteString = "delete from [EducationRule] where [ID]=";
                    LinkListEx.QuerySQL = "select [ID], 2 as [ContentType],[Content],[Title],-1 as [FS] from [EducationRule]";
                    ibAdd.Visible = true;
                    ibAdd.PostBackUrl = HttpContext.Current.Request.ApplicationPath + LinkListEx.TargetPage;
                    break;
                case "5":
                    lbTitle.Text = "学生培养方案管理";
                    LinkListEx.TargetPage = "/Teaching/Admin/StudentTrainingPlanMng.aspx";
                    LinkListEx.DeleteString = "delete from [EducationSchema] where [ID]=";
                    LinkListEx.QuerySQL = "select [ID], 2 as [ContentType],[Content],[Title],-1 as [FS]  from [EducationSchema]";
                    ibAdd.Visible = true;
                    ibAdd.PostBackUrl = HttpContext.Current.Request.ApplicationPath + LinkListEx.TargetPage;
                    break;
                case "6":
                    lbTitle.Text = "企业合作介绍管理";
                    LinkListEx.TargetPage = "/Teaching/Admin/EnterpriseCooperationMng.aspx";
                    LinkListEx.DeleteString = "delete from [EnterpriseCooperation] where [ID]=";
                    LinkListEx.QuerySQL = "select [ID], 2 as [ContentType],[Content],[Title],-1 as [FS]  from [EnterpriseCooperation]";
                    ibAdd.Visible = true;
                    ibAdd.PostBackUrl = HttpContext.Current.Request.ApplicationPath + LinkListEx.TargetPage;
                    break;
                case "7":
                    lbTitle.Text = "教学工作委员会管理";
                    LinkListEx.TargetPage = "/Teaching/Admin/TeachingCommitteeMng.aspx";
                    LinkListEx.DeleteString = "delete from [EducationMeetingRecord] where [ID]=";
                    LinkListEx.QuerySQL = "select [ID], 2 as [ContentType],[Content],[Title],-1 as [FS]  from [EducationMeetingRecord] where [ID]>1";
                    ibAdd.Visible = true;
                    ibAdd.PostBackUrl = HttpContext.Current.Request.ApplicationPath + LinkListEx.TargetPage;
                    break;
                case "8":
                    lbTitle.Text = "下载专区管理";
                    LinkListEx.TargetPage = "/Teaching/Admin/DownloadingPageMng.aspx";
                    LinkListEx.DeleteString = "delete from [TemplateFile] where [ID]=";
                    LinkListEx.QuerySQL = "select [ID],[ContentType],[Content],[Title],-1 as [FS] from [TemplateFile]";
                    ibAdd.Visible = true;
                    ibAdd.PostBackUrl = HttpContext.Current.Request.ApplicationPath + LinkListEx.TargetPage;
                    break;
                case "9":
                    lbTitle.Text = "教学教改研究管理";
                    LinkListEx.TargetPage = "/Teaching/Admin/TeachingReformMng.aspx";
                    LinkListEx.DeleteString = "delete from [EducationReformResearch] where [ID]=";
                    LinkListEx.QuerySQL = "select [ID], 2 as [ContentType],[Content],[Title],-1 as [FS]  from [EducationReformResearch]";
                    ibAdd.Visible = true;
                    ibAdd.PostBackUrl = HttpContext.Current.Request.ApplicationPath + LinkListEx.TargetPage;
                    break;
            }

        }
    }
}
