using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace Astrology.Models
{

    public class EmailModule
    {
        static string FromAddress { get { return WebConfigurationManager.AppSettings["FromAddress"]; } }
        static string FromDisplayName { get { return WebConfigurationManager.AppSettings["FromDisplayName"]; } }
        static string SmtpHost { get { return WebConfigurationManager.AppSettings["SmtpHost"]; } }
        static int SmtpPort { get { int port = 0; int.TryParse(WebConfigurationManager.AppSettings["SmtpPort"], out port); return port; } }
        static string Username { get { return WebConfigurationManager.AppSettings["Username"]; } }
        static string Password { get { return WebConfigurationManager.AppSettings["Password"]; } }
        static bool EnableSSL { get { return WebConfigurationManager.AppSettings["EnableSSL"].ToLower() == "true" ? true : false; ; } }
        static bool IsbodyHtml { get { return WebConfigurationManager.AppSettings["IsbodyHtml"].ToLower() == "true" ? true : false; } }
        static string ToAddress { get { return WebConfigurationManager.AppSettings["ToAddress"]; } }
        static string CCAddress { get { return WebConfigurationManager.AppSettings["CCAddress"]; } }

        public static void SendEmail(string subject, string message, List<StreamFilename> streams, string replyToEmail)
        {
            SendEmail(ToAddress, CCAddress, subject, message, streams, replyToEmail);
        }

        public static void SendEmail(string email, string ccEmail, string subject, string message, List<StreamFilename> streams, string replyToEmail)
        {
            if (email.Length == 0)
                return;
            MailMessage mail = new MailMessage();
            if (streams != null)
            {
                foreach (var item in streams)
                    mail.Attachments.Add(new Attachment(item.Stream, item.Filename));
            }

            mail.Body = message;
            if (ccEmail.Length > 0)
                mail.CC.Add(ccEmail);
            if (replyToEmail.Length > 0)
                mail.ReplyToList.Add(replyToEmail);

            mail.From = new MailAddress(FromAddress, FromDisplayName);
            mail.IsBodyHtml = IsbodyHtml;
            mail.Subject = subject;
            mail.To.Add(email);

            SmtpClient smtpClient = new SmtpClient(SmtpHost, SmtpPort);
            smtpClient.EnableSsl = EnableSSL;
            NetworkCredential authinfo = new NetworkCredential(Username, Password);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = authinfo;
            smtpClient.Send(mail);
        }
    }

    public class StreamFilename
    {
        public string Filename { get; set; }

        public Stream Stream { get; set; }
    }
}
