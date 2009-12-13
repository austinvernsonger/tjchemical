using System;
using System.Collections.Generic;
using System.Text;
using SunMkr;
using SunMkr.Com.Mail;
using SunMkr.Com.Xml;
using SunMkr.Com.Literal;
using System.Threading;
using System.Collections.Specialized;

namespace SunMkrLibTestor
{
    class Program
    {
        static void Main( string [] args )
        {
            //MailSender.Start( );
            Console.WriteLine( MD5Hash.GetMD5Hash( "admin" ) );
            //int n = 0;

            System.Net.Mail.SmtpClient sc = MailSender.CreateSmtpServer( "61.172.242.25", 25, 
                new System.Net.NetworkCredential( null, null ), 
                false, System.Net.Mail.SmtpDeliveryMethod.Network );

            MailSender.Send( sc, "tm@dev.snda.com", "chenweiming@snda.com", "邮件测试", "这就是一封测试邮件，请勿回复" );
        }
    }
}
