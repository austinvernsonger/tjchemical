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

public partial class Login_LoginManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setbind();
        }
    }
    protected void grvLoginInformation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.grvLoginInformation.EditIndex = e.NewEditIndex;
        setbind();
    }
    protected void grvLoginInformation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.grvLoginInformation.EditIndex = -1;
        setbind();
    }
    protected void lbSelectAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.grvLoginInformation.Rows.Count; i++)
        {
            ((CheckBox)grvLoginInformation.Rows[i].Cells[0].FindControl("cbDelete")).Checked = true;
        }
    }
    protected void lbChancelAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.grvLoginInformation.Rows.Count; i++)
        {
            ((CheckBox)grvLoginInformation.Rows[i].Cells[0].FindControl("cbDelete")).Checked = false;
        }
    }
    private void setbind()
    {
        grvLoginInformation.DataSource = SysCom.Login.GetList();
        grvLoginInformation.DataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.grvLoginInformation.Rows.Count; i++)
        {
            CheckBox ckBox = (CheckBox)this.grvLoginInformation.Rows[i].Cells[0].FindControl("cbDelete");
            if (ckBox.Checked)
            {
                SysCom.LoginInfo infotest = new SysCom.LoginInfo();
                infotest.Username = grvLoginInformation.DataKeys[i][0].ToString();
                SysCom.Login.Delete(infotest);
            }
        }
        //this.chkSelectAll.Checked = false;
        this.grvLoginInformation.EditIndex = -1;
        setbind();

    }
    protected void grvLoginInformation_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SysCom.LoginInfo i = new SysCom.LoginInfo();
        i.Username = ((Label)grvLoginInformation.Rows[e.RowIndex].Cells[0].FindControl("lbAccountID")).Text.ToString();
        i.Password = ((TextBox)grvLoginInformation.Rows[e.RowIndex].Cells[0].FindControl("tbPassword")).Text.ToString();
        i.Accoutstate = ((DropDownList)grvLoginInformation.Rows[e.RowIndex].Cells[0].FindControl("ddlAccountState")).SelectedValue.ToString();
        i.Emailaddress = ((TextBox)grvLoginInformation.Rows[e.RowIndex].Cells[0].FindControl("tbSafetyEmail")).Text.ToString();
        i.Emailvalidation = Convert.ToInt16(((CheckBox)grvLoginInformation.Rows[e.RowIndex].Cells[0].FindControl("cbEmailValidation")).Checked);
        SysCom.Login.Update(i);
        this.grvLoginInformation.EditIndex = -1;
        setbind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    }
}
