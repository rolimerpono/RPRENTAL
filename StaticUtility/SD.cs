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
    }
      
}
