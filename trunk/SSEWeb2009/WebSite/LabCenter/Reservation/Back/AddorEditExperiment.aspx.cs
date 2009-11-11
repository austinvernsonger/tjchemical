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
using LabCenter.LabUtility.LoginUtility;

public partial class LabCenter_Reservation_Back_AddorEditExperiment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCtrl.CheckAuthorityRedirect(this, 8, 1);

        }  
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        int index = Int32.Parse(e.Item.Value);
        MultiView1.ActiveViewIndex = index;
        if (1 == MultiView1.ActiveViewIndex)
        {
            ddlExperiment.Items.Clear();
            DataSet ds = BackManager.GetExperiment();
            if (ds == null && ds.Tables.Count == 0 && ds.Tables[0].Rows.Count == 0)
            { return; }
            else
            {
                ddlExperiment.DataTextField = "ExperimentName";
                ddlExperiment.DataValueField = "ExperimentID";
                ddlExperiment.DataSource = ds.Tables[0];
                ddlExperiment.DataBind();
                ddlExperiment.Items.Insert(0, "");
            }
        }
    }
    protected void Btnadd_Click(object sender, EventArgs e)
    {
        if(!BackManager.AddExperiment(labname.Text.Trim()))
        {
            lblresult1.Text = BackManager.ErrorMsg;
        }
        else 
        { lblresult1.Text = "添加实验成功!"; }
    }

    protected void btnsavechange_Click(object sender, EventArgs e)
    {
        if(!BackManager.UpdateuniqueExperiment(Convert.ToInt32(ddlExperiment.SelectedValue),txtname.Text,Convert.ToInt32(chkisvalid.Checked)))
        {
            lblresult2.Text = BackManager.ErrorMsg;
        }
        else
        { lblresult2.Text = "保存修改成功!"; }
    }
    protected void ddlExperiment_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = BackManager.GetuniqueExperiment(Convert.ToInt32(ddlExperiment.SelectedValue));
        if (ds == null && ds.Tables.Count == 0 && ds.Tables[0].Rows.Count == 0)
        { return; }
        else
        {
            txtname.Text = ds.Tables[0].Rows[0]["ExperimentName"].ToString();
            chkisvalid.Checked = false;
            if (1 == Convert.ToInt32(ds.Tables[0].Rows[0]["IfValid"]))
            {
                chkisvalid.Checked = true;
            }
        }
        
        btnsavechange.Enabled = true;
    }
}
