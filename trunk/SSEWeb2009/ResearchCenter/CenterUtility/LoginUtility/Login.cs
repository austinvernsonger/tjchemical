using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using ResearchCenter.Ops;

namespace ResearchCenter.CenterUtility.LoginUtility
{
    public class Login
    {
        /// <summary>
        /// 检查是否已登录，如果未登录就跳转，否则返回用户ID
        /// </summary>
        /// <returns>登录用户ID,或者null</returns>
        public static String CheckLoginRedirect(MasterPage page)
        {
            if (IsLogin(page))
            {
                return LoginID(page);
            }
            else
            {
                GotoLoginPage(page);
                return null;
            }
        }
        /// <summary>
        /// 判断是否已登录的函数
        /// </summary>
        /// <param name="request">
        /// HttpRequest
        /// </param>
        /// <returns>
        /// 如果已登录，返回true，否则返回false
        /// </returns>
        public static bool IsLogin(MasterPage page)
        {
            return null != LoginID(page);
        }

        /// <summary>
        /// 返回用户的ID
        /// </summary>
        /// <param name="request">HttpRequest</param>
        /// <returns>若没登陆返回null</returns>
        public static string LoginID(MasterPage page)
        {
            return (string)page.Session["IdentifyNumber"];
        }

        /// <summary>
        /// 跳转到登录页面的函数
        /// </summary>
        /// <param name="request">
        /// HttpRequest
        /// </param>
        /// <param name="response">
        /// HttpResponse
        /// </param>
        public static void GotoLoginPage(MasterPage page)
        {
            SysCom.Login.LoginRedirect(page.Request.CurrentExecutionFilePath);
        }
    }
}
