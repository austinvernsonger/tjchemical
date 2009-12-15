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

public partial class Login_LoginMailOk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String str;
        if (Request.QueryString["AccountId"]!=null)
        {
            str = Request.QueryString["AccountId"];
            if(SysCom.LoginMail.MailCommit(SysCom.LoginDes.Decrypt(str)))
            {
                Response.Write("<script>alert('邮箱认证成功');window.location.href='"+ConstValue.PureURL+"Default.aspx'</script>");
            }
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}
