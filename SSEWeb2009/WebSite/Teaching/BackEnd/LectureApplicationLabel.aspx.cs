using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching;
using Teaching.Ops;

public partial class Teaching_BackEnd_LectureApplicationLabel : System.Web.UI.Page
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
            else
            {
                opsTeachingQuery opsQuery = new opsTeachingQuery("select Subject, Content, DetailPlan, RequestTime from LectureApplication where RequestID = " + ArticleId);
                opsQuery.Do();
                Subject.Text = opsQuery.mResult.Tables[0].Rows[0][0].ToString();
                Content.Text = opsQuery.mResult.Tables[0].Rows[0][1].ToString();
                Content.ReadOnly = true;
                DetailPlan.Text = opsQuery.mResult.Tables[0].Rows[0][2].ToString();
                DetailPlan.ReadOnly = true;
                RequestTime.Text = opsQuery.mResult.Tables[0].Rows[0][3].ToString();
            }
        }
    }
}

