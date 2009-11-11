using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching;
using Teaching.Ops;

public partial class Teaching_Admin_TeachingManagementMng : System.Web.UI.Page
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
            opsTeachingQuery opsQuery = new opsTeachingQuery("select Type, Title, Content from EducationRule where ID = " + ArticleId);
            opsQuery.Do();
            if (opsQuery.mResult.Tables[0].Rows[0][0].ToString() == "0")
                Type.Text = "教师管理类条例";
            else if (opsQuery.mResult.Tables[0].Rows[0][0].ToString() == "1")
                Type.Text = "学生培养类条例";
            else if (opsQuery.mResult.Tables[0].Rows[0][0].ToString() == "2")
                Type.Text = "教学过程管理类条例";
            ArticleTitle.Text = opsQuery.mResult.Tables[0].Rows[0][1].ToString();
            TeachingManagementArticle.Value = opsQuery.mResult.Tables[0].Rows[0][2].ToString();
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        String ArticleId = Request.QueryString["ID"];
        String ArticleType;
        if (ArticleTitle.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "文章标题");
            return;
        }
        if (Type.Text == "教师管理类条例")
            ArticleType = "0";
        else if (Type.Text == "学生培养类条例")
            ArticleType = "1";
        else
            ArticleType = "2";
        if (ArticleId == null)
        {
            String sql = "insert into EducationRule(Type, Content, Title, ContentType) values(" + ArticleType + ", " + FckConverter.ProcessString(TeachingManagementArticle.Value) + ", \'" + TextConverter.ProcessString(ArticleTitle.Text) + "\', 0)";
            opsTeachingExec opsInsert = new opsTeachingExec(sql);
            opsInsert.Do();
        }
        else
        {
            String sql = "update EducationRule set Type = " + ArticleType + ", Content = " + FckConverter.ProcessString(TeachingManagementArticle.Value) + ", Title = \'" + TextConverter.ProcessString(ArticleTitle.Text) + "\' where ID = " + ArticleId;
            opsTeachingExec opsInsert = new opsTeachingExec(sql);
            opsInsert.Do();
        }
        Response.Redirect("~/Teaching/Admin/AdminManagement.aspx?Type=4");
    }
}
