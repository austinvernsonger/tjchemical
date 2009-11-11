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

public partial class Teaching_FrontEnd_MasterTrainingPlan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] == null) return;
        if (DDLYear.SelectedItem.Text == "全部")
        {
            this.LinkListEx.QuerySQL = "select *,-1 as FS  from [EducationSchema] where [Type]=" + Request.QueryString["Type"]; ;
        }
        else
        {
            this.LinkListEx.QuerySQL = "select *,-1 as FS  from [EducationSchema] where [Type]=" + Request.QueryString["Type"] + "and [Term]='" + DDLYear.SelectedItem.Text + "'";
        }
        this.LinkListEx.ReBindData();
    }


    protected void AfterDDLYearDataBind(object sender, EventArgs e)
    {

        DDLYear.Items.Add("全部");
        DDLYear.SelectedIndex = DDLYear.Items.Count - 1;

    }
}
