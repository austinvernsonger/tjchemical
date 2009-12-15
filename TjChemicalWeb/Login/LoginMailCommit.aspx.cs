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

public partial class Login_LoginMailCommit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCommit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["AccountId"] != null)
        {
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            string strEmail = tbMailAddress.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(strEmail, pattern))
            {
                Response.Write("<script>alert('邮箱地址格式错误!');</script>");
            }
            else
            {
                SysCom.LoginMail.MailUpdate(tbMailAddress.Text.ToString(), Request.QueryString["AccountId"].ToString());
                SysCom.LoginMail.sendMail(tbMailAddress.Text.ToString(), Request.QueryString["AccountId"].ToString());
                Response.Write("<script>alert('邮件已发出请注意查收');location.href='" + "http://" +
                HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath + "/Default.aspx'</script>");
            }
        }
        else
        {
            Response.Redirect(HttpContext.Current.Request.ApplicationPath + "/Default.aspx");
        }
    }
}
