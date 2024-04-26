
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

        

    }
      
}
