using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace SunMkr.Kernel.Handler
{
    /// <summary>
    /// Page not found.
    /// </summary>
    class ErrorHandler : ISunMkrHandler
    {
        #region ISunMkrHandler Members

        public void SunMkrHandler(System.Web.HttpContext context)
        {
            //throw new NotImplementedException();
            HttpResponse Response = context.Response;
            HtmlPage page = new HtmlPage("Error: Page not found");
            page.LoadPage( "Error", context.Request.Url.ToString( ) );
            page.OutputPage( Response );
        }

        #endregion
    }
}
