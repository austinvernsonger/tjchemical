using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;
using SunMkr.Com.Literal;

namespace SunMkr.Com.Mail
{
    /// <summary>
    /// Mail Sender Object.
    /// Send a mail to more than one mail box.
    /// </summary>
    public sealed class MailSender
    {
        /// <summary>
        /// Delegate to process the unsent mail in the mail cache.
        /// </summary>
        /// <param name="mailItems"></param>
        public delegate void ProcessUnSentMails( MailItem [] mailItems );

        private static MailCache m_ActiveMailList;

        private static MailCache m_InvalidateMail;

        private static MailCache m_InActiveMailList;

        private static Thread m_sender;

        //private static MailSender m_instance = null;

        private static bool m_running = false;

        private static ProcessUnSentMails m_invalidateProcessor;
        private static ProcessUnSentMails m_inactiveProcessor;

        private static object lockObj;

        /// <summary>
        /// Delegate For Invalidate
        /// </summary>
        public static ProcessUnSentMails InvalidaterMailProcessor
        {
            set { m_invalidateProcessor += value; }
        }

        /// <summary>
        /// Delegate For Inactive
        /// </summary>
        public static ProcessUnSentMails InActiveMailProcessor
        {
            set { m_inactiveProcessor += value; }
        }

        /// <summary>
        /// Static constructor providered to create static instance.
        /// </summary>
        static MailSender()
        {
            lockObj = new object( );
            m_running = true;
            m_ActiveMailList = new MailCache( 50 );
            m_InvalidateMail = new MailCache( );
            m_InActiveMailList = new MailCache( );
            m_sender = new Thread( new ThreadStart( MailSender.AutoMailSender ) );
            m_sender.Start( );
        }

        private MailSender()
        {
        }

        /// <summary>
        /// Destructor of the Mail Sender
        /// </summary>
        ~MailSender( )
        {
            m_running = false;
        }

        /// <summary>
        /// Send the mail automatically.
        /// </summary>
        private static void AutoMailSender()
        {
            while ( m_running )
            {
                MailItem mailItem = m_ActiveMailList.Get( );
                // Empty Active Mail List
                if ( mailItem == null )
                {
                    mailItem = m_InActiveMailList.Get();
                }
                if ( mailItem != null )
                {
                    try
                    {
                        mailItem.SmtpClt.Send( mailItem.MailMsg );
                        Debug.WriteLine( "Sent " + mailItem.MailMsg.Body );
                    }
                    catch ( SmtpException smtpExp )
                    {
                        Trace.WriteLine( smtpExp );
                        // This exception may be timeout or smtp server error. wait to send again.
                        if ( mailItem.TryTimes == 2 )
                        {
                            // Check the times try to send this mail.
                            // If more than 3 times, then put it into 
                            // the invalidate message list.
                            if ( m_InvalidateMail.IsFull )
                            {
                                ProcessInValidateMail( );
                            }
                            m_InvalidateMail.Add( ref mailItem );
                            continue;
                        }
                        if ( m_InActiveMailList.IsFull )
                        {
                            ProcessInActiveMail( );
                        }
                        mailItem.IncreaseSendTimes( );
                        m_InActiveMailList.Add( ref mailItem );
                    }
                    catch ( Exception exp )
                    {
                        Trace.WriteLine( exp.Message );
                        if ( m_InvalidateMail.IsFull )
                        {
                            // Invoke InvalidateMail Empty Function.
                            ProcessInValidateMail( );
                        }
                        m_InvalidateMail.Add( ref mailItem );
                    }
                }
                else
                {
                    Thread.Sleep( 1000 );
                }
                Trace.WriteLine( "In Auto Mail Sender" );
            }
        }

        /// <summary>
        /// Process In active mails.
        /// Can invoke manually.
        /// </summary>
        public static void ProcessInActiveMail( )
        {
            if ( m_inactiveProcessor != null )
            {
                lock ( lockObj )
                {
                    List<MailItem> lstMailItem = new List<MailItem>( );
                    while ( !m_InActiveMailList.IsEmpty )
                    {
                        lstMailItem.Add( m_InActiveMailList.Get( ) );
                    }
                    m_inactiveProcessor( lstMailItem.ToArray( ) );
                }
            }
            m_InvalidateMail.Clear( );
        }

        /// <summary>
        /// Process Invalidate mails.
        /// Can invoke manually.
        /// </summary>
        public static void ProcessInValidateMail( )
        {
            if ( m_invalidateProcessor != null )
            {
                lock ( lockObj )
                {
                    List<MailItem> lstMailItem = new List<MailItem>( );
                    while ( !m_InvalidateMail.IsEmpty )
                    {
                        lstMailItem.Add( m_InActiveMailList.Get( ) );
                    }
                    m_invalidateProcessor( lstMailItem.ToArray( ) );
                }
            }
            m_InvalidateMail.Clear( );
        }

        private static void AddToSendList( MailItem Item )
        {
            while ( m_ActiveMailList.IsFull ) ;
            //MailItem item = Item as MailItem;
            m_ActiveMailList.Add( ref Item );
            Debug.WriteLine( "Added " + Item.MailMsg.Body );
        }

        /// <summary>
        /// Send the mail
        /// </summary>
        /// <param name="SMTP"></param>
        /// <param name="Mail"></param>
        public static void Send( SmtpClient SMTP, MailMessage Mail )
        {
            if ( null == SMTP || null == Mail ) return;
            // Wait untile the active mail list has some empty position.
            MailItem item = new MailItem( SMTP, Mail );
            //Thread m_Adder = new Thread( new ThreadStart( AddToSendList(item) ) );
            ThreadStart starter = delegate { AddToSendList( item ); };
            new Thread( starter ).Start( );
            //while ( m_ActiveMailList.IsFull ) ;
            //m_ActiveMailList.Add( ref item );
        }

        /// <summary>
        /// Send the mail use default SMTP Server.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        public static void Send( string to, string subject, string message )
        {
            if ( null == to || null == subject || null == message ) return;
            if ( !Validate.IsMailAddress( to ) ) 
                throw new FormatException( string.Format( "'{0}' is not a validate mail address.", to ) );
            // Send the mail use default account.
            SmtpClient smtp = CreateSmtpServer( MailSmtpServer.GMail,
                                                "smbl.error",     // System Account.
                                                "sundaymakersystem"         // Password.
                                              );
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mail = new MailMessage( "smbl.error@gmail.com", to, subject, message );

            Send( smtp, mail );
        }

        /// <summary>
        /// Send the mail use specified SMPT Client
        /// </summary>
        /// <param name="SMTP"></param>
        /// <param name="from">Email Address</param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        public static void Send( SmtpClient SMTP, string from, string to, string subject, string message )
        {
            if ( null == SMTP || null == from || null == to || null == subject || null == message ) return;
            if ( !Validate.IsMailAddress( from ) )
                throw new FormatException( string.Format( "'{0}' is not a validate mail address.", from ) );
            if ( !Validate.IsMailAddress( to ) )
                throw new FormatException( string.Format( "'{0}' is not a validate mail address.", to ) );
            MailMessage mail = new MailMessage( from, to, subject, message );
            Send( SMTP, mail );
        }

        /// <summary>
        /// Create an SMTP Server
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="credential"></param>
        /// <param name="ssl"></param>
        /// <param name="deliveryMethod"></param>
        /// <returns></returns>
        public static SmtpClient CreateSmtpServer(
            string host, 
            int port, 
            NetworkCredential credential, 
            bool ssl, 
            SmtpDeliveryMethod deliveryMethod)
        {
            SmtpClient smtp = new SmtpClient( host, port );
            smtp.Credentials = credential;
            smtp.EnableSsl = ssl;
            smtp.DeliveryMethod = deliveryMethod;

            return smtp;
        }

        /// <summary>
        /// Create Smtp Client via special Servername in the Mail Smtp Server List.
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static SmtpClient CreateSmtpServer( MailSmtpServer ServerName, string UserName, string Password )
        {
            SmtpClient smtp = SmtpServerList.GetSmtpServer( ServerName );
            smtp.Credentials = new NetworkCredential( UserName, Password );
            return smtp;
        }

        /// <summary>
        /// For Test Usage.
        /// </summary>
        public static void Start( )
        {
        }
    }
}
