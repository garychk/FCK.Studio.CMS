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
        public static string MailServer { get; set; }
        public static string MailAcount { get; set; }
        public static string MailPassword { get; set; }
        public static string SendEmail(string MailsTo, string MailSubject, string MailBody)
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
