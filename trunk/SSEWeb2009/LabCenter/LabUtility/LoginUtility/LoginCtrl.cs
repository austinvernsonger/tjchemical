using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using LabCenter.Authority;

namespace LabCenter.LabUtility.LoginUtility
{
    public class LoginCtrl
    {
        /// <summary>
        /// 检查是否已登录，如果未登录就跳转，否则返回用户ID
        /// </summary>
        /// <returns>登录用户ID,或者null</returns>
        public static String CheckLoginRedirect(Page page)
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
        /// 检查是否具有权限，如果没有权限跳转
        /// </summary>
        /// <param name="page"></param>
        /// <param name="index">功能索引号，详见~/LabCenter/XmlConfig/FunctionConfig.xml</param>
        /// <param name="sonindex">子功能索引号，详见~/LabCenter/XmlConfig/FunctionConfig.xml</param>
        public static Boolean CheckAuthorityRedirect(Page page,Int32 index,Int32 sonindex)
        {
            String id=LoginCtrl.CheckLoginRedirect(page);
            {
                if (null==id)
                {
                    return false;
                }
            }
            AuthorityManage am = new AuthorityManage();
            if (am.IsSuper(id))
            {
                return true;
            }
            if (!am.HasAuthority(id, index, sonindex))
            {
                page.Response.Redirect("~/LabCenter/NoAuthority.aspx");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 类似CheckAuthorityRedirect
        /// </summary>
        /// <param name="page"></param>
        /// <param name="index"></param>
        /// <param name="sonindex"></param>
        /// <returns></returns>
        public static Boolean HasAuthority(Page page,Int32 index,Int32 sonindex)
        {
            string id = LoginID(page);
            if (null == id)
            {
                return false;
            }

            AuthorityManage am = new AuthorityManage();
            if (am.IsSuper(id))
            {
                return true;
            }
            if (!am.HasAuthority(id, index, sonindex))
            {
                return false;
            }
            else
            {
                return true;
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
        public static bool IsLogin(Page page)
        {
            return null != LoginID(page);
        }

        /// <summary>
        /// 返回用户的ID
        /// </summary>
        /// <param name="request">HttpRequest</param>
        /// <returns>若没登陆返回null</returns>
        public static string LoginID(Page page)
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
        public static void GotoLoginPage(Page page)
        {
            SysCom.Login.LoginRedirect(page.Request.CurrentExecutionFilePath);
        }
    }
}
