using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr.Kernel.Handler
{
    /// <summary>
    /// Modules.sm
    /// </summary>
    class ModulesHandler : ISunMkrHandler
    {
        #region ISunMkrHandler Members

        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="context"></param>
        public void SunMkrHandler(System.Web.HttpContext context)
        {
            //throw new NotImplementedException();
            HtmlPage modules = new HtmlPage("SundayMake&copy; Management");
            modules.LoadPage("Modules");
            modules.OutputPage(context.Response);
        }

        #endregion
    }
}
