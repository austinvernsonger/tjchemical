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

public partial class Login_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        SysCom.LoginInfo info=new SysCom.LoginInfo();
        info.Password=tbNewPassword.Text;
        info.Username = Session["IdentifyNumber"].ToString();
        if (SysCom.Login.ChangePassword(info)) Response.Write("<script>alert('!');</script>");
    }
}
