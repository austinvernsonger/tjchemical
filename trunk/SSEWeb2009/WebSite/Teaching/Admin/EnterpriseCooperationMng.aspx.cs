using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching;
using Teaching.Ops;

public partial class Teaching_Admin_EnterpriseCooperationMng : System.Web.UI.Page
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
            opsTeachingQuery opsQuery = new opsTeachingQuery("select Type, Title, Content from EnterpriseCooperation where ID = " + ArticleId);
            opsQuery.Do();
            if (opsQuery.mResult.Tables[0].Rows[0][0].ToString() == "0")
                Type.Text = "合作单位及合作过程";
            else if (opsQuery.mResult.Tables[0].Rows[0][0].ToString() == "1")
                Type.Text = "合作俱乐部情况";
            else if (opsQuery.mResult.Tables[0].Rows[0][0].ToString() == "2")
                Type.Text = "联合实验室情况";
            else if (opsQuery.mResult.Tables[0].Rows[0][0].ToString() == "3")
                Type.Text = "合作活动/讲座/课程";
            ArticleTitle.Text = opsQuery.mResult.Tables[0].Rows[0][1].ToString();
            EnterpriseCoorperation.Value = opsQuery.mResult.Tables[0].Rows[0][2].ToString();
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        String ArticleId = Request.QueryString["ID"];
        String ArticleType = null;
        if (ArticleTitle.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "合作企业");
            return;
        }
        if (Type.Text == "合作单位及合作过程")
            ArticleType = "0";
        else if (Type.Text == "合作俱乐部情况")
            ArticleType = "1";
        else if (Type.Text == "联合实验室情况")
            ArticleType = "2";
        else if (Type.Text == "合作活动/讲座/课程")
            ArticleType = "3";
        if (ArticleId == null)
        {
            String sql = "insert into EnterpriseCooperation(Type, Content, Title) values(" + ArticleType + ", " + FckConverter.ProcessString(EnterpriseCoorperation.Value) + ", \'" + TextConverter.ProcessString(ArticleTitle.Text) + "\')";
            opsTeachingExec opsInsert = new opsTeachingExec(sql);
            opsInsert.Do();
        }
        else
        {
            String sql = "update EnterpriseCooperation set Type = " + ArticleType + ", Content = " + FckConverter.ProcessString(EnterpriseCoorperation.Value) + ", Title = \'" + TextConverter.ProcessString(ArticleTitle.Text) + "\' where ID = " + ArticleId;
            opsTeachingExec opsInsert = new opsTeachingExec(sql);
            opsInsert.Do();
        }
        Response.Redirect("~/Teaching/Admin/AdminManagement.aspx?Type=6");
    }
}
