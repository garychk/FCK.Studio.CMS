using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FCK.Studio.Utility
{
    public class MailHelper
    {
        public string MailServer { get; set; }
        public string MailAcount { get; set; }
        public string MailPassword { get; set; }
        /// <summary>
        /// 邮件服务器构造函数
        /// </summary>
        /// <param name="_MailServer"></param>
        /// <param name="_MailAcount"></param>
        /// <param name="_MailPassword"></param>
        public MailHelper(string _MailServer,string _MailAcount,string _MailPassword)
        {
            MailServer = _MailServer;
            MailAcount = _MailAcount;
            MailPassword = _MailPassword;
        }
        public string SendEmail(string MailsTo, string MailSubject, string MailBody)
        {
            string result = "";
            try
            {
                bool flag = true;                
                if (string.IsNullOrEmpty(MailServer))
                {
                    flag = false;
                    result = "MailServer can not null";
                }
                if (string.IsNullOrEmpty(MailAcount))
                {
                    flag = false;
                    result = "MailAcount can not null";
                }
                if (string.IsNullOrEmpty(MailPassword))
                {
                    flag = false;
                    result = "MailPassword can not null";
                }
                if (flag)
                {
                    SmtpClient client = new SmtpClient(MailServer);
                    client.UseDefaultCredentials = true;
                    client.Credentials = new System.Net.NetworkCredential(MailAcount, MailPassword);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(MailAcount);
                    mail.To.Add(MailsTo);
                    mail.Subject = MailSubject;
                    mail.BodyEncoding = System.Text.Encoding.Default;
                    mail.Body = MailBody;
                    mail.IsBodyHtml = true;
                    client.Send(mail);
                    result = "true";
                }                
            }
            catch (Exception err)
            {
                result = err.Message;
            }
            return result;
        }
    }
}
