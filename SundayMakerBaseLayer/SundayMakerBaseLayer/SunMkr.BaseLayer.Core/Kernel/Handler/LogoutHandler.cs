using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr.Kernel.Handler
{
    class LogoutHandler : ISunMkrHandler
    {
        #region ISunMkrHandler 成员

        public void SunMkrHandler(System.Web.HttpContext context)
        {
            //throw new NotImplementedException();
            context.Session.Abandon();
            context.Response.Redirect("admin.sm");
        }

        #endregion
    }
}
