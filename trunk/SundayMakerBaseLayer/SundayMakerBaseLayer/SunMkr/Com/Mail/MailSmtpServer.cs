using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace SunMkr.Com.Mail
{
    /// <summary>
    /// Mail Smtp Server Enumerate
    /// </summary>
    public enum MailSmtpServer
    {
        /// <summary>
        /// Gmail Smtp Server
        /// </summary>
        GMail,          // smtp.gmail.com, 587, Ssl
        /// <summary>
        /// Live mail Smtp Server
        /// </summary>
        LiveMail,       // smtp.live.com, 25(587), Ssl
        /// <summary>
        /// Sina free mail Smtp Server
        /// </summary>
        Sina,           // smtp.sina.com, 25
        /// <summary>
        /// 163 mail Smtp Server
        /// </summary>
        Mail163,        // smtp.163.com, 25
        /// <summary>
        /// 126 mail Smtp Server
        /// </summary>
        Mail126         // smtp.126.com, 25
    }

    static class SmtpServerList
    {
        static Hashtable _SmtpList;

        static SmtpServerList( )
        {
            _SmtpList = new Hashtable( );
            // Add Gmail.
            SmtpClient smtp_Gmail = new SmtpClient( "smtp.gmail.com", 587 );
            smtp_Gmail.EnableSsl = true;
            smtp_Gmail.DeliveryMethod = SmtpDeliveryMethod.Network;
            _SmtpList.Add( MailSmtpServer.GMail, smtp_Gmail );
            // Add Live Mail.
            SmtpClient smtp_Live = new SmtpClient( "smtp.live.com", 587 );
            smtp_Live.EnableSsl = true;
            smtp_Live.DeliveryMethod = SmtpDeliveryMethod.Network;
            _SmtpList.Add( MailSmtpServer.LiveMail, smtp_Live );
            // Add Sina.
            SmtpClient smtp_Sina = new SmtpClient( "smtp.sina.com", 25 );
            smtp_Sina.DeliveryMethod = SmtpDeliveryMethod.Network;
            _SmtpList.Add( MailSmtpServer.Sina, smtp_Sina );
            // Add 163.
            SmtpClient smtp_163 = new SmtpClient( "smtp.163.com", 25 );
            smtp_163.DeliveryMethod = SmtpDeliveryMethod.Network;
            _SmtpList.Add( MailSmtpServer.Mail163, smtp_163 );
            // Add 126.
            SmtpClient smtp_126 = new SmtpClient( "smtp.126.com", 25 );
            smtp_126.DeliveryMethod = SmtpDeliveryMethod.Network;
            _SmtpList.Add( MailSmtpServer.Mail126, smtp_126 );
        }

        /// <summary>
        /// Get an SmtpServer specified by the server name in SmtpServer Enumerate.
        /// </summary>
        /// <param name="ServerName"></param>
        /// <returns></returns>
        public static SmtpClient GetSmtpServer(MailSmtpServer ServerName)
        {
            SmtpClient refSmtp = _SmtpList [ServerName] as SmtpClient;
            SmtpClient CloneSmtp = new SmtpClient( refSmtp.Host, refSmtp.Port );
            CloneSmtp.EnableSsl = refSmtp.EnableSsl;
            return CloneSmtp;
        }
    }
}
