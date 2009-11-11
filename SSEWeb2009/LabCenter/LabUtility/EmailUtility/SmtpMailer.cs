using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net.Mail;

namespace LabCenter.LabUtility.EmailUtility
{
    public class SmtpMailer
    {
        private string _sender_address;
        /// <summary>
        /// ��ʾ�ķ����������ַ
        /// </summary>
        public string SenderAddress
        {
            get { return _sender_address; }
            set { _sender_address = value; }
        }

        private string _sender_name;
        /// <summary>
        /// ��ʾ�ķ���������
        /// </summary>
        public string SenderName
        {
            get { return _sender_name; }
            set { _sender_name = value; }
        }

        private string _sender_password;
        /// <summary>
        /// ����������
        /// </summary>
        public string SenderPsd
        {
            get { return _sender_password; }
            set { _sender_password = value; }
        }

        private string _receiver;
        /// <summary>
        /// �����������ַ
        /// </summary>
        public string Receiver
        {
            get { return _receiver; }
            set { _receiver = value; }
        }

        private string _subject;
        /// <summary>
        /// �ʼ�����
        /// </summary>
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        private string _body;
        /// <summary>
        /// �ʼ�����
        /// </summary>
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        private string _lasterror;
        /// <summary>
        /// ������Ϣ
        /// </summary>
        public string LastError
        {
            get { return _lasterror; }
            set { _lasterror = value; }
        }

        private string _host;
        /// <summary>
        /// �ʼ���������ַ
        /// </summary>
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }

        private Int32 _port;
        /// <summary>
        /// �ʼ��������˿�
        /// </summary>
        public Int32 Port
        {
            get { return _port; }
            set { _port = value; }
        }



        public Boolean SenderConfig(string configfilepath)
        {
            try
            {
                using (XmlReader rd = XmlReader.Create(configfilepath))
                {
                    rd.Read();
                    rd.ReadStartElement("SendConfig");

                    rd.ReadStartElement("Sender");
                    rd.ReadStartElement("Address");
                    _sender_address = rd.ReadString();
                    rd.ReadEndElement();
                    rd.ReadStartElement("Password");
                    _sender_password = rd.ReadString();
                    rd.ReadEndElement();
                    rd.ReadEndElement();

                    rd.ReadStartElement("Host");
                    rd.ReadStartElement("Address");
                    _host = rd.ReadString();
                    rd.ReadEndElement();
                    rd.ReadStartElement("Port");
                    _port = Int32.Parse(rd.ReadString());
                    rd.ReadEndElement();
                    rd.ReadEndElement();

                    rd.ReadEndElement();
                }
            }
            catch (Exception e)
            {
                _lasterror = e.ToString();
                return false;
            }
            return true;
        }
        public Boolean CheckEmpty()
        {
            if (_receiver.Equals(""))
            {
                _lasterror = "�����߲���Ϊ��";
                return false;
            }
            if (_sender_address.Equals(""))
            {
                _lasterror = "�����߲���Ϊ��";
                return false;
            }
            return true;
        }
        public Boolean Check()
        {
            if (!CheckEmpty())
            {
                return false;
            }
            //������Խ���һЩemail��ַ��ʽ�ļ��
            //...
            return true;
        }
        public Boolean Send()
        {
            if (!Check())
            {
                return false;
            }
            try
            {
                MailAddress sender = new MailAddress(_sender_address, null == _sender_name ? _sender_address : _sender_name);
                MailAddress receiver = new MailAddress(_receiver);
                MailMessage message = new MailMessage(sender, receiver);
                message.Subject = _subject;
                message.IsBodyHtml = true;
                message.Body = _body;
                SmtpClient client = new SmtpClient(_host, _port);
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(_sender_address, _sender_password);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(message);
            }
            catch (Exception e)
            {
                _lasterror = e.ToString();
                return false;
            }
            return true;
        }
    }
}
