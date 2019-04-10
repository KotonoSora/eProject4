using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MyWeb.Common
{
    public class MailSender
    {
        #region[Public Properties]

        public static void SendMail(string to, string subject, string messages)
        {
            var SmtpServer = new SmtpClient();
            SmtpServer.Credentials = new NetworkCredential("", "");
            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.EnableSsl = true;
            var mail = new MailMessage();
            String[] addr = to.Split(',');
            try
            {
                mail.From = new MailAddress("thanhnv128@gmail.com",
                                            "Liên hệ ", Encoding.UTF8);
                Byte i;
                for (i = 0; i < addr.Length; i++)
                    mail.To.Add(addr[i]);
                mail.Subject = subject;
                mail.Body = messages;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.ReplyTo = new MailAddress(to);
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion
    }
}