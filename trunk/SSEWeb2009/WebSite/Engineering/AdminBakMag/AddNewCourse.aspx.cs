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

public partial class Engineering_AdminBakMag_AddNewCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGrade.SelectedIndex == 0)
        {
            ddlSchool.Items.Clear();
            ddlSchool.Items.Add("--请选择教学点--");
        }
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            TextBox tbCourseName = (TextBox)FormView1.FindControl("tbCourseName");
            DropDownList ddlTerm = (DropDownList)FormView1.FindControl("ddlTerm");
            DropDownList ddlGrade = (DropDownList)FormView1.FindControl("ddlGrade");
            DropDownList ddlSchool = (DropDownList)FormView1.FindControl("ddlSchool");
            TextBox tbCredit = (TextBox)FormView1.FindControl("tbCredit");
            TextBox tbCreditHour = (TextBox)FormView1.FindControl("tbCreditHour");
            DropDownList ddlPorperty = (DropDownList)FormView1.FindControl("ddlPorperty");
            DropDownList ddlCategory = (DropDownList)FormView1.FindControl("ddlCategory");
            TextBox tbClassPeriod = (TextBox)FormView1.FindControl("tbClassPeriod");
            TextBox tbPlace = (TextBox)FormView1.FindControl("tbPlace");
            DropDownList ddlTeacher1 = (DropDownList)FormView1.FindControl("ddlTeacher1");
            DropDownList ddlTeacher2 = (DropDownList)FormView1.FindControl("ddlTeacher2");
            CourseInfo cInfo = new CourseInfo();
            
            if (ddlTerm.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择学期')</script>", false);
                return;
            }
            else
            {
                cInfo.CourseTime = ddlTerm.SelectedValue;
            }
            if (ddlGrade.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择年级')</script>", false);
                return;
            }
            else
            {
                cInfo.Grade = ddlGrade.SelectedValue;
            }
            if (ddlSchool.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择教学点')</script>", false);
                return;
            }
            else
            {
                cInfo.TeaSchoolID = ddlSchool.SelectedValue;
            }
            if (ddlPorperty.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择课程性质')</script>", false);
                return;
            }
            else
            {
                cInfo.Property = ddlPorperty.SelectedIndex - 1;
            }
            if (ddlCategory.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('请选择课程类别')</script>", false);
                return;
            }
            else
            {
                cInfo.Category = ddlCategory.SelectedIndex - 1;
            }
            if (ddlTeacher1.SelectedIndex == ddlTeacher2.SelectedIndex && ddlTeacher1.SelectedIndex != 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "<script>alert('不能安排相同的教师教授同一门课')</script>", false);
                return;
            }
            cInfo.CourseName = tbCourseName.Text.Trim();
            cInfo.Credit = Convert.ToInt32(tbCredit.Text.Trim());
            cInfo.CreditHour = Convert.ToInt32(tbCreditHour.Text.Trim());
            if (tbClassPeriod.Text.Trim() != "")
            {
                cInfo.ClassPeriod = tbClassPeriod.Text.Trim();
            }
            if (tbPlace.Text.Trim() != "")
            {
                cInfo.Place = tbPlace.Text.Trim();
            }
            List<string> teacher = new List<string>();
            if (ddlTeacher1.SelectedIndex != 0)
            {
                teacher.Add(ddlTeacher1.SelectedValue);
            }
            if (ddlTeacher2.SelectedIndex != 0)
            {
                teacher.Add(ddlTeacher2.SelectedValue);
            }
        }
    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {

    }
}
