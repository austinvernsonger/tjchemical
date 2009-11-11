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

public partial class Engineering_AdminBakMag_SetTestArrangement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["courseid"] = Convert.ToInt32(Request["id"]);
            bindData();
           
        }
    }
    protected void dvTestArrange_DataBound(object sender, EventArgs e)
    {
        int courseid = Convert.ToInt32(ViewState["courseid"]);
        if (dvTestArrange.CurrentMode == DetailsViewMode.Edit)
        {
             string dtNow = System.DateTime.Now.ToString("yyyy-MM-dd");
             TextBox tb = (TextBox)dvTestArrange.Rows[5].Cells[1].FindControl("tbCalendar");
             tb.Text = dtNow;
        }
        else
        {
            TestManage tMag = new TestManage();
            DataSet ds = tMag.GetTestArrangement(courseid);
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                dvTestArrange.Rows[5].Cells[1].Text = dr["ExamTime"].ToString();
                dvTestArrange.Rows[6].Cells[1].Text = dr["ExamPlace"].ToString();
                TeacherManage teaMag = new TeacherManage();
                DataSet ds1 = teaMag.GetTeacherInfoByTeacherID(dr["Supervisor1"].ToString());
                dvTestArrange.Rows[7].Cells[1].Text = ds1.Tables[0].Rows[0]["Name"].ToString();
                DataSet ds2 = teaMag.GetTeacherInfoByTeacherID(dr["Supervisor2"].ToString());
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    dvTestArrange.Rows[8].Cells[1].Text = ds2.Tables[0].Rows[0]["Name"].ToString();
                }
            }
        }
    }
    protected void bindData()
    {
        int courseid = Convert.ToInt32(ViewState["courseid"]);
        CourseManage cMag = new CourseManage();
        DataSet ds = cMag.GetCourseInformation(courseid);
        dvTestArrange.DataSource = ds.Tables[0];
        dvTestArrange.DataBind();
    }
    protected void dvTestArrange_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        lblMessage.Text = "";
        if (e.NewMode == DetailsViewMode.Edit)
        {
            dvTestArrange.ChangeMode(DetailsViewMode.Edit);
            bindData();
        }
        else if (e.CancelingEdit == true)
        {
            if (dvTestArrange.CurrentMode == DetailsViewMode.Edit)
            {
                dvTestArrange.ChangeMode(DetailsViewMode.ReadOnly);
                bindData();
            }
        }
    }
    protected void dvTestArrange_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        TestInfo tInfo = new TestInfo();
        int courseid = Convert.ToInt32(ViewState["courseid"]);
        tInfo.CourseID = courseid;
        TextBox tb = (TextBox)dvTestArrange.Rows[5].Cells[1].FindControl("tbCalendar");
        TextBox tbPlace = (TextBox)dvTestArrange.Rows[6].Cells[1].FindControl("tbPlace");
        tInfo.TestPlace = tbPlace.Text.Trim();
        string time = tb.Text.Trim();
        if (System.DateTime.Now > Convert.ToDateTime(time))
        {
            lblMessage.Text = "日期设置有误，请确认后重新选择";
            lblMessage.Visible = true;
            return;
        }
        DropDownList ddlStart = (DropDownList)dvTestArrange.Rows[5].Cells[1].FindControl("ddlStartHour");
        DropDownList ddlEnd = (DropDownList)dvTestArrange.Rows[5].Cells[1].FindControl("ddlEndHour");
        DropDownList sTeacher1 = (DropDownList)dvTestArrange.Rows[7].Cells[1].FindControl("ddlTeacher1");
        DropDownList sTeacher2 = (DropDownList)dvTestArrange.Rows[8].Cells[1].FindControl("ddlTeacher2");
        string starHour = ddlStart.SelectedValue;
        string endHour = ddlEnd.SelectedValue;
        string dateHour = time + " " + starHour + "-" + endHour;
        tInfo.TestTime = dateHour;
        if (sTeacher1.SelectedIndex != 0)
        {
            tInfo.Supervisor1 = sTeacher1.SelectedValue;
        }
        else
        {
            tInfo.Supervisor1 = "";
        }
        if (sTeacher2.SelectedIndex != 0)
        {
            tInfo.Supervisor2 = sTeacher2.SelectedValue;
        }
        else
        {
            tInfo.Supervisor2 = "";
        }
        if (sTeacher1.SelectedIndex != 0 && sTeacher2.SelectedIndex != 0 && sTeacher1.SelectedValue == sTeacher2.SelectedValue)
        {
            tInfo.Supervisor2 = "";
            lblMessage.Text = "选择的两位监考老师为同一个人！";
        }
        TestManage tMag = new TestManage();
        DataSet ds = tMag.GetTestArrangement(courseid);
        if (ds.Tables[0].Rows.Count == 0)
        {
            //不存在考试安排 add
            tMag.AddTestArrangement(tInfo);
            dvTestArrange.ChangeMode(DetailsViewMode.ReadOnly);
            bindData();
        
        }
        else
        {
            //存在考试安排 update 
            int examId = Convert.ToInt32(ds.Tables[0].Rows[0]["ExamArrID"]);
            tInfo.ExamID = examId;
            tMag.UpdateExamArrangement(tInfo);
            dvTestArrange.ChangeMode(DetailsViewMode.ReadOnly);
            bindData();
           
        }
    }
  
}
