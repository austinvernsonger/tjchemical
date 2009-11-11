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
using System.Collections.Generic;

public partial class Engineering_StuBackMag_ViewMyCourses : System.Web.UI.Page
{
    public string[] sProperty = new string[] { "学位课", "非学位课", "必修环节", "其他" };
    public string[] sCategory = new string[] { "必修", "选修", "其他" };
    private string studentID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        studentID = Session["IdentifyNumber"].ToString();
        if (!IsPostBack)
        {
            bindMyCourse();
        }
    }
    protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChangeMyCourseInfo();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChangeMyCourseInfo();
    }
    protected void ChangeMyCourseInfo()
    {
        string term = ddlTerm.SelectedValue.Trim();
        string year = ddlYear.SelectedValue.Trim();
        string actualYear = "";
        string actualTerm = "";
        if (Convert.ToInt32(term) == 1)
        {
            // 上学期
            actualYear = year.Substring(0, 4);
            actualTerm = actualYear + "0";
        }
        else
        {
            //下学期
            actualYear = year.Substring(5, 4);
            actualTerm = actualYear + "1";
        }
        CourseManage cMag = new CourseManage();
        DataSet ds = cMag.GetAllCourseInfo(studentID, actualTerm);
        gvMyCourse.DataSource = ds.Tables[0];
        gvMyCourse.DataBind();
    }
    protected void gvMyCourse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                int courseid = Convert.ToInt32(gvMyCourse.DataKeys[e.Row.RowIndex].Value);
                DataSet ds = null;
                CourseManage cMag = new CourseManage();
                ds = cMag.GetCourseTeacherInfo(courseid);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    if (ds.Tables[0].Rows[0]["Name"] != System.DBNull.Value)
                    {
                        e.Row.Cells[5].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    }
                }
                if (ds.Tables[0].Rows.Count == 2)
                {
                    e.Row.Cells[5].Text = ds.Tables[0].Rows[0]["Name"].ToString() + " " + ds.Tables[0].Rows[1]["Name"].ToString();
                }
            }
        }
    }
    protected void bindMyCourse()
    {
        CourseManage cMag = new CourseManage();
        DataSet ds = cMag.GetMyLastestCourse(studentID);
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            //课程不存在
            StudentManage sMag = new StudentManage();
            DataSet ds1 = sMag.GetStusInfo(studentID);
            string grade = ds1.Tables[0].Rows[0]["Grade"].ToString();
            string year = grade.Substring(0, 4);
            //string term = grade.Substring(4);
            if (grade.Contains("春") == true)
            {
                string itemYear = (Convert.ToInt32(year) - 1).ToString() + "-" + year;
                ddlYear.Items.Clear();
                ddlYear.Items.Add(itemYear);
            }
            else
            {
                string itemYear = year + "-" + (Convert.ToInt32(year) + 1).ToString();
                ddlYear.Items.Clear();
                ddlYear.Items.Add(itemYear);
            }
        }
        else
        {
            //我的课程存在
            List<string> schoolYear = cMag.GetCourseTimeByStuID(studentID);
            List<string> year = GetListYear(schoolYear);
            ddlYear.Items.Clear();
            foreach (string y in year)
            {
                ddlYear.Items.Add(y);
            }
            string curCourseTime = ds.Tables[0].Rows[0]["CourseTime"].ToString();
            string cYear = curCourseTime.Substring(0, 4);
            string cTerm = curCourseTime.Substring(4, 1);
            if (Convert.ToInt32(cTerm) == 0)
            {
                //当前为上学期
                ddlTerm.Items[0].Selected = true;
                for (int i = 0; i < ddlYear.Items.Count; i++)
                {
                    string itemYear = ddlYear.Items[i].Text.Substring(0, 4);
                    if (string.Compare(cYear, itemYear) == 0)
                    {
                        ddlYear.Items[i].Selected = true;
                        break;
                    }
                }
            }
            else
            {
                //当前为下学期
                ddlTerm.Items[1].Selected = true;
                for (int i = 0; i < ddlYear.Items.Count; i++)
                {
                    string itemYear = ddlYear.Items[i].Text.Substring(5, 4);
                    if (string.Compare(cYear, itemYear) == 0)
                    {
                        ddlYear.Items[i].Selected = true;
                        break;
                    }
                }
            }
            gvMyCourse.DataSource = ds.Tables[0];
            gvMyCourse.DataBind();
        }
    }
    public List<string> GetListYear(List<string> schoolYear)
    {
        List<string> syear = new List<string>();
        foreach (string dt in schoolYear)
        {
            int i = 0;
            string tmpYear = "";
            string year = dt.Substring(0, 4);
            string term = dt.Substring(4, 1);
            if (Convert.ToInt32(term) == 0)
            {
                //表示上学期
                tmpYear = year + "-" + (Convert.ToInt32(year) + 1).ToString();
            }
            else
            {
                //表示下学期
                tmpYear = (Convert.ToInt32(year) - 1) + "-" + year;
            }
            for (; i < syear.Count; i++)
            {
                if (string.Compare(syear[i].Trim(), tmpYear) == 0)
                {
                    //已经存在这样的学年
                    break;
                }
            }
            if (i >= syear.Count)
            {
                syear.Add(tmpYear);
            }
        }
        return syear;
    }
}
