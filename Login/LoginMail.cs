using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Web;
using SysCom.Sql;
namespace SysCom
{
    ///<summary>
    /// 功能类：LoginMail - 用于登陆模块的邮件发送 
    /// 作者：Sunwell
    /// 最近一次修改时间：2009-7-9
    ///</summary>
    public class LoginMail
    {
        /// <summary>
        /// 邮箱信息
        /// 通过gmail发送邮件
        /// 账号：admin.sse.tju@gmail.com
        /// 密码：sunwell23
        /// 端口：587
        /// 服务器：smtp.gmail.com
        /// </summary>
        private static readonly String mailAccount = "admin.sse.tju@gmail.com";
        private static readonly String mailPassword = "sunwell23";
        private static readonly String mailServer = "smtp.gmail.com";
        private static readonly Int32 mailPort = 587;
        private static MailMessage reportMail;

        /// <summary>
        /// 生成认证邮件并发送 
        /// </summary>
        /// <param name="Mailaddress"></param>
        /// <param name="AccountId"></param>
        public static void sendMail(String Mailaddress,String AccountId)
        {
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            string strEmail = Mailaddress;
            if (!System.Text.RegularExpressions.Regex.IsMatch(strEmail, pattern))
            {
                return;
            }
            String prefix = HttpContext.Current.Request.ApplicationPath;
            if (!prefix.EndsWith("/")) prefix += "/";
            LoginMail.reportMail = new MailMessage(LoginMail.mailAccount, Mailaddress);
            LoginMail.reportMail.Subject = "同济大学软件学院网站用户邮箱认证";
            LoginMail.reportMail.IsBodyHtml = true;
            LoginMail.reportMail.Body = "请点击链接完成邮箱认证"+
                                        "<a href=http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"] + prefix + "Login/LoginMailOk.aspx?AccountId=" +
                                        HttpContext.Current.Server.UrlEncode(LoginDes.Encrypt(AccountId)) + ">" +
                                        "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"] + prefix + "Login/LoginMailOk.aspx?AccountId=" +
                                        HttpContext.Current.Server.UrlEncode(LoginDes.Encrypt(AccountId)) + "</a>";
            MailSend();
        }

        /// <summary>
        /// 用户通过链接认证邮箱
        /// </summary>
        /// <param name="AccountId"></param>
        /// <returns></returns>
        public static bool MailCommit(String AccountId)
        {
             Ops.OpLoginExecute op = new Ops.OpLoginExecute("Account", new sqlMailCommit(AccountId));
            op.Do();
            return op.ExecuteResult;
        }

        /// <summary>
        /// 修改邮件地址
        /// </summary>
        /// <param name="EMailAddress">新地址</param>
        /// <param name="AccountId"></param>
        /// <returns></returns>
        public static bool MailUpdate(String EMailAddress, String AccountId)
        {
            Ops.OpLoginExecute op = new Ops.OpLoginExecute("Account", new sqlSetMailAddress(EMailAddress,AccountId));
            op.Do();
            return op.ExecuteResult;
        }

        /// <summary>
        /// 生成密码寻回邮件并发送
        /// </summary>
        /// <param name="Mailaddress"></param>
        /// <param name="PassWord"></param>
        public static void FindPasswordMail(String Mailaddress, String PassWord)
        {
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            string strEmail = Mailaddress;
            if (!System.Text.RegularExpressions.Regex.IsMatch(strEmail, pattern))
            {
                return;
            }
            String prefix = HttpContext.Current.Request.ApplicationPath;
            if (!prefix.EndsWith("/")) prefix += "/";
            LoginMail.reportMail = new MailMessage(LoginMail.mailAccount, Mailaddress);
            LoginMail.reportMail.Subject = "同济大学软件学院网站用户密码寻回";
            LoginMail.reportMail.IsBodyHtml = true;
            LoginMail.reportMail.Body = "您的密码是:" + PassWord + "<br/>" +
                                        "<a href=http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"] + prefix + "Login/Login.aspx" +
                                        ">点此登陆同济大学软件学院网站</a>";
            MailSend();
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        private static void MailSend()
        {
            try
            {
                SmtpClient smtp = new SmtpClient(
                    LoginMail.mailServer,    // smtp.gmail.com
                    LoginMail.mailPort);     // 587
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(
                    LoginMail.mailAccount,   // Account Information
                    LoginMail.mailPassword);
                smtp.EnableSsl = true;              // Google Need SSL Authorization
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                // Send the report mail
                smtp.Send(LoginMail.reportMail);
            }
            catch (System.Exception e)
            {
            }
        }
    }
}
