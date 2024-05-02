using Model;
using System.IO;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using System.Web.Mvc;
using Microsoft.Identity.Client;


namespace StaticUtility
{
    public static class SD
    {
        public enum UserRole
        { 
            Admin,
            Customer           
        }

        public enum BookingStatus
        { 
            All,
            Approved,
            Pending,
            Checkin,
            Checkout,
            Cancelled,
            Refunded        
        }


        public struct CrudTransactions
        {
            public const string Save = "Record was successfully saved.";
            public const string Edit = "Record was successfully updated.";
            public const string Delete = "Record was successfully deleted.";
            public const string RecordExists = "Record is already exists!";
            public const string EmptyField = "Please fill all required fields";
            public const string InvalidInput = "Please make sure the input you entered was valid.";        
        }

        public struct BookingTransaction 
        {
            public const string Success = "Transaction completed.";
            public const string Fail = "Transaction fail.";

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
                var sendSmtpEmail = new SendSmtpEmail(Email, To, null, null, email.HtmlContent,email.TextContent, email.Subject);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                return true;

            }
            catch (Exception e)
            {

            }
            return false;
        }

        public static string GenerateOTP()
        {
            Random rnd = new Random();
            int otp = rnd.Next(100000, 999999);
            return otp.ToString();
        }


    }
      
}
