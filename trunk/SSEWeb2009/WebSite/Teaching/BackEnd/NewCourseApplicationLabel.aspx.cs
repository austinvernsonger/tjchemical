using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching;
using Teaching.Ops;

public partial class Teaching_BackEnd_NewCourseApplicationLabel : System.Web.UI.Page
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
            TeacherName.Text = QueryName.mResult.Tables[0].Rows[0][0].ToString();
            String ArticleId = Request.QueryString["ID"];
            if (ArticleId == null)
                return;
            opsTeachingQuery opsQuery = new opsTeachingQuery("select CourseName, Hour, LanguageClass, CourseTime, CourseNumber, Target, TargetGrade, Reason from NewCourseApplication where RequestID = " + ArticleId);
            opsQuery.Do();
            CourseName.Text = opsQuery.mResult.Tables[0].Rows[0][0].ToString();
            Hour.Text = opsQuery.mResult.Tables[0].Rows[0][1].ToString();
            if (opsQuery.mResult.Tables[0].Rows[0][2].ToString() == "0")
                Language.Text = "中文";
            else if (opsQuery.mResult.Tables[0].Rows[0][2].ToString() == "1")
                Language.Text = "英文";
            else if (opsQuery.mResult.Tables[0].Rows[0][2].ToString() == "2")
                Language.Text = "日文";
            else if (opsQuery.mResult.Tables[0].Rows[0][2].ToString() == "3")
                Language.Text = "德文";
            else if (opsQuery.mResult.Tables[0].Rows[0][2].ToString() == "4")
                Language.Text = "法文";
            CourseTime.Text = ((DateTime)opsQuery.mResult.Tables[0].Rows[0][3]).ToString("yyyy-MM-dd");
            CourseNumber.Text = opsQuery.mResult.Tables[0].Rows[0][4].ToString();
            Target.Text = opsQuery.mResult.Tables[0].Rows[0][5].ToString();
            TargetGrade.Text = opsQuery.mResult.Tables[0].Rows[0][6].ToString();
            Reason.Text = opsQuery.mResult.Tables[0].Rows[0][7].ToString();
        }
    }
}
