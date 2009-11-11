using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching;
using Teaching.Ops;

public partial class Teaching_Admin_StudentTrainingPlanMng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime date = DateTime.Now;
            // Add Year
            Term.Items.Clear();
            for (int i = -30; i < 30; ++i)
                Term.Items.Add((date.Year + i).ToString());
            Term.SelectedIndex = 30;
            ArticleTitle.Text = Term.Text + "学年" + Type.Text + "培养方案"; 
            if (Session["IdentifyNumber"] == null)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            opsTeachingQuery QueryName = new opsTeachingQuery("select * from TeacherAdministrator where TeacherID = '" + Session["IdentifyNumber"].ToString()+"'");
            QueryName.Do();
            if (QueryName.mResult.Tables.Count == 0 || QueryName.mResult.Tables[0].Rows.Count == 0)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            String ArticleId = Request.QueryString["ID"];
            if (ArticleId == null)
                return;
            opsTeachingQuery opsQuery = new opsTeachingQuery("select Type, Title, Term, Content from EducationSchema where ID = " + ArticleId);
            opsQuery.Do();
            if (opsQuery.mResult.Tables[0].Rows[0][0].ToString() == "0")
                Type.Text = "本科生";
            else if (opsQuery.mResult.Tables[0].Rows[0][0].ToString() == "1")
                Type.Text = "研究生";
            ArticleTitle.Text = opsQuery.mResult.Tables[0].Rows[0][1].ToString();
            Term.Text = opsQuery.mResult.Tables[0].Rows[0][2].ToString();
            TrainingPlan.Value = opsQuery.mResult.Tables[0].Rows[0][3].ToString();
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        String ArticleId = Request.QueryString["ID"];
        String ArticleType = null;
        if (ArticleTitle.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "文章标题");
            return;
        }
        if (Type.Text == "本科生")
            ArticleType = "0";
        else
            ArticleType = "1";
        if (ArticleId == null)
        {
            String sql = "insert into EducationSchema(Type, Content, Title, Term) values(" + ArticleType + ", " + FckConverter.ProcessString(TrainingPlan.Value) + ", \'" + TextConverter.ProcessString(ArticleTitle.Text) + "\', " + TextConverter.ProcessString(Term.Text) + ")";
            opsTeachingExec opsInsert = new opsTeachingExec(sql);
            opsInsert.Do();
        }
        else
        {
            String sql = "update EducationSchema set Type = " + ArticleType + ", Content = " + FckConverter.ProcessString(TrainingPlan.Value) + ", Title = \'" + TextConverter.ProcessString(ArticleTitle.Text) + "\', Term = " + TextConverter.ProcessString(Term.Text) + " where ID = " + ArticleId;
            opsTeachingExec opsInsert = new opsTeachingExec(sql);
            opsInsert.Do();
        }
        Response.Redirect("~/Teaching/Admin/AdminManagement.aspx?Type=5");
    }
}
