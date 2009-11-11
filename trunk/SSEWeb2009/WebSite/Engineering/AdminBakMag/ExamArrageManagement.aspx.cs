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

public partial class Engineering_AdminBakMag_ExamArrageManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["IdentifyNumber"] == null)
        //{
        //    SysCom.Login.LoginRedirect(Request.Url.ToString());
        //}
        bindgvViewArrange();
    }
    protected void btQuery_Click(object sender, EventArgs e)
    {
        QueryInfo qInfo = new QueryInfo();
        if (ddlGrade.SelectedIndex != 0)
        {
            qInfo.Grade = ddlGrade.SelectedValue;
        }
        if (ddlSchool.SelectedIndex != 0)
        {
            qInfo.TSchoolID = ddlSchool.SelectedValue;
        }
        if (ddlTerms.SelectedIndex != 0)
        {
            qInfo.Time = ddlTerms.SelectedValue;
        }
        ViewState["qInfo"] = qInfo;
        bindgvViewArrange();
    }
    protected void bindgvViewArrange()
    {
        if (ViewState["qInfo"] != null)
        {
            QueryInfo qInfo = (QueryInfo)ViewState["qInfo"];
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseInfo(qInfo);
            gvViewArrange.DataSource = ds.Tables[0];
            gvViewArrange.DataBind();
        }
        else
        {
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseInfo();
            gvViewArrange.DataSource = ds.Tables[0];
            gvViewArrange.DataBind();
        }
    }
    protected void gvViewArrange_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            int courseid = Convert.ToInt32(gvViewArrange.DataKeys[e.Row.RowIndex].Value);
            LinkButton lb = (LinkButton)e.Row.FindControl("lblArrange");
           lb.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + courseid + "',610,570)");
            TestManage tMag = new TestManage();
            DataSet ds1 = tMag.GetTestArrangement(courseid); 
            if (ds1.Tables[0].Rows.Count > 0)
            {
                TeacherManage teaMag = new TeacherManage();
                DataSet ds2 = null;
                DataRow dr = ds1.Tables[0].Rows[0];
                e.Row.Cells[4].Text = dr["ExamTime"].ToString();
                e.Row.Cells[5].Text = dr["ExamPlace"].ToString();
                e.Row.Cells[6].Text = "";
                if(dr["Supervisor1"] != null && dr["Supervisor1"].ToString().Trim() !=""
                    && (dr["Supervisor2"] == null || dr["Supervisor2"].ToString().Trim() == ""))
                {
                    ds2 = teaMag.GetTeacherInfoByTeacherID(dr["Supervisor1"].ToString());
                   e.Row.Cells[6].Text = ds2.Tables[0].Rows[0]["Name"].ToString() ;
                }
                else if(dr["Supervisor2"] != null && dr["Supervisor2"].ToString().Trim() !=""
                    && (dr["Supervisor1"] == null || dr["Supervisor1"].ToString().Trim() == ""))
                {
                    ds2 = teaMag.GetTeacherInfoByTeacherID(dr["Supervisor2"].ToString());
                    e.Row.Cells[6].Text = ds2.Tables[0].Rows[0]["Name"].ToString();
                }
                else if ((dr["Supervisor1"] == null || dr["Supervisor1"].ToString().Trim() == "")
                    && (dr["Supervisor2"] == null || dr["Supervisor2"].ToString().Trim() == ""))
                {
                    e.Row.Cells[6].Text = null;
                }
                else
                {
                    ds2 = teaMag.GetTeacherInfoByTeacherID(dr["Supervisor1"].ToString());
                    string name = ds2.Tables[0].Rows[0]["Name"].ToString();
                    ds2 = teaMag.GetTeacherInfoByTeacherID(dr["Supervisor2"].ToString());
                    name = name + "," + ds2.Tables[0].Rows[0]["Name"].ToString();
                    e.Row.Cells[6].Text = name;
                }
            }
        }
    }
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGrade.SelectedIndex == 0)
        {
            ddlSchool.Items.Clear();
            ddlSchool.Items.Add("--请选择教学点--");
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
    protected void gvViewArrange_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvViewArrange.PageIndex = e.NewPageIndex;
        bindgvViewArrange();
    }
}
