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

public partial class Engineering_Control_gradeSchool : System.Web.UI.UserControl
{
    public string Grade
    {
        get { return ddlGrade.SelectedValue; }
    }

    public int SchoolID
    {
        
        get { return Convert.ToInt32(ddlSchool.SelectedValue); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
        
    }
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGrade.SelectedIndex == 0)
        {
            ddlSchool.Items.Clear();
            ddlSchool.Items.Add("--请选择教学点--");
            ddlSchool.SelectedIndex = 0;
        }
        else
        {
            ddlSchool.Items.Clear();
        }
    }
}
