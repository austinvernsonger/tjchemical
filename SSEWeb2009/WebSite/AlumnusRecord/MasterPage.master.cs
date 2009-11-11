using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

//             if (Session["IdentifyNumber"] != null)
//             {
//                 this.DivLogout.Style.Remove("display");                
// 
//                 this.DivLogin.Style.Remove("display");
//                 this.DivLogin.Style.Add("display", "none");
// 
//                 this.Label1.Text = Session["IdentifyNumber"].ToString();
// 
//             }
//             else
//             {
//                 this.DivLogin.Style.Remove("display");                
// 
//                 this.DivLogout.Style.Remove("display");
//                 this.DivLogout.Style.Add("display", "none"); 
//             }
        }

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
//         string userName = this.Login1.UserName;
//         string password = this.Login1.Password;
// 
//         SysCom.LoginInfo li = new SysCom.LoginInfo();
//         li.Username = userName;
//         li.Password = password;
// 
//         switch (SysCom.Login.CheckInfo(li, true))
//         {
//             case SysCom.LoginType.Succeed:
//                 Session["IdentifyNumber"] = userName;
//                 e.Authenticated = true;
//                 string s = Request.Url.AbsolutePath;
// 
//                 if (s == @"/WebSite/AlumnusRecord/Admin/Default.aspx")
//                 {
//                     Response.Redirect(@"~/AlumnusRecord//Admin/Default.aspx");
//                 }
//                 else   Response.Redirect(@"~/AlumnusRecord/alumnusCenter.aspx");
// 
//                 break;
//             case SysCom.LoginType.PsError:
// 
//                 break;
//             case SysCom.LoginType.Frozen:
// 
//                 break;
//             case SysCom.LoginType.Nouser:
// 
//                 break;
//             default:
//                 break;
//         }



       // Session["IdentifyNumber"] = userName;
      //  e.Authenticated = true;

      
 

    }
    protected void LinkButtonLogout_Click(object sender, EventArgs e)
    {
        System.Web.Security.FormsAuthentication.SignOut();
        Session["IdentifyNumber"] = null;

        //this.DivLogin.Style.Remove("display");
        //this.DivLogout.Style.Remove("display");
        //this.DivLogout.Style.Add("display", "none");

        Response.Redirect(@"~/AlumnusRecord/alumnusRecordHome.aspx");
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
}
