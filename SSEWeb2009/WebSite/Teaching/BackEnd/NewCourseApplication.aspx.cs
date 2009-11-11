using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Teaching;
using Teaching.Ops;

public partial class Teaching_BackEnd_NewCourseApplication : System.Web.UI.Page
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
        }
    }
    protected void bnSubmit_Click(object sender, EventArgs e)
    {
        if(CourseName.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "课程名称");
            return;
        }
        if (Hour.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "上课时数");
            return;
        }
        if (Language.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "上课时数");
            return;
        }
        if (CourseTime.SelectedDate.ToString() == "0001/1/1 0:00:00")
        {
            ErrorMsg.WriteErrorMsg(Response, "开课时间");
            return;
        }
        if (CourseNumber.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "开课次数");
            return;
        }
        foreach (char c in CourseNumber.Text)
        {
            if (Char.IsDigit(c))
                continue;
            ErrorMsg.WriteErrorMsg(Response, "开课次数(输入字符必须为数字)");
            return;
        }
        if (Reason.Text == "")
        {
            ErrorMsg.WriteErrorMsg(Response, "开课理由");
            return;
        }

        String sql = "insert into [NewCourseApplication](CourseName, TeacherID, Hour, LanguageClass, CourseTime, CourseNumber, Target, TargetGrade, Reason) values(";
        sql += FckConverter.ProcessString(this.CourseName.Text) + ",";
        sql += Session["IdentifyNumber"].ToString() + ", ";
        int HourNum = Convert.ToInt32(this.Hour.Text);
        sql += HourNum.ToString() + ",";
        sql += this.Language.SelectedIndex + ",";
        sql += "\'" + this.CourseTime.SelectedDate.ToString("yyyy-MM-dd") + "\',";

        int iCourseNum = Convert.ToInt32(this.CourseNumber.Text);
        sql += iCourseNum.ToString() + ",";

        sql += this.Target.SelectedIndex + ",";
        sql += "\'" + TextConverter.ProcessString(this.TargetGrade.Text) + "\',";
        sql += "\'" + TextConverter.ProcessString(this.Reason.Text) + "\'";
        sql += ")";


        opsTeachingQuery insert = new opsTeachingQuery(sql);
        insert.Do();
        Response.Redirect("./NewCourseApplicationList.aspx");
    }
    protected void bnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("./NewCourseApplicationList.aspx");
       
    }
}
