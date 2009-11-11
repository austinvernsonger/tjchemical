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

public partial class Engineering_Control_Terms : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime date = DateTime.Now;
            ddlTerm.Items.Clear();
            ddlTerm.Items.Add("--请选择学期--");
            for (int i = 0; i < 10; ++i)
            {
                ddlTerm.Items.Add((date.Year + i).ToString() + " 春学期");
                ddlTerm.Items.Add((date.Year + i).ToString() + " 秋学期");
                
            }
            ddlTerm.SelectedIndex = 0;
        }
    }

    public string GetTerm()
    {
        string term="";
        if (ddlTerm.SelectedIndex == 0)
        {
            return null;
        }
        string year = ddlTerm.SelectedValue.Substring(0, 4);
        if (ddlTerm.SelectedValue.Contains("春") == true)
        {
            term = year + "1";
        }
        else
        {
            term = year + "0";
        }
        return term;
    }

    public string GetTermText()
    {
        return ddlTerm.SelectedItem.Text;
    }
}
