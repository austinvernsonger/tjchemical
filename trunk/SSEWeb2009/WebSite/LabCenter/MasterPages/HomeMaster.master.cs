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
using LabCenter.LabUtility.LoginUtility;
using LabCenter.LabUtility.PublicUtility;

public partial class LabCenter_MasterPages_HomeMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (LoginCtrl.IsLogin(this.Page))
        {
            if (Account.IsManager(LoginCtrl.LoginID(this.Page)))
            {
                HyperLinkLogin.Visible = true;
                HyperLinkLogin.Text = "管理";
                HyperLinkLogin.NavigateUrl = "~/sse_sys.aspx";
            }
            else
            {
                HyperLinkLogin.Visible = false;
            }
            
        }
        else
        {
            HyperLinkLogin.Text = "登陆";
            HyperLinkLogin.Visible = true;
            HyperLinkLogin.NavigateUrl = "~/Login/Login.aspx?toURL=/WebSite/LabCenter/";
        }
    }
}
