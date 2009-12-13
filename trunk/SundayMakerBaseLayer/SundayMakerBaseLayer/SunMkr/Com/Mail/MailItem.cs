using System;
using System.Net.Mail;

namespace SunMkr.Com.Mail
{
    /// <summary>
    /// Mail Item structure.
    /// Contains the smtp client and the message body.
    /// </summary>
    public class MailItem
    {
        /// <summary>
        /// The SMTP Client to send the mail.
        /// </summary>
        public SmtpClient      SmtpClt;

        /// <summary>
        /// The Mail Message contain the messages and the mail addresses.
        /// </summary>
        public MailMessage     MailMsg;

        private int            _tryTimes;
        /// <summary>
        /// Times to try to send this itme.
        /// </summary>
        public int TryTimes
        {
            get { return _tryTimes; }
        }

        /// <summary>
        /// Increase the sending times of this mail item
        /// </summary>
        public void IncreaseSendTimes()
        {
            ++_tryTimes;
        }

        /// <summary>
        /// Construction to create a MailItem
        /// </summary>
        /// <param name="Client"></param>
        /// <param name="Message"></param>
        public MailItem( SmtpClient Client, MailMessage Message )
        {
            SmtpClt = Client;
            MailMsg = Message;
            _tryTimes = 0;
        }
    }
}