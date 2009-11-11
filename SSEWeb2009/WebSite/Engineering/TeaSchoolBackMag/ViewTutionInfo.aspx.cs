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

public partial class Engineering_TeaSchoolBackMag_ViewTutionInfo : System.Web.UI.Page
{
    //教学点测试编号
    int teaSchoolID = 34;

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btn_SearchGrade_Click(object sender, EventArgs e)
    {
        TuitionInfo tInfo = new TuitionInfo();
        if (dplGrade.SelectedIndex == 0 && dplPayStatus.SelectedIndex == 0)
        {
           
            Response.Write("<script language='javascript'>alert('请选择要查询的年级！')</script>");

        }
        else
        {            
            tInfo.TSchoolID = teaSchoolID.ToString();
            if (dplGrade.SelectedIndex != 0)
            {
                tInfo.Grade = dplGrade.SelectedValue;
            }
            if (dplPayStatus.SelectedIndex != 0)
            {
                tInfo.Status = Convert.ToInt32(dplPayStatus.SelectedValue);
            }            
        }
        ViewState["tInfo"] = tInfo;
        bindgvTutionInfo();
    }

    protected void bindgvTutionInfo()
    {
        TuitionInfo tInfo = (TuitionInfo)ViewState["tInfo"];
        TuitionManage tMag = new TuitionManage();
        DataSet ds = tMag.GetTuitionInfo(tInfo);        
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblResult2.Text = "记录不存在！";
            
            
        }
        gvGradeTutionInfo.DataSource = ds.Tables[0];
        gvGradeTutionInfo.DataBind();
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

    //查询单个学生的学费情况
    protected void btn_Query_Click(object sender, EventArgs e)
    {
        TuitionInfo tInfo = new TuitionInfo();
        if (tbStudentID.Text == "")
        {

            Response.Write("<script language='javascript'>alert('请填入需要查询的学号！')</script>");

        }
        else
        {
            tInfo.TSchoolID = teaSchoolID.ToString();
            tInfo.StudID = tbStudentID.Text.Trim();
        }
        ViewState["tInfo"] = tInfo;
        bindgvStudentTution();

    }

    protected void bindgvStudentTution()
    {
        TuitionInfo tInfo = (TuitionInfo)ViewState["tInfo"];
        TuitionManage tMag = new TuitionManage();
        DataSet ds = tMag.GetTuitionInfo(tInfo);
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblResult1.Text = "对不起，本教学点没有你所要查询的学生！";


        }
        gvStudentTution.DataSource = ds.Tables[0];
        gvStudentTution.DataBind();
    }
}
