using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWrapper.Interface
{
    public interface IBookingService
    {
        void Update(Booking objBooking);

        void UpdateBookingStatus(int BookingID, string BookingStatus, int RoomNumber);

        void UpdateStripePaymentID(int BookingID, string SessionID, string StripePaymentID);

        void UpdatePaypalPaymentID(int BookingID, string SessionID, string PaypalPaymentID);

        void Save();
    }
}
