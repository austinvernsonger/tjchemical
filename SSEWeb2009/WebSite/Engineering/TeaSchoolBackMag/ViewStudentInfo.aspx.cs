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

public partial class Engineering_TeaSchoolBackMag_ViewStudentInfo : System.Web.UI.Page
{
    //测试教学点编号
    int teaSchoolID = 34;
 
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //通过学号查看该教学点某个学生信息
    protected void btn_Query_Click(object sender, EventArgs e)
    {
        string studID = tbStudentID.Text.Trim();

         if (tbStudentID.Text.Trim() == "")
        {
            Response.Write("<script language='javascript'>alert('请输入查询学号')</script>");
        }
        else
        {
            lblResult1.Text = "";
            QueryInfo qInfo = new QueryInfo();
            StudentManage stu = new StudentManage();
            DataSet ds = null;
            qInfo.AccountID = tbStudentID.Text.Trim();
            qInfo.TSchoolID = teaSchoolID.ToString();
            ds = stu.GetStusInfo(qInfo);
            if (ds.Tables[0].Rows.Count == 0)
            {
                lblResult1.Text = "该教学点没有你所查询的该同学！";
            }          
                dvStudentInfo.DataSource = ds.Tables[0];
                dvStudentInfo.DataBind();
            
        }
     }

    //查看本教学点某一年级的所有学生的信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (dplGrade.SelectedIndex == 0)
        {
            Response.Write("<script language='javascript'>alert('请选择你要查询的年级！')</script>");
        }
        else
        {
            lblResult2.Text = "";
            QueryInfo qInfo = new QueryInfo();
            StudentManage stu = new StudentManage();
            DataSet ds = null;
            qInfo.Grade = dplGrade.SelectedValue;
            qInfo.TSchoolID = teaSchoolID.ToString();
            ds = stu.GetStusInfo(qInfo);
            if (ds.Tables[0].Rows.Count == 0)
            {
                lblResult2.Text = "该教学点没有你所查询的该同学！";
            }
            gvStudInfoList.DataSource = ds.Tables[0];
            gvStudInfoList.DataBind();

        }

    }
}
