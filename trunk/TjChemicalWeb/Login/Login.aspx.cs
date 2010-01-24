using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Login_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      


        if (Session["IdentifyNumber"] != null &&
            Session["Authority"] != null && 
            Session["Authority"].ToString().Equals("Admin"))
        {
            Response.Redirect("../Default.aspx");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SysCom.LoginInfo li = new SysCom.LoginInfo();
        li.Username = tbUserName.Text;
        li.Password = tbPassWord.Text;
        //SysCom.Login.CheckInfo(li,true)
        switch (SysCom.Login.CheckInfo(li, true))
        {
            case SysCom.LoginType.Succeed:
                Session["IdentifyNumber"] = li.Username;
                Session["LoginPassword"] = li.Password;
              
                if (SysCom.Login.CheckAuthority(li))
                {
                    Session["Authority"] = "Admin";
                  
                  
                }   
                else{
                    Session["Authority"] = "Student";
                  
                
                }
                pLogin.Visible = false;
                pSucceed.Visible = true;
               String toUrl;
                if (Request.QueryString["toURL"] != null) toUrl = Request.QueryString["toURL"];
                else
                {
                    toUrl = "http://" + HttpContext.Current.Request.Url.Authority +HttpContext.Current.Request.ApplicationPath;
                    if (!toUrl.EndsWith("/")) toUrl += "/";
                    toUrl += "Default.aspx";
               }
                hlToUrl.NavigateUrl = toUrl;
              hlToUrl.Text = toUrl;
             AutoRedirect("showurl", 3, toUrl);
                break;
            case SysCom.LoginType.PsError:
                lbErrorMessage.Text = "密码错误";
                break;
            case SysCom.LoginType.Frozen:
                lbErrorMessage.Text = "帐号已被冻结";
                break;
            case SysCom.LoginType.Nouser:
                lbErrorMessage.Text = "没有此帐号";
                break;
            case SysCom.LoginType.NotSure:
                Response.Redirect("LoginMailCommit.aspx?AccountId="+li.Username);
                break;
            default:
                break;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        tbUserName.Text = "";
        tbPassWord.Text = "";
    }


    public void AutoRedirect(string showID, int seconds, string url)
    {
        //string msg = "<script>document.getElementById('" + showID + "').innerHTML ='" + seconds.ToString() + "秒后页面跳转！';</script>";

        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>"); 
        sb.Append("Load('" + url + "');");
        sb.Append("</script>");
        this.Controls.Add(new LiteralControl(sb.ToString()));//
    }
}
