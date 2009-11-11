using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching;
using Teaching.Ops;

public partial class Teaching_Admin_TeachingReformMng : System.Web.UI.Page
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
            String ArticleId = Request.QueryString["ID"];
            if (ArticleId == null)
                return;
            opsTeachingQuery opsQuery = new opsTeachingQuery("select Title, Content from EducationReformResearch where ID = " + ArticleId);
            opsQuery.Do();
            ArticleTitle.Text = opsQuery.mResult.Tables[0].Rows[0][0].ToString();
            TeachingReformArticle.Value = opsQuery.mResult.Tables[0].Rows[0][1].ToString();
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        String ArticleId = Request.QueryString["ID"];
        if (ArticleTitle.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "文章标题");
            return;
        }
        if(TeachingReformArticle.Value == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "教改内容");
            return;
        }
        if (ArticleId == null)
        {
            String sql = "insert into EducationReformResearch(Title, Content) values(" + FckConverter.ProcessString(ArticleTitle.Text) + ", " + FckConverter.ProcessString(TeachingReformArticle.Value) + ")";
            opsTeachingExec opsInsert = new opsTeachingExec(sql);
            opsInsert.Do();
        }
        else
        {
            String sql = "update EducationReformResearch set Title = " + FckConverter.ProcessString(ArticleTitle.Text) + ", Content = " + FckConverter.ProcessString(TeachingReformArticle.Value) + " where ID = " + ArticleId;
            opsTeachingExec opsInsert = new opsTeachingExec(sql);
            opsInsert.Do();
        }
        Response.Redirect("~/Teaching/Admin/AdminManagement.aspx?Type=9");
    }
}
