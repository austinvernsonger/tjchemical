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
using SMBL.Operation;
using SMBL.Interface.Database;
using SysCom;

public partial class SysMgr_NewStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        BasicStudentInfo BSI = new BasicStudentInfo(txtStudentID.Text.Trim(), txtName.Text.Trim(), txtPassword.Text, dropGender.SelectedValue.ToString() == "0" ? 0 : 1, txtMajor.Text.Trim(), dropLOS.SelectedValue, txtDegree.Text.Trim());
        BSI.InserNewStudent();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtStudentID.Text = "";
        txtPassword.Text = "";
        txtMajor.Text = "";
    }

}
