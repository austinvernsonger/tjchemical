using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching;
using Teaching.Ops;

public partial class Teaching_BackEnd_LectureApplication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["IdentifyNumber"] == null)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            opsTeachingQuery QueryName = new opsTeachingQuery("select Name from Teacher where TeacherID = '" + Session["IdentifyNumber"].ToString()+"'");
            QueryName.Do();
            if (QueryName.mResult.Tables.Count == 0 || QueryName.mResult.Tables[0].Rows.Count == 0)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            Name.Text = QueryName.mResult.Tables[0].Rows[0][0].ToString();
            String ArticleId = Request.QueryString["ID"];
            if (ArticleId == null)
                return;
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        if (Subject.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "讲座主题");
            return;
        }
        if(Content.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "讲座内容");
            return;
        }
        if(DetailPlan.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "讲座具体安排");
            return;
        }
        String sql = "insert into LectureApplication(Subject, TeacherID, Content, DetailPlan, RequestTime) values(";
        sql += "\'" + TextConverter.ProcessString(this.Subject.Text) + "\',";
        sql += "\'" + Session["IdentifyNumber"].ToString() + "\',";
        sql += "\'" + TextConverter.ProcessString(Content.Text) + "\',";
        sql += "\'" + TextConverter.ProcessString(DetailPlan.Text) + "\',";
        sql += "\'" + RequestTime.SelectedDate.ToString() + "\')";
        opsTeachingExec insert = new opsTeachingExec(sql);
        insert.Do();
        Response.Redirect("./LectureApplicationList.aspx");
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("./LectureApplicationList.aspx");
    }
}
