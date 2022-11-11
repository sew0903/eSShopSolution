using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThriftShop.Models;
using ThriftShop.Controllers;
using ThriftShop.Controllers.User;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace ThriftShop.Helpers
{
    public class MailHelpers
    {
        public void SendMail(string toEmailAddress, string subject, string content)
        {
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var sMTPHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var sMTPPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
            bool enabledSSL = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());
            string body = content;
            MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = sMTPHost;
            client.EnableSsl = enabledSSL;
            client.Port = int.Parse("587");
            client.Send(message);
        }
    }
}