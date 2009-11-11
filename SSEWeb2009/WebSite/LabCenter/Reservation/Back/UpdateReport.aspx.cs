using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LabCenter.Reservation;
using System.Web.Configuration;
using LabCenter.LabUtility.LoginUtility;

public partial class 实验预约_UpdateReport : System.Web.UI.Page
{
    string termspath = AppDomain.CurrentDomain.BaseDirectory +
                           @"LabCenter\XmlConfig\Terms.xml";
    //string basicConfigpath = AppDomain.CurrentDomain.BaseDirectory +
    //                       @"LabCenter\XmlConfig\basicConfig.xml";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
          
                LoginCtrl.CheckAuthorityRedirect(this, 8, 1);

            
            TermList tl = BackManager.GetTermList(termspath);
            int curterm = BasicConfig.CurrentTerm;
            for (int i = 0; i < tl.Terms.Count; i++)
            {
                ListItem termli = new ListItem(tl.Terms[i].ToString());
                ddlterm.Items.Add(termli);
            }
            DataSet ds;
            ds = BackManager.GetExperiment();
            if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
            {
                ddlname.DataTextField = "ExperimentName";
                ddlname.DataValueField = "ExperimentID";
                ddlname.DataSource = ds.Tables[0];
                ddlname.DataBind();
                ddlname.Items.Insert(0, "");
            }
            ds.Clear();
        }
    }
    protected void btnselect_Click(object sender, EventArgs e)
    {
        if (ddlterm.SelectedIndex == 0&&ddlname.SelectedIndex == 0&&txtNo.Text == "")
        {
            grdreport.Visible = false;
            lblsave.Text = "请输入查询条件！";
            return;
        }
        else
        {
            grdreport.Visible = true;
            lblsave.Text = "";
        }

        if (ddlterm.SelectedIndex > 0)
        {
            //BasicConfig bc = BackManager.GetBasicConfig(basicConfigpath);
            int curterm = BasicConfig.CurrentTerm;
            if (Convert.ToInt32(ddlterm.SelectedItem.Text.Trim()) < curterm)
            {
                grdreport.Enabled = false;
            }
            else
            {
                grdreport.Enabled = true;
            }

            HttpContext.Current.Cache["term"] = Convert.ToInt32(ddlterm.SelectedItem.Text.Trim());
        }
        else
        {
            HttpContext.Current.Cache.Remove("term");
        }
        
        if (ddlname.SelectedIndex > 0)
        {
            HttpContext.Current.Cache["name"] = Convert.ToInt32(ddlname.SelectedValue);
        }
        else
        {
            HttpContext.Current.Cache.Remove("name");
        }

        if (txtNo.Text != "")
        {
            HttpContext.Current.Cache["number"] = txtNo.Text.Trim();
        }
        else
        {
            HttpContext.Current.Cache.Remove("number");
        }
        
        grdreport.DataBind();
    }
}
