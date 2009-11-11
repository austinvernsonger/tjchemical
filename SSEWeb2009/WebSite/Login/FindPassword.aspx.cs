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

public partial class Login_FindPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        SysCom.LoginInfo info = SysCom.Login.FindPassWord(tbAccountId.Text.ToString());
        if(info!=null)
        {
            SysCom.LoginMail.FindPasswordMail(info.Emailaddress, info.Password);
            Response.Write("<script>alert('邮件已发出请注意查收');location.href='"+"http://" +
            HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath+"/Default.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('用户名不存在');</script>");
        }
    }
}
