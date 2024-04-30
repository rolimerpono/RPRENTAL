using Model;
using System.IO;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using System.Web.Mvc;


namespace StaticUtility
{
    public static class SD
    {
        public enum UserRole
        { 
            ADMIN,
            CUSTOMER           
        }

        public enum BookingStatus
        { 
            ALL,
            APPROVED,
            PENDING,
            CHECK_IN,
            CHECK_OUT,
            CANCELLED,
            REFUNDED        
        }

        public struct BookingTransaction 
        {
            public const string success = "Transaction completed.";
            public const string fail = "Transaction fail.";

        }


        public static bool MailSend(Email email)
        {
            var apiInstance = new TransactionalEmailsApi();
            SendSmtpEmailSender Email = new SendSmtpEmailSender(email.SenderName, email.SenderMail);
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(email.RecieverEmail, email.RecieverName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);

            try
            {
                var sendSmtpEmail = new SendSmtpEmail(Email, To, null, null, null, email.Content, email.Subject);
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
