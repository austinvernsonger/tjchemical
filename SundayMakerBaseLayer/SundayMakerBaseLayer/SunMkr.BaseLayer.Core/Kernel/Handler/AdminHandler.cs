using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace SunMkr.Kernel.Handler
{
    class AdminHandler : ISunMkrHandler
    {
        #region ISunMkrHandler 成员

        public void SunMkrHandler(System.Web.HttpContext context)
        {
            //throw new NotImplementedException();
            //context.Response.Write("This is Admin.sm");
            HtmlPage adminPage = new HtmlPage("SundayMake&copy; Management");
            HttpResponse Response = context.Response;

            adminPage.LoadPage("ServerStatue");
            adminPage.OutputPage(Response);
        }

        #endregion
    }
}
