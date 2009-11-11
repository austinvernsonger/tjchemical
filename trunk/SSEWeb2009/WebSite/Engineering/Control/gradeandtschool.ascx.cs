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

public partial class Engineering_Control_gradeandtschool : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TSchoolDnList.Enabled = false;
            StudentManage stu = new StudentManage();
            DataSet ds = stu.GetGrade();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GradeDnList.Items.Clear();
                GradeDnList.DataSource = ds.Tables[0];
                GradeDnList.DataTextField = "Grade";
                GradeDnList.DataValueField = "Grade";
                GradeDnList.DataBind();
            }
        }
    }
    protected void TSchoolDnList_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void GradeDnList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (GradeDnList.SelectedIndex == 0)
        {
            TSchoolDnList.Enabled = false;
            TSchoolDnList.SelectedIndex = 0;
        }
        else
        {
            TSchoolDnList.Enabled = true;
            TSchoolDnList.Items.Clear();
            TeachingSchool ts = new TeachingSchool();
            TSchoolDnList.DataSource = ts.GetTeaSchool(GradeDnList.SelectedValue).Tables[0];
            TSchoolDnList.DataTextField = "TeaSchoolName";
            TSchoolDnList.DataValueField = "TeaSchoolName";
            TSchoolDnList.DataBind();
        }
    }
}
