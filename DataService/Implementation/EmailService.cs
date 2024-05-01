using DataService.Interface;
using Model;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataService.Implementation
{
    public class EmailService : IEmailService
    {
        public bool MailSend(Email email)
        {
            var apiInstance = new TransactionalEmailsApi();
            SendSmtpEmailSender Email = new SendSmtpEmailSender(email.SenderName, email.SenderMail);
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(email.RecieverEmail,email.RecieverName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);

            try
            {
                var sendSmtpEmail = new SendSmtpEmail(Email, To, null, null, email.HtmlContent, email.TextContent, email.Subject);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                return true;
                
            }
            catch (Exception e)
            {
               
            }
            return false;
        }
    }
}
