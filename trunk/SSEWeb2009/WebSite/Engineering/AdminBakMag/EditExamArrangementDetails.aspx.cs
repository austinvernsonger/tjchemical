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

public partial class Engineering_AdminBakMag_EditExamArrangementDetails : System.Web.UI.Page
{
    private int _courseID;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null && Request["id"] != "")
        {
            _courseID = Convert.ToInt32(Request["id"]);
        }
        if (!IsPostBack)
        {
            bindData();
        }
    }
    protected void bindData()
    {
        CourseManage cMag = new CourseManage();
        DataSet ds = cMag.GetCourseInformation(_courseID);
        fvTestArrange.DataSource = ds.Tables[0];
        fvTestArrange.DataBind();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        AddDay();
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        AddDay();
    }
    protected void ddlYear_PreRender(object sender, EventArgs e)
    {

    }
    protected void bindCalendar()
    {
        DropDownList ddlYear = (DropDownList)fvTestArrange.FindControl("ddlYear");
        DropDownList ddlMonth = (DropDownList)fvTestArrange.FindControl("ddlMonth");
        DropDownList ddlDay = (DropDownList)fvTestArrange.FindControl("ddlDay");

        DateTime date = DateTime.Now;
        // Add Year
        ddlYear.Items.Clear();
        for (int i = 0; i < 3; ++i)
            ddlYear.Items.Add((date.Year + i).ToString());
        ddlYear.SelectedIndex = 0;
        // Add Monty
        ddlMonth.Items.Clear();
        for (int i = 1; i < 13; ++i)
            ddlMonth.Items.Add(i.ToString());
        ddlMonth.SelectedIndex = date.Month - 1;

        AddDay();
    }
    protected void AddDay()
    {
        DropDownList ddlYear = (DropDownList)fvTestArrange.FindControl("ddlYear");
        DropDownList ddlMonth = (DropDownList)fvTestArrange.FindControl("ddlMonth");
        DropDownList ddlDay = (DropDownList)fvTestArrange.FindControl("ddlDay");

        int tmpMaxDays = 30;
        if (ddlMonth.SelectedIndex == 2)    // Feb.
        {
            int tmpYear = Convert.ToInt32(ddlYear.SelectedValue);
            if (((tmpYear % 4) == 0 && (tmpYear % 100) != 0) || (tmpYear % 400) == 0)
                tmpMaxDays = 29;
            else tmpMaxDays = 28;
        }
        else if (ddlMonth.SelectedIndex == 1 ||    // Jan.
            ddlMonth.SelectedIndex == 3 ||         // Mar.
            ddlMonth.SelectedIndex == 5 ||         // May
            ddlMonth.SelectedIndex == 7 ||         // Jul.
            ddlMonth.SelectedIndex == 8 ||         // Aug.
            ddlMonth.SelectedIndex == 10 ||         // Ost.
            ddlMonth.SelectedIndex == 12)          // Dec.
            tmpMaxDays = 31;
        else tmpMaxDays = 30;

        ddlDay.Items.Clear();
        for (int i = 1; i < tmpMaxDays + 1; ++i)
            ddlDay.Items.Add(i.ToString());
        // ddlDay.Items.Insert(0, "");
        ddlDay.SelectedIndex = 0;
    }
    public void SetDateTime(DateTime theDate)
    {
        DropDownList ddlYear = (DropDownList)fvTestArrange.FindControl("ddlYear");
        DropDownList ddlMonth = (DropDownList)fvTestArrange.FindControl("ddlMonth");
        DropDownList ddlDay = (DropDownList)fvTestArrange.FindControl("ddlDay");

        DateTime _now = DateTime.Now;
        ddlYear.SelectedIndex = (theDate.Year - _now.Year);
        ddlMonth.SelectedIndex = theDate.Month - 1;
        ddlDay.SelectedIndex = (theDate.Day - 1);
    }
    protected void SetTime(string[] time)
    {
        DropDownList ddlStartTime = (DropDownList)fvTestArrange.FindControl("ddlStartHour");
        DropDownList ddlEndTime = (DropDownList)fvTestArrange.FindControl("ddlEndHour");
        for (int i = 0; i < ddlStartTime.Items.Count; i++)
        {
            if (string.Compare(time[0], ddlStartTime.Items[i].Value) == 0)
            {
                ddlStartTime.Items[i].Selected = true;
            }
        }
        for (int i = 0; i < ddlEndTime.Items.Count; i++)
        {
            if (string.Compare(time[1], ddlEndTime.Items[i].Value) == 0)
            {
                ddlEndTime.Items[i].Selected = true;
            }
        }
    }
    public string GetDateTime()
    {
        DropDownList ddlYear = (DropDownList)fvTestArrange.FindControl("ddlYear");
        DropDownList ddlMonth = (DropDownList)fvTestArrange.FindControl("ddlMonth");
        DropDownList ddlDay = (DropDownList)fvTestArrange.FindControl("ddlDay");
        DropDownList ddlStartHour = (DropDownList)fvTestArrange.FindControl("ddlStartHour");
        DropDownList ddlEndHour = (DropDownList)fvTestArrange.FindControl("ddlEndHour");
        return ddlYear.SelectedValue + "-" + ddlMonth.SelectedValue + "-" + ddlDay.SelectedValue + 
            " " + ddlStartHour.SelectedValue + "-" + ddlEndHour.SelectedValue;
    }
    protected void fvTestArrange_DataBound(object sender, EventArgs e)
    {
        if (fvTestArrange.CurrentMode == FormViewMode.Edit)
        {
            bindCalendar();
            TestManage tMag = new TestManage();
            DataSet ds = tMag.GetTestArrangement(_courseID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ExamPlace"] != null)
                {
                    TextBox tbPlace = (TextBox)fvTestArrange.FindControl("tbPlace");
                    tbPlace.Text = ds.Tables[0].Rows[0]["ExamPlace"].ToString();
                }
                string[] time = ds.Tables[0].Rows[0]["ExamTime"].ToString().Split(' ');
                string year = time[0];
                SetDateTime(Convert.ToDateTime(year));
                string []hour = time[1].Split('-');
                SetTime(hour);
                if (ds.Tables[0].Rows[0]["Supervisor1"] != null)
                {
                    DropDownList ddlTeacher1 = (DropDownList)fvTestArrange.FindControl("ddlTeacher1");
                    string teacher1 = ds.Tables[0].Rows[0]["Supervisor1"].ToString().Trim();
                    for(int i = 1 ; i<ddlTeacher1.Items.Count; i++)
                    {
                        if(string.Compare(ddlTeacher1.Items[i].Value.Trim(), teacher1)==0)
                        {
                            ddlTeacher1.Items[i].Selected = true;
                        }
                    }
                }
                
                if(ds.Tables[0].Rows[0]["Supervisor2"] != null)
                {
                    DropDownList ddlTeacher2 = (DropDownList)fvTestArrange.FindControl("ddlTeacher2");
                    string teacher2 = ds.Tables[0].Rows[0]["Supervisor2"].ToString().Trim();
                    for(int i=1; i<ddlTeacher2.Items.Count; i++)
                    {
                        if(string.Compare(ddlTeacher2.Items[i].Value.Trim(), teacher2)==0)
                        {
                            ddlTeacher2.Items[i].Selected = true;
                        }
                    }
                }
            }
        }
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        TestInfo tInfo = new TestInfo();
        tInfo.CourseID = _courseID;
        tInfo.TestTime =  GetDateTime();
        TextBox tbPlace = (TextBox)fvTestArrange.FindControl("tbPlace");
        if (tbPlace.Text.Trim() != "")
        {
            tInfo.TestPlace = tbPlace.Text.Trim();
        }
        DropDownList ddlTeacher1 = (DropDownList)fvTestArrange.FindControl("ddlTeacher1");
        DropDownList ddlTeacher2 = (DropDownList)fvTestArrange.FindControl("ddlTeacher2");
        if (ddlTeacher1.SelectedIndex != 0)
        {
            tInfo.Supervisor1 = ddlTeacher1.SelectedValue.Trim();
        }
        if (ddlTeacher2.SelectedIndex != 0)
        {
            tInfo.Supervisor2 = ddlTeacher2.SelectedValue.Trim();
        }
        TestManage tMag = new TestManage();
        DataSet ds = tMag.GetTestArrangement(_courseID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            //不存在考试安排 add
            tMag.AddTestArrangement(tInfo);
            lblMessage.Text = "添加成功";
        }
        else
        {
            //存在考试安排 update 
            int examId = Convert.ToInt32(ds.Tables[0].Rows[0]["ExamArrID"]);
            tInfo.ExamID = examId;
            tMag.UpdateExamArrangement(tInfo);
            lblMessage.Text = "修改成功";
        }
    }
}
