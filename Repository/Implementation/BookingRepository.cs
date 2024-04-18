using DatabaseAccess;
using Model;
using Repository.Interface;
using StaticUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {

        private readonly ApplicationDBContext _db;

        public BookingRepository(ApplicationDBContext db)  : base(db)
        {
            _db = db;
        }
                   
        
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Booking objBooking)
        {
           _db.tbl_Booking.Update(objBooking);
        }

        public void UpdateBookingStatus(int BookingID, string BookingStatus, int room_number)
        {
            var objBooking = _db.tbl_Booking.FirstOrDefault(fw => fw.BOOKING_ID == BookingID);

            SD.BookingStatus objStatus;
            objStatus = (SD.BookingStatus)Enum.Parse(typeof(SD.BookingStatus), BookingStatus);

            switch (objStatus) 
            {
                case SD.BookingStatus.CHECK_IN:
                    objBooking.ROOM_NUMBER = room_number;
                    objBooking.ACTUAL_CHECK_IN_DATE = DateTime.Now;
                    objBooking.BOOKING_STATUS = BookingStatus;
                    break;

                case SD.BookingStatus.CHECK_OUT:
                    objBooking.ACTUAL_CHECK_OUT_DATE = DateTime.Now;
                    objBooking.BOOKING_STATUS = BookingStatus;
                    break;

                case SD.BookingStatus.APPROVED:
                    objBooking.BOOKING_DATE = DateTime.Now;
                    objBooking.BOOKING_STATUS = BookingStatus;
                    break;

                case SD.BookingStatus.CANCELLED:                   
                    break;            
            
            }
            
        }
      
        public void UpdateStripePaymentID(int BookingID, string SessionID, string StripePaymentID)
        {
            var objBooking = _db.tbl_Booking.FirstOrDefault(fw => fw.BOOKING_ID ==BookingID);

            if (objBooking != null) { 
                if(!string.IsNullOrEmpty(SessionID))
                {
                    objBooking.STRIPE_SESSION_ID = SessionID;
                }

                if (!string.IsNullOrEmpty(StripePaymentID))
                {
                    objBooking.STRIPE_PAYEMENT_INTENT_ID = StripePaymentID;
                    objBooking.PAYMENT_DATE = DateTime.Now;
                    objBooking.IS_PAYMENT_SUCCESSFULL = true;

                }
            
            }
        }

        public void UpdatePaypalPaymentID(int BookingID, string SessionID, string PaypalPaymentID)
        {
            throw new NotImplementedException();
        }

    }
}
