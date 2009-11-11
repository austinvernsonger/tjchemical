using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Department.Engineering;
using System.IO;

public partial class Engineering_TeacherBackMag_MyCourse : System.Web.UI.Page
{
    private string teacherID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        teacherID = Session["IdentifyNumber"].ToString();
        if (!IsPostBack)
        {
            bindMyCourse();
        }
    }
    public string GetCourseTime(string cTime)
    {
        string courseTime = "";
        courseTime = cTime.Substring(0, 4);
        int term = Convert.ToInt32(cTime.Substring(4, 1));
        if (term == 0)
        {
            courseTime = courseTime + "秋学期";
        }
        else
        {
            courseTime = courseTime + "春学期";
        }
        return courseTime;
    }
    protected void gvMyCourse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
                LinkButton l = (LinkButton)e.Row.FindControl("lbViewDetails");
                int courseID = Convert.ToInt32(gvMyCourse.DataKeys[e.Row.RowIndex].Value);
                DataSet dsXml = new DataSet();
                if (File.Exists(Server.MapPath(@"../Resources/Xml/xmlEvaluationRes.xml")) == false)
                { 
                    //文件不存在
                    //没有学生对这门课程进行评教
                    l.Attributes.Add("onclick", "javascript:alert('占时没有学生对这门课程进行评估!')");
                    return;
                }
                dsXml.ReadXml(Server.MapPath(@"../Resources/Xml/xmlEvaluationRes.xml"));
                int num = dsXml.Tables[0].Rows.Count;
                int i;
                for (i = 0; i < num; i++)
                {
                    int courID = Convert.ToInt32(dsXml.Tables[0].Rows[i]["CourseID"]);
                    if (courID == courseID)
                    {
                        //有学生对该门课程进行了评教;
                        l.PostBackUrl = "TeachingFeedBack.aspx?item=" + i + "&courseid=" + courseID;
                        break;
                    }
                }
                if (i == num)
                {
                    //没有学生对这门课程进行评教
                    l.Attributes.Add("onclick", "javascript:alert('占时没有学生对这门课程进行评估!')");
                }
            }
        }
    }
    protected void bindMyCourse()
    {
        TeacherManage tMag = new TeacherManage();
        DataSet ds = tMag.GetTeacherCourseInfo(teacherID);
        gvMyCourse.DataSource = ds.Tables[0];
        gvMyCourse.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblMessage.Text = "你当前没有需要教授的课程:-)";
        }
        else
        {
            string term = GetCourseTime(ds.Tables[0].Rows[0]["CourseTime"].ToString());
            lblMessage.Text = term + "开课情况如下：";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
}
