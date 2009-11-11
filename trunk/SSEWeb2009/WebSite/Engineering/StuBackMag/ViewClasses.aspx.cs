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

public partial class Engineering_StuBackMag_ViewClasses : System.Web.UI.Page
{
    public string[] sProperty = new string[] { "学位课", "非学位课", "必修环节", "其他" };
    public string[] sCategory = new string[] { "必修", "选修", "其他" };
    private string studentid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        studentid = Session["IdentifyNumber"].ToString();
        if (!IsPostBack)
        {
            bindGvCourseInfo();
        }   
   }
    public string GetCourseTime(string cTime)
    {
        string courseTime = "";
        courseTime = cTime.Substring(0, 4);
        int term = Convert.ToInt32(cTime.Substring(4, 1));
        if (term == 0)
        {
            courseTime = courseTime + "年秋学期";
        }
        else
        {
            courseTime = courseTime + "年春学期";
        }
        return courseTime;
    }
    protected void gvCourseInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int courseid = Convert.ToInt32(gvCourseInfo.DataKeys[e.Row.RowIndex].Value);
            LinkButton lb = (LinkButton)e.Row.FindControl("lbViewDetails");
            lb.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + courseid + "',560,500)"); 
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }

    }
    protected void bindGvCourseInfo()
    {
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetLatestCourseInfoByStuid(studentid);
        gvCourseInfo.DataSource = ds.Tables[0];
        gvCourseInfo.DataBind();
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            lblMessage.Text = "当前还没有课程信息:-)";
            lblMessage.Visible = true;
        }
        else
        {
            string cTime = ds.Tables[0].Rows[0]["CourseTime"].ToString();
            string st = GetCourseTime(cTime);
            st = st + "预开课课程如下：";
            lblMessage.Text = st;
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
}
