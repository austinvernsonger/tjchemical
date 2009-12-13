using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace SunMkr.Kernel.Handler
{
    /// <summary>
    /// Admin Login.
    /// </summary>
    class LoginHandler : ISunMkrHandler
    {
        #region ISunMkrHandler 成员

        public void SunMkrHandler(System.Web.HttpContext context)
        {
            //throw new NotImplementedException();
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            HttpSessionState Session = context.Session;

            bool bError = false;

            if (!string.IsNullOrEmpty(Request.Params["usrName"]))
            {
                string usrName = Request.Params["usrName"];
                string pwd = Request.Params["password"];

                // Check the user name and password.
                // Test
                if ( Authorization.Check( usrName, pwd ) )
                {
                    Session ["_sm_admin"] = usrName;
                    string _lastPage = Session ["_last_page"] as string;
                    Session ["_last_page"] = null;
                    if (string.IsNullOrEmpty(_lastPage))
                        _lastPage = "admin.sm";
                    Response.Redirect( _lastPage );
                    return;
                }
                else
                {
                    bError = true;
                }
            }
            if (bError == false)    // First use.
            {
                // Logined.
                if (Session["_sm_admin"] != null) Response.Redirect("admin.sm");
                Session["_last_page"] = Request.Path.Substring(Request.Path.LastIndexOf('/') + 1);
            }

            // Show Page.
            HtmlPage loginPage = new HtmlPage("SunMkr Login", "login.sm");
            string _errMsg = string.Empty;
            if ( bError )
                _errMsg = @"<tr><td colspan='2' class='LoginError'>Username or password error.</td></tr>";
            loginPage.LoadPage( "Login", _errMsg );
            loginPage.OutputPage( Response );
        }

        #endregion
    }
}
