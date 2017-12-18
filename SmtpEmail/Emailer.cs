using MimeKit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmtpEmail
{
    public class Emailer
    {
     
        public static void SendMail(EmailMessage email)
        {
            MailMessage mailObj =
                new MailMessage(email.send_from, email.send_to, email.email_subject, email.email_body);
            mailObj.IsBodyHtml = !email.text_body;
            var Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
            var SMTPServer = new SmtpClient(Host);
            try
            {
                SMTPServer.Send(mailObj);
            }
            catch (Exception ex)
            {
                //TODO: Show Error
                //throw ex;
            }
        }
       
        }
    }
