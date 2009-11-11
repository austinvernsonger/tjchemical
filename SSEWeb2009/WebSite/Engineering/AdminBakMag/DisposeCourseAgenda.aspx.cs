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

public partial class Engineering_AdminBakMag_DisposeCourseAgenda : System.Web.UI.Page
{
    private int agendaid;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["IdentifyNumber"] == null)
        //{
        //    SysCom.Login.LoginRedirect(Request.Url.ToString());
        //}
        if (Request["id"] != null && Request["id"] != "")
        {
            agendaid = Convert.ToInt32(Request["id"]);
            if(!IsPostBack)
            {
                bindData();
            }
        }
    }
    protected void btConfirm_Click(object sender, EventArgs e)
    {
       List<int> courseID = new List<int>();
        for(int i=0; i<gvCourseInfo.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gvCourseInfo.Rows[i].FindControl("cbOpen");
            if(cb.Checked == true)
            {
                int courid = Convert.ToInt32(gvCourseInfo.DataKeys[i].Value);
                courseID.Add(courid);
            }
        }
        CourseManage cMag = new CourseManage();
        if (cMag.updateCourseAgenAndOpenedTran(agendaid, courseID )== true)
        {
            Response.Write("<script>alert('操作成功')</script>");
            Response.Redirect("CourseViewManagement.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('操作失败，请重试')</script>");
            return;
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
        if (e.Row.DataItem != null)
        {
            int courseID = Convert.ToInt32(gvCourseInfo.DataKeys[e.Row.RowIndex].Value);
            LinkButton lb = (LinkButton)e.Row.FindControl("lbViewStudent");
            lb.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + courseID + "',550,500)");
            CourseManage cMag = new CourseManage();
            DataSet ds = cMag.GetCourseTeacherInfo(courseID);
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                if (count == 1)
                {
                    if (ds.Tables[0].Rows[0]["Name"] != System.DBNull.Value)
                    {
                        e.Row.Cells[1].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    }
                }
                if (count == 2)
                {
                    string str = ds.Tables[0].Rows[0]["Name"].ToString() + " " + ds.Tables[0].Rows[1]["Name"].ToString();
                    e.Row.Cells[1].Text = str;
                }
            }
        }
    }
    protected void bindData()
    {
        CourseManage cMag = new CourseManage();
        DataSet ds = cMag.GetAllCourseInfoByAgendaID(agendaid);
        gvCourseInfo.DataSource = ds.Tables[0];
        gvCourseInfo.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            lblGrade.Text = "年级：" + dr["Grade"].ToString();
            lblSchool.Text = "教学点：" + dr["TeaSchoolName"].ToString();
            lblMessage.Text = GetCourseTime(dr["Term"].ToString()) + "选课结果如下：";
        }
    }
    protected void cbOpen_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gvCourseInfo.Rows.Count; i++)
        {
            CheckBox cbBox = (CheckBox)gvCourseInfo.Rows[i].FindControl("cbOpen");
            if (cbBox.Checked == false)
            {
                gvCourseInfo.Rows[i].BackColor = System.Drawing.Color.LightBlue;
                cbBox.Text = "不开设";
            }
            else
            {
                gvCourseInfo.Rows[i].BackColor = System.Drawing.Color.White;
                cbBox.Text = "开设";
            }
        }
 
    }
}
