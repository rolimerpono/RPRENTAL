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
            var objBooking = _db.tbl_Booking.FirstOrDefault(fw => fw.BookingId == BookingID);

            SD.BookingStatus objStatus;
            objStatus = (SD.BookingStatus)Enum.Parse(typeof(SD.BookingStatus), BookingStatus);

            switch (objStatus) 
            {
                case SD.BookingStatus.Checkin:
                    objBooking.RoomNo = room_number;
                    objBooking.ActualCheckinDate = DateTime.Now;
                    objBooking.BookingStatus = BookingStatus;
                    break;

                case SD.BookingStatus.Checkout:
                    objBooking.ActualCheckoutDate = DateTime.Now;
                    objBooking.BookingStatus = BookingStatus;
                    break;

                case SD.BookingStatus.Approved:
                    objBooking.BookingDate = DateTime.Now;
                    objBooking.BookingStatus = BookingStatus;
                    break;

                case SD.BookingStatus.Cancelled:
                    objBooking.BookingStatus = BookingStatus;
                    objBooking.ActualCheckinDate = DateTime.Now;

                    break;            
            
            }
            
        }
      
        public void UpdateStripePaymentID(int BookingId, string SessionId, string StripePaymentId)
        {
            var objBooking = _db.tbl_Booking.FirstOrDefault(fw => fw.BookingId ==BookingId);

            if (objBooking != null) { 
                if(!string.IsNullOrEmpty(SessionId))
                {
                    objBooking.StripeSessionId = SessionId;
                }

                if (!string.IsNullOrEmpty(StripePaymentId))
                {
                    objBooking.StripePaymentIntentId = StripePaymentId;
                    objBooking.PaymentDate = DateTime.Now;
                    objBooking.IsPaymentSuccessfull = true;

                }
            
            }
        }

        public void UpdatePaypalPaymentID(int BookingId, string SessionId, string PaypalPaymentId)
        {
            throw new NotImplementedException();
        }

    }
}
