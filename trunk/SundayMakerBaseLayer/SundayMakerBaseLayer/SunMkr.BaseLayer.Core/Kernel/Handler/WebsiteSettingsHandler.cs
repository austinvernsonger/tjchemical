using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr.Kernel.Handler
{
    class WebsiteSettingsHandler : ISunMkrHandler
    {
        #region ISunMkrHandler Members

        /// <summary>
        /// Sub Hanlder
        /// </summary>
        /// <param name="context"></param>
        public void SunMkrHandler(System.Web.HttpContext context)
        {
            //throw new NotImplementedException();
            HtmlPage modules = new HtmlPage("SundayMake&copy; Management");
            modules.LoadPage("WebsiteSettings");
            modules.OutputPage(context.Response);
        }

        #endregion
    }
}
