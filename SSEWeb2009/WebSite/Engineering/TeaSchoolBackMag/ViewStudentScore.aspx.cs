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

public partial class Engineering_TeaSchoolBackMag_ViewStudentScore : System.Web.UI.Page
{
    //教学点测试编号
    int teaSchoolID = 34;

    public string[] sProperty = new string[] { "学位课", "非学位课", "必修环节", "其他" };
    public string[] sCategory = new string[] { "必修", "选修", "其他" };

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnQueryStdScores_Click(object sender, EventArgs e)
    {
        if (tbStudentID.Text.Trim() == "")
        {
            Response.Write("<script language='javascript'>alert('请输入你所要查询的学生学号！')</script>");
        }
        else
        {
            string stuID = tbStudentID.Text.Trim();
            StudentManage sMag = new StudentManage();
            DataSet ds = sMag.GetExamResultByStuID(stuID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblStudentID.Text = "学号：" + stuID;
                lblName.Text = "姓名：" + ds.Tables[0].Rows[0]["Name"].ToString();
                lblGender.Text = "性别：" + GetSex(ds.Tables[0].Rows[0]["Gender"]);
                lblDegree.Text = "学位类别：" + ds.Tables[0].Rows[0]["Degree"].ToString();
                lblGrade.Text = "所属年级：" + ds.Tables[0].Rows[0]["Grade"].ToString();
                lblTeaSchool.Text = "所属教学点：" + ds.Tables[0].Rows[0]["TeaSchoolName"].ToString();
             }
            else
            {
                lblResult2.Text = "对不起，你查询的该学号不存在！";
            }
            gvStudentScore.DataSource = ds.Tables[0];
            gvStudentScore.DataBind();
        }
    }

    protected string GetSex(object value)
    {
    if(value.ToString() == "1")
      {
          return "女";
      }
    else
      {
          return "男";
       }

    }
}
