using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teaching_StudentTrainingPlan: System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
            if (Request.QueryString["Type"] != null)
            {
                if (!IsPostBack)
                {
                    LinkListEx.QuerySQL = "select *,-1 as FS  from [EducationSchema] where [Type]=" + Request.QueryString["Type"];
                    LinkListEx.ReBindData();
                } 
           }


    }
    protected void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] == null) return;
        if (DDLYear.SelectedItem.Text == "全部")
        {
            this.LinkListEx.QuerySQL = "select *,-1 as FS  from [EducationSchema] where [Type]=" + Request.QueryString["Type"]; ;
        }else
        {
            this.LinkListEx.QuerySQL = "select *,-1 as FS  from [EducationSchema] where [Type]=" + Request.QueryString["Type"] +"and [Term]='" + DDLYear.SelectedItem.Text + "'";
        }
        this.LinkListEx.ReBindData();
    }


    protected void AfterDDLYearDataBind(object sender, EventArgs e)
    {

        DDLYear.Items.Add("全部");
        DDLYear.SelectedIndex = DDLYear.Items.Count - 1;

    }
 
}
