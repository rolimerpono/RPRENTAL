using Model;
using System.IO;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using System.Web.Mvc;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Utility
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


        public struct CrudTransactionsMessage
        {
            public const string Save = "Record was successfully saved.";
            public const string Edit = "Record was successfully updated.";
            public const string Delete = "Record was successfully deleted.";
            public const string RecordExists = "Record was already exists.";
            public const string EmptyField = "Please fill all required fields.";
            public const string InvalidInput = "Please make sure the input you entered was valid.";
            public const string PasswordConfirm = "The password you have entered did not matched.";
            public const string DateRange = "Please provide a valid date range, and choose dates from tomorrow onwards. Thank you.";
            public const string IsUserHasTransactions = "The user you have selected have current transaction.";
            public const string IsDefaultAdmin = "The user you have selected was the default admin of the system.";
            public const string RecordNotFound = "The record not found.";
            public const string RecordFound = "Record found.";
        }

        public struct SystemMessage
        {
            public const string ContactAdmin = "Please contact system administrator.";
            public const string Login = "You have successfully login.";
            public const string Logout = "You have successfully logout.";
            public const string FailUserLogin = "The username or password you entered is invalid. Please try again. Thank you.";
            
        }

        public struct BookingTransactionMessage 
        {
            public const string Success = "Transaction has been completed.";
            public const string Fail = "Transaction has been fail.";
           
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
