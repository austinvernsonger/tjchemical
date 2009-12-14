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

public partial class Login_NewAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        SysCom.LoginInfo i = new SysCom.LoginInfo();
        i.Username = tbAccount.Text;
        i.Password = tbPassword.Text;
        i.Accoutstate = ddlAccountState.SelectedValue.ToString();
        i.Emailaddress = tbSafetyEmail.Text;
        i.Emailvalidation = Convert.ToInt16(cbEmailValidation.Checked);
        if (SysCom.Login.Insert(i))
        {
            Response.Write("<script>alert('添加成功')</script>");
        }
    }
}
