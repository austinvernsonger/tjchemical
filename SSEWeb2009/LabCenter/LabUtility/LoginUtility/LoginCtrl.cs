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
        /// ����Ƿ��ѵ�¼�����δ��¼����ת�����򷵻��û�ID
        /// </summary>
        /// <returns>��¼�û�ID,����null</returns>
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
        /// ����Ƿ����Ȩ�ޣ����û��Ȩ����ת
        /// </summary>
        /// <param name="page"></param>
        /// <param name="index">���������ţ����~/LabCenter/XmlConfig/FunctionConfig.xml</param>
        /// <param name="sonindex">�ӹ��������ţ����~/LabCenter/XmlConfig/FunctionConfig.xml</param>
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
        /// ����CheckAuthorityRedirect
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
        /// �ж��Ƿ��ѵ�¼�ĺ���
        /// </summary>
        /// <param name="request">
        /// HttpRequest
        /// </param>
        /// <returns>
        /// ����ѵ�¼������true�����򷵻�false
        /// </returns>
        public static bool IsLogin(Page page)
        {
            return null != LoginID(page);
        }

        /// <summary>
        /// �����û���ID
        /// </summary>
        /// <param name="request">HttpRequest</param>
        /// <returns>��û��½����null</returns>
        public static string LoginID(Page page)
        {
            return (string)page.Session["IdentifyNumber"];
        }

        /// <summary>
        /// ��ת����¼ҳ��ĺ���
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
