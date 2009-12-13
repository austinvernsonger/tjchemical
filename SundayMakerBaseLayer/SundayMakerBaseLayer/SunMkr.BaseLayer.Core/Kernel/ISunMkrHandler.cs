using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace SunMkr.Kernel
{
    /// <summary>
    /// Handler to process SunMkr Request.
    /// </summary>
    interface ISunMkrHandler
    {
        /// <summary>
        /// The method.
        /// </summary>
        /// <param name="context"></param>
        void SunMkrHandler(HttpContext context);
    }
}
