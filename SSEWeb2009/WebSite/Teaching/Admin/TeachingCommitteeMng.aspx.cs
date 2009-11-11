using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching;
using Teaching.Ops;

public partial class Teaching_Admin_TeachingCommitteeMng : System.Web.UI.Page
{
    protected void InitializeValue(String ArticleId)
    {
        if (ArticleId == "0")
        {
            ArticleTitle.Text = "教学工作指导委员会章程";
            ArticleTitle.Enabled = false;
        }
        else if (ArticleId == "1")
        {
            ArticleTitle.Text = "教学工作指导委员会组成";
            ArticleTitle.Enabled = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["IdentifyNumber"] == null)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            opsTeachingQuery QueryName = new opsTeachingQuery("select * from TeacherAdministrator where TeacherID = " + Session["IdentifyNumber"].ToString());
            QueryName.Do();
            if (QueryName.mResult.Tables.Count == 0 || QueryName.mResult.Tables[0].Rows.Count == 0)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            String ArticleId = Request.QueryString["ID"];
            if (ArticleId == null)
                return;
            opsTeachingQuery opsQuery = new opsTeachingQuery("select MeetingTime, Title, Content from EducationMeetingRecord where ID = " + ArticleId);
            opsQuery.Do();
            if (opsQuery.mResult.Tables[0].Rows.Count == 0)
            {
                InitializeValue(ArticleId);
                return;
            }
            MeetingTime.VisibleDate = MeetingTime.SelectedDate = (DateTime)opsQuery.mResult.Tables[0].Rows[0][0];
            ArticleTitle.Text = opsQuery.mResult.Tables[0].Rows[0][1].ToString();
            TeachingCommittee.Value = opsQuery.mResult.Tables[0].Rows[0][2].ToString();
            InitializeValue(ArticleId);
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        String ArticleId = Request.QueryString["ID"];
        if (ArticleTitle.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "会议标题");
            return;
        }
        if (MeetingTime.SelectedDate.ToString() == "0001/1/1 0:00:00")
        {
            ErrorMsg.WriteErrorMsg(Response, "会议日期");
            return;
        }
        if (ArticleId == null)
        {
            String sql = "insert into EducationMeetingRecord(MeetingTime, Content, Title) values(\'" + MeetingTime.SelectedDate.ToString("yyyy-MM-dd") + "\', " + FckConverter.ProcessString(TeachingCommittee.Value) + ", \'" + TextConverter.ProcessString(ArticleTitle.Text) + "\')";
            opsTeachingExec opsInsert = new opsTeachingExec(sql);
            opsInsert.Do();
        }
        else
        {
            String sql = "update EducationMeetingRecord set MeetingTime = \'" + MeetingTime.SelectedDate.ToString("yyyy-MM-dd") + "\', Content = " + FckConverter.ProcessString(TeachingCommittee.Value) + ", Title = \'" + TextConverter.ProcessString(ArticleTitle.Text) + "\' where ID = " + ArticleId;
            opsTeachingExec opsUpdate = new opsTeachingExec(sql);
            opsUpdate.Do();
        }

        Response.Redirect("~/Teaching/Admin/AdminManagement.aspx?Type=7");
    }
}
