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

public partial class Engineering_AdminBakMag_EditCourseDetails : System.Web.UI.Page
{
    public string[] sProperty = new string[] { "学位课", "非学位课", "必修环节", "其他" };
    public string[] sCategory = new string[] { "必修", "选修", "其他" };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null && Request["id"] != "")
        {
            ViewState["CourseID"] = Convert.ToInt32(Request["id"]);
            if (!IsPostBack)
            {
                binddvCourseDetails();
            }
        }
    }
    protected void dvCourseDetails_ItemCreated(object sender, EventArgs e)
    {
        
    }
    protected void dvCourseDetails_DataBound(object sender, EventArgs e)
    {
        int courseID = (int)ViewState["CourseID"];
        CourseManage cMag = new CourseManage();
        DataSet ds = null;
        int count;
        if (dvCourseDetails.CurrentMode == DetailsViewMode.Edit)
        {
            ds = cMag.GetCourseInformation(courseID);
            DropDownList ddlProperty = (DropDownList)dvCourseDetails.Rows[6].FindControl("ddlProperty");
            DropDownList ddlCategory = (DropDownList)dvCourseDetails.Rows[7].FindControl("ddlCategory");
            ddlProperty.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["Property"]);
            ddlCategory.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["Category"]);
            DataSet ds1 = cMag.GetCourseTeacherInfo(courseID);
            count = ds1.Tables[0].Rows.Count;
            if (count == 1)
            {
                DropDownList ddlteacher1 = (DropDownList)dvCourseDetails.Rows[10].FindControl("ddlTeacher1");
                int i = 0;
                for (; i < ddlteacher1.Items.Count; i++)
                {
                    if (string.Compare(ddlteacher1.Items[i].Value, ds1.Tables[0].Rows[0]["TeacherID"].ToString()) == 0)
                    {
                        ddlteacher1.Items[i].Selected = true;
                        break;
                    }
                }
            }
            if (count == 2)
            {
                DropDownList ddlteacher1 = (DropDownList)dvCourseDetails.Rows[10].FindControl("ddlTeacher1");
                DropDownList ddlteacher2 = (DropDownList)dvCourseDetails.Rows[11].FindControl("ddlTeacher2");
                for (int i=0; i < ddlteacher1.Items.Count; i++)
                {
                    if (string.Compare(ddlteacher1.Items[i].Value, ds1.Tables[0].Rows[0]["TeacherID"].ToString()) == 0)
                    {
                        ddlteacher1.Items[i].Selected = true;
                        break;
                    }
                }
                for (int j = 0; j < ddlteacher1.Items.Count; j++)
                {
                    if (string.Compare(ddlteacher2.Items[j].Value, ds1.Tables[0].Rows[1]["TeacherID"].ToString()) == 0)
                    {
                        ddlteacher2.Items[j].Selected = true;
                        break;
                    }
                }
            }
        }
        else
        {

            ds = cMag.GetCourseTeacherInfo(courseID);
            count = ds.Tables[0].Rows.Count;
            if (count == 1)
            {
                dvCourseDetails.Rows[10].Cells[1].Text = ds.Tables[0].Rows[0]["Name"].ToString();
            }
            if (count == 2)
            {
                dvCourseDetails.Rows[10].Cells[1].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                dvCourseDetails.Rows[11].Cells[1].Text = ds.Tables[0].Rows[1]["Name"].ToString();
            }
        }
    }
    protected void dvCourseDetails_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (e.NewMode == DetailsViewMode.Edit)
        {
            dvCourseDetails.ChangeMode(DetailsViewMode.Edit);
            binddvCourseDetails();
        }
        else if (e.CancelingEdit == true)
        {
            if (dvCourseDetails.CurrentMode == DetailsViewMode.Edit)
            {
                dvCourseDetails.ChangeMode(DetailsViewMode.ReadOnly);
                binddvCourseDetails();
            }
        }
    }
    protected void binddvCourseDetails()
    {
        int courseID = (int)ViewState["CourseID"];
        CourseManage cMag = new CourseManage();
        DataSet ds = cMag.GetCourseInformation(courseID);
        dvCourseDetails.DataSource = ds.Tables[0];
        dvCourseDetails.DataBind();
    }
    protected void dvCourseDetails_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        int courseID = (int)ViewState["CourseID"];
        CourseInfo cInfo = new CourseInfo();
        cInfo.CourseID = courseID;
        cInfo.CourseName = ((Label)dvCourseDetails.Rows[0].FindControl("lblCourseName")).Text ;
        cInfo.Credit = Convert.ToInt32(((TextBox)dvCourseDetails.Rows[4].FindControl("tbCredit")).Text.Trim());
        cInfo.CreditHour = Convert.ToInt32(((TextBox)dvCourseDetails.Rows[5].FindControl("tbCreditHour")).Text.Trim());
        cInfo.Property = Convert.ToInt32(((DropDownList)dvCourseDetails.Rows[6].FindControl("ddlProperty")).SelectedValue);
        cInfo.Category = Convert.ToInt32(((DropDownList)dvCourseDetails.Rows[7].FindControl("ddlCategory")).SelectedValue);
        cInfo.ClassPeriod = ((TextBox)dvCourseDetails.Rows[8].FindControl("tbClassPeriod")).Text.Trim();
        cInfo.Place = ((TextBox)dvCourseDetails.Rows[9].FindControl("tbPlace")).Text.Trim();
        DropDownList ddlteacher1 = (DropDownList)dvCourseDetails.Rows[10].FindControl("ddlTeacher1");
        DropDownList ddlteacher2 = (DropDownList)dvCourseDetails.Rows[11].FindControl("ddlTeacher2");
        List<string> teacher = new List<string>();
        if (ddlteacher1.SelectedIndex == ddlteacher2.SelectedIndex && ddlteacher1.SelectedIndex !=0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('不能安排相同的教师教授同一门课')</script>");
            return;
        }
        if (ddlteacher1.SelectedIndex != 0)
        {
            teacher.Add(ddlteacher1.SelectedValue);
        }
        if (ddlteacher2.SelectedIndex != 0)
        {
            teacher.Add(ddlteacher2.SelectedValue);
        }
        CourseManage cMag = new CourseManage();
        if (cMag.UpdateCourseTeacherTran(cInfo, teacher) == true)
        {
            //更新成功
            dvCourseDetails.ChangeMode(DetailsViewMode.ReadOnly);
            binddvCourseDetails();
        }
        else
        { 
            //更新失败
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('更新失败')</script>");
        }
    }
}
