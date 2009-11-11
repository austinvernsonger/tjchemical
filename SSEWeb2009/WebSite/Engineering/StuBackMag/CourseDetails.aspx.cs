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

public partial class Engineering_CourseDetails : System.Web.UI.Page
{
    private string[] sProperty = new string[] { "学位课", "非学位课", "必修环节", "其他" };
    private string[] sCategory = new string[] { "必修", "选修", "其他" };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        if (Request["courseid"] != null)
        {
            bindCourseDetail();
        }
    }
    public string GetCourseTime(string cTime)
    {
        string courseTime = "";
        courseTime = cTime.Substring(0, 4);
        int term = Convert.ToInt32(cTime.Substring(4, 1));
        if (term == 0)
        {
            courseTime = courseTime + "年秋";
        }
        else
        {
            courseTime = courseTime + "年春";
        }
        return courseTime;
    }
    protected void bindCourseDetail()
    {
        CourseManage cMag = new CourseManage();
        CourseInfo cInfo = cMag.GetCourseInfo(Convert.ToInt32(Request["courseid"]));
        if (cInfo != null)
        {
            if (cInfo.CourseName != null)
            {
                lbCourseName.Text = cInfo.CourseName;
            }
            if (cInfo.CourseTime != null)
            {
                lbCourseTime.Text = GetCourseTime(cInfo.CourseTime);
            }
            if (cInfo.Category != -1)
            {
                lbCategory.Text = sCategory[cInfo.Category];
            }
            if (cInfo.Property != -1)
            {
                lbProperty.Text = sProperty[cInfo.Property];
            }
            if (cInfo.ExamMode != null)
            {
                lbExamMode.Text = cInfo.ExamMode;
            }
            if (cInfo.InstruMode != null)
            {
                lbInstruMode.Text = cInfo.InstruMode;
            }
            if (cInfo.Diglossia != -1)
            {
                lbDialossia.Text = (cInfo.Diglossia == 0) ? "是" : "否";
            }
            if (cInfo.Credit != -1)
            {
                lbCredit.Text = cInfo.Credit.ToString();
            }
            if (cInfo.CreditHour != -1)
            {
                lbCreditHour.Text = cInfo.CreditHour.ToString();
            }
            if (cInfo.Teacher != null)
            {
                lbTeacher.Text = cInfo.Teacher;
            }
            if (cInfo.Place != null)
            {
                lbPlace.Text = cInfo.Place;
            }
            if (cInfo.ClassPeriod != null)
            {
                lbPeriod.Text = cInfo.ClassPeriod;
            }
        }
    }
}
