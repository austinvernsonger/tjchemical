using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr.Kernel.Handler
{
    class RecentErrorsHandler : ISunMkrHandler
    {
        #region ISunMkrHandler Members

        /// <summary>
        /// Sub handler
        /// </summary>
        /// <param name="context"></param>
        public void SunMkrHandler(System.Web.HttpContext context)
        {
            //throw new NotImplementedException();
            HtmlPage modules = new HtmlPage("SundayMake&copy; Management");
            modules.LoadPage("RecentErrors");
            modules.OutputPage(context.Response);
        }

        #endregion
    }
}
