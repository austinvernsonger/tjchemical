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

public partial class Engineering_TeaSchoolBackMag_ViewTestArrange : System.Web.UI.Page
{
    int teaSchoolID = 34;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        QueryInfo qInfo = new QueryInfo();

        if (ddlGrade.SelectedIndex == 0 && ddlSmaster.SelectedIndex == 0)
        {
            Response.Write("<script language='javascript'>alert('请选择查询条件！')</script>");
        }

        qInfo.TSchoolID = teaSchoolID.ToString();
        if (ddlGrade.SelectedIndex != 0)
        {
            qInfo.Grade = ddlGrade.SelectedValue;
        }
        if (ddlSmaster.SelectedIndex != 0)
        {
            qInfo.Time = ddlSmaster.SelectedValue;
        }
        ViewState["qInfo"] = qInfo;
        bindgvTestArrange();
    }

    protected void bindgvTestArrange()
    {
        QueryInfo qInfo = (QueryInfo)ViewState["qInfo"];
        CourseManage cMag = new CourseManage();
        DataSet ds = cMag.GetCourseInfo(qInfo);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblResult1.Text = "本教学点" + ds.Tables[0].Rows[0]["CourseTime"].ToString();
            lblResult1.Text = lblResult1.Text + "," + ddlGrade.SelectedValue + "级考试安排如下：";
            //lblResult1.Text = lblResult1.Text + ddlViewSchool.SelectedItem.Text + "教学点考试安排如下：";
            
        }
        else
        {
            lblResult1.Text = "查询结果不存在";            
        }
        gvTestArrange.DataSource = ds.Tables[0];
        gvTestArrange.DataBind();
    }

    protected void gvTestArrange_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            int courseid = Convert.ToInt32(gvTestArrange.DataKeys[e.Row.RowIndex].Value);
            LinkButton lb = (LinkButton)e.Row.FindControl("lblArrange");
            //lb.Attributes.Add("onclick", "window.open('SetTestArrangement.aspx?id=" + courseid + "',null,'width=530,height=500,top=150,left=200,scrollbars=yes')");
            TestManage tMag = new TestManage();
            DataSet ds1 = tMag.GetTestArrangement(courseid);
            if (ds1.Tables[0].Rows.Count == 0)
            {
                e.Row.Cells[2].Text = "null";
                e.Row.Cells[3].Text = "null";
                e.Row.Cells[4].Text = "null";
            }
            else
            {
                TeacherManage teaMag = new TeacherManage();
                DataSet ds2 = null;
                DataRow dr = ds1.Tables[0].Rows[0];
                e.Row.Cells[2].Text = dr["ExamTime"].ToString();
                e.Row.Cells[3].Text = dr["ExamPlace"].ToString();
                e.Row.Cells[4].Text = "";
                if (dr["Supervisor1"] != null && dr["Supervisor1"].ToString().Trim() != ""
                    && (dr["Supervisor2"] == null || dr["Supervisor2"].ToString().Trim() == ""))
                {
                    ds2 = teaMag.GetTeacherInfoByTeacherID(dr["Supervisor1"].ToString());
                    e.Row.Cells[4].Text = ds2.Tables[0].Rows[0]["Name"].ToString();
                }
                else if (dr["Supervisor2"] != null && dr["Supervisor2"].ToString().Trim() != ""
                    && (dr["Supervisor1"] == null || dr["Supervisor1"].ToString().Trim() == ""))
                {
                    ds2 = teaMag.GetTeacherInfoByTeacherID(dr["Supervisor2"].ToString());
                    e.Row.Cells[4].Text = ds2.Tables[0].Rows[0]["Name"].ToString();
                }
                else if ((dr["Supervisor1"] == null || dr["Supervisor1"].ToString().Trim() == "")
                    && (dr["Supervisor2"] == null || dr["Supervisor2"].ToString().Trim() == ""))
                {
                    e.Row.Cells[4].Text = null;
                }
                else
                {
                    ds2 = teaMag.GetTeacherInfoByTeacherID(dr["Supervisor1"].ToString());
                    string name = ds2.Tables[0].Rows[0]["Name"].ToString();
                    ds2 = teaMag.GetTeacherInfoByTeacherID(dr["Supervisor2"].ToString());
                    name = name + "," + ds2.Tables[0].Rows[0]["Name"].ToString();
                    e.Row.Cells[4].Text = name;
                }
            }

            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseTeacherInfo(courseid);
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                if (count == 1)
                {
                    e.Row.Cells[1].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (count == 2)
                {
                    e.Row.Cells[1].Text = ds.Tables[0].Rows[0]["Name"].ToString() + "," + ds.Tables[0].Rows[1]["Name"].ToString();
                }
            }
            else
            {
                e.Row.Cells[1].Text = "null";
            }
        }

    }
}
